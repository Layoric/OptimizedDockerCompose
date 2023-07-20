using Funq;
using ServiceStack;
using OptimizedDockerCompose.ServiceInterface;

[assembly: HostingStartup(typeof(OptimizedDockerCompose.AppHost))]

namespace OptimizedDockerCompose;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        });

    public AppHost() : base("OptimizedDockerCompose", typeof(MyServices).Assembly) {}

    public override void Configure(Container container)
    {
        // Configure ServiceStack only IOC, Config & Plugins
        SetConfig(new HostConfig {
            UseSameSiteCookies = true,
        });
        
                
        foreach(var envVar in Environment.GetEnvironmentVariables().Keys)
        {
            Log.Warn($"{envVar}={Environment.GetEnvironmentVariable(envVar.ToString())}");
        }

    }
}
