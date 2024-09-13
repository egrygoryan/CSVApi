namespace CSVApi.Data.Repositories;

public class ManagerRepo(ManagerContext ctx) : IManagerRepo
{
    public async Task AddRangeAsync(IEnumerable<Manager> managers)
    {
        await ctx.AddRangeAsync(managers);
        await ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Manager manager)
    {
        ctx.Managers.Remove(manager);
        await ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<Manager>> GetAllAsync() =>
        await ctx.Managers.ToListAsync();

    public async Task<Manager?> GetAsync(int managerId) =>
        await ctx
            .Managers
            .FirstOrDefaultAsync(x => x.ManagerId == managerId); // find manager by it's id, not record id
}
