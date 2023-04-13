using HW_8;

var cleansArray = new VacuumCleaner[]
{
    new DustBag("Samsung", 9),
    new Robot("Xiaomi", 22),
    new Washing("Kerher", 45),
};
int i = 0;
foreach (var vacuumCleaner in cleansArray)
{
    if (vacuumCleaner is Washing)
    {
        //Console.WriteLine("что угодно");
        ((Washing) vacuumCleaner).StartCleaning();
    }
    else
    {
        vacuumCleaner.StartCleaning();
    }
}