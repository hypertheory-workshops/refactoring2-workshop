var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.



// http://api.hypertheory.com/my/account
app.MapGet("/", async () =>
{
    await Task.Delay(500);
    return new { PersonalInfo = new AccountInfo { FirstName = "Bob", LastName = "Jones", EmployeeId = "993", Email = "bib@aol.com" } };
});




app.Run();
public record AccountInfo
{
    public string EmployeeId { init; get; }
    public string FirstName { init; get; }
    public string LastName { init; get; }
    public string Email { init; get; }

}
