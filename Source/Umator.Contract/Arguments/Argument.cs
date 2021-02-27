namespace Umator.Contract
{
    public class Argument
    {
        public Argument(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public object Value { get; set; }
    }
}