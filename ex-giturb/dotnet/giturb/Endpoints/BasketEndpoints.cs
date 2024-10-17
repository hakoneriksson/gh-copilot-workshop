using Microsoft.AspNetCore.Mvc;

public static class BasketEndpoints
{
    public static void MapBasketEndpoints(this WebApplication build)
    {
        build.MapGet("/baskets/", (IDataStore<BasketOfUrbs> repository) =>
        {
            return repository.ToList();
        })
        .Produces<BasketOfUrbs>(StatusCodes.Status200OK);

        build.MapPost("/baskets/", (IDataStore<BasketOfUrbs> repository) =>
        {
            return Results.BadRequest("Basket is not ready to be sent");
        })
        .Produces<BasketOfUrbs>(StatusCodes.Status201Created);


        build.MapPost("/baskets/{basketId}/urbs", (IDataStore<BasketOfUrbs> repository, IDataStore<Urb> urbRepository, int basketId, [FromQuery] int urbId) =>
        {
            return Results.BadRequest("Basket is not ready to be sent");
        })
        .Produces<BasketOfUrbs>(StatusCodes.Status201Created);


        build.MapPost("/baskets/{basketId}/send", (IDataStore<BasketOfUrbs> repository, int basketId) =>
        {
            return Results.BadRequest("Basket is not ready to be sent");
        })
        .Produces<Order>(StatusCodes.Status201Created);
    }
}
