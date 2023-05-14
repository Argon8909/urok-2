namespace HomeworkGenerics;

public class RailGun
{
    private int _heat;

    public int Shot<T>() where T : RailGunBullet, new()
    {
        T bullet = new T();
        int damage = bullet.Damage;
        _heat += bullet.Heating;
        
        Console.WriteLine($"bullet тип: {typeof(T)}");
        Print.PrintInfo("Heating", bullet.Heating);
        Print.PrintInfo("_heat", _heat);
        
        if (_heat >= 100)
        {
            _heat = 0;
            throw new OverheatException("----------------Railgun overheated!-----------------");
        }

        return damage;
    }
}