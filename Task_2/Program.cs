using System;
using System.Collections.Generic;
using System.Text;
using FiguresLib;




    class Program
    {
        /// Логику ещё не успел сделать, но реализовал интерфейсы
        
        static void Main(string[] args)
        {
            
            Figure[] figures = new Figure[] { new Circle(4, 1), new Square(55, 2), new Circle(3, 4), new Square(33, 5) };

            foreach (var figure in figures)
            {
                Console.WriteLine(figure.GetTitle());
            }
            
            //var d = new D();
            var a = new A();
            var b = new B();

           // var a = new A();
            
            bool result = b is A;
            
            Console.WriteLine(result);

            return;
            // Circle:5
            // Square:10
            // Triangle:10,4,4

            // List<Figure> figures = new List<Figure>();
            // int number = 0;
            // while (true)
            // {
            //     string str = Console.ReadLine();
            //
            //     if (str == "EXIT")
            //     {
            //         break;
            //     }
            //     
            //     string[] arguments = str.Split(":");
            //     string title = arguments[0];
            //
            //     if (Enum.TryParse(typeof(FigureType), title, true, out var temp))
            //     {
            //         FigureType figureType = (FigureType)temp;
            //         Figure figure = null;
            //         
            //         string[] strValues = arguments[1].Split(",");
            //         double[] values = new double[strValues.Length];
            //         for (int i = 0; i < strValues.Length; i++)
            //         {
            //             values[i] = Convert.ToDouble(strValues[i]);
            //         }
            //         
            //         switch (figureType)
            //         {
            //             case FigureType.Circle:
            //                 figure = new Circle(values[0], number);
            //                 break;
            //             
            //             case FigureType.Square:
            //                 figure = new Square(values[0], number);
            //                 break;
            //             
            //             case FigureType.Triangle:
            //                 figure = new Triangle(values[0],values[1],values[2], number);
            //                 break;
            //             default:
            //                 throw new Exception("Не знаю такую фигуру");
            //         }
            //
            //         number++;
            //         figures.Add(figure);
            //     }
            //     else
            //     {
            //         Console.WriteLine("Не знаю такую фигуру");
            //     }
            // }
            //
            
            
            
            // double summ = 0;
            //
            // foreach (var figure in figures)
            // {
            //     summ += figure.Perimeter;
            // }
            //
            // Console.WriteLine($"Суммарная площадь всех фигур: {summ}");
            //
            //
            // Console.WriteLine("Areas.");
            // Console.WriteLine(CalculateAreas(figures));
            //
            // Console.WriteLine("Perimeters.");
            // Console.WriteLine(CalculatePerimeters(figures));
            
        }

        static string CalculateAreas(List<Figure> figures)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var figure in figures)
            {
                var str = $"{figure.GetTitle()}:{figure.Area:F1}";
                sb.AppendLine(str);
            }

            return sb.ToString();
        }
        
        static string CalculatePerimeters(List<Figure> figures)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var figure in figures)
            {
                var str = $"{figure.GetTitle()}:{figure.Perimeter:F1}";
                sb.AppendLine(str);
            }

            return sb.ToString();
        }
    }
    
    /*
     * public class A
        {
            protected string S { get; set; }
            public int I { get; set; }
        }

        public class B : A
        {
            public int K { get; set; }

            public void Temp()
            {
                S = "sdfsdf";
            }
        }
    
        public class C : B
        {
            public int G { get; set; }

        }
    
    
        public class D : C
        {
            public int LL { get; set; }

        }
     * 
    */
    