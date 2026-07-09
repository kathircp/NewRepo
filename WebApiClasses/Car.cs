namespace WebApiApp.WebApiClasses
{
    public class Car : IVehicle
    {
        public async Task<string> GetProductByIdAsync(int id)
        {
            return await Task.FromResult($"Car with ID {id} retrieved successfully.");
        }

    }
}
