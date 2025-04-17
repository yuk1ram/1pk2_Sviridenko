using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_03
{
    public static class Cinema
    {
        private static List<Movie> movies = new List<Movie>();

        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
            Console.WriteLine($"Фильм '{movie.Title}' добавлен в систему.");
        }

        public static void ChangeTicketPrice(string movieTitle, decimal newPrice)
        {
            Movie movie = movies.Find(m => m.Title == movieTitle);
            if (movie != null)
            {
                movie.TicketPrice = newPrice;
                Console.WriteLine($"Стоимость билета на фильм '{movieTitle}' изменена на {newPrice} руб.");
            }
            else
            {
                Console.WriteLine($"Фильм с названием '{movieTitle}' не найден.");
            }
        }

        public static void PrintMoviesByRating()
        {
            Console.WriteLine("\nСписок фильмов по возрастным цензам:");

            foreach (AgeRating rating in Enum.GetValues(typeof(AgeRating)))
            {
                Console.ForegroundColor = GetColorForRating(rating);
                Console.WriteLine($"\n{GetRatingString(rating)}:");

                var filteredMovies = movies.FindAll(m => m.Rating == rating);
                if (filteredMovies.Count == 0)
                {
                    Console.WriteLine("  Нет фильмов");
                }
                else
                {
                    foreach (var movie in filteredMovies)
                        Console.WriteLine($"  {movie.Title} - {movie.ShowTime:hh\\:mm}, {movie.TicketPrice} руб.");
                }
            }
            Console.ResetColor();
        }

        public static void PrintMoviesForToday()
        {
            DateTime today = DateTime.Today;
            Console.WriteLine($"\nФильмы на сегодня ({today:dd.MM.yyyy}):");

            var todayMovies = movies.FindAll(m => m.IsShowingOnDate(today));
            if (todayMovies.Count == 0)
            {
                Console.WriteLine("Сегодня нет показов.");
            }
            else
            {
                foreach (var movie in todayMovies)
                {
                    Console.WriteLine($"{movie.Title} - {movie.ShowTime:hh\\:mm}, {movie.TicketPrice} руб. ({GetRatingString(movie.Rating)})");
                }
            }
        }

        public static void PrintMorningShows()
        {
            Console.WriteLine("\nУтренние сеансы (8:00 - 12:00):");
            var morningShows = movies.FindAll(m => m.ShowTime >= TimeSpan.FromHours(8) && m.ShowTime <= TimeSpan.FromHours(12));

            if (morningShows.Count == 0)
            {
                Console.WriteLine("Нет утренних сеансов.");
            }
            else
            {
                foreach (var movie in morningShows)
                {
                    Console.WriteLine($"{movie.Title} - {movie.ShowTime:hh\\:mm}, {movie.TicketPrice} руб. ({GetRatingString(movie.Rating)})");
                }
            }
        }

        public static void PrintEveningShows()
        {
            Console.WriteLine("\nВечерние сеансы (21:00 - 23:59):");
            var eveningShows = movies.FindAll(m => m.ShowTime >= TimeSpan.FromHours(21) && m.ShowTime <= TimeSpan.FromHours(23) + TimeSpan.FromMinutes(59));

            if (eveningShows.Count == 0)
            {
                Console.WriteLine("Нет вечерних сеансов.");
            }
            else
            {
                foreach (var movie in eveningShows)
                {
                    Console.WriteLine($"{movie.Title} - {movie.ShowTime:hh\\:mm}, {movie.TicketPrice} руб. ({GetRatingString(movie.Rating)})");
                }
            }
        }

        public static void GenerateMovies()
        {
            DateTime today = DateTime.Today;
            AddMovie(new Movie(
                startDate: today.AddDays(-2),
                endDate: today.AddDays(5),
                title: "Миньоны",
                rating: AgeRating.ZeroPlus,
                showTime: new TimeSpan(11, 0, 0),
                ticketPrice: 300
            ));

            AddMovie(new Movie(
                startDate: today,
                endDate: today.AddDays(7),
                title: "Аватар",
                rating: AgeRating.SixPlus,
                showTime: new TimeSpan(16, 30, 0),
                ticketPrice: 400
            ));

            AddMovie(new Movie(
                startDate: today.AddDays(-1),
                endDate: today.AddDays(3),
                title: "Хроники Нарнии",
                rating: AgeRating.TwelvePlus,
                showTime: new TimeSpan(21, 30, 0),
                ticketPrice: 500
            ));

            AddMovie(new Movie(
                startDate: today.AddDays(1),
                endDate: today.AddDays(10),
                title: "Огонь из преисподней",
                rating: AgeRating.SixteenPlus,
                showTime: new TimeSpan(22, 0, 0),
                ticketPrice: 450
            ));

            AddMovie(new Movie(
                startDate: today,
                endDate: today.AddDays(2),
                title: "Оно",
                rating: AgeRating.EighteenPlus,
                showTime: new TimeSpan(23, 0, 0),
                ticketPrice: 600
            ));

            AddMovie(new Movie(
                startDate: today,
                endDate: today.AddDays(1),
                title: "Утренний сеанс",
                rating: AgeRating.SixPlus,
                showTime: new TimeSpan(9, 0, 0),
                ticketPrice: 200
            ));
        }

        private static string GetRatingString(AgeRating rating)
        {
            return rating switch
            {
                AgeRating.ZeroPlus => "0+",
                AgeRating.SixPlus => "6+",
                AgeRating.TwelvePlus => "12+",
                AgeRating.SixteenPlus => "16+",
                AgeRating.EighteenPlus => "18+",
                _ => "0+"
            };
        }

        private static ConsoleColor GetColorForRating(AgeRating rating)
        {
            return rating switch
            {
                AgeRating.ZeroPlus => ConsoleColor.Yellow,
                AgeRating.SixPlus => ConsoleColor.Blue,
                AgeRating.TwelvePlus => ConsoleColor.Magenta,
                AgeRating.SixteenPlus => ConsoleColor.DarkGreen,
                AgeRating.EighteenPlus => ConsoleColor.Red,
                _ => ConsoleColor.White
            };
        }
    }
}




