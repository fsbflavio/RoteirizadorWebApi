using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.Domain.Model
{
    public class Route
    {
        public int Id { get; set; }

        public string Descricao { get; set; }
        public ICollection<Coordinate> Coordinates { get; set; }
    }
}
