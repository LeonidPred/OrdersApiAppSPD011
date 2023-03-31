namespace OrdersApiAppSPD011.Service
{
    public interface IDaoInfo
    {
        Task<IResult> GetInfo(int id);
    }
}
