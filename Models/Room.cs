using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen_VG.Models
{
    internal class Room
    {
        public int Id { get; set; }
        public int RoomNr { get; set; }
        public int SeatsQuantity { get; set; }
        public bool Whiteboard { get; set; }
        public bool Projector { get; set; }

    }
}
