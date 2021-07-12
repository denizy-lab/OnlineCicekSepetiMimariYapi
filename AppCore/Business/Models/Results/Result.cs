using AppCore.Business.Models.Results.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Business.Models.Results
{
   public class Result
    {
        public ResultStatus Status { get; set; }
        public string Massage { get; set; }


        protected Result(ResultStatus status,string massage)
        {
            Status = status;
            Massage = massage;
        }
    }
    public class Result<TResultType> : Result, IResultData<TResultType>
    {
        public TResultType Data { get; }

        public Result(ResultStatus status, string massage,TResultType data):base(status,massage)
        {
            Data = data;

        }
    }
}
