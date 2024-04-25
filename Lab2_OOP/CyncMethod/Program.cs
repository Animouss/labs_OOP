using System;
using System.Diagnostics;
using System.Net.Http;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string[] urls = { "https://jsonplaceholder.typicode.com/posts/1", "https://jsonplaceholder.typicode.com/posts/2", "https://jsonplaceholder.typicode.com/posts/3" };

        HttpClient client = new HttpClient();
        foreach (string url in urls)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request to {url} failed with message: {e.Message}");
            }
        }

        stopwatch.Stop();
        Console.WriteLine($"Total  time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
