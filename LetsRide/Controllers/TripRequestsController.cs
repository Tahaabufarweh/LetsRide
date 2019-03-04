namespace Triviaa.Controllers
{
    #region References
    using System.Collections.Generic;
    using System.Linq;
    using LetsRide.Models;
    using LetsRide.Models.Enum;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
   
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class TripRequestsController : ControllerBase
    {
        #region Variables
        private readonly RideryesContext _context;
        #endregion

        #region Constructor
        public TripRequestsController(RideryesContext context)
        {
            _context = context;
        }
        #endregion

        #region Public API

        /// <summary>
        /// Create New Trip Request 
        /// </summary>
        /// <param name="NewTripRequest">Object of Trip Request</param>
        /// <returns>TripRequest </returns>
        [HttpPost]
        [Route("ApproveOrRejectRequest")]
        public TripRequest ApproveOrRejectRequest([FromBody] TripRequest NewTripRequest)
        {
            int RequestsCount = _context.TripRequest.Where(request => request.TripId == NewTripRequest.TripId).ToList().Count();
            Trip TripObj = _context.Trip.Where(trip => trip.Id == NewTripRequest.Id).FirstOrDefault();
            if (RequestsCount <= TripObj.SeatsNo)
            {
                NewTripRequest = InsertNewTripRequest(NewTripRequest);
            }
            else
            {
                TripObj.Status = TripStatus.FullBoard.ToString();
                _context.SaveChanges();
            }
            return NewTripRequest;
        }


        /// <summary>
        /// Canel Request Trip 
        /// </summary>
        /// <param name="TripRequestId">integer variable</param>
        [HttpPost]
        [Route("CanelRequestTrip")]
        public void CanelRequestTrip(int TripRequestId)
        {
            TripRequest TripRequestObj = _context.TripRequest.Where(request => request.Id == TripRequestId).FirstOrDefault();
            _context.Remove(TripRequestObj);
            _context.SaveChanges();

        }

        /// <summary>
        /// Canel Request Trip 
        /// </summary>
        /// <param name="TripRequestId">integer variable</param>
        [HttpPost]
        [Route("CanelRequestTrip")]
        public void ApproveOrRejectRequest(int TripRequestId)
        {

        }

        /// <summary>
        /// Get All And Search Trip Request By Passenger Id 
        /// </summary>
        /// <param name="SearchModel">Object of TripRequest</param>
        /// <param name="PageNo">integer variable</param>
        /// <param name="PageSize">integer variable</param>
        [HttpGet]
        [Route("GetAllAndSearchTripRequestByPassengerId")]
        public List<TripRequest> GetAllAndSearchTripRequestByPassengerId(TripRequest SearchModel = default(TripRequest), int PageNo = 1, int PageSize = 10)
        {
            return _context.TripRequest.Include(request => request.Trip).Where(request => request.PassengerId == SearchModel.PassengerId &&
                                            (SearchModel.Status == 0 || request.Status == SearchModel.Status))
                 .OrderByDescending(y => y.Id).Skip((PageNo - 1) * PageSize).Take(PageSize).ToList();
        }

        /// <summary>
        /// Get Trip Request By Trip Id 
        /// </summary>
        /// <param name="TripRequestId">integer variable</param>
        [HttpGet]
        [Route("GetTripRequestByTripId")]
        public List<TripRequest> GetTripRequestByTripId(int TripRequestId)
        {
            return _context.TripRequest.Include(request => request.Trip).Where(request => request.Id == TripRequestId).ToList();
        }
        #endregion

        #region Private Methods
        private TripRequest InsertNewTripRequest(TripRequest NewTripRequest)
        {
            _context.TripRequest.Add(NewTripRequest);
            _context.SaveChanges();
            return NewTripRequest;
        }

        #endregion
    }
}