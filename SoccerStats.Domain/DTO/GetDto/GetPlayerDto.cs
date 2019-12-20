using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Domain.DTO.GetDto
{
    public class GetPlayerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BackNumber { get; set; }
        public int TeamId { get; set; }
        public byte[] Image { get; set; }
    }
}
