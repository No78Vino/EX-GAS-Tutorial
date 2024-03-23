using System;
using GAS.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

public class FireAsset : AbilityAsset
{
    [BoxGroup] public GameObject bulletPrefab;

    public override Type AbilityType()
    {
        return typeof(Fire);
    }
}
