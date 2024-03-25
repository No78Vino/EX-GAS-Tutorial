using GAS.Runtime;
using UnityEngine;

public class CueReadyBoom : GameplayCueDurational
{
    public float period = 0.5f;
    public float zoomScale = 0.5f;
    
    public override GameplayCueDurationalSpec CreateSpec(GameplayCueParameters parameters)
    {
        return new CueReadyBoomSpec(this, parameters);
    }
}

public class CueReadyBoomSpec : GameplayCueDurationalSpec<CueReadyBoom>
{
    Transform ownerTransform;
    public CueReadyBoomSpec(CueReadyBoom cue, GameplayCueParameters parameters) : base(cue, parameters)
    {
        ownerTransform = Owner.transform;
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

    private float timer;
    public override void OnTick()
    {
        var p = (Mathf.Sin(timer*(2*Mathf.PI)/cue.period) + 1) * 0.5f;
        var scale = Mathf.Lerp(cue.zoomScale, 1, p);
        ownerTransform.localScale = Vector3.one * scale;
        
        timer += Time.deltaTime;
    }
}