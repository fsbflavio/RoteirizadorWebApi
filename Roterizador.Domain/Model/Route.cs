using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.Domain.Model
{
    public class Route
    {
        public int Id { get; set; }
        public Coordinate Start { get; set; }
        public Coordinate End { get; set; }
    }
}
