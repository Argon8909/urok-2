using System;

namespace HomeworkGenerics
{
    public class Program
    {
        static void Main()
        {
            RailGun RailGun = new RailGun();
            TestRifle<Plasma>(RailGun);
            TestRifle<Neon>(RailGun);
            TestRifle<Pin>(RailGun);
        }

        public static void TestRifle<T>(RailGun railgun) where T : RailGunBullet, new()
        {
            int shotCount = 0;
            int totalDamage = 0;
            try
            {
                while (true)
                {
                    int damage = railgun.Shot<T>();
                    shotCount++;
                    totalDamage += damage;
                    Print.PrintInfo("totalDamage", totalDamage);
                }
            }
            catch (OverheatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Total damage: {totalDamage}");
                Console.WriteLine($"Shot count: {shotCount}");
            }
        }
    }
}