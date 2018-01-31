using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;

namespace WebApiDemo.Models
{
    public class WebApiDemoContextInitializer : DropCreateDatabaseAlways<WebApiDemoContext>
    {
        protected override void Seed(WebApiDemoContext context)
        {
            var books = new List<Book>
            {
                new Book() {Name = "War and Peace", Author = "Tolstoy", Price = 19.95m},
                new Book() {Name = "Me Love Ya", Author = "Sean Paul", Price = 49.95m},
                new Book() {Name = "Harry Potter 1", Author = "J.K. Rowling", Price = 20.95m},
                new Book() {Name = "Harry Potter 2", Author = "J.K. Rowling", Price = 19.95m},
                new Book() {Name = "Love and Mariage", Author = "Hal Bandy", Price = 39.95m},
                new Book() {Name = "Book one", Author = "Author1", Price = 19.95m},
                new Book() {Name = "Book two", Author = "Author2", Price = 35.95m}
            };
            foreach (var book in books)
            {
                context.Books.Add(book);
            }

            context.SaveChanges();

            var order = new Order() { Customer = "Nesli Blau", OrderDate = new DateTime(2017, 8, 17) };
            var details = new List<OrderDetail>()
            {
                new OrderDetail() {Book = books[2], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[1], Quantity = 2, Order = order},
                new OrderDetail() {Book = books[0], Quantity = 3, Order = order}
            };

            context.Orders.Add(order);
            foreach (var orderDetail in details)
            {
                context.OrderDetails.Add(orderDetail);
            }

            context.SaveChanges();

            order = new Order() { Customer = "Didi Cat", OrderDate = new DateTime(2016, 11, 11) };
            details = new List<OrderDetail>()
            {
                new OrderDetail() {Book = books[1], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[1], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[3], Quantity = 12, Order = order},
                new OrderDetail() {Book = books[4], Quantity = 3, Order = order}
            };

            context.Orders.Add(order);
            foreach (var orderDetail in details)
            {
                context.OrderDetails.Add(orderDetail);
            }

            order = new Order() { Customer = "Ward Bell", OrderDate = new DateTime(2018, 1, 15) };
            details = new List<OrderDetail>()
            {
                new OrderDetail() {Book = books[2], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[4], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[3], Quantity = 1, Order = order},
                new OrderDetail() {Book = books[1], Quantity = 3, Order = order}
            };

            context.Orders.Add(order);
            foreach (var orderDetail in details)
            {
                context.OrderDetails.Add(orderDetail);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
