using System;
using System.Collections.Generic;
using System.Linq;
using SaladeTomateOignon.Enums;

namespace SaladeTomateOignon.Utils
{
    public class WeaponUtils
    {

        public static List<KeyValuePair<string,int>> GetWeaponsIds<WeaponsIds>()
        {
            return Enum.GetValues(typeof(WeaponsIds)).Cast<object>()
                .Select(e => new KeyValuePair<string, int>(e.ToString(),(int)e))
                .ToList();
        }
    }
}