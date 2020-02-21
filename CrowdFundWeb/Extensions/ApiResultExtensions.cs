using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core;
using Microsoft.AspNetCore.Mvc;


namespace CrowFun.Extensions {
    public static class ApiResultExtensions 
    {
        public static ObjectResult AsStatusResult<T>(
           this ApiResult<T> @this)
        {
            var result = default(ObjectResult);

            if (@this.Success) {
                result = new ObjectResult(@this.Data);
            } else {
                result = new ObjectResult(@this.ErrorText);
            }

            result.StatusCode = (int)@this.ErrorCode;

            return result;
        }
    }
}
