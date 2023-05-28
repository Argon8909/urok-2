using System;

namespace Products
{
    public class ProductAddEventArgs : EventArgs
    {
        public  Product AddedProduct { get; }

        public ProductAddEventArgs(Product addedProduct)
        {
            AddedProduct = addedProduct;
        }
    }
}