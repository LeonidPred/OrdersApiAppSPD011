using OrdersApiAppSPD011.Model;

namespace OrdersApiAppSPD011.Service
{
    public interface IDaoReceipt
    {
        Task<IResult> GetReceipt(Receipt Id);
    }
}
