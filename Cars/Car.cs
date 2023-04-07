using System;

namespace Cars
//namespace Class_Car;
{
    public class Car
    {
        public enum CarColor
        {
            Blue,
            Black,
            Red
        }

        private CarColor _color;
        private sbyte _fuel;
        private double _fuelСonsumption;
        private double _mileage;
        private int _year;

        public Car(int year, CarColor color, double mileage, sbyte fuel = 100)
        {
            _color = color;
            _year = year;
            _mileage = mileage;
            _fuel = fuel;
        }

        public sbyte Fuel
        {
            get => _fuel;
            private set
            {
                if (value < 0)
                {
                    _fuel = 0;
                }
                else if (value > 100)
                {
                    _fuel = 100;
                }
                else
                {
                    _fuel = value;
                }
            }
        }

        private void FuelControl()
        {
            if (_fuelСonsumption < _mileage)
            {
                Fuel = (sbyte) (_fuelСonsumption - _mileage);
                if (Fuel == 0)
                {
                    Console.WriteLine("Топливо кончилось!");
                }
            }

            _fuelСonsumption = _mileage;
        }

        public string FuelReplenishment(sbyte f)
        {
            Fuel += f;
            if (Fuel == 100)
            {
                return "Мамшина заправлена на 100%!";
            }

            return $"Запас топлива теперь {Fuel}%";
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


}