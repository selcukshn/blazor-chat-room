using System.Net;
using System.Net.Http.Json;
using Blazor.Services.Authentication;
using Common.Enums;
using Common.Response;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Services.Request.Base
{
    public class BaseRequest
    {
        protected readonly HttpClient Client;
        protected readonly AuthenticationService AuthenticationStateProvider;
        public BaseRequest(HttpClient client, AuthenticationStateProvider authenticationStateProvider)
        {
            Client = client;
            AuthenticationStateProvider = (AuthenticationService)authenticationStateProvider;
        }

        public async Task<RequestResponseData<TModel>> GetAsync<TModel>(string address)
        {
            return await RequestAsync<TModel>(async c => await c.GetAsync(address));
        }
        public async Task<RequestResponseData<TModel>> PostAsync<TModel>(string address, object body)
        {
            return await RequestAsync<TModel>(async c => await c.PostAsync(address, JsonContent.Create(body)));
        }
        private async Task<RequestResponseData<TModel>> RequestAsync<TModel>(Func<HttpClient, Task<HttpResponseMessage>> request)
        {
            try
            {
                var response = await request(Client);
                if (response.IsSuccessStatusCode)
                    return new RequestResponseData<TModel>(ResponseStatus.Success, await DeserializeContentAsync<TModel>(response.Content));
                else
                {
                    var exception = await DeserializeExceptionContentAsync(response.Content);
                    return new RequestResponseData<TModel>()
                    {
                        Message = exception.Message,
                        Status = response.StatusCode == HttpStatusCode.NotFound ? ResponseStatus.NotFound : ResponseStatus.Error,
                        Detail = exception.Detail
                    };
                }
            }
            catch (Exception exception)
            {
                return new RequestResponseData<TModel>(ResponseStatus.Error, exception.Message);
            }
        }

        private async Task<TModel?> DeserializeContentAsync<TModel>(HttpContent content)
        {
            return await content.ReadFromJsonAsync<TModel>();
        }
        private async Task<ExceptionResponse> DeserializeExceptionContentAsync(HttpContent content)
        {
            var result = await content.ReadFromJsonAsync<ExceptionResponse>();
            if (result == null)
                return new ExceptionResponse("Bilinmeyen hata");
            return result;
        }
    }
}