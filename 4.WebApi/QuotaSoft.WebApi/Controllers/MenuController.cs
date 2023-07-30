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
    public class MenuController : Controller
    {
        private IMenuApplication menuApplication;

        public MenuController(IMenuApplication menuApplication)
        {
            this.menuApplication = menuApplication;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetMenu")]
        public IActionResult GetMenu()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token = Request.Headers[MyHeadersEnum.Authorization];
            string userName = HeaderClaims.GetClaimValue(token, MyClaimsEnum.unique_name);
            return Ok(this.menuApplication.GetMenuByClaimsUserIn(userName));
        }
    }
}
