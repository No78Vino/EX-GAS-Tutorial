using GAS.Runtime;
using UnityEngine;
using Object = UnityEngine.Object;

public class Fire : AbstractAbility<FireAsset>
{
    public readonly GameObject bulletPrefab;

    public Fire(AbilityAsset abilityAsset) : base(abilityAsset)
    {
        bulletPrefab = AbilityAsset.bulletPrefab;
    }

    public override AbilitySpec CreateSpec(AbilitySystemComponent owner)
    {
        return new FireSpec(this, owner);
    }
}

public class FireSpec : AbilitySpec<Fire>
{
    public FireSpec(Fire ability, AbilitySystemComponent owner) : base(ability, owner)
    {
    }

    public override void ActivateAbility(params object[] args)
    {
        // 生成子弹
        var bullet = Object.Instantiate(data.bulletPrefab).GetComponent<Bullet>();
        var transform = Owner.transform;
        bullet.Init(transform.position, transform.up, 10, Owner.AttrSet<AS_Fight>().Atk.CurrentValue);
        TryEndAbility();
    }

    public override void CancelAbility()
    {
    }

    public override void EndAbility()
    {
    }
}