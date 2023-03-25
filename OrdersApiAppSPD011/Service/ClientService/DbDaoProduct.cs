using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.ClientService
{
    public class DbDaoProduct : IDaoMain<Product>
    {
        private readonly ApplicationDbContext daodb;

        public DbDaoProduct(ApplicationDbContext db)
        {
            this.daodb = db;
        }
        public async Task<Product> AddAsync(Product client)
        {
            await daodb.Products.AddAsync(client);
            await daodb.SaveChangesAsync();
            return client;
        }

        public async Task<IResult> DeleteAsync(Product id)
        {
            var client = await daodb.Products.FirstOrDefaultAsync(c => c.Id == id.Id);

            if (client == null)
            {
                return Results.NotFound(new { message = "Нет такого продукта" });
            }

            daodb.Products.Remove(client);
            await daodb.SaveChangesAsync();

            return Results.Ok(new { message = "Продукт удалён" });
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = await daodb.Products.ToListAsync();

            if (products.Count == 0)
            {   
                return null;
            }

            return products;
        }

        public async Task<IResult> GetAsync(Product id)
        {
            var product = await daodb.Products.FirstOrDefaultAsync(c => c.Id == id.Id);

            if (product == null)
            {
                return Results.NotFound(new { message = "Нет такого продукта" });
            }
            return Results.Ok(product);
        }

        public async Task<IResult> UpdateAsync(Product product)
        {
            daodb.Products.Entry(product).State = EntityState.Modified;
            await daodb.SaveChangesAsync();

            return Results.Ok(product);
        }
    }
}
