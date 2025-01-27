﻿using my_bible_formatter.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace my_bible_formatter
{
    public static class Helper
    {
        public static List<BibleVerse>? KJVListifyBible(string path)
        {
            string jsonBible = File.ReadAllText(path);

            string[] pieces = jsonBible.Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

            List<BibleVerse> bibleVerses = [];

            foreach (var piece in pieces)
            {
                // Check if the line starts with " \"field\": ["
                if (!Regex.IsMatch(piece, "^ \"field\": \\["))
                {
                    continue;
                }
                // Remove the leading " \"field\": [" and trailing "] "
                string parts = piece.Substring(11, piece.Length - 14);

                // Split the string by comma, but only for the first 4 commas
                string[] part = parts.Split(new char[] { ',' }, 5);

                // Parse each number and store it as an integer
                int num1 = int.Parse(part[0]);
                int book = int.Parse(part[1]);
                int chapter = int.Parse(part[2]);
                int verse = int.Parse(part[3]);

                // The remaining part of the string
                string text = part[4].Substring(2); // substring to remove the first \" character

                BibleVerse bv = new()
                {
                    Text = text,
                    Book = book,
                    Chapter = chapter,
                    Verse = verse
                };

                bibleVerses.Add(bv);
            }

            return bibleVerses;
        }
        public static List<BibleVerse>? XMLListifyBible(string path)
        {
            List<BibleVerse> bibleVerses = [];

            XDocument doc = XDocument.Load(path);

            // Iterate over each <VERS> element
            foreach (var verse in doc.Descendants("VERS"))
            {
                BibleVerse bv = new();

                // Get the bnumber, cnumber, and vnumber attributes
                bv.Book = Convert.ToInt16(verse.Parent.Parent.Attribute("bnumber")?.Value); // <BIBLEBOOK> element
                bv.Chapter = Convert.ToInt16(verse.Parent.Attribute("cnumber")?.Value); // <CHAPTER> element
                bv.Verse = Convert.ToInt16(verse.Attribute("vnumber")?.Value);

                // Get the verse text
                bv.Text = verse.Value;

                bibleVerses.Add(bv);
            }



            return bibleVerses;
        }
        public static void SaveFormattedBible(List<BibleVerse>? bible, string destination)
        {
            string json = JsonSerializer.Serialize(bible);

            // Write the JSON string to a file
            File.WriteAllText(destination, json);
        }
    }
}
