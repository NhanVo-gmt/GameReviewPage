namespace OrderManagementSystem.Utility 
{
    public interface IRoleInventory 
    {
        Task CreateNewRoleAsync();
        Task AddRoleAsync(string UserId);
    }
}