namespace CSVApi.Endpoints;

public class ManagersEndpoint
{
    public async static Task<IResult> GetAll(
    [FromServices] IManagerService managerService)
    {
        var result = await managerService.GetAllAsync();

        return Results.Ok(result);
    }

    public async static Task<IResult> Delete(
    [FromRoute] int id,
    [FromServices] IManagerService managerService)
    {
        await managerService.DeleteAsync(id);

        return Results.Ok(new { Message = "Manager deleted succesfully" });
    }

    public async static Task<IResult> Upload(
    [FromForm] IFormFileCollection file,
    [FromServices] IManagerService managerService)
    {
        await managerService.UploadAsync(file);

        return Results.Ok(new { Message = "Manager's uploaded succesfully" });
    }
}
