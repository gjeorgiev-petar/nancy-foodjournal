namespace Nancy.FoodJournal.Core
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider
        {
            get
            {
                return new ServiceRootPathProvider();
            }
        }
    }
}
