using System;
using System.Text.Json.Serialization;
using Amazon.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }
    }
}
