using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppNetM4S22021.Client.Repositorios
{
    interface IRepositorio
    {
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
    }
}
