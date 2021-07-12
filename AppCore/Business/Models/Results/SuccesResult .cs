using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Business.Models.Results
{
   public class SuccesResult : Result
    {
        public SuccesResult(string massage):base (ResultStatus.Succes,massage)

        {

        }
        public SuccesResult():base(ResultStatus.Succes,"")
        {

        }
        
    }
    public class SuccesResult<TResultType> : Result<TResultType>
    {
        public SuccesResult(string massage,TResultType data) : base(ResultStatus.Succes,massage,data)
        {

        }
        public SuccesResult(string massage) : base(ResultStatus.Succes, massage, default)
        {

        }

        public SuccesResult(TResultType data) : base(ResultStatus.Succes, "", data)
        {

        }
        public SuccesResult():base(ResultStatus.Succes, "", default)
        {

        }
    }
}
