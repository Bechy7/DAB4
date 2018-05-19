using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Http;
using Trader.Models;

namespace Trader.Controllers
{
    public class TradesController : ApiController
    {
        Trade[] trades = 
        {
            new Trade
            {
                Consumers = new[]
                {
                    new Consumer
                    {
                        Buy = 10,
                        BuyFrom = new[]
                        {
                            new Producer
                            {
                                Id = "1",
                                Sell = 7
                            },
                            new Producer
                            {
                                Id = "2",
                                Sell = 10
                            }
                        },
                        Id = "3"
                    }
                }
            }
        };
        // GET: Trade
        public IEnumerable<Trade> GetAllProducts()
        {
            return trades;
        }
    }
}