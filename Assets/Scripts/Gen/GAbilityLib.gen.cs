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

    public static AbilityInfo Bomb = new AbilityInfo { Name = "Bomb", AssetPath = "Assets/Config/GAS/GameplayAbilityLib/Bomb.asset",AbilityClassType = typeof(GAS.Runtime.TimelineAbility) };

    public static AbilityInfo Die = new AbilityInfo { Name = "Die", AssetPath = "Assets/Config/GAS/GameplayAbilityLib/Die.asset",AbilityClassType = typeof(GAS.Runtime.TimelineAbility) };

    public static AbilityInfo Fire = new AbilityInfo { Name = "Fire", AssetPath = "Assets/Config/GAS/GameplayAbilityLib/Fire.asset",AbilityClassType = typeof(Fire) };

  public static Dictionary<string, AbilityInfo> AbilityMap = new Dictionary<string, AbilityInfo>
  {
      ["Bomb"] = Bomb,
      ["Die"] = Die,
      ["Fire"] = Fire,
  };
  }
}
