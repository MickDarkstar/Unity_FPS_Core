using System;
using System.Collections.Generic;


// Gör liknande https://github.com/lordofduct/spacepuppy-unity-framework/blob/master/SpacepuppyBase/Utils/RandomUtil.cs
namespace Assets._Scripts.Core.Helpers
{
    public static class RandomizerHelper
    {
        internal static Random random = new Random(); // använda System.Random eller Unity.Random? Har inte kollat upp skillnaden

        public static int Randomize(int size)
        {
            return random.Next(0, size);
        }

        public static T PickRandom<T>(List<T> list)
        {
            return list[random.Next(list.Count)];
        }
    }
}
