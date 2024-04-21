using Web.Common.Enumerations;
using Web.Common.Models;

namespace WebStructure.Admin.ViewModels.Base
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Messages = new List<UIMessageResponse>();
        }
        public string UserId { get; set; }

        public bool IsError { get; set; }
        public string PicUserUrl { get; set; }
        public List<UIMessageResponse> Messages { get; set; }


        public void AddMessage(MessageType type, string exceptionMsg, string msg = "", bool isError = false)
        {
            IsError = isError;
            Messages.Add(new UIMessageResponse { Type = type, ExceptionMessage = exceptionMsg, CustomMessage = msg });
        }
    }
}
