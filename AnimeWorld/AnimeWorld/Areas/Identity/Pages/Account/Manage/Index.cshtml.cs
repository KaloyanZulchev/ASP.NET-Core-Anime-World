using AnimeWorld.Data.Models;
using AnimeWorld.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static AnimeWorld.Data.DataConstants.User;

namespace AnimeWorld.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService users;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserService users)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.users = users;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
            public string Username { get; set; }

            [Url]
            public string ImageUrl { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var imageUrl = this.users.GetImageUrl(user.Id);

            Username = userName;

            Input = new InputModel
            {
                Username = userName,
                ImageUrl = imageUrl
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userName = await _userManager.GetUserNameAsync(user);
            if (Input.Username != userName)
            {
                var setUserResult = await _userManager.SetUserNameAsync(user, Input.Username);
                if (!setUserResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set username.";
                    return RedirectToPage();
                }
            }

            var imageUrl = this.users.GetImageUrl(user.Id);
            if (Input.ImageUrl != imageUrl)
            {
                var setImageUrlResult = this.users.SetImageUrl(Input.ImageUrl, user.Id);
                if (!setImageUrlResult)
                {
                    StatusMessage = "Unexpected error when trying to set image url.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
