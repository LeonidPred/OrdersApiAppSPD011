using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.ClientService
{
    // интерфейс DAO для работы с клиентом
    public interface IDaoMain<T> where T : class
    {
        // базовый CRUD
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T client);
        Task<IResult> UpdateAsync(T client);
        Task<IResult> DeleteAsync(T id);
        Task<IResult> GetAsync(T id);
    }
}
