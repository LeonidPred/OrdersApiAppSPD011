using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.ClientService
{
    public class PlugDaoClient : IDaoMain<Client>
    {
        private static List<Client> plugClients = new List<Client>();
        private static int currentId = 1;

        public Task<Client> AddAsync(Client client)
        {
            client.Id = currentId++;
            plugClients.Add(client);
            return Task.Run(() => client);
        }

        public Task<List<Client>> GetAllAsync()
        {
            return Task.Run(() => plugClients);
        }

        // Not Implemented methods
        public Task<IResult> DeleteAsync(Client id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetAsync(Client id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
