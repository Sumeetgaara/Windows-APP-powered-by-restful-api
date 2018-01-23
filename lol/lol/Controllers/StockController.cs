using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StockDataLayer;

namespace lol.Controllers
{
    public class StockController : ApiController
    {
        public HttpResponseMessage Get(string symbol = "noparam")
        {
            using (StockEntity stockEntity = new StockEntity())
            {
                //return stockEntity.Stocks.ToList();

                if (symbol.ToUpper() == "NOPARAM")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, stockEntity.Stocks.ToList());
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                    stockEntity.Stocks.Where(s => s.Symbol == symbol.ToUpper()).ToList());
                }

            }
        }
        public HttpResponseMessage Get(int id)
        {
            using (StockEntity stockEntity = new StockEntity())
            {
                var entity = stockEntity.Stocks.FirstOrDefault(s => s.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Stock with id " + id.ToString() + " not found");
                }
            }
        }
        
    }

}
