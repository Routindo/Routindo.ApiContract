namespace Umator.Contract
{
    public interface IArgumentsMapper : IRuntimeComponent
    {
        ArgumentCollection Map(ArgumentCollection arguments);
    }
}