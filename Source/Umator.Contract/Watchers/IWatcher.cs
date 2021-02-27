namespace Umator.Contract
{
    public interface IWatcher : IArguedRuntimeComponent
    {
        WatcherResult Watch();
    }
}