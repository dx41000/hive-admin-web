using hive_admin_web.Models;

namespace hive_admin_web.Services.Interfaces;

public interface IStoreService
{ 
    Task<IList<Store>> GetStoresAsync(string apiVersion = null);
}