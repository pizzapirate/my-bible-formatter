using my_bible_formatter;
using my_bible_formatter.Models;
using System.Reflection;

string pathToGodsWord = @"C:\Users\mvellozzo\source\repos\my-bible-formatter\my-bible-formatter\kjv.json";

var bible = Helper.ListifyBible(pathToGodsWord);



Console.WriteLine(bible);