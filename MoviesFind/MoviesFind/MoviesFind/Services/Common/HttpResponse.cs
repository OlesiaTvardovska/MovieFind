using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesFind.Services.Common
{
    public class HttpResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
