using my_bible_formatter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace my_bible_formatter
{
    public static class Helper
    {
        public static List<BibleVerse>? ListifyBible(string path)
        {
            string jsonBible = File.ReadAllText(path);

            string[] pieces = jsonBible.Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

            return null;
        }
    }
}
