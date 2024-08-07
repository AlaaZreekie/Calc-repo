using API;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/hello", () =>
{
    Console.Write("dsfsf---------------------");
    return "hello, world";
    
});
app.MapGet("/hello {name}", (string name) =>
{
    return $"hello, {name}";
    
});


// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();
app.MapPost("/eval", (HttpContext cx) =>
{
    var data = cx.Request.Form["expression"];

    // data = data.Replace("/eval", "");
    
    // int l = data.Length;
    // data = data.Substring(6,l - 5 );
    Console.WriteLine($"jfkdkfsdjfkffskfnskfnskd{data}");

    // cx.Response.Headers.Append("X-Alaa", data);
    var exp = new API.Expression(data);
    // var exp = firstP.Expression.Parse(data);
    double ans  = exp.Evaluate();
    Console.WriteLine(ans);
    return $"is ans {ans}";
});
app.Use((cx, next) =>
{
    Console.WriteLine(cx.Request.Path);
    return next();
});

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
