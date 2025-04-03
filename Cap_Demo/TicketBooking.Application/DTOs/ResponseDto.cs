using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.DTOs
{
    public class ResponseDto
    {
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
    }
}
