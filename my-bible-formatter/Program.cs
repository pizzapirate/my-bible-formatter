using my_bible_formatter;
using my_bible_formatter.Models;
using System.Reflection;

string path = @"C:\Users\mvell\source\repos\my-bible-formatter\my-bible-formatter\web.xml";
// https://github.com/seven1m/open-bibles
//var bible = Helper.KJVListifyBible(pathToGodsWord);

var bible = Helper.XMLListifyBible(path);

Helper.SaveFormattedBible(bible, @"C:\Users\mvell\Downloads\web-formatted.json");


Console.WriteLine("Done.");

