using Web.Common.Enumerations;

namespace Web.Common.Models
{
    public class ResponseModel
    {
        public bool OperationSuccess { get; set; }

        public object Content { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();

    }



    public class UIMessageResponse
    {
        public MessageType Type { get; set; }
        public string ExceptionMessage { get; set; }
        public string CustomMessage { get; set; }
    }
}
