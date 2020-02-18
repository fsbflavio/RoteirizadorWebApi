using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roterizador.Domain.Model;
using Roterizador.Domain.Repository;
using Roterizador.EntityPostgres;

namespace Roteirizador.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoutesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Route>>> GetRoutes()
        {
            return await _unitOfWork.Routes.GetAllCompleteAsync();
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Route>> GetRoute(int id)
        {
            var route = await _unitOfWork.Routes.GetAsync(id);


            if (route == null)
            {
                return NotFound();
            }

            return route;
        }

        // PUT: api/Routes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute(int id, Route route)
        {
            if (id != route.Id)
            {
                return BadRequest();
            }

            var routeInBd = await _unitOfWork.Routes.GetAsync(id);

            if (routeInBd == null)
            {
                return NotFound();
            }

            routeInBd.Start = route.Start;
            routeInBd.End = route.End;

            await _unitOfWork.CompleteAsync();

            return Ok(routeInBd);
        }

        // POST: api/Routes
        [HttpPost]
        public async Task<ActionResult<Route>> PostRoute(Route route)
        {
            _unitOfWork.Routes.Add(route);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetRoute", new { id = route.Id }, route);
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Route>> DeleteRoute(int id)
        {
            var route = await _unitOfWork.Routes.GetAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            _unitOfWork.Routes.Remove(route);
            await _unitOfWork.CompleteAsync();

            return route;
        }
    }
}
