using System.Data;
using System.Globalization;
using TrainingQuestCsharp.Shared.Models;

namespace TrainingQuestCsharp.Server.Provider
{
    public interface IDataReader
    {
        public List<ValueRow> ReadValues(string filePath);
        public string DataPath { get; }
    }

    public class DataReader : IDataReader
    {
        public const string ColumnAttType = "ATT_TYPE";
        public const string ColumnValInt = "VALINT";
        public const string ColumnValReal = "VALREAL";
        public const string ColumnValBool = "VALBOOL";
        public const string ColumnDate = "DATE_NDX";
        public const string ColumnTime = "TIME_NDX";

        private readonly ILogger<DataReader> logger;

        public string DataPath { get; private set; }

        public DataReader(ILogger<DataReader> logger, IConfiguration applicationConfig)
        {
            this.logger = logger;

            if (applicationConfig["DataPath"] is not null)
            {
                DataPath = applicationConfig["DataPath"]!;
                logger.LogInformation("Initialisierung abgeschlossen mit Pfad: {path}", DataPath);
            }
            else
            {
                logger.LogError("'DataPath' wurde nicht konfiguriert");
                throw new ArgumentNullException();
            }
        }

        public List<ValueRow> ReadValues(string filePath)
        {
            var valueRows = new List<ValueRow>();

            using (DbfDataReader.DbfDataReader dataAdapter = new DbfDataReader.DbfDataReader(Path.Combine(DataPath, filePath)))
            {
                while (dataAdapter.Read())
                    valueRows.Add(GetValueRow(dataAdapter));
            }
            return valueRows;
        }

        private ValueRow GetValueRow(DbfDataReader.DbfDataReader dataRow)
        {
            var attType = (int)dataRow.GetInt32(ColumnAttType);
            double value = 0;

            switch (attType)
            {
                case 1:
                    value = (double)dataRow.GetDouble(ColumnValInt);
                    break;
                case 2:
                    value = (double)dataRow.GetDecimal(ColumnValReal);
                    break;
                case 3:
                    value = (double)dataRow.GetInt32(ColumnValBool);
                    break;
            }

            var date = ((double)dataRow.GetInt32(ColumnDate)).ToString();
            string timestring = $"0000{dataRow.GetValue(ColumnTime)}";
            var time = timestring.Substring(timestring.Length - 4);
            DateTime timestamp = DateTime.ParseExact($"{date}{time}", "yyyMMddHHmm", CultureInfo.InvariantCulture);
            timestamp = timestamp.AddYears(1900);
            return new ValueRow(value, timestamp);
        }
    }
}
