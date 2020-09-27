using System;
using Xamarin.Forms;

namespace ESILib.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookKey { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Available { get; set; }
        public string ISBN { get; set; }
        public string Coverurl { get; set; }
        public Boolean isFavorite { get; set; }
    }
}
