using System.Collections.Generic;

namespace Products
{
    public class ProductBasket
    {
        private Dictionary<Product, int> _products = new Dictionary<Product, int>();
        public IReadOnlyDictionary<Product, int> Products => _products;
        public int SumProducts { private set; get; }

        public void AddProduct(Product product, int quantity)
        {
            if (_products.ContainsKey(product))
            {
                _products[product] += quantity;
            }
            else
            {
                _products.Add(product, quantity);
            }

            SumProducts += quantity;
        }
    }
}