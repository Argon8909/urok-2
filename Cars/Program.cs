using System;
using Cars;



    Car car = new Car(2010, Car.CarColor.Black, 10000);


    Console.WriteLine(car.GetCarYear());
    Console.WriteLine(car.GetMileage());

    Console.WriteLine($"1. {car}");
    Console.WriteLine($"В баке {car.Fuel}% топлива");
    //
    do
    {
        car.GoOneMile();
        Console.WriteLine($"Еду...");
    } while (car.Fuel > 10);
    Console.WriteLine($"В баке {car.Fuel}% топлива");
    Console.WriteLine($"Заправьте автомобиль!");
    car.FuelReplenishment(Console.ReadLine());

    Console.WriteLine(car.GetMileage());

    Console.WriteLine(car.GetCarYear());

    Console.WriteLine($"2. {car}");




//namespace Cars;