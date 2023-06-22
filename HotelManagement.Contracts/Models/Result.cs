using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Contracts.Models
{
    public class Result<T>
    {

        //Result class is used to return the result of the operation
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public Result() { }
    }
}

