using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.Shared.DTO;

namespace Shopping.Shared
{
    public class BaseController: ControllerBase
    {
        //public string Token
        //{
        //    get
        //    {
        //        return Request.Headers.FirstOrDefault(h => h.Key== "token").Value;
        //    }
        //}

        //public ResponseDTO GetResponse(object data, bool isSuccess = false)
        //{
        //    try
        //    {
        //        return new ResponseDTO { IsSuccess = isSuccess, Data = data };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseDTO { IsSuccess = false, ErrorMessage = ex.Message };
        //    }
        //}
    }
}
