using System;
using System.Collections.Generic;

namespace LetsRide.Models
{
    public partial class User
    {
        public User()
        {
            RatingRatedUserNavigation = new HashSet<Rating>();
            RatingUser = new HashSet<Rating>();
            ReportReportedUserNavigation = new HashSet<Report>();
            ReportUser = new HashSet<Report>();
            Trip = new HashSet<Trip>();
            TripRequest = new HashSet<TripRequest>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public bool? Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CarInfo { get; set; }
        public string CarNumber { get; set; }

        public virtual ICollection<Rating> RatingRatedUserNavigation { get; set; }
        public virtual ICollection<Rating> RatingUser { get; set; }
        public virtual ICollection<Report> ReportReportedUserNavigation { get; set; }
        public virtual ICollection<Report> ReportUser { get; set; }
        public virtual ICollection<Trip> Trip { get; set; }
        public virtual ICollection<TripRequest> TripRequest { get; set; }
    }
}
