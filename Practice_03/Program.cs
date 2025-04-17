namespace Practice_03

{  /* Создать перечисления возрастного ценза кино (0+, 6+ и т.д.)
Создать класс фильма (дата начала показа, дата окончания показа, название, ценз, время показа, стоимость билета)
Создать список фильмов. Заполнить его программно через специальный метод-генератор

Создать статичный класс кинотеатра со статичными методами для:
1. Добавления в систему нового фильма
2. Изменения стоимости билета для фильма
3. Вывода списка фильмов по возрастным цензам (с цветовой индентификацией)
4. Вывода списка фильмов на текущий день
5. Вывод только утренних сеансов (с 8.00 до 12.00)
6. Вывод только вечерних сеансов (с 21.00 до 23.59) */


    class Program
    {
        static void Main(string[] args)
        {

            Cinema.GenerateMovies();


            Cinema.PrintMoviesByRating();
            Cinema.PrintMoviesForToday();
            Cinema.PrintMorningShows();
            Cinema.PrintEveningShows();


            Cinema.ChangeTicketPrice("Аватар", 400);


            Cinema.AddMovie(new Movie(
                startDate: DateTime.Today,
                endDate: DateTime.Today.AddDays(5),
                title: "Новый фильм",
                rating: AgeRating.TwelvePlus,
                showTime: new TimeSpan(15, 30, 0),
                ticketPrice: 300
            ));


            Cinema.PrintMoviesByRating();
        }
    }
}

