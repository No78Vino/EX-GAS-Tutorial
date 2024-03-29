using System.Threading.Tasks;
using GAS.Runtime;
using UnityEngine;

public class CueCameraShake : GameplayCueInstant
{
    public float shakePower = 0.5f;
    public float shakeDuration = 0.5f;

    public override GameplayCueInstantSpec CreateSpec(GameplayCueParameters parameters)
    {
        return new CueCameraShakeSpec(this, parameters);
    }
}

public class CueCameraShakeSpec : GameplayCueInstantSpec<CueCameraShake>
{
    private readonly Vector3 _originalPosition = new Vector3(0, 0, -10);

    public CueCameraShakeSpec(CueCameraShake cue, GameplayCueParameters parameters) : base(cue, parameters)
    {
    }

    public override void Trigger()
    {
        // 相机震动
        CameraShake(cue.shakePower, cue.shakeDuration);
    }

    private async void CameraShake(float magnitude, float duration)
    {
        if (Camera.main == null) return;
        var transform = Camera.main.transform;
        var elapsed = 0f;
        while (elapsed < duration)
        {
            var offset = Random.insideUnitSphere * magnitude;

            transform.localPosition = _originalPosition + offset;

            await Task.Yield();

            elapsed += Time.deltaTime;
        }

        transform.localPosition = _originalPosition;
    }
}