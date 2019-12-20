using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Domain.DTO
{
    public class PlayerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BackNumber { get; set; }
        public int TeamId { get; set; }
        public IFormFile Image { get; set; }
    }
}
