using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Domain.Results
{
    public class BaseResponseResult<TData> where TData : class
    {
        public BaseResponseResult()
        {
            Errors = new List<string>();
        }

        public bool HasError => Errors.Any();
        public List<string> Errors { get; set; }
        public TData Result { get; set; }

    }
    public class BaseResponseResult
    {
        public BaseResponseResult()
        {
            Errors = new List<string>();
        }

        public bool HasError => Errors.Any();
        public List<string> Errors { get; set; }
    }
}
