using System;
using System.IO;
using Library;
using Library.figures;
using Products.mails;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            //var circle = new Circle(1, "23");

            var typeOfCircle = typeof(Circle);
            foreach (var att in typeOfCircle.GetCustomAttributes(true))
            {
                if (att is AuthorAttribute authorAttribute)
                {
                    Console.WriteLine($"Наш атрибут: {authorAttribute}");
                }
            }
            
            return;
            
            
            MainFigures();
            return;
            Main1();
            return;
            void OnMail(object sender, MailEventArgs eventArgs)
            {
                //Console.WriteLine($"5Получено письмо: {eventArgs.Mail}");
            }
            
            void OnMail1(object sender, MailEventArgs eventArgs)
            {
                //Console.WriteLine($"5Получено письмо: {eventArgs.Mail}");
            }

            var man = new Human();
            
            man.GetMailEvent += OnMail;
            man.GetMailEvent += OnMail1;
            man.PrintInvocationList();

            man.AddMail(new Mail("ssfd", "sdf", "sdf"));
            
            man.GetMailEvent -= OnMail;
            man.PrintInvocationList();
            
            
            // EventHandler<ProductAddEventArgs> cardOnProductAddedEvent()
            // {
            //     return (sender, eventArgs) =>
            //     {
            //         var product = eventArgs.AddedProduct;
            //         Console.WriteLine($"Обработчик1. {product}"); 
            //     };
            // }
            //
            //
            // // EventHandler<ProductAddEventArgs> cardOnProductAddedEvent2()
            // // {
            // //     return (sender, eventArgs) =>
            // //     {
            // //         Console.WriteLine("Обработчик2"); 
            // //     };
            // // }
            // var pr1 = new Product(10000, "pr1");
            // var pr2 = new Product(99, "pr2");
            // var pr3 = new Product(10, "pr3");
            //
            // var card = new ProductCard(NotifyMagnit, NotifyOfSaleByConsole, CalculateSaleMagnit, obj => true );
            //
            // card.ProductAddedEvent += cardOnProductAddedEvent();
            // //card.ProductAddedEvent += cardOnProductAddedEvent2();
            //
            // card.AddProducts(new []{pr1, pr2, pr3});
            //
            // card.ProductAddedEvent -= cardOnProductAddedEvent();
            // //card.ProductAddedEvent -= cardOnProductAddedEvent2();
            
            return;

            // Console.WriteLine("perekrestok");
            // var card1 = new ProductCard(
            //     product => { Console.WriteLine($"Added new product: {product}"); },
            //     (sale, summOfSale) =>
            //     {
            //         Console.WriteLine($"Скидка составила {sale:P} процентов. В деньгах: {summOfSale:N0}");
            //     },
            //     (arg) => 0.8M, 
            //     summ =>
            //     {
            //         if (summ > 1000) return true;
            //         return false;
            //     });
            //
            // card1.AddProduct(pr1);
            // Console.WriteLine($"Total: {card1.GetTotalSumm():N0}");


            // Console.WriteLine("magin");
            // var card2 = new ProductCard(NotifyMagnit, NotifyOfSaleByConsole, CalculateSaleMagnit);
            // card2.AddProduct(pr2);
            // Console.WriteLine($"Total: {card2.GetTotalSumm():N0}");
            //
            // //
            // var card2 = new ProductCard(NotifyPerekrestok, NotifyOfSaleByFile);
            // Console.WriteLine($"Total: {card2.GetTotalSumm():N0}");

            // Console.WriteLine("DIKSI");
            // var productCardDiksi = new ProductCard(NotifyDiksi, NotifyOfSale);
            // productCardDiksi.AddProduct(pr1);
            // productCardDiksi.AddProduct(pr2);
            // productCardDiksi.AddProduct(pr3);
            //
            // Console.WriteLine("MAGNIT");
            // var productCardMagnit = new ProductCard(NotifyMagnit, NotifyOfSale);
            // productCardMagnit.AddProduct(pr1);

            // Console.WriteLine(productCard.PrintAllProduct());

        }


        static void MainFigures()
        {

            int i = 1;
            
            i.PrintInt();
            
            var cube = new Cube(1, 10);
            cube.GetAreaAndVolSumm();

            var circle = new Circle(10, "324");
            
            circle.CalculateAndPrint("Квадрат площади");

            //var prop = GetAreaAndVolSumm(cube);
        }

        static double GetAreaAndVolSumm(Cube cube)
        {
            return cube.Perimeter + cube.Volume;
        }
        
        static void Main1()
        {
            var pr1 = new Product(10000, "pr1");
            var pr2 = new Product(99, "pr2");
            var pr3 = new Product(10, "pr3");

            // var card = new ProductCard(NotifyMagnit, NotifyOfSaleByConsole, CalculateSaleMagnit, obj => true);
            //
            // card.BuyEvent += CardOnBuyEvent;
            // card.AddProducts(new []{pr1, pr2, pr3});
            // card.Buy();
            //
            // card.BuyEvent -= CardOnBuyEvent;

            
        }

        private static void CardOnBuyEvent(object sender, decimal total)
        {
            Console.WriteLine($"Сделана покупка на сумму {total}");
        }

        public static void NotifyPerekrestok(Product product)
        {
            Console.WriteLine($"Added new product: {product}");
        }
        
        public static void NotifyDiksi(Product product)
        {
            Console.WriteLine($"Welcome! Added new product: {product}");
        }
        
        public static void NotifyMagnit(Product product)
        {
            //Console.WriteLine($"MAGNIT! Added new product: {product}");
        }

        public static void NotifyOfSaleByConsole(decimal sale, decimal summOfSale)
        {
           // Console.WriteLine($"Скидка составила {sale:P} процентов. В деньгах: {summOfSale:N0}");
        }
        
        public static void NotifyOfSaleByFile(decimal sale, decimal summOfSale)
        {
            var message = $"Скидка составила {sale:P} процентов. В деньгах: {summOfSale:N0}";
            File.WriteAllText("log.txt", message);
        }
        
        // private readonly Func<decimal, decimal> _calculateSaleFunc;

        public static decimal CalculateSaleMagnit(decimal summ)
        {
            decimal sale = 1;
            
            if (summ > 1000)
            {
                sale = 0.95M;
            }
            else if (summ > 100)
            {
                sale = 0.975M;
            }
            else if (summ > 25)
            {
                sale =  0.99M;
            }
        
            return sale;
        }
        
        public static decimal CalculateSalePerekrestok(decimal summ)
        {
            decimal sale = 0.9M;
        
            return sale;
        }
    }
}