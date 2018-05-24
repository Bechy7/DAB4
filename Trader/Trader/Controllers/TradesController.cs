using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Trader.Models;

namespace Trader.Controllers
{
    public class TradesController : ApiController
    {
        // GET: Trade
        public async Task<IEnumerable<Trade>> GetTrades()
        {
            //return trades;
            return await DocumentDBRepository<Trade>.Get(p => true);
        }

        [ResponseType(typeof(Trade))]
        public async Task<IHttpActionResult> GetTrade(string id)
        {
            var trade = await DocumentDBRepository<Trade>.Get(p => p.Id == id);

            if (!trade.Any())
                return NotFound();

            return Ok(trade);
        }

        [ResponseType(typeof(Trade))]
        public async Task<IHttpActionResult> PutTrade(Trade person)
        {
            return await DocumentDBRepository<Trade>.Put(person);
        }

        [ResponseType(typeof(Trade))]
        public async Task<IHttpActionResult> PostTrade(Trade person)
        {
            return await DocumentDBRepository<Trade>.Post(person);
        }

        public async Task<IHttpActionResult> DeleteTrade(string id)
        {
            return await DocumentDBRepository<Trade>.Delete(id);
        }

    }
}