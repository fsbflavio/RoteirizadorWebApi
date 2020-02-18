using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roteirizador.WebApi.Auth
{
    public class BasicAuthAttribute : TypeFilterAttribute
    {
        public BasicAuthAttribute(string realm = @"Full Access") 
            : base(typeof(BasicAuthFilter))
        {
            Arguments = new object[] { realm };
        }
    }
}
