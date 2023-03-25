using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service
{
    public class DaoReceipt : IDaoReceipt
    {
        private readonly ApplicationDbContext daodb;

        public DaoReceipt(ApplicationDbContext db)
        {
            this.daodb = db;
        }

        // Метод вывода суммы заказа
        public async Task<IResult> GetReceipt(Receipt ord)
        {
            var order = await daodb.Orders.FirstOrDefaultAsync(o => o.Id == ord.Id);

            if (order == null)
            {
                return Results.NotFound(new { message = "Такого заказа нет" });
            }

            // здесь получаем расшивки с информацией о продукте
            var orderProducts = daodb.OrderProducts
                .Where(op => op.OrderId == ord.Id)
                .Include(p => p.Product);

            // создание чека и добавление в него информации с расшивки
            var check = new Receipt()
            {
                Id = ord.Id,
                ProductName = new(),
                Count = new(),
                Price = new(),
                Sum = 0
            };
            foreach (var product in orderProducts)
            {
                check.ProductName.Add(product.Product.Name);
                check.Count.Add(product.Count);
                check.Price.Add(product.Product.Price);

                check.Sum += product.Count * product.Product.Price;
            }

            return Results.Ok(check);
        }
    }
}
