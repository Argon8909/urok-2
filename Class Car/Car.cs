namespace Class_Car;

public class Car
{
    public enum CarColor
    {
        Blue,
        Black,
        Red
    }

    private CarColor _color;
    private int _year;
    private double _mileage;
    private sbyte _fuel;
    private double _fuelСonsumption;

    public Car(int year, CarColor color, double mileage, sbyte fuel = 100)
    {
        _color = color;
        _year = year;
        _mileage = mileage;
        _fuel = fuel;
    }

    public sbyte FuelControl()
    {
        if (_fuelСonsumption > _mileage)
        {
            _fuel = (sbyte) (_fuelСonsumption - _mileage);
            if (_fuel <= 0)
            {
                _fuel = 0;
                Console.WriteLine("Топливо кончилось!");
            }
        }
        _fuelСonsumption = _mileage;
        return _fuel;
    }
    
    public void GoOneMile()
    {
        FuelControl();
        if (_fuel > 0)
        {
             _mileage += 1;
        }
       
    }

    public double GetMileage()
    {
        return _mileage;
    }

    public int GetCarYear()
    {
        return DateTime.Now.Year - _year;
    }

    public override string ToString()
    {
        return $"Color: {_color}, Year: {_year}, Mileage: {_mileage}";
    }
}