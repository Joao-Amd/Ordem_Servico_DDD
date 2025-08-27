namespace Meraki.Core.Mappers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MapFromAttribute : Attribute
    {
        public string Path { get; }
        public MapFromAttribute(string path) => Path = path;
    }
}
