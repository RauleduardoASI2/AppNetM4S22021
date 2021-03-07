using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppNetM4S22021.Client.Repositorios
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool error, HttpResponseMessage httResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httResponseMessage;
        }

        public bool Error { get; set; }
        public T Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
