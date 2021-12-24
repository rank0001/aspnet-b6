using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Models
{
    public class BookModel
    {
        public string BookName { get; set; }

        public BookModel()
        {
            BookName = "To kill a Mockingbird!";
        }
    }
}
