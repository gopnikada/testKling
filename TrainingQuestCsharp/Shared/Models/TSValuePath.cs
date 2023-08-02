namespace TrainingQuestCsharp.Shared.Models
{
    public class TSValuePath
    {
        public TSValuePath(DateTime datetime, Dictionary<double, string> valuePath)
        {
            ValuePath = valuePath;
            DateTime = datetime;
        }

        public Dictionary<double, string> ValuePath { get; }
        public DateTime DateTime { get; set; }
    }
}
