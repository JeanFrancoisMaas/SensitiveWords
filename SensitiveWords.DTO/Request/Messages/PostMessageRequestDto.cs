using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveWords.DTO.Request.Messages
{
    public class PostMessageRequestDto
    {
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
