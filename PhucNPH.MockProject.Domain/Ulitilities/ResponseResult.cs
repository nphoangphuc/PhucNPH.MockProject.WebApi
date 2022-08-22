using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhucNPH.MockProject.Domain.Ulitilities
{
    public class ResponseResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        /// <summary>
        /// Only return status code
        /// </summary>
        /// <param name="statusCode"></param>
        public ResponseResult(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Return status code and a message
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public ResponseResult(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        /// <summary>
        /// Return status code and list of error messages
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="errors"></param>
        public ResponseResult(int statusCode, List<string> errors)
        {
            this.StatusCode = statusCode;
            this.Errors = errors;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public ResponseResult()
        {

        }

    }
}
