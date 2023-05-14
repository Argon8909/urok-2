using System;

namespace HomeworkGenerics
{
    public class Program
    {
        static void Main()
        {
            RailGun railGun = new RailGun();
            TestRifle<Plasma>(railGun);
            TestRifle<Neon>(railGun);
            TestRifle<Pin>(railGun);
        }

        public static void TestRifle<T>(RailGun railGun) where T : RailGunBullet, new()
        {
            int shotCount = 0;
            int totalDamage = 0;
            try
            {
                while (true)
                {
                    int damage = railGun.Shot<T>();
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