using System;
namespace Flashcard
{
    public class President
    {
        private string name;
        private string year;


        public President(string name, string year)
        {
            Name = name;
            Year = year;
        }

        public string Name { get => name; set => name = value; }
        public string Year { get => year; set => year = value; }
    }
}
