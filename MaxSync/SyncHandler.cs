namespace MaxSync
{
    public class SyncHandler
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

    public interface IAdvertiserDataProvider
    {
        void GetAdvertisersIndexes();
    }
}
