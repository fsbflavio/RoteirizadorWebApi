using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.Domain.Model
{
    public class Coordinate
    {
        public int Id { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }
    }
}
