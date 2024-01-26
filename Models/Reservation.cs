using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen_VG.Models
{
    internal class Reservation
    {
        public int Id { get; set; }
        public int ResvYear { get; set; }
        public int ResvMonth { get; set; }
        public int ResvDay { get; set; }
        public int ResvTimeStart { get; set; }
        public int ResvTimeEnd { get; set; }
        public string LiableFirName { get; set; }
        public string LiableSecName { get; set; }
        public string? Department { get; set; }
        public int? RoomId { get; set; }//FK Id
        public virtual Room Room { get; set; }//FK adressing
    }
}
