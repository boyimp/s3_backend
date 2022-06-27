// In the name of Allah

namespace Application.Endpoints;
public abstract class Endpoint
{
    protected readonly WebApplication Application;//field
    protected Endpoint(WebApplication application) => Application = application;//constructor

    public abstract void EndpointDefinition();//func
}//class