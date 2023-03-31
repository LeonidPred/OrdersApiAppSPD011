using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;
using OrdersApiAppSPD011.Service.ClientService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

//это crud для сущностей
builder.Services.AddTransient<IDaoMain<Client>, DbDaoClient>();
builder.Services.AddTransient<IDaoMain<Product>, DbDaoProduct>();
builder.Services.AddTransient<IDaoMain<Order>, DbDaoOrder>();
builder.Services.AddTransient<IDaoMain<OrderProduct>, DbDaoOrderProduct>();

//это чек
builder.Services.AddTransient<IDaoReceipt, DaoReceipt>();
//это информация о заказе
builder.Services.AddTransient<IDaoInfo, DaoInfo>();



var app = builder.Build();

app.MapGet("/", () => new {Message = "pong"});


//эндпоинты для работы с клиентом
app.MapGet("/client/all", async (IDaoMain<Client> daoClient) =>
{
    return await daoClient.GetAllAsync();
});

app.MapPost("/client/add", async (Client client, IDaoMain<Client> daoClient) =>
{
    return await daoClient.AddAsync(client);
});

app.MapPost("/client/delete", async (Client id, IDaoMain<Client> daoClient) =>
{
    return await daoClient.DeleteAsync(id);
});

app.MapPost("/client/get", async (Client id, IDaoMain<Client> daoClient) =>
{
    return await daoClient.GetAsync(id);
});

app.MapPost("/client/update", async (Client id, IDaoMain<Client> daoClient) =>
{
    return await daoClient.UpdateAsync(id);
});

//эндпоинты для работы с продуктом
app.MapGet("/product/all", async (IDaoMain<Product> daoProduct) =>
{
    return await daoProduct.GetAllAsync();
});

app.MapPost("/product/add", async (Product product, IDaoMain<Product> daoProduct) =>
{
    return await daoProduct.AddAsync(product);
});

app.MapPost("/product/delete", async (Product id, IDaoMain<Product> daoProduct) =>
{
    return await daoProduct.DeleteAsync(id);
});

app.MapPost("/product/get", async (Product id, IDaoMain<Product> daoProduct) =>
{
    return await daoProduct.GetAsync(id);
});

app.MapPost("/product/update", async (Product id, IDaoMain<Product> daoProduct) =>
{
    return await daoProduct.UpdateAsync(id);
});

//эндпоинты для работы с заказами
app.MapGet("/order/all", async (IDaoMain<Order> daoOrder) =>
{
    return await daoOrder.GetAllAsync();
});

app.MapPost("/order/add", async (Order order, IDaoMain<Order> daoOrder) =>
{
    return await daoOrder.AddAsync(order);
});

app.MapPost("/order/delete", async (Order order, IDaoMain<Order> daoOrder) =>
{
    return await daoOrder.DeleteAsync(order);
});

app.MapPost("/order/get", async (Order order, IDaoMain<Order> daoOrder) =>
{
    return await daoOrder.GetAsync(order);
});

app.MapPost("/order/update", async (Order order, IDaoMain<Order> daoOrder) =>
{
    return await daoOrder.UpdateAsync(order);
});

//эндпоинты для работы с расшивками
app.MapGet("/orderproduct/all", async (IDaoMain<OrderProduct> daoOP) =>
{
    return await daoOP.GetAllAsync();
});

app.MapPost("/orderproduct/add", async (OrderProduct op, IDaoMain<OrderProduct> daoOP) =>
{
    return await daoOP.AddAsync(op);
});

app.MapPost("/orderproduct/delete", async (OrderProduct op, IDaoMain<OrderProduct> daoOP) =>
{
    return await daoOP.DeleteAsync(op);
});

app.MapPost("/orderproduct/get", async (OrderProduct op, IDaoMain<OrderProduct> daoOP) =>
{
    return await daoOP.GetAsync(op);
});

app.MapPost("/orderproduct/update", async (OrderProduct op, IDaoMain<OrderProduct> daoOP) =>
{
    return await daoOP.UpdateAsync(op);
});

//эндпоинт для чека
app.MapGet("/receipt", async (IDaoReceipt dr, int id) =>
{
    return await dr.GetReceipt(id);
});

//эндпоинт информации о заказе
app.MapGet("/information", async ( IDaoInfo dao, int id) =>
{
    return await dao.GetInfo(id);
});

app.Run();
