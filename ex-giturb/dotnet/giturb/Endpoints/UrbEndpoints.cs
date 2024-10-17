public static class UrbEndpoints
{
    public static void MapUrbEndpoints(this WebApplication build)
    {
        build.MapGet("/urbs", (IDataStore<Urb> urbRepository) =>
         {
             return urbRepository.ToList();
         })
         .Produces<List<Urb>>(StatusCodes.Status200OK);
    }
}
