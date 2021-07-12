using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Business.Models.Results
{
    public class ErrorResult: Result
    {
        public ErrorResult(string massage):base (ResultStatus.Error,massage)

        {

        }
        public ErrorResult():base(ResultStatus.Error,"")
        {

        }
        
    }
    public class ErrorResult<TResultType> : Result<TResultType>
    {
        public ErrorResult(string massage,TResultType data) : base(ResultStatus.Error,massage,data)
        {

        }
        public ErrorResult(string massage) : base(ResultStatus.Error, massage, default)
        {

        }

        public ErrorResult(TResultType data) : base(ResultStatus.Error, "", data)
        {

        }
        public ErrorResult():base(ResultStatus.Error, "", default)
        {

        }
    }
}
