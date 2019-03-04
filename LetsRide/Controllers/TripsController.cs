namespace Triviaa.Controllers
{
    using System;
    #region References
    using System.Collections.Generic;
    using System.Linq;
    using LetsRide.Models;
    using LetsRide.Models.Enum;
    using Microsoft.AspNetCore.Mvc;
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        #region Variables
        private readonly RideryesContext _context;
        #endregion

        #region Constructor
        public TripsController(RideryesContext context)
        {
            _context = context;
        }
        #endregion

        #region Public API

        /// <summary>
        /// Create New Trip 
        /// </summary>
        /// <param name="NewTrip">Object of trip</param>
        /// <returns>Trip </returns>
        [HttpPost]
        [Route("CreateNewTrip")]
        public Trip CreateNewTrip([FromBody] Trip NewTrip)
        {
            return InsertNewTrip(NewTrip);
        }

        /// <summary>
        /// Update Trip By ID 
        /// </summary>
        /// <param name="OldTrip">Object of trip</param>
        /// <returns>Trip </returns>
        [HttpPost]
        [Route("UpdateTripByID")]
        public Trip UpdateTripByID([FromBody] Trip OldTrip)
        {
            return UpdateTrip(OldTrip);
        }

        /// <summary>
        /// Update Trip Status 
        /// </summary>
        /// <param name="TripId">integer variable</param>
        /// <param name="Status">String variable</param>
        [HttpPost]
        [Route("UpdateTripStatus")]
        public void UpdateTripStatus(int TripId, string Status)
        {
            Trip TripObj = _context.Trip.Where(trip => trip.Id == TripId).FirstOrDefault();
            TripObj.Status = Status;
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete trip 
        /// </summary>
        /// <param name="TripId">integer variable</param>
        [HttpPost]
        [Route("WithdrawTrip")]
        public void WithdrawTrip(int TripId)
        {
            Trip TripObj = _context.Trip.Where(trip => trip.Id == TripId).FirstOrDefault();
            TripObj.Status = TripStatus.Deleted.ToString();
            _context.SaveChanges();
        }

        /// <summary>
        /// Get All And Search Trips By User Id 
        /// </summary>
        /// <param name="SearchModel">Object of tript</param>
        /// <param name="PageNo">integer variable</param>
        /// <param name="PageSize">integer variable</param>
        /// <returns>list of trips </returns>
        [HttpGet]
        [Route("GetAllAndSearchTripsByUserId")]
        public List<Trip> GetAllAndSearchTripsByUserId(Trip SearchModel = default(Trip), int PageNo = 1, int PageSize = 10)
        {
            return _context.Trip.Where(trip => trip.DriverId == SearchModel.DriverId &&
                                            (SearchModel.StartTime == null || trip.StartTime >= SearchModel.StartTime) ||
                                            (SearchModel.ArriveTime == null || trip.ArriveTime >= SearchModel.ArriveTime) ||
                                            (string.IsNullOrEmpty(SearchModel.Status) || trip.Status.ToLower() == SearchModel.Status.ToLower()))
                 .OrderByDescending(y => y.Id).Skip((PageNo - 1) * PageSize).Take(PageSize).ToList();
        }

        /// <summary>
        /// Get Trip By Trip Id 
        /// </summary>
        /// <param name="TripId">integer variable</param>
        /// <returns>object of trips </returns>
        [HttpGet]
        [Route("GetTripByTripId")]
        public Trip GetTripByTripId(int TripId)
        {
            return _context.Trip.Where(trip => trip.Id == TripId).FirstOrDefault();
        }

        /// <summary>
        /// Check if trip startTime is passed 
        /// </summary>
        /// <param name="TripId">integer variable</param>
        /// <returns>bool </returns> 
        [HttpGet]
        [Route("CheckIfTripPassed")]
        public bool CheckIfTripPassed(int TripId)
        {
            return _context.Trip.Where(trip => trip.Id == TripId && trip.StartTime < DateTime.Now).ToList().Count() > 0 ? true : false;

        }

        /// <summary>
        /// Check if trip startTime is passed 
        /// </summary>
        /// <param name="TripId">integer variable</param>
        /// <returns>bool </returns> 
        [HttpGet]
        [Route("CheckIfTripPassed")]
        public bool CheckIfTripFullBoard(int TripId)
        {
            return _context.Trip.Where(trip => trip.Id == TripId && trip.Status == TripStatus.FullBoard.ToString()).ToList().Count() > 0 ? true : false;
        }
        #endregion

        #region Private Methods
        private Trip InsertNewTrip(Trip NewTrip)
        {
            NewTrip.Status = TripStatus.Opened.ToString();
            _context.Trip.Add(NewTrip);
            _context.SaveChanges();
            return NewTrip;
        }
        private Trip UpdateTrip(Trip OldTrip)
        {
            Trip NewTrip = _context.Trip.Where(trip => trip.Id == OldTrip.Id).FirstOrDefault();
            NewTrip.FromDestination = OldTrip.FromDestination;
            NewTrip.ToDestination = OldTrip.ToDestination;
            NewTrip.StartTime = OldTrip.StartTime;
            NewTrip.ArriveTime = OldTrip.ArriveTime;
            NewTrip.DriverId = OldTrip.DriverId;
            NewTrip.ExpectedArrivalTime = OldTrip.ExpectedArrivalTime;
            NewTrip.Details = OldTrip.Details;
            NewTrip.CarInfo = OldTrip.CarInfo;
            NewTrip.Price = OldTrip.Price;
            _context.SaveChanges();
            return NewTrip;
        }

        #endregion
    }
}