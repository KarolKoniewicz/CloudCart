using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Ebiscon.CloudCart.Domain.Extensions;
using Ebiscon.CloudCart.Application.HttpClient.Models;

namespace Ebiscon.CloudCart.Application.HttpClient;

public abstract class BaseHttpClient<TConfiguration>
    where TConfiguration : class
{
    protected ILogger<BaseHttpClient<TConfiguration>> logger;
    protected System.Net.Http.HttpClient HttpClient { get; }
    protected string ConfigurationFileName { get; }
    protected TConfiguration Configuration { get; }
    protected Func<IHttpRequestBuilder> Builder { get; set; }

    protected BaseHttpClient(
        System.Net.Http.HttpClient httpClient,
        TConfiguration configuration,
        ILogger<BaseHttpClient<TConfiguration>> logger)
    {
        this.logger = logger;
        HttpClient = httpClient;
        ConfigurationFileName = $"{configuration.GetType().Name}.json";
        Configuration = GetConfiguration();
    }

    protected BaseHttpClient(
       System.Net.Http.HttpClient httpClient,
       string configurationFileName,
       ILogger<BaseHttpClient<TConfiguration>> logger)
    {
        this.logger = logger;
        HttpClient = httpClient;
        ConfigurationFileName = configurationFileName;
        Configuration = GetConfiguration();
    }

    public async Task<TResponse> Send<TRequest, TResponse>(
        Func<HttpRequestBuilder<TRequest>, HttpRequestMessage> operation)
        where TRequest : class
        where TResponse : class
    {
        try
        {
            var requestBuilder = Builder?.Invoke() as HttpRequestBuilder<TRequest>;

            var request = operation(requestBuilder ?? new HttpRequestBuilder<TRequest>());

            var response = await HttpClient.SendAsync(request);
            return await ParseResponse<TResponse>(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "basehhtpclient failed with exception");
            throw;
        }
    }

    public async Task<ApiResponse<TResponse>> SendApiResponse<TRequest, TResponse>(
       Func<HttpRequestBuilder<TRequest>, HttpRequestMessage> operation)
       where TRequest : class
       where TResponse : class
    {
        try
        {
            var requestBuilder = Builder?.Invoke() as HttpRequestBuilder<TRequest>;

            var request = operation(requestBuilder ?? new HttpRequestBuilder<TRequest>());
            var response = await HttpClient.SendAsync(request);

            return new ApiResponse<TResponse>
            {
                StatusCode = (int)response.StatusCode,
                Data = await ParseResponse<TResponse>(response)
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "basehhtpclient failed with exception");
            throw;
        }
    }

    private async Task<TResponse> ParseResponse<TResponse>(HttpResponseMessage response)
       where TResponse : class
    {
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return !content.IsNullOrEmpty() ? JsonConvert.DeserializeObject<TResponse>(content) : default;
        }
        throw new HttpRequestException($"Request failed with status code {response.StatusCode} and Reason Phrase {await response.Content.ReadAsStringAsync()}.");
    }

    private TConfiguration GetConfiguration()
    {
        try
        {
            var currentDirectory = Directory.EnumerateFiles(
                Directory.GetCurrentDirectory(),
                ConfigurationFileName,
                SearchOption.AllDirectories);

            using StreamReader stream = new(currentDirectory.FirstOrDefault());
            string json = stream.ReadToEnd();

            return JsonConvert.DeserializeObject<TConfiguration>(json);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "basehhtpclient failed with exception");
            throw;
        }
    }
}
