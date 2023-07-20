using ServiceStack;
using OptimizedDockerCompose.ServiceModel;

namespace OptimizedDockerCompose.ServiceInterface;

public class MyServices : Service
{
    public object Any(Hello request)
    {
        return new HelloResponse { Result = $"Hello, {request.Name}!" };
    }
}