var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.



app.MapGet("/account", async () =>
{
    await Task.Delay(500);
    return new { PersonalInfo = new AccountInfo { FirstName = "Robert", LastName = "Smith", EmployeeId = "993", Email = "bob@cure.com" } };
});
app.MapGet("/order-history", async () =>
{

    await Task.Delay(3500);
    return new
    {
        Data = new List<OrderInfo>
    {
        new OrderInfo { Id="123", Date = DateTime.Now.AddDays(-200), Fulfilled = true },
        new OrderInfo { Id="898", Date = DateTime.Now.AddDays(-112), Fulfilled = true},
        new OrderInfo { Id="993", Date=DateTime.Now.AddDays(-2), Fulfilled = false},
    }
    };
});

app.Run();
public record AccountInfo
{
    public string EmployeeId { init; get; }
    public string FirstName { init; get; }
    public string LastName { init; get; }
    public string Email { init; get; }

}
public record OrderInfo
{
    public string Id { get; init; } 
    public DateTime Date { get; init; }
    public bool Fulfilled { get; init; }
}