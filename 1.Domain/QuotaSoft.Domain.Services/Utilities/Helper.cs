namespace Quota.Domain.Services.Utilities
{
    using Quota.Domain.Entities.Response;

    public static class Helper
    {
        public static GeneralResponse ManageResponse(object data = null, bool status = true, string message = null)
        {
            return new GeneralResponse { isSuccess = status, result = data, message = message };
        }

    }
}