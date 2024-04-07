using my_bible_formatter;
using my_bible_formatter.Models;
using System.Reflection;

string pathToGodsWord = @"C:\Users\mvell\source\repos\my-bible-formatter\my-bible-formatter\kjv.json";

var bible = Helper.ListifyBible(pathToGodsWord);

Helper.SaveFormattedBible(bible, @"C:\Users\mvell\Downloads\formatted-bible.json");

Console.WriteLine("Done.");

