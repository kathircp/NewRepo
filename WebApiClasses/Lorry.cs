namespace WebApiApp.WebApiClasses
{
    public class Lorry : IVehicle
    {
        public async Task<string> GetProductByIdAsync(int id)
        {
            return await Task.FromResult($"Lorry with ID {id} retrieved successfully.");
        }
    }
}
