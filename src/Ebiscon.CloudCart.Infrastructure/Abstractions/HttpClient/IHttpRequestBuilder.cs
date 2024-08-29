namespace Ebiscon.CloudCart.Infrastructure.Abstractions.HttpClient
{
    public interface IHttpRequestBuilder
    {
        HttpRequestMessage Build();
    }
}
