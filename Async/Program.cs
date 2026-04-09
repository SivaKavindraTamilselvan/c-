using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ImageData
{
    public string? id { get; set; }
    public string? author { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public string? url { get; set; }
    public string? download_url { get; set; }
}
class Program
{
    static async Task<List<ImageData>> FetchData()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = "https://picsum.photos/v2/list?page=2&limit=10";

                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<List<ImageData>>(json);

                return data ?? new List<ImageData>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<ImageData>();
            }

        }
    }
    static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Start the Task");

            await Task.Delay(5000);
            Console.WriteLine("Waited for 5 seconds");

            var images = await FetchData();

            foreach (var image in images)
            {
                Console.WriteLine($"Author: {image.author}");
                Console.WriteLine($"URL: {image.download_url}");
                Console.WriteLine("");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }
}