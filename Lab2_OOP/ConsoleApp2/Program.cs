using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {

        using var httpClient = new HttpClient();


        string[] urls = { "https://jsonplaceholder.typicode.com/posts/1", "https://jsonplaceholder.typicode.com/posts/2", "https://jsonplaceholder.typicode.com/posts/3" };

      
        TimeSpan totalTime = TimeSpan.Zero;

        
        foreach (var url in urls)
        {
            try
            {
                
                var stopwatch = Stopwatch.StartNew();
               
                var response = await httpClient.GetAsync(url);               
                stopwatch.Stop();
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                
                Console.WriteLine($"Response from {url}: {responseBody}");
                totalTime += stopwatch.Elapsed;
            }
            catch (HttpRequestException ex)
            {
                
                Console.WriteLine($"Error  data from {url}: {ex.Message}");
            }
        }
        Console.WriteLine($"Total  time: {totalTime}");
    }
}
