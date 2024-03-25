using GAS.Runtime;

public class CueCdUiUpdate : GameplayCueDurational
{
    public override GameplayCueDurationalSpec CreateSpec(GameplayCueParameters parameters)
    {
        return new CueCdUiUpdateSpec(this, parameters);
    }
}

public class CueCdUiUpdateSpec : GameplayCueDurationalSpec<CueCdUiUpdate>
{
    public CueCdUiUpdateSpec(CueCdUiUpdate cue, GameplayCueParameters parameters) : base(cue, parameters)
    {
    }

    public override void OnAdd()
    {
    }

    public override void OnRemove()
    {
    }

    public override void OnGameplayEffectActivate()
    {
    }

    public override void OnGameplayEffectDeactivate()
    {
    }

    public override void OnTick()
    {
        var cd = _parameters.sourceGameplayEffectSpec.DurationRemaining();
        UIManager.Instance.SetSweepCd(cd);
    }
}