﻿namespace Quota.Application.Services.Transversal
{
    using Quota.Application.Interfaces.Transversal;
    using Quota.Domain.Entities.Dto;
    using Quota.Domain.Entities.Response;
    using Quota.Domain.Interfaces.Services;
    using Quota.Domain.Services.Utilities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="AuthorizationApplication" />
    /// </summary>
    public class AuthorizationApplication : IAuthorizationApplication
    {
        /// <summary>
        /// Defines the authorizationService
        /// </summary>
        private readonly IAuthorizationService authorizationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationApplication"/> class.
        /// </summary>
        /// <param name="authorizationService">The authorizationService<see cref="IAuthorizationService"/></param>
        public AuthorizationApplication(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestAuthorization"></param>
        /// <returns></returns>
        public GenericResponse<IEnumerable<AuthorizationDto>> RequestAuthorization(RequestAuthorizationDto requestAuthorization)
        {
            var auth = authorizationService.RequestAuthorization(requestAuthorization);
            return HelperGeneric<IEnumerable<AuthorizationDto>>.CastToGenericResponse(Helper.ManageResponse(auth));
        }
    }
}
