using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Amazon.Models
{
    public class Cart
    {
        public List<LineItem> Items { get; set; } = new List<LineItem>();

        public virtual void AddItem(Book book, int qty)
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

        public virtual void RemoveItem(Book book)
        {
            Items.RemoveAll(b => b.Book.BookId == book.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }

        public double CalcTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }

    }

    public class LineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
