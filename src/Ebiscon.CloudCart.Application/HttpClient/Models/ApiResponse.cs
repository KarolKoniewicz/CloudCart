using System.Net;

namespace Ebiscon.CloudCart.Application.HttpClient.Models;

public class ApiResponse<T>
{
    public T Data { get; set; }
    public int StatusCode { get; set; }
    public bool Success => StatusCode >= (int)HttpStatusCode.OK && StatusCode < (int)HttpStatusCode.MultipleChoices;
}
