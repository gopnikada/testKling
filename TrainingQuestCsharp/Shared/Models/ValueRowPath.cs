namespace TrainingQuestCsharp.Shared.Models
{
    public class ValueRowPath
    {
        public ValueRowPath(double value, DateTime timestamp, string path)
        {
            Value = value;
            Timestamp = timestamp;
            Path = path;    

        }

        public double Value { get; }
        public DateTime Timestamp { get; }
        public string Path { get; set; }
    }
}
