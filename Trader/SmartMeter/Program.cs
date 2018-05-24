using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Trader;
using Trader.Controllers;
using Trader.Models;
using System.Net.Http.Formatting;

namespace SmartMeter
{
    // INSPIRATION
    // https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
    public class Program
    {
        //static async Task Main(string[] args)
        //{
        //static string url = "http://localhost:60490/api/Trades";

        static HttpClient client = new HttpClient();

        static void ShowTrade(Trade trade)
        {
            Console.WriteLine($"Timestamp: {trade.Id}");

            foreach (var tradeConsumer in trade.Consumers)
            {
                Console.WriteLine("ID: " + tradeConsumer.Id + ", Buy: " + tradeConsumer.Buy);
            }

        }

        static async Task<Uri> CreateTradeAsync(Trade trade)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Trades", trade);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Trade> GetTradeAsync(string id)
        {
            string path = client.BaseAddress.AbsoluteUri + "api/Trades/" + id;
            List<Trade> trades = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                trades = await response.Content.ReadAsAsync<List<Trade>>();
                //var response = await response.Content.ReadAsAsync<Trade>():
                //var hej = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(hej2[0]);
            }

            return trades[0];
        }

        static async Task<Trade> UpdateTradeAsync(Trade trade)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/Trades/{trade.Id}", trade);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            trade = await response.Content.ReadAsAsync<Trade>();
            return trade;
        }

        static async Task<HttpStatusCode> DeleteTradeAsync(string timestamp)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/Trades/{timestamp}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:60490/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                List<Trade> allTrades = new List<Trade>(45);

                int timeStart = 0;
                int timeEnd = timeStart + 1;
                int prosumerId = 0;

                Random rnd = new Random();
                for (int i = 0; i < allTrades.Capacity; i++)
                {
                    Trade trade = new Trade();

                    int numberOfProducers = rnd.Next(1, 21);
                    int numberOfConsumers = rnd.Next(1, 21);

                    Producer[] producers = new Producer[numberOfProducers];
                    Consumer[] consumers = new Consumer[numberOfConsumers];

                    for (int j = 0; j < numberOfProducers; j++)
                    {
                        producers[j].Id = prosumerId.ToString();
                        producers[j].Sell = rnd.Next(1, 15);
                    }

                    for (int j = 0; j < numberOfConsumers; j++)
                    {
                        consumers[j].Id = (++prosumerId).ToString();
                        consumers[j].Buy = rnd.Next(1, 15);

                        int numberToBuyFrom = rnd.Next(1, 5);

                        consumers[j].BuyFrom = new Producer[numberToBuyFrom];

                        for (int m = 0; m < numberToBuyFrom; m++)
                        {
                            consumers[j].BuyFrom[m].

                        }
                    }

                    trade.Id = $"{timeStart}:00-{timeEnd}:00";
                    trade.Consumers
                }
                // Create a new product
                Trade trade = new Trade
                {
                    Id = "1600-1615",
                    Consumers = new[]
                    {
                        new Consumer
                        {
                            Id = "1",
                            Buy = 10,
                            BuyFrom = new[]
                            {
                                new Producer
                                {
                                    Id = "2",
                                    Sell = 15
                                }
                            }
                        }
                    },
                    Producers = new[]
                    {
                        new Producer()
                        {
                            Id = "2",
                            Sell = 15
                        }
                    }
                };


                // Delete the product

                string id = "1600-1615";
                var t = await GetTradeAsync(id);
                Console.WriteLine(client.BaseAddress.AbsoluteUri);
                Console.WriteLine("Before update: ");
                ShowTrade(t);


                //var statusCode = await DeleteTradeAsync(id);
                //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode}");

                //var url = await CreateTradeAsync(trade);
                //Console.WriteLine($"Created at {url.AbsoluteUri}");

                //Get the product


                ////Console.WriteLine(client.BaseAddress.AbsoluteUri);
                ////var t = await GetTradeAsync(url.PathAndQuery);
                ////ShowTrade(trade);

                // Update the product

                Console.WriteLine("Consumers buy value..");
                t.Consumers[0].Buy = 2;
                await UpdateTradeAsync(t);

                //// Get the updated product
                //trade = await GetTradeAsync(url.PathAndQuery);
                //ShowTrade(trade);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}


