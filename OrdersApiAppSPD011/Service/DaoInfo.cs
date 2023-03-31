using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;

namespace OrdersApiAppSPD011.Service
{
    public class DaoInfo : IDaoInfo
    {
        private readonly ApplicationDbContext db;

        public DaoInfo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IResult> GetInfo(int id)
        {
            var order = await db.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (order is null)
            {
                return Results.NotFound(new { message = "Такого заказа нет" });
            }

            // получаем расшивки с информацией о товаре
            var orderProducts = db.OrderProducts
                .Where(op => op.OrderId == id)
                .Include(p => p.Product);

            // формируем объект для ответа
            var info = new Info()
            {
                Id = id,
                Description = order.Description,
                ProductCount = new(),
                Count = 0
            };

            // заполняем данными о товаре и количестве
            foreach (var product in orderProducts)
            {
                info.ProductCount.Add(product.Product.Name, product.Count);
                info.Count += product.Count;
            }

            return Results.Ok(info);
        }
    }
}
