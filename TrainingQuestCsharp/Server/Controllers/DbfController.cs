using Microsoft.AspNetCore.Mvc;
using TrainingQuestCsharp.Server.Provider;
using TrainingQuestCsharp.Shared.Models;

namespace TrainingQuestCsharp.Server.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DbfController : ControllerBase
    {
        private readonly ILogger<DbfController> logger;
        private readonly IDataReader dataReader;

        public DbfController(ILogger<DbfController> logger, IDataReader dataReader)
        {
            this.logger = logger;
            this.dataReader = dataReader;
        }


        /// <summary>
        /// Diese Funktion implementiert das Lesen der Daten aus einer Datei (unvollständig)
        /// </summary>
        /// <returns></returns>
        [HttpGet("file")]
        public ActionResult<List<ValueRow>> GetDataOfFile()
        {
            this.logger.LogCritical("Funktion unvollständig");
            var values = dataReader.ReadValues("E01\\E600DI01\\128.DBF");
            return Ok(values);
        }
    }
}
