using System.Text;

using var client = new HttpClient();
HttpResponseMessage? response = null;
string url = "https://jsonplaceholder.typicode.com/posts/1";
string verb = "";

var requestBody = new StringContent(
    """{"id":100,"name":"Jane Doe"}""",
    Encoding.UTF8,
    "application/json"
);

Console.Write("Enter choice (A = GET, B = POST, C = PUT, D = DELETE): ");
string choice = Console.ReadLine()?.Trim().ToUpper() ?? "";

if (choice == "A")
{
    verb = "GET";
    response = await client.GetAsync(url);
}
else if (choice == "B")
{
    verb = "POST";
    response = await client.PostAsync(url, requestBody);
}
else if (choice == "C")
{
    verb = "PUT";
    response = await client.PutAsync(url, requestBody);
}
else if (choice == "D")
{
    verb = "DELETE";
    response = await client.DeleteAsync(url);
}

if (response != null)
{
    string body = await response.Content.ReadAsStringAsync();

    Console.WriteLine($"\nVerb: {verb}");
    Console.WriteLine($"URL: {url}");
    Console.WriteLine($"Response:\n{body}");
}
else
{
    Console.WriteLine("Invalid selection.");
}