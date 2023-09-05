using Snap.Geetest.Transit.Client.Damagou;
using Snap.Geetest.Transit.Option;

namespace Snap.Geetest.Transit;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services
            .AddHttpClient()
            .AddSingleton(builder.Configuration.Get<AppOptions>()!)
            .AddTransient<DamagouClient>();

        WebApplication app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}