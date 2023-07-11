using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebApp;

public static class FileSaver
{
    public static string SaveBookToFile(List<PhoneRecord> book)
    {
        try
        {
            var serialzedBook = JsonConvert.SerializeObject(book);
            File.WriteAllText(@"D:\test\user.json", serialzedBook);
            return "Ok";
        }
        catch (Exception e)
        {
            return "Ошибка: " + e.Message;
        }
    }

    public static List<PhoneRecord>? ReadBookFromFile()
    {
        var serialzedBook = File.ReadAllText(@"D:\test\user.json");
        List<PhoneRecord>? book = JsonConvert.DeserializeObject<List<PhoneRecord>>(serialzedBook);

        return book;

        //File.AppendAllText();
    }
}

/*
  
*/