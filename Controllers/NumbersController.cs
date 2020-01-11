using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BluestoneApi.Models;
using BluestoneApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BluestoneApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumbersController : ControllerBase
    {

        INumbersService _numbersService;

        public NumbersController(INumbersService numbersService)
        {
            _numbersService = numbersService;
        }

        [HttpPost]
        public ActionResult<List<int>> Post([FromBody] NumbersRequest numbersRequest)
        {
            try
            {

                List<int> result = _numbersService.ExtractNumbers(numbersRequest.numbers);

                if (numbersRequest.isSort)
                {
                    result = _numbersService.SortNumbers(result);
                }

                if (numbersRequest.isFilter)
                {
                    result = _numbersService.FilterNumbers(result);
                }

                return Ok(result);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public ContentResult Get()
        {

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<html><style>html {margin-top:100px; text-align: center;}</style><body>" +
                "<h2>Please use the following link to test Bluestone API <h2>" +
                "<a href = https://" + Request.Host.Value + "/swagger/index.html> Bluestone API </a>" +
                "</body></html>"
            };
        }
    }
}


