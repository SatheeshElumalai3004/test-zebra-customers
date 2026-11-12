var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// The Angular build is copied into wwwroot at deploy time, so one site serves both the page and the API.
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/customers", () => StripeData.GetAll());
app.MapGet("/api/health", () => Results.Ok(new { status = "ok" }));

app.Run();

public record StripeItem(Guid Id, int Number, string Name, string Detail, string Status);

public static class StripeData
{
    public static IReadOnlyList<StripeItem> GetAll() =>
    [
        new(Guid.Parse("11111111-1111-1111-1111-111111111111"), 4001, "A Patel", "Email", "Active"),
        new(Guid.Parse("22222222-2222-2222-2222-222222222222"), 4002, "B Jones", "Phone", "Active"),
        new(Guid.Parse("33333333-3333-3333-3333-333333333333"), 4003, "C Smith", "Post", "Inactive"),
    ];
}
