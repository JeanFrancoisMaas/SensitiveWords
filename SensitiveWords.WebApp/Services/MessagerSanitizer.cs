using SensitiveWords.WebApp.Interfaces;
using System.Text.RegularExpressions;

namespace SensitiveWords.WebApp.Services
{
    public class MessagerSanitizer : IMessageSanitizer
    {
        private readonly Regex _regex;

        public MessagerSanitizer(IEnumerable<string> keyWords)
        {
            var pattern = $@"\b({string.Join("|", keyWords.Select(x => Regex.Escape(x)))})\b";
            _regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        
        //For improving performance, instead of doing everything in SQL, this should be a better way of sanitizing
        public string Sanitize(string message)
        {
            return _regex.Replace(message,
                m => new string('*', m.Value.Length));
        }
    }
}
