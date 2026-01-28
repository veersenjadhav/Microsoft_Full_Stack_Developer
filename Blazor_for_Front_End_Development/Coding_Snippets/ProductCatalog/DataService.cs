using System.Collections.Generic;
using System.Threading.Tasks;

public class DataService
{
    public async Task<List<string>> GetProductsAsync()
    {
        await Task.Delay(1000); // Simulates delay from API call
        return new List<string> { "Product 1", "Product 2", "Product 3" };
    }
}