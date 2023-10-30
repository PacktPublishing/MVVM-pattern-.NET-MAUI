namespace Recipes.Mobile.Navigation;

public static class Routes
{
    static Dictionary<string, Type> routes 
        = new Dictionary<string, Type>();

    public static void Register<T>(string key) 
        where T : Page
        => routes.Add(key, typeof(T));

    public static Type GetType(string key)
        => routes[key];
}
