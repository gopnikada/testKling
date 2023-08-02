namespace TrainingQuestCsharp.Shared.Models
{
    public class ResponseType
    {
        public ResponseType(double value, DateTime timestamp)
        {
            Value = value;
            Timestamp = timestamp;
        }


        public double Value { get; }
        public DateTime Timestamp { get; }
    }
}
