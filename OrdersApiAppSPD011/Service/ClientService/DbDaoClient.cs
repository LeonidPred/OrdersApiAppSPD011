using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.ClientService
{
    public class DbDaoClient : IDaoMain<Client>
    {
        private readonly ApplicationDbContext daodb;

        public DbDaoClient(ApplicationDbContext db)
        {
            this.daodb = db;
        }

        public async Task<Client> AddAsync(Client client)
        {
            await daodb.Clients.AddAsync(client);
            await daodb.SaveChangesAsync();
            return client;
        }

        public async Task<IResult> DeleteAsync(Client id)
        {
            var client = await daodb.Clients.FirstOrDefaultAsync(c => c.Id == id.Id);

            if (client == null)
            {
                return Results.NotFound(new { message = "Нет такого клиента" });
            }

            daodb.Clients.Remove(client);
            await daodb.SaveChangesAsync();

            return Results.Ok(new { message = "Клиент удалён" });
        }

        public async Task<List<Client>> GetAllAsync()
        {
            var clients = await daodb.Clients.ToListAsync();

            if (clients.Count == 0)
            {
                return null;
            }

            return clients;
        }

        public async Task<IResult> GetAsync(Client id)
        {
            var client = await daodb.Clients.FirstOrDefaultAsync(c => c.Id == id.Id);

            if (client == null)
            {
                return Results.NotFound(new { message = "Нет такого клиента" });
            }
            return Results.Ok(client);
        }

        public async Task<IResult> UpdateAsync(Client client)
        {
            daodb.Clients.Entry(client).State = EntityState.Modified;
            await daodb.SaveChangesAsync();

            return Results.Ok(client);
        }
    }
}
