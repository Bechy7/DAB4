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

        static Trade[] GenerateTradesForOneDay()
        {
            Trade[] allTrades = new Trade[24];

            int timeStart = 0;
            int timeEnd = timeStart + 1;
            int prosumerId = -1;

            // Very random seed
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < allTrades.Length; i++)
            {
                Trade trade = new Trade
                {
                    Id = $"{timeStart}:00-{timeEnd}:00"
                };

                // Create number of Prosumer (1-20 of each)
                int numberOfProducers = rnd.Next(1, 21);
                int numberOfConsumers = rnd.Next(1, 21);

                Producer[] producers = new Producer[numberOfProducers];
                Consumer[] consumers = new Consumer[numberOfConsumers];

                // Initiate all producers with Sell value of 1-15
                for (int j = 0; j < numberOfProducers; j++)
                {
                    var prod = new Producer
                    {
                        Id = (++prosumerId).ToString(),
                        Sell = rnd.Next(1, 16)
                    };

                    producers[j] = prod;
                }

                // Initiate all consumers with Buy value of 1-15
                for (int j = 0; j < numberOfConsumers; j++)
                {
                    var con = new Consumer
                    {
                        Id = (++prosumerId).ToString(),
                        Buy = rnd.Next(1, 16)
                    };

                    consumers[j] = con;

                    // Give 1-5 random producers to buy from
                    int numberToBuyFrom = rnd.Next(1, 6);

                    if (numberOfProducers < numberToBuyFrom)
                        numberToBuyFrom = numberOfProducers;

                    consumers[j].BuyFrom = new Producer[numberToBuyFrom];

                    // Initiate "BuyFrom" with random producers
                    for (int m = 0; m < numberToBuyFrom; m++)
                    {
                        // Index 1 - numberOfProducers
                        int producerIndex = rnd.Next(0, numberOfProducers);

                        // Check first that it does not exist in the list before inserting
                        var producerToCheck = producers[producerIndex];

                        bool isInList = false;

                        do
                        {
                            // Loop through list to check if in list
                            for (int k = 0; k < m; k++)
                            {
                                // If exist, do not insert
                                if (producerToCheck.Id == consumers[j].BuyFrom[k].Id)
                                {
                                    // Generate new index of a producer and try insert again
                                    producerIndex = rnd.Next(0, numberOfProducers);
                                    producerToCheck = producers[producerIndex];
                                    isInList = true;
                                    break;
                                }

                                isInList = false;

                            }

                        } while (isInList);

                       consumers[j].BuyFrom[m] = producers[producerIndex];
                    }
                }

                // Reset prosumer ID
                prosumerId = -1;

                // Initialize trade with prosumers
                trade.Consumers = consumers;
                trade.Producers = producers;

                allTrades[i] = trade;

                // Increment timestamp
                timeStart++;
                timeEnd++;
            }

            return allTrades;
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

                // Create a new product
                //Trade trade = new Trade
                //{
                //    Id = "1600-1615",
                //    Consumers = new[]
                //    {
                //        new Consumer
                //        {
                //            Id = "1",
                //            Buy = 10,
                //            BuyFrom = new[]
                //            {
                //                new Producer
                //                {
                //                    Id = "2",
                //                    Sell = 15
                //                }
                //            }
                //        }
                //    },
                //    Producers = new[]
                //    {
                //        new Producer()
                //        {
                //            Id = "2",
                //            Sell = 15
                //        }
                //    }
                //};


                // Delete the product

                //string id = "1600-1615";
                //var t = await GetTradeAsync(id);
                //Console.WriteLine(client.BaseAddress.AbsoluteUri);
                //Console.WriteLine("Before update: ");
                //ShowTrade(t);


                //var statusCode = await DeleteTradeAsync(id);
                //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode}");
                var trades = GenerateTradesForOneDay();

                foreach (var t in trades)
                {
                    var url = await CreateTradeAsync(t);
                    //Console.WriteLine($"Created at {url.AbsoluteUri}");
                }

                Console.WriteLine("Done");

                //Get the product


                ////Console.WriteLine(client.BaseAddress.AbsoluteUri);
                ////var t = await GetTradeAsync(url.PathAndQuery);
                ////ShowTrade(trade);

                // Update the product

                //Console.WriteLine("Consumers buy value..");
                //t.Consumers[0].Buy = 2;
                //await UpdateTradeAsync(t);

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


