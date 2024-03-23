///////////////////////////////////
//// This is a generated file. ////
////     Do not modify it.     ////
///////////////////////////////////
using System;
using System.Collections.Generic;

namespace GAS.Runtime
{
  public static class GAbilityLib
  {
      public struct AbilityInfo
      {
          public string Name;
          public string AssetPath;
          public Type AbilityClassType;
      }

    public static AbilityInfo Fire_Info = new AbilityInfo { Name = "Fire", AssetPath = "Assets/Config/GAS/GameplayAbilityLib/Fire.asset",AbilityClassType = typeof(Fire) };

  public static Dictionary<string, AbilityInfo> AbilityMap = new Dictionary<string, AbilityInfo>
  {
      ["Fire"] = Fire_Info,
  };
  }
}
