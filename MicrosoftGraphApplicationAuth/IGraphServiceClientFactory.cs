using Microsoft.Graph;

namespace MicrosoftGraphApplicationAuth
{
    public interface IGraphServiceClientFactory
    {
        IGraphServiceClient Create(IGraphConfig graphConfig);
    }
}