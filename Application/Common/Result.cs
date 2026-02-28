using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static Result Sucess(string message)
            => new Result { Success = true, Message = message };

        public static Result Failure(string message) 
            => new Result { Success = false, Message = message };


    }
}
