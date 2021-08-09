namespace AnimeWorld.Data
{
    public class DataConstants
    {
        public class Anime
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 1500;
            public const int MinEpizodes = 1;
            public const int MaxEpizodes = 10000;
        }

        public class Comment
        {
            public const int ContentMaxLength = 1000;
        }

        public class Genre
        {
            public const int NameMaxLength = 20;
        }

        public class Type
        {
            public const int NameMaxLength = 20;
        }

        public class Producer
        {
            public const int NameMaxLength = 50;
        }
    }
}
