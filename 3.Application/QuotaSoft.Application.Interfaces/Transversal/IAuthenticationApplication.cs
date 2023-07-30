namespace Quota.Application.Interfaces.Transversal
{
    using Quota.Domain.Entities.Dto;
    using Quota.Domain.Entities.Response;

    /// <summary>
    /// The Authentication Application interface.
    /// </summary>
    public interface IAuthenticationApplication
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="credencialDto"></param>
       /// <returns></returns>
        GenericResponse<LoginResponse> Authentication(CredentialDto credencialDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        GenericResponse<UserDto> GetUserAuth(string userName);
    }
}