using MaxSync.DataProviders;

namespace MaxSync
{
    public class SyncHandler: ISyncHandler
    {
        private IAdvertiserDataProvider _advertiserDataProvider;
        public SyncHandler(IAdvertiserDataProvider someInterface)
        {
            _advertiserDataProvider = someInterface;
        }

        public void GetAdvertiserIndexData()
        {
            _advertiserDataProvider.GetAdvertisersIndexes();
        }
    }

    public interface ISyncHandler
    {
        void GetAdvertiserIndexData();
    }
}
