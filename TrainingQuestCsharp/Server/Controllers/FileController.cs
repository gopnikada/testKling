using Microsoft.AspNetCore.Mvc;

namespace TrainingQuestCsharp.Server.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public FileController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Diese Funktion könnte verwendet werden um alle Dateien aufzulisten.
        /// Kleiner Tipp ... der Pfad zu den Dateien ist in der Config hinterlegt.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<List<string>> GetAllFileNames()
        {
            return BadRequest("Funktion nicht implementiert");
        }
    }
}
