using Microsoft.AspNetCore.Mvc;
using Web.Common.Exceptions;
using Web.Common.Logging;

namespace WebStructure.Admin.Controllers.Base
{
    public class BaseController : Controller
    {
        public string UserId
        {

            get
            {
                try
                {
                    return User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

                }
                catch (Exception ex)
                {
                    WebLogging.LogException(ex.Message);
                    throw new WebException("");
                }
            }
        }

        public string EmailAddress
        {
            get
            {
                try
                {
                    return User.Claims.First(c => c.Type.Contains("emailaddress")).Value;

                }
                catch (Exception ex)
                {
                    WebLogging.LogException(ex.Message);
                    throw new WebException("");
                }
            }
        }

        public string RoleName
        {
            get
            {
                try
                {
                    return User.Claims.First(c => c.Type.Contains("role")).Value;

                }
                catch (Exception ex)
                {
                    WebLogging.LogException(ex.Message);
                    throw new WebException("");
                }
            }
        }
    }
}
