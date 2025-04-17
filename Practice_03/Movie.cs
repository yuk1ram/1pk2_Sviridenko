using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_03
{
    public class Movie
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public AgeRating Rating { get; set; }
        public TimeSpan ShowTime { get; set; }
        public decimal TicketPrice { get; set; }

        public Movie(DateTime startDate, DateTime endDate, string title,
                    AgeRating rating, TimeSpan showTime, decimal ticketPrice)
        {
            StartDate = startDate;
            EndDate = endDate;
            Title = title;
            Rating = rating;
            ShowTime = showTime;
            TicketPrice = ticketPrice;
        }

        public bool IsShowingOnDate(DateTime date)
        {
            return date >= StartDate && date <= EndDate;
        }
    }
}