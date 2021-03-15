namespace Routindo.Contract.Watchers
{
    public interface IWatcher : IArguedRuntimeComponent
    {
        WatcherResult Watch();
    }
}