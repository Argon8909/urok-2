using Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Products
{
    class Program
    {
        private const int BasketCapacity = 10;
        private const int ProductsCapacity = 100;

        private static Random _random = new Random();
        private static List<Product> _products = new List<Product>(ProductsCapacity); //перечень продуктов
        private static List<ProductBasket> Baskets = new List<ProductBasket>(); //список корзин

        static void Main(string[] args)
        {
            Creator();

            var threads = new List<Thread>(BasketCapacity);

            for (int i = 0; i < threads.Count; i++)
            {
                Thread th = new Thread(() => Console.WriteLine(SumProducts(Baskets[i])));
                th.Start();
            }
             
           
        }

        static decimal SumProducts(ProductBasket basket)
        {
            return basket.Products.Sum(x => x.Key.Price * x.Value);
        }

        static void Creator()
        {
            for (int i = 0; i < ProductsCapacity; i++)
            {
                _products.Add(CreateProduct());
            }


            for (int i = 0; i < BasketCapacity; i++)
            {
                Baskets.Add(CreateBasket());
            }
        }

        static Product CreateProduct()
        {
            int price = _random.Next(1, 25);
            var productName = RandomString(_random.Next(2, 10));
            return new Product(price, productName); //
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        static ProductBasket CreateBasket()
        {
            var basket = new ProductBasket();
            var productsCount = _random.Next(1, 10);

            for (int i = 0; i < productsCount; i++)
            {
                var randomProductIndex = _random.Next(_products.Count);
                var selectedProduct = _products[randomProductIndex];
                basket.AddProduct(selectedProduct, _random.Next(1, 200)); //Заполняем количество продуктов в корзине
            }

            return basket;
        }
    }
}

/*
  for (int i = 0; i < ProductsCapacity; i++)
            {
                _products.Add(CreateProduct());
            }

            List<ProductBasket> Baskets = new List<ProductBasket>(); //список корзин
            for (int i = 0; i < 10; i++)
            {
                Baskets.Add(CreateBasket());
            }

            //выбрать такие корзины, в которых сумма всех продуктов больше 100
            var basketsOver100 = Baskets.Where(b => b.SumProducts > 100);

            //ыбрать такие продукты, у которых название длинее 5 символов и цена больше 10
            var namePriceProducts = _products.Where(p => p.Title.Length > 5 && p.Price > 10);

            //выбрать такие корзины, у которых более 4 продуктов 
            var basketsOver4Positions = Baskets.Where(b => b.Products.Count > 4);

            //выбрать продукты из всех корзин, у которых цена в интервале от 10 до 100
            var price10To100 =
                _products.Where(p =>
                    p.Price > 10 &&
                    p.Price < 100);

            //выбрать для каждой корзины продукт с максимальной ценой в рамках данной корзины
            var maxPriceInBasket = Baskets
                .Select(b => b.Products.OrderByDescending(p => p.Key.Price).FirstOrDefault())
                .Select(p => p.Key);

            //посчитать сумму всех продуктов в рамках каждой корзины
            var sumProductPriceInBasket = Baskets.Select(s => s.Products.Sum(s => s.Key.Price));

            //посмитчать сумму всех продуктов для всех корзин суммарно
            var sumPriceProductInAllBasket = Baskets.SelectMany(b => b.Products.Keys)
                .Sum(p => p.Price);
*/