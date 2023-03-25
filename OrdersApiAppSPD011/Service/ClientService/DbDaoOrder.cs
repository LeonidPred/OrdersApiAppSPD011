using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.ClientService
{
    public class DbDaoOrder : IDaoMain<Order>
    {
        private readonly ApplicationDbContext daodb;

        public DbDaoOrder(ApplicationDbContext db)
        {
            this.daodb = db;
        }
        public async Task<Order> AddAsync(Order order)
        {
            await daodb.Orders.AddAsync(order);
            await daodb.SaveChangesAsync();
            return order;
        }

        public async Task<IResult> DeleteAsync(Order id)
        {
            var order = await daodb.Orders.FirstOrDefaultAsync(c => c.Id == id.Id);

            if (order == null)
            {
                return Results.NotFound(new { message = "Нет такого заказа" });
            }

            daodb.Orders.Remove(order);
            await daodb.SaveChangesAsync();

            return Results.Ok(new { message = "Заказ удалён" });
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var orders = await daodb.Orders.ToListAsync();

            if (orders.Count == 0)
            {
                return null;
            }

            return orders;
        }

        public async Task<IResult> GetAsync(Order id)
        {
            var order = await daodb.Orders.FirstOrDefaultAsync(c => c.Id == id.Id);

            if (order == null)
            {
                return Results.NotFound(new { message = "Нет такого заказа" });
            }
            return Results.Ok(order);
        }

        public async Task<IResult> UpdateAsync(Order order)
        {
            daodb.Orders.Entry(order).State = EntityState.Modified;
            await daodb.SaveChangesAsync();

            return Results.Ok(order);
        }
    }
}
