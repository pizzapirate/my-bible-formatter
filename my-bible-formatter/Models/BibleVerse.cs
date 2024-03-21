
namespace my_bible_formatter.Models
{
    public class BibleVerse
    {   
        public BibleVerse() {
            Text = "";
        }
        public int Book {  get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Text { get; set; }
    }
}
