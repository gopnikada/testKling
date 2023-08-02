using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet("all")]
        public ActionResult<List<string>> GetAllFileNames()
        {
            
            var unstructuredDataList = new List<ValueRowPath>();

            string? folderPath = configuration.GetSection("DataPath").Value;

            FilesInDir.FindFilesInDir(folderPath);

            var paths = FilesInDir.Paths;

            foreach (var path in paths)
            {
                int minIndex = path.IndexOf(folderPath);
                string usefulPath = path[minIndex..];

                var rowsFromFile = dataReader.ReadValues(path);

                foreach (var row in rowsFromFile)
                {
                    var dataWithPath = new ValueRowPath(row.Value, row.Timestamp, usefulPath);
                    unstructuredDataList.Add(dataWithPath);
                }

            }

            var groupedData = unstructuredDataList.GroupBy(
             p => p.Timestamp,
             p => new ValuePath(p.Value, p.Path),
             (key, g) => new { Timestamp = key, Value = g.ToList() }).Take(20);

            var typedData = groupedData.Select(x => new Dictionary<DateTime, List<ValuePath>> { { x.Timestamp, x.Value } }).ToList();

            typedData.ForEach(x => x.FirstOrDefault().Value.RemoveAll(y => y.Value == 0));

            return Ok(typedData);
        }
    }
}
