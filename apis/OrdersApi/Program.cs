var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/", async () =>
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


public record OrderInfo
{
    public string Id { get; set; }
    public DateTime Date { get; set; }
    public bool Fulfilled { get; set; }
}
