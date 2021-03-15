namespace Routindo.Contract.Arguments
{
    public interface IArgumentsMapper : IRuntimeComponent
    {
        ArgumentCollection Map(ArgumentCollection arguments);
    }
}