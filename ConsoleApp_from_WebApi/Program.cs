using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var httpClient = new HttpClient();
        var baseAddress = "https://localhost:7281/api/PhoneBook";

        // Вызов метода GetAll() - HTTP GET
        var getAllResponse = await httpClient.GetAsync($"{baseAddress}/GetPhoneBook");
        var getAllResult = await getAllResponse.Content.ReadAsStringAsync();
        Console.WriteLine(getAllResult);

        // Вызов метода PostContact() - HTTP POST
        var postContent = new FormUrlEncodedContent(new[]
        {
            new Dictionary<string, string>("name", "John"),
            new Dictionary<string, string>("number", "1234567890")
        });
        var postResponse = await httpClient.PostAsync($"{baseAddress}/PostPhoneBook", postContent);
        var postResult = await postResponse.Content.ReadAsStringAsync();
        Console.WriteLine(postResult);

        // Вызов метода DeleteContact() - HTTP DELETE
        var deleteResponse = await httpClient.DeleteAsync($"{baseAddress}/DeletePhoneBook?name=John");
        var deleteResult = await deleteResponse.Content.ReadAsStringAsync();
        Console.WriteLine(deleteResult);

        // Вызов метода PatchContact() - HTTP PATCH
        var patchContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("name", "John"),
            new KeyValuePair<string, string>("mewName", "Jane")
        });
        var patchResponse = await httpClient.PatchAsync($"{baseAddress}/PatchPhoneBook", patchContent);
        var patchResult = await patchResponse.Content.ReadAsStringAsync();
        Console.WriteLine(patchResult);

        // Вызов метода PutContact() - HTTP PUT
        var putContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("name", "John"),
            new KeyValuePair<string, string>("mewName", "Jane"),
            new KeyValuePair<string, string>("newNumber", "9876543210"),
            new KeyValuePair<string, string>("newAdress", "123 Main St")
        });
        var putResponse = await httpClient.PutAsync($"{baseAddress}/PutPhoneBook", putContent);
        var putResult = await putResponse.Content.ReadAsStringAsync();
        Console.WriteLine(putResult);
    }
}

/*
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var httpClient = new HttpClient();
        var baseAddress = "https://localhost:7281/api/PhoneBoo";

        // Вызов метода GetAll() - HTTP GET
        var getAllResponse = await httpClient.GetAsync($"{baseAddress}/GetPhoneBook");
        var getAllResult = await getAllResponse.Content.ReadAsStringAsync();
        Console.WriteLine(getAllResult);

        // Вызов метода PostContact() - HTTP POST
        var postContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("name", "John"),
            new KeyValuePair<string, string>("number", "1234567890")
        });
        var postResponse = await httpClient.PostAsync($"{baseAddress}/PostPhoneBook", postContent);
        var postResult = await postResponse.Content.ReadAsStringAsync();
        Console.WriteLine(postResult);

        // Вызов метода DeleteContact() - HTTP DELETE
        var deleteResponse = await httpClient.DeleteAsync($"{baseAddress}/DeletePhoneBook?name=John");
        var deleteResult = await deleteResponse.Content.ReadAsStringAsync();
        Console.WriteLine(deleteResult);

        // Вызов метода PatchContact() - HTTP PATCH
        var patchContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("name", "John"),
            new KeyValuePair<string, string>("mewName", "Jane")
        });
        var patchResponse = await httpClient.PatchAsync($"{baseAddress}/PatchPhoneBook", patchContent);
        var patchResult = await patchResponse.Content.ReadAsStringAsync();
        Console.WriteLine(patchResult);

        // Вызов метода PutContact() - HTTP PUT
        var putContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("name", "John"),
            new KeyValuePair<string, string>("mewName", "Jane"),
            new KeyValuePair<string, string>("newNumber", "9876543210"),
            new KeyValuePair<string, string>("newAdress", "123 Main St")
        });
        var putResponse = await httpClient.PutAsync($"{baseAddress}/PutPhoneBook", putContent);
        var putResult = await putResponse.Content.ReadAsStringAsync();
        Console.WriteLine(putResult);
    }
}

*/