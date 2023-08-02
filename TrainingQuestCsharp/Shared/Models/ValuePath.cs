namespace TrainingQuestCsharp.Shared.Models
{
    public class ValuePath
    {
        public ValuePath(double value, string path)
        {
            Value = value;
            Path = path;
        }

        public double Value { get; }
        public string Path{ get; }
    }
}
