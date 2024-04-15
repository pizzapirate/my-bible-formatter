using my_bible_formatter;
using my_bible_formatter.Models;
using System.Reflection;

string path = @"C:\Users\mvellozzo\source\repos\testEnv\my-bible-formatter\my-bible-formatter\asv.xml";

//var bible = Helper.KJVListifyBible(pathToGodsWord);

var bible = Helper.XMLListifyBible(path);

//Helper.SaveFormattedBible(bible, @"C:\Users\mvell\Downloads\formatted-bible.json");




Console.WriteLine("Done.");

