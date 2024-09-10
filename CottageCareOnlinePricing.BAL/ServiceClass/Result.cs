using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CottageCare.BAL.ServiceClass
{
        public class Result
        {
            public bool HasError
            {
                get
                {
                    return (Status == StatusType.Error);
                }
                set { }
            }

            public bool HasSuccess
            {
                get
                {
                    return (Status == StatusType.Success);
                }
                set { }
            }
            public bool IsServiceable { get; set; }

            public StatusType Status { get; set; }
            
            public string MessageTitle { get; set; }
            public string Message { get; set; }
            public string ExceptionMessage { get; set; }
            public string ExceptionStackTrace { get; set; }
            public Exception ResultException { get; set; }

            public Object ResultObject; // to pass generic data in results

            public Result()
            {
                this.Status = StatusType.Success;
            }

            public Result(string message)
            {
                this.Status = StatusType.Error;
                this.Message = message;
            }

            public Result(string message, StatusType statusType,bool IsServiceable)
            {
                
                this.Status = statusType;
                this.Message = message;
                this.IsServiceable = IsServiceable;
            }
            public Result(string message, StatusType statusType)
            {
              this.Message = message;
             this.Status = statusType;
            }

        public Result(string message, Exception exp)
        {
                this.Status = StatusType.Error;
                this.Message = message;
                if (null != exp)
                {
                    this.ExceptionMessage = exp.Message;
                    this.ExceptionStackTrace = exp.StackTrace;
                }
                this.ResultException = exp;
            }
        }

}
    public enum StatusType
    {
        //Status Code Refrence from https://docs.microsoft.com/en-us/dotnet/api/system.net.httpstatuscode?view=net-5.0
        Success = 200,
        Error = 500,
        UnprocessableEntity = 422,
        Unauthorized = 401,
        NotFound = 404,
        BadRequest = 400
    }


