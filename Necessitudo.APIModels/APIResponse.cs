using System;
using System.Collections.Generic;
using System.Text;

namespace Necessitudo.APIModels
{
    public class ApiResponse
    {
        public int ResponseCode { get; set; }
        public string RespMessage { get; set; }
        public int RecordCount { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T ResponseObject { get; set; }
    }
   
    public class ApiResponseList<T> where T : class
    {
        public int ResponseCode { get; set; }
        public string RespMessage { get; set; }
        public List<T> ResponseObject { get; set; }
        public int RecordCount { get; set; }
    }
}
