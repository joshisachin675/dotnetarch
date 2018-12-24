using System;
using System.Net;
using System.Net.Http;
using Common;
using Google.Apis.Auth;
using IDScan.Application.UseCases.User;
using IDScan.Domain;
using IDScan.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IDScan.WebApi.UseCases.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Constructor and Global Variable 
        private readonly IAccountApplication _accountApplication;
        private const string GoogleApiTokenInfoUrl = "https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={0}";
        private IConfiguration _config;
        public AccountController(IConfiguration config, IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
            _config = config;
        }
        #endregion

        #region Public Method's
        [AllowAnonymous]
        [HttpPost]
        [Route("ValidateToken")]
        public IActionResult ValidateToken(string authToken)
        {
            var validPayload = GoogleJsonWebSignature.ValidateAsync(authToken);
            if (validPayload == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { response = string.Empty, message = GlobalErrorMessages.INVALID_TOKEN });
            }
            var requestUri = new Uri(string.Format(GoogleApiTokenInfoUrl, authToken));
            HttpResponseMessage httpResponseMessage;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpResponseMessage = httpClient.GetAsync(requestUri).Result;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { response = string.Empty, message = ex.InnerException.Message ?? ex.Message });
                }
            }
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { response = string.Empty, message = GlobalErrorMessages.INVALID_TOKEN });
            }
            var response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            GoogleApiTokenInfo userInfo = JsonConvert.DeserializeObject<GoogleApiTokenInfo>(response);
            if (_config.GetSection("GoogleClientId").Value.ToString() != userInfo.aud.ToString())
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { response = string.Empty, message = GlobalErrorMessages.INVALID_TOKEN });
            }
            if (userInfo != null && !String.IsNullOrEmpty(userInfo.email))
            {
                if (!userInfo.email.Contains(_config.GetSection("CompanyDomain").Value.ToString()))
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new { response = string.Empty, message = GlobalErrorMessages.INVALID_EMAIL_ADDRESS });
                }
                /// Check user register or not CheckUserExistWithEmailAndAdd                            
                UserDTO objUser = new UserDTO();
                objUser.Email = userInfo.email;
                objUser.FirstName = userInfo.name.Split(' ')[0];
                objUser.LastName = userInfo.name.Split(' ')[1];
                objUser.UserName = userInfo.email;
                objUser.LoginProvider = Enumaration.LoginProvide.Google.ToString();
                objUser.ProfileImage = userInfo.picture;
                UserDTO checkUser = _accountApplication.CheckUserExistWithEmailAndAdd(objUser);

            }
            return Ok();
        }

        #endregion

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
