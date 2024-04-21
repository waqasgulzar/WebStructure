using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common.Exceptions
{
    /// <summary>
    ///     This exception class is the base for all exception classes in the CaritagFirmware Application
    ///     This class may also be thrown as it is.
    ///     This exception will usually be application level error and may not be logged in the log table.
    /// </summary>
    [Serializable]
    public class WebException : ApplicationException
    {
        private readonly string _title = "Web Exception";
        private readonly string _userMessage;

        /// <summary>
        /// </summary>
        public WebException()
            : base("Application Error")
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="message">ExceptionMessage and UserMessage will be the same</param>
        public WebException(string message)
            : base(message)
        {
            _userMessage = message;
        }


        /// <summary>
        /// </summary>
        /// <param name="message">ExceptionMessage and UserMessage will be the same</param>
        /// <param name="title">Title to be shown to the user</param>
        public WebException(string message, string title)
            : base(message)
        {
            _userMessage = message;
            _title = title;
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="userMessage">ExceptionMessage to be shown to the user, other than Exception message</param>
        public WebException(string message, string title, string userMessage)
            : base(message)
        {
            _title = title;
            _userMessage = userMessage;
        }

        /// <summary>
        /// </summary>
        /// <param name="message">ExceptionMessage and UserMessage will be same here</param>
        /// <param name="innerException"></param>
        public WebException(string message, Exception innerException)
            : base(message, innerException)
        {
            _userMessage = message;
        }

        public string Title => string.IsNullOrEmpty(_title) ? "Web Error" : _title;
        public string UserMessage => string.IsNullOrEmpty(_userMessage) ? Message : _userMessage;
    }

}
