using SensitiveWords.WebApp.Models.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveWords.Contracts.Response.KeyWords
{
    public record KeyWordsResponseContract(IEnumerable<KeyWord> keyWords);
    
    
}
