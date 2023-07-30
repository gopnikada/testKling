using Microsoft.AspNetCore.Mvc;
using TrainingQuestCsharp.Server.Provider;

namespace TrainingQuestCsharp.Server.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IDataReader dataReader;

        public FileController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.dataReader = dataReader;
        }

        /// <summary>
        /// Diese Funktion könnte verwendet werden um alle Dateien aufzulisten.
        /// Kleiner Tipp ... der Pfad zu den Dateien ist in der Config hinterlegt.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<List<string>> GetAllFileNames()
        {
            var values = dataReader.ReadValues("E11\\P011DI02\\128.DBF");
            return Ok(values);
        }
    }
}
