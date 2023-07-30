using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TrainingQuestCsharp.Server.Provider;
using TrainingQuestCsharp.Shared.Models;

namespace TrainingQuestCsharp.Server.Controllers
{
    
    
        [Route("api/test1")]
        [ApiController]
    public class TestCont : ControllerBase
    {
        [HttpGet("test2")]
        public ActionResult<string> GetTest()
        {
            return Ok("test resp");
        }
    }
    
}
