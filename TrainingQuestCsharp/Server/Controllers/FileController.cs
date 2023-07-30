using Microsoft.AspNetCore.Mvc;
using TrainingQuestCsharp.Server.Helpers;

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
            string? folderPath = configuration.GetSection("DataPath").Value;
            FilesInDir.TraverseDirectory(folderPath);
            var paths = FilesInDir.Paths;

            //foreach (var item in collection)
            //{

            //}
            return Ok("ok1");
        }
    }
}
