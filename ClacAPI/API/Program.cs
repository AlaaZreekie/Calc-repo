
var builder = WebApplication.CreateBuilder(args);
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


app.MapPost("/eval", (HttpContext cx) =>
{
    var data = cx.Request.Form["expression"];

    // data = data.Replace("/eval", "");
    
    // int l = data.Length;
    // data = data.Substring(6,l - 5 );
    Console.WriteLine($"jfkdkfsdjfkffskfnskfnskd----------{data}");

    // cx.Response.Headers.Append("X-Alaa", data);
    var exp = new API.Expression(data);
    // var exp = firstP.Expression.Parse(data);
    double ans  = exp.Evaluate();
    Console.WriteLine(ans + "  is the final ans");
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
