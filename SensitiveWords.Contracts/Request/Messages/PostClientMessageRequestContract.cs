using SensitiveWords.WebApp.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveWords.Contracts.Request.Messages
{
    public record PostClientMessageRequestContract(ClientMessage message);
    
}
