namespace Recipes.Mobile.Misc;

internal static class HttpClientHelper
{
    internal static HttpClient GetPlatformHttpClient(string baseAddress)
    {
        if (DeviceInfo.Platform == DevicePlatform.Android ||
            DeviceInfo.Platform == DevicePlatform.iOS)
        {
            var handler = new HttpsClientHandlerService();
            return new(handler.GetPlatformMessageHandler())
            {
                BaseAddress = new Uri(baseAddress)
            };
        }
        else
        {
            return new()
            {
                BaseAddress = new Uri(baseAddress)
            };
        }
    }
}
