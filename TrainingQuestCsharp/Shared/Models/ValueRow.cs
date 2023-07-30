namespace TrainingQuestCsharp.Shared.Models
{
    public class ValueRow
    {
        public ValueRow(double value, DateTime timestamp)
        {
            Value = value;
            Timestamp = timestamp;
        }

        public double Value { get; }
        public DateTime Timestamp { get; }
    }
}
