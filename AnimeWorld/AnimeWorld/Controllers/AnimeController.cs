using AnimeWorld.Models.Animes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeWorld.Controllers
{
    public class AnimeController : Controller
    {
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AnimeFormModel anime)
        {
            //if (!this.cars.CategoryExists(car.CategoryId))
            //{
            //    this.ModelState.AddModelError(nameof(car.CategoryId), "Category does not exist.");
            //}

            //if (!this.ModelState.IsValid)
            //{
            //    car.Categories = this.cars.AllCategories();

            //    return View(car);
            //}

            //var carId = this.cars.Create(
            //    car.Brand,
            //    car.Model,
            //    car.Description,
            //    car.ImageUrl,
            //    car.Year,
            //    car.CategoryId,
            //    dealerId);

            //TempData[GlobalMessageKey] = "You car was added and is awaiting for approval!";

            return RedirectToAction("Index", "Home");
        }
    }
}
