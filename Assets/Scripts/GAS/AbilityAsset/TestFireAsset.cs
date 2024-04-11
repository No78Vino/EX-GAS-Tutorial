using System;
using GAS.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

sealed class TestFireAsset : AbilityAsset
{
    [BoxGroup] public GameObject bulletPrefab;
    [BoxGroup] public string testString;

    public override Type AbilityType()
    {
        return typeof(Fire);
    }
}
