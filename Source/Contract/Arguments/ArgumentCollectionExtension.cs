namespace Routindo.Contract.Arguments
{
    public static class ArgumentCollectionExtension
    {
        public static ArgumentCollection WithArgument(this ArgumentCollection argumentCollection, string key,
            object value)
        {
            argumentCollection.Add(key, value);
            return argumentCollection;
        }
    }
}
