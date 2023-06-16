using Blazor.Models;
using Blazored.LocalStorage;

namespace Blazor.Extensions.Blazored.LocalStorage
{
    public static class SyncLocalStorageExtension
    {
        #region JWT
        public static string GetJWT(this ISyncLocalStorageService storage)
        {
            return storage.GetItemAsString(LocalStorageConstant.JWTKey);
        }
        public static void SetJWT(this ISyncLocalStorageService storage, string token)
        {
            storage.SetItemAsString(LocalStorageConstant.JWTKey, token);
        }
        public static void RemoveJWT(this ISyncLocalStorageService storage)
        {
            storage.RemoveItem(LocalStorageConstant.JWTKey);
        }
        public static bool HaveToken(this ISyncLocalStorageService storage)
        {
            return !string.IsNullOrEmpty(storage.GetJWT());
        }
        #endregion

        #region User
        public static void SetUserInformation(this ISyncLocalStorageService storage, AuthorizedUser model)
        {
            storage.SetItem<AuthorizedUser>(LocalStorageConstant.UserKey, model);
        }
        public static AuthorizedUser? GetUserInformation(this ISyncLocalStorageService storage)
        {
            return storage.GetItem<AuthorizedUser>(LocalStorageConstant.UserKey) ?? null;
        }
        public static void RemoveUserInformation(this ISyncLocalStorageService storage)
        {
            storage.RemoveItem(LocalStorageConstant.UserKey);
        }
        public static bool HaveUser(this ISyncLocalStorageService storage)
        {
            return storage.GetUserInformation() != null;
        }
        #endregion
    }
}