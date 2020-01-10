using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<int> Get()
        {
            return new List<int> { 1, 2, 3 };
        }
    }
}
