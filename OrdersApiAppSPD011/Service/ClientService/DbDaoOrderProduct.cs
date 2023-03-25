using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.ClientService
{
    public class DbDaoOrderProduct : IDaoMain<OrderProduct>
    {
        private readonly ApplicationDbContext daodb;

        public DbDaoOrderProduct(ApplicationDbContext db)
        {
            this.daodb = db;
        }
        public async Task<OrderProduct> AddAsync(OrderProduct orderproduct)
        {
            await daodb.OrderProducts.AddAsync(orderproduct);
            await daodb.SaveChangesAsync();
            return orderproduct;
        }

        public async Task<IResult> DeleteAsync(OrderProduct id)
        {
            var orderproduct = await daodb.OrderProducts.FirstOrDefaultAsync(c => c.Id == id.Id);

            if (orderproduct == null)
            {
                return Results.NotFound(new { message = "Нет такой расшивки" });
            }

            daodb.OrderProducts.Remove(orderproduct);
            await daodb.SaveChangesAsync();

            return Results.Ok(new { message = "Расшивка удалена" });
        }

        public async Task<List<OrderProduct>> GetAllAsync()
        {
            var op = await daodb.OrderProducts.ToListAsync();

            if (op.Count == 0)
            {
                return null;
            }

            return op;
        }

        public async Task<IResult> GetAsync(OrderProduct id)
        {
            var op = await daodb.OrderProducts.FirstOrDefaultAsync(c => c.Id == id.Id);

            if (op == null)
            {
                return Results.NotFound(new { message = "Нет такой расшивки" });
            }
            return Results.Ok(op);
        }

        public async Task<IResult> UpdateAsync(OrderProduct op)
        {
            daodb.OrderProducts.Entry(op).State = EntityState.Modified;
            await daodb.SaveChangesAsync();

            return Results.Ok(op);
        }
    }
}
