using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var httpClientHandler = new HttpClientHandler();
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;

        var httpClient = new HttpClient(httpClientHandler);
        var baseAddress = "http://localhost:5137/api/PhoneBook";

        // Вызов метода GetAll() - HTTP GET
        var getAllResponse = await httpClient.GetAsync($"{baseAddress}/GetAllPhoneBook");
        var getAllResult = await getAllResponse.Content.ReadAsStringAsync();
        Console.WriteLine("Get>>> " + getAllResult);


        // Вызов метода PostContact() - HTTP POST
        NameValueCollection queryStringPost = System.Web.HttpUtility.ParseQueryString(string.Empty);
        queryStringPost.Add("name", "John");
        queryStringPost.Add("number", "1234567890");
        queryStringPost.Add("adress", "Moskow");

        var postResponse = await httpClient.PostAsync($"{baseAddress}/PostPhoneBook?{queryStringPost}", null);
        var postResult = await postResponse.Content.ReadAsStringAsync();
        Console.WriteLine("Post>>> " + postResult);
        Console.WriteLine(postResponse.RequestMessage.RequestUri.AbsoluteUri);


        // Вызов метода PatchContact() - HTTP PATCH
        NameValueCollection queryStringPatch = System.Web.HttpUtility.ParseQueryString(string.Empty);
        queryStringPatch.Add("name", "John");
        queryStringPatch.Add("newName", "Jane");
        var patchResponse = await httpClient.PatchAsync($"{baseAddress}/PatchPhoneBook?{queryStringPatch}", null);
        var patchResult = await patchResponse.Content.ReadAsStringAsync();
        Console.WriteLine("Patch>>> " + patchResult);
        Console.WriteLine(patchResponse.RequestMessage.RequestUri.AbsoluteUri);


        // Вызов метода PutContact() - HTTP PUT
        NameValueCollection queryStringPut = System.Web.HttpUtility.ParseQueryString(string.Empty);
        queryStringPut.Add("name", "Jane");
        queryStringPut.Add("newName", "Mike");
        queryStringPut.Add("newNumber", "9876543210");
        queryStringPut.Add("newAdress", "123 Main St");

        var putResponse = await httpClient.PutAsync($"{baseAddress}/PutPhoneBook?{queryStringPut}", null);
        var putResult = await putResponse.Content.ReadAsStringAsync();
        Console.WriteLine("Put>>> " + putResult);
        Console.WriteLine(putResponse.RequestMessage.RequestUri.AbsoluteUri);


        // Вызов метода DeleteContact() - HTTP DELETE
        var deleteResponse = await httpClient.DeleteAsync($"{baseAddress}/DeletePhoneBook?name=Mike");
        var deleteResult = await deleteResponse.Content.ReadAsStringAsync();
        Console.WriteLine("Delete>>> " + deleteResult);
    }
}


/*


*/