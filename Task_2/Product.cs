using System;

namespace Products
{
    public class Product
    {
        public decimal Price { get; }
        public string Title { get; }

        public int Id { get; set; }

        public bool IsNew { get; set; }

        public Product()
        {
        }

        public Product(decimal price, string title)
        {
            Price = price;
            Title = title;
        }

        public Product(decimal price, string title, bool isNew) : this(price, title)
        {
            IsNew = isNew;
        }

        public override string ToString()
        {
            return $"Title: {Title}. Price: {Price:N0}";
        }
        //

        protected bool Equals(Product other)
        {
            return Price == other.Price && Title == other.Title;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Product left, Product right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Product left, Product right)
        {
            return !Equals(left, right);
        }
    }
}