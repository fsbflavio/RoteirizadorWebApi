using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roteirizador.WebApi.Auth
{
    public class BasicAuthAttribute : TypeFilterAttribute
    {
        public BasicAuthAttribute() 
            : base(typeof(BasicAuthFilter))
        {
        }
    }
}
