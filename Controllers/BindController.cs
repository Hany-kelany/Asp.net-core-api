using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindController : ControllerBase
    {

        //[HttpGet("{id:int}")]
        [HttpGet("{id}/{Name}/{Salary}")]
        public IActionResult Get([FromRoute] Employee em)
        {
            return Ok($"Added... ");
        }


    }
}
