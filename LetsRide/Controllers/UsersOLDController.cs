namespace Triviaa.Controllers
{

    #region References 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using LetsRide.Models;
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class UsersOLDController : ControllerBase
    {
        #region Variables
        private readonly RideryesContext _context;
        #endregion

        #region Constructor
        public UsersOLDController(RideryesContext context)
        {
            _context = context;
        }
        #endregion

        #region Public API

        #region Users
        /// <summary>
        /// Create New User 
        /// </summary>
        /// <param name="NewUser"></param>
        /// <returns>user </returns>
        [HttpPost]
        [Route("SignUp")]
        public User SignUp([FromBody] User NewUser)
        {
            return CreateNewUser(NewUser);
        }

        /// <summary>
        /// Get User info by UserId
        /// </summary>
        /// <param name="UsernameOrEmail"> string </param>
        /// <returns>Object of user type</returns>
        [HttpGet]
        [Route("SignIn")]
        public User SignIn(string UsernameOrEmail, string Password)
        {
            return GetUser(UsernameOrEmail, Password);
        }

        /// <summary>
        /// Update user infomation 
        /// </summary>
        /// <param name="NewUserInfo"></param>
        /// <returns>user </returns>
        [HttpPost]
        [Route("UpdateUserInfo")]
        public User UpdateUserInfo([FromBody] User NewUserInfo)
        {
            return UpdateInfo(NewUserInfo);
        }

        /// <summary>
        /// Check is the username is exist
        /// </summary>
        /// <param name="Username">string</param>
        /// <returns>boolean true/false</returns>
        [HttpGet]
        [Route("IsUniqueUsername")]
        public bool IsUniqueUsername(string Username)
        {
            return CheckUniqueUsername(Username);
        }

        /// <summary>
        /// Check is the email is exist
        /// </summary>
        /// <param name="Email">string</param>
        /// <returns>boolean true/false</returns>
        [HttpGet]
        [Route("IsUniqueEmail")]
        public bool IsUniqueEmail(string Email)
        {
            return CheckUniqueEmail(Email);
        }
        #endregion

        #region Rating

        /// <summary>
        /// Insert new rate for specific user
        /// </summary>
        /// <param name="NewRate">object of Rating</param>
        /// <returns>Rating Object</returns>
        [HttpPost]
        [Route("InsertNewRate")]
        public Rating InsertNewRate([FromBody] Rating NewRate)
        {
            return InsertRate(NewRate);
        }

        /// <summary>
        /// Get All Ratings By User Id
        /// </summary>
        /// <param name="UserId">int variable</param>
        /// <returns>Rating List</returns>
        [HttpGet]
        [Route("GetAllRatingsByUserId")]
        public List<Rating> GetAllRatingsByUserId(int UserId)
        {
            return _context.Rating.Where(rate => rate.UserId == UserId).ToList();
        }
        #endregion

        #region Reporting
        /// <summary>
        /// Insert new report for specific user
        /// </summary>
        /// <param name="NewReport">object of Rating</param>
        /// <returns>Report Object</returns>
        [HttpPost]
        [Route("InsertNewReport")]
        public Report InsertNewReport([FromBody] Report NewReport)
        {
            return InsertReport(NewReport);
        }

        /// <summary>
        /// Get All Report By User Id
        /// </summary>
        /// <param name="UserId">int variable</param>
        /// <returns>Report List</returns>
        [HttpGet]
        [Route("GetAllReportByUserId")]
        public List<Report> GetAllReportByUserId(int UserId)
        {
            return _context.Report.Where(rate => rate.UserId == UserId).ToList();
        }
        #endregion

        #endregion

        #region Private Methods

        #region Users
        private User CreateNewUser(User NewUser)
        {
            NewUser.Password = Encrypt(NewUser.Password);
            _context.User.Add(NewUser);
            _context.SaveChanges();
            return NewUser;
        }

        private User UpdateInfo(User NewUserInfo)
        {
            User OldUser = _context.User.Where(user => user.Id == NewUserInfo.Id).FirstOrDefault();
            OldUser.FirstName = NewUserInfo.FirstName;
            OldUser.LastName = NewUserInfo.LastName;
            OldUser.Gender = NewUserInfo.Gender;
            OldUser.CarInfo = NewUserInfo.CarInfo;
            OldUser.Country = NewUserInfo.Country;
            _context.SaveChanges();
            return OldUser;
        }

        private User GetUser(string UsernameOrEmail, string Password)
        {
            List<User> UsersList = _context.User.Where(user => (user.Username.Trim().ToLower() == UsernameOrEmail.Trim().ToLower() ||
                                  user.Username.Trim().ToLower() == UsernameOrEmail.Trim().ToLower()) && (Decrypt(user.Password) == Password)).ToList();
            return UsersList.FirstOrDefault();
        }

        private bool CheckUniqueUsername(string Username)
        {
            List<User> UsersList = _context.User.Where(user => user.Username.Trim().ToLower() == Username.Trim().ToLower()).ToList();
            return UsersList.Count() > 0;
        }

        private bool CheckUniqueEmail(string Email)
        {
            List<User> UsersList = _context.User.Where(user => user.Email.Trim().ToLower() == Email.Trim().ToLower()).ToList();
            return UsersList.Count() > 0;
        }

        private static string Encrypt(string data)
        {
            byte[] encData_byte = new byte[data.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;

        }

        private static string Decrypt(string sData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(sData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        #endregion

        #region Rating
        private Rating InsertRate(Rating NewRate)
        {
            _context.Rating.Add(NewRate);
            _context.SaveChanges();
            return NewRate;
        }
        #endregion

        #region Reporting
        private Report InsertReport(Report NewReport)
        {
            _context.Report.Add(NewReport);
            _context.SaveChanges();
            return NewReport;
        }

        #endregion

        #endregion
    }
}