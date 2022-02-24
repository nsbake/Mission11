using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazon.Models
{
    public class Cart
    {
        public List<LineItem> Items { get; set; } = new List<LineItem>();

        public void AddItem(Book book, int qty)
        {
            LineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new LineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalcTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }

    }

    public class LineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
