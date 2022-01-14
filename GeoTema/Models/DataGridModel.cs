using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema.Models
{
    public class DataGridModel
    {
        public int ID { get; set; }
        public string Land { get; set; }
        public string Verdensdel { get; set; }
        public int Rang { get; set; }
        public Decimal Fødselsrate { get; set; }
    }
}
