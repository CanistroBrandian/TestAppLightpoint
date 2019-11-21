using TestAppLightpoint.DAL.Entities;
using TestAppLightpoint.DAL.Interface;

namespace TestAppLightpoint.DAL.Repository
{
    public class StoreRepository : CommonRepository<Store>
    {

        public StoreRepository(IUnitOfWork uow):base(uow)
        {           
        }
        
    }
}
