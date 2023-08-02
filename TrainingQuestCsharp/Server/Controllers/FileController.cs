using Microsoft.AspNetCore.Mvc;
using TrainingQuestCsharp.Server.Helpers;
using TrainingQuestCsharp.Server.Provider;
using TrainingQuestCsharp.Shared.Models;

namespace TrainingQuestCsharp.Server.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IDataReader dataReader;


        public FileController(IConfiguration configuration, IDataReader dataReader)
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
            var dict = new List<KeyValuePair<string, List<ValueRow>>>();
            var allRows = new List<ValueRowPath>();
            string? folderPath = configuration.GetSection("DataPath").Value;
            FilesInDir.TraverseDirectory(folderPath);
            var paths = FilesInDir.Paths;

            foreach (var path in paths)
            {
                int minIndex = path.IndexOf(folderPath);
                string usefulPath = path[minIndex..];

                var rawsFromFile = dataReader.ReadValues(path);

                //var kv = new KeyValuePair<string, List<ValueRow>>(usefulPath, rawsFromFile);
                //dict.Add(kv);
                foreach (var item in rawsFromFile)
                {
                    var vrp = new ValueRowPath(item.Value, item.Timestamp, usefulPath);
                    allRows.Add(vrp);
                }


            }
            var results = allRows.GroupBy(
     p => p.Timestamp,
     p => p.Path,
     
     (key, g) => new { Timestamp = key, Value = g.ToList() });


            return Ok("ok1");
        }
    }
}
