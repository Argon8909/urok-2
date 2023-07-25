namespace WebApp.Model;

public class People
{
    // Id SERIAL PRIMARY KEY,
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
}