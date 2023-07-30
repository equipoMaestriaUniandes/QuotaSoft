namespace Quota.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Quota.Application.Interfaces.Transversal;
    using Quota.Domain.Entities.Dto;
    using Quota.WebApi.Middleware;
    using Quota.Domain.Entities.Enums;
    using Quota.Domain.Entities.Response;
    using Common.Utils.Utils.Interface;
    using System.Security.Claims;

    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private ILocationApplication locationApplication;

        public LocationController(ILocationApplication locationApplication)
        {
            this.locationApplication = locationApplication;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetCountries")]
        public IActionResult GetCountries()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token = Request.Headers[MyHeadersEnum.Authorization];
            string userName = HeaderClaims.GetClaimValue(token, MyClaimsEnum.unique_name);
            return Ok(this.locationApplication.GetCountries());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetStates")]
        public IActionResult GetStates()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token = Request.Headers[MyHeadersEnum.Authorization];
            string userName = HeaderClaims.GetClaimValue(token, MyClaimsEnum.unique_name);
            return Ok(this.locationApplication.GetStates());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetCitiesByState/{stateId}")]
        public IActionResult GetCitiesByState(int stateId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token = Request.Headers[MyHeadersEnum.Authorization];
            string userName = HeaderClaims.GetClaimValue(token, MyClaimsEnum.unique_name);
            return Ok(this.locationApplication.GetCitiesByState(stateId));
        }
    }
}
