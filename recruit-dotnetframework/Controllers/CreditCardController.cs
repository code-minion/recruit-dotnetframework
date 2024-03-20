using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using recruit_dotnetframework.Models;

namespace recruit_dotnetframework.Controllers
{
    public class CreditCardController : ApiController
    {
        [HttpPost]
        [Route("api/creditcard/validate")]
        public HttpResponseMessage SaveCreditCard([FromBody] CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            

            return Request.CreateResponse(HttpStatusCode.OK, "Credit card is valid.");
        }
        
    }
}
