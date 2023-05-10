namespace GeoMastery.Domain.Utilities;
public static class StringUtilities
{
    public static string Slugify(string name)
    {
        if(name == "N/A" || string.IsNullOrEmpty(name))
        {
            return "not-available";
        }
        var slug = name.ToLower().Replace(" ", "-");
        return slug;
    }
}