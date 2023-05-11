using System.Text.RegularExpressions;
using UnityEngine;

namespace Assets._Scripts.Core.Helpers
{
    public static class GlobalNamesHelper
    {
        public static string GameObjectName(GameObject gameObject)
        {
            return Regex.Replace(gameObject.name, @"\(.*\)", "").Trim();
        }
    }
}
