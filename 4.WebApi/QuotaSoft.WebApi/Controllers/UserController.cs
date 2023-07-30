﻿namespace Quota.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Quota.Application.Interfaces.Transversal;
    using Quota.Domain.Entities.Dto;
    using Quota.WebApi.Middleware;
    using Quota.Domain.Entities.Enums;
    using Quota.Domain.Entities.Response;
    using Common.Utils.Utils.Interface;
    using System.Security.Claims;
    using Quota.Domain.Entities.Model.Authentication;

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserApplication userApplication;

        public UserController(IUserApplication userApplication)
        {
            this.userApplication = userApplication;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token = Request.Headers[MyHeadersEnum.Authorization];
            string userName = HeaderClaims.GetClaimValue(token, MyClaimsEnum.unique_name);
            return Ok(this.userApplication.GetUsers());
        }

        [Authorize]
        [HttpPost]
        [Route("InsertUser")]
        public IActionResult InsertUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token = Request.Headers[MyHeadersEnum.Authorization];
            return Ok(this.userApplication.InsertUser(user));
        }
    }
}