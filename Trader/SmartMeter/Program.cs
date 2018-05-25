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

        //static void ShowTrade(Trade trade)
        //{
        //    Console.WriteLine($"Timestamp: {trade.Id}");

        //    foreach (var tradeConsumer in trade.Consumers)
        //    {
        //        Console.WriteLine("ID: " + tradeConsumer.Id + ", Buy: " + tradeConsumer.Buy);
        //    }
        //}

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

            // Very random seed
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < allTrades.Length; i++)
            {
                Trade trade = new Trade
                {
                    Id = $"{timeStart}00-{timeEnd}00"
                };

                // Initiate values to 'zero'
                int prosumerId = -1;
                trade.TotalProduction = 0;
                trade.TotalConsumption = 0;
                trade.PowerSourceOrDestination = "";

                // 1-6 Company Prosumers
                int numberOfCompanyProducers = rnd.Next(1, 7);
                int numberOfCompanyConsumers = rnd.Next(1, 7);
                // Create number of Regular Prosumer (1-10 of each)
                int numberOfRegularProducers = rnd.Next(1, 11);
                int numberOfRegularConsumers = rnd.Next(1, 11);

                Producer[] regProducers = new Producer[numberOfRegularProducers];
                Consumer[] regConsumers = new Consumer[numberOfRegularConsumers];

                Producer[] companyProducers = new Producer[numberOfCompanyProducers];
                Consumer[] companyConsumers = new Consumer[numberOfCompanyConsumers];

                // Initiate all company producers
                for (int j = 0; j < numberOfCompanyProducers ; j++)
                {
                    var prod = new Producer
                    {
                        Id = (++prosumerId).ToString(),
                        Sell = rnd.Next(1, 501),
                        Type = "Company"
                        
                    };

                    companyProducers[j] = prod;
                    trade.TotalProduction += prod.Sell;
                }
                
                // Initiate all producers with Sell value of 1-15
                for (int j = 0; j < numberOfRegularProducers; j++)
                {
                    var prod = new Producer
                    {
                        Id = (++prosumerId).ToString(),
                        Sell = rnd.Next(1, 21),
                        Type = "Household"
                    };

                    regProducers[j] = prod;
                    trade.TotalProduction += prod.Sell;
                    
                }

                // Initiate all companyConsumers with Buy value of 1-15
                for (int j = 0; j < numberOfCompanyConsumers; j++)
                {
                    var con = new Consumer
                    {
                        Id = (++prosumerId).ToString(),
                        Buy = rnd.Next(1, 501),
                        Type = "Company"
                    };

                    companyConsumers[j] = con;
                    trade.TotalConsumption += con.Buy;

                    // Give 1-3 random producers to buy from
                    int numberToBuyFrom = rnd.Next(1, 4);

                    if (numberOfCompanyProducers < numberToBuyFrom)
                        numberToBuyFrom = numberOfCompanyProducers;

                    companyConsumers[j].BuyFrom = new Producer[numberToBuyFrom];

                    // Initiate "BuyFrom" with random producers
                    for (int m = 0; m < numberToBuyFrom; m++)
                    {
                        // Index 1 - numberOfProducers
                        int producerIndex = rnd.Next(0, numberOfCompanyProducers);

                        // Check first that it does not exist in the list before inserting
                        var producerToCheck = companyProducers[producerIndex];

                        bool isInList = false;

                        do
                        {
                            // Loop through list to check if in list
                            for (int k = 0; k < m; k++)
                            {
                                // If exist, do not insert
                                if (producerToCheck.Id == companyConsumers[j].BuyFrom[k].Id)
                                {
                                    // Generate new index of a producer and try insert again
                                    producerIndex = rnd.Next(0, numberOfCompanyProducers);
                                    producerToCheck = companyProducers[producerIndex];
                                    isInList = true;
                                    break;
                                }

                                isInList = false;

                            }

                            } while (isInList);

                            companyConsumers[j].BuyFrom[m] = companyProducers[producerIndex];
                    }
                }

                // Initiate all companyConsumers with Buy value of 1-20
                for (int j = 0; j < numberOfRegularConsumers; j++)
                {
                    var con = new Consumer
                    {
                        Id = (++prosumerId).ToString(),
                        Buy = rnd.Next(1, 21),
                        Type = "Household"
                    };

                    regConsumers[j] = con;
                    trade.TotalConsumption += con.Buy;

                    // Give 1-6 random producers to buy from
                    int numberToBuyFrom = rnd.Next(1, 6);

                    
                    if (numberOfRegularProducers < numberToBuyFrom)
                        numberToBuyFrom = numberOfRegularProducers;

                    regConsumers[j].BuyFrom = new Producer[numberToBuyFrom];

                    // Initiate "BuyFrom" with random producers
                    for (int m = 0; m < numberToBuyFrom; m++)
                    {
                        // Index 1 - numberOfProducers
                        int producerIndex = rnd.Next(0, numberOfRegularProducers);

                        // Check first that it does not exist in the list before inserting
                        var producerToCheck = regProducers[producerIndex];

                        bool isInList = false;

                        do
                        {
                            // Loop through list to check if in list
                            for (int k = 0; k < m; k++)
                            {
                                // If exist, do not insert
                                if (producerToCheck.Id == regConsumers[j].BuyFrom[k].Id)
                                {
                                    // Generate new index of a producer and try insert again
                                    producerIndex = rnd.Next(0, numberOfRegularProducers);
                                    producerToCheck = regProducers[producerIndex];
                                    isInList = true;
                                    break;
                                }

                                isInList = false;

                            }

                        } while (isInList);

                        regConsumers[j].BuyFrom[m] = regProducers[producerIndex];
                    }
                }

                // Initialize trade with prosumers
                trade.CompanyConsumers = companyConsumers;
                trade.CompanyProducers = companyProducers;
                trade.RegularConsumers = regConsumers;
                trade.RegularProducers = regProducers;

                // Excess power
                if (trade.TotalProduction > trade.TotalConsumption)
                {
                    trade.PowerSourceOrDestination = "To Local Heater";

                    if (trade.TotalProduction - trade.TotalConsumption > 400)
                    {
                        trade.PowerSourceOrDestination = "To National Smart Grid";
                    }
                }

                // Less power
                if (trade.TotalProduction < trade.TotalConsumption)
                {
                    trade.PowerSourceOrDestination = "From National Smart Grid";
                }


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
                while (true)
                {
                    Console.WriteLine("Press U to update the day");

                    if (Console.ReadLine() != "U")
                        Console.WriteLine("Not valid input. Press U to update.");
                    else
                    {
                        Console.WriteLine("Updating .. ");
                        var trades = GenerateTradesForOneDay();


                        foreach (var trade in trades)
                        {
                            await UpdateTradeAsync(trade);
                        }

                        Console.WriteLine("Done updating. Check database for new values");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}


