using SensitiveWords.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveWords.Sanitizer.Tests.Unit_Tests
{
    public class SanitizerTests
    {
        [Fact]
        public void Sanitize_ShouldReplaceWholeWords_IgnoreCase()
        {
            var keyWords = new[] { "select", "from", "insert", "update" };
            var sanitizer = new MessagerSanitizer(keyWords);

            var result = sanitizer.Sanitize("This is a select * from any of the insert or update statements test.");

            Assert.Equal("This is a ****** * **** any of the ****** or ****** statements test.", result);
        }
    }


}
