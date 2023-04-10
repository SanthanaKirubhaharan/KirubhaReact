// FrozenDictionaryType.cs

using System.Collections.Frozen;

namespace DotNet8Features
{
    internal class FrozenDictionaryType
    {
        private static readonly FrozenDictionary<string, string> staticData =
            LoadStaticData().ToFrozenDictionary();

        private static Dictionary<string,string> LoadStaticData()
        {
            return new Dictionary<string, string>() { { "Key1","Value1" }, { "Key2", "Value2" }, { "Key3", "Value3" } };

        }

        internal string GetValue(string key) 
        {
            if (staticData.TryGetValue(key, out string? keyValue))
            {
                return keyValue;
            }

            return string.Empty;
        }

    }
}
