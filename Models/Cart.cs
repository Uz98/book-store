using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookly.Models
{
    public class Cart
    {
        private List<CartLine> _cartlines = new List<CartLine>();
        public List<CartLine> CartLines { get { return _cartlines; } }

        public void AddBook(Book book, int quantity)
        {
            var line = _cartlines.FirstOrDefault(b => b.Book.Id == book.Id);
            if (line == null)
            {
                _cartlines.Add(new CartLine() {Book=book,Quantity=quantity});
            }
            else
            {
                line.Quantity += quantity;
            }
        }


        public void DeleteBook(int id)
        {
            _cartlines.RemoveAll(b => b.Book.Id == id);
        }

        public double Total()
        {
            return _cartlines.Sum(i => i.Book.Price * i.Quantity);
        }

        public void Clear()
        {
            _cartlines.Clear();
        }
    }

    public class CartLine
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}