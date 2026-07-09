namespace WebApiApp.WebApiClasses
{
    public interface IVehicle
    {
        Task<string> GetProductByIdAsync(int id);
    }
}
