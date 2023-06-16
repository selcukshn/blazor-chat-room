using Blazor.Models;
using Blazored.LocalStorage;

namespace Blazor.Extensions.Blazored.LocalStorage
{
    public static class AsyncLocalStorageExtension
    {
        #region JWT
        public static async Task<string> GetJWTAsync(this ILocalStorageService storage)
        {
            return await storage.GetItemAsStringAsync(LocalStorageConstant.JWTKey);
        }
        public static async Task SetJWTAsync(this ILocalStorageService storage, string token)
        {
            await storage.SetItemAsStringAsync(LocalStorageConstant.JWTKey, token);
        }
        public static async Task RemoveJWTAsync(this ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(LocalStorageConstant.JWTKey);
        }
        public static async Task<bool> HaveTokenAsync(this ILocalStorageService storage)
        {
            return !string.IsNullOrEmpty(await storage.GetJWTAsync());
        }
        #endregion

        #region User
        public static async Task SetUserInformationAsync(this ILocalStorageService storage, AuthorizedUser model)
        {
            await storage.SetItemAsync<AuthorizedUser>(LocalStorageConstant.UserKey, model);
        }
        public static async Task<AuthorizedUser?> GetUserInformationAsync(this ILocalStorageService storage)
        {
            return await storage.GetItemAsync<AuthorizedUser>(LocalStorageConstant.UserKey) ?? null;
        }
        public static async Task RemoveUserInformationAsync(this ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(LocalStorageConstant.UserKey);
        }
        public static async Task<bool> HaveUserAsync(this ILocalStorageService storage)
        {
            return await storage.GetUserInformationAsync() != null;
        }
        #endregion
    }
}