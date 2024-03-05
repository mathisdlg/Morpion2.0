var builder = WebApplication.CreateBuilder(args);

/* // Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); */

await using var app = builder.Build();

/* // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} */

app.UseHttpsRedirection();
app.UseWebSockets();

static async Task HandleWebSocket(HttpContext context)
{
    // TODO: extract session data

    // Upgrade request to WebSocket
    using var socket = await context.WebSockets.AcceptWebSocketAsync();

    // Used to keep the socket alive
    var completionSource = new TaskCompletionSource();

    // TODO: handle socket in background worker

    // Wait for the background task using the socket to finish before closing it.
    await completionSource.Task;
}

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/session" && context.WebSockets.IsWebSocketRequest)
    {
        await HandleWebSocket(context);
    }
    else
    {
        await next(context);
    }
});

app.UseDefaultFiles()
    .UseStaticFiles();

await app.RunAsync();
