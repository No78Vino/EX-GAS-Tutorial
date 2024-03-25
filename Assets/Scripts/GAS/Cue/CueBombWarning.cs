using GAS.General;
using GAS.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GAS.Cue
{
    public class CueBombWarning : GameplayCueDurational
    {
        [BoxGroup]
        [LabelText("半径")]
        public float Radius;

        [BoxGroup]
        [LabelText("可视预制体")]
        public GameObject Visualization;
        
        [BoxGroup]
        [LabelText("持续时间(s)")]
        public float Duration = 1;
        
        public override GameplayCueDurationalSpec CreateSpec(GameplayCueParameters parameters)
        {
            return new CueBombWarningSpec(this, parameters);
        }
    }

    public class CueBombWarningSpec : GameplayCueDurationalSpec<CueBombWarning>
    {
        private AreaVisualization _visualization;
        private int _startFrame;
        private int durationFrame;
        public CueBombWarningSpec(CueBombWarning cue, GameplayCueParameters parameters) : base(
            cue, parameters)
        {
            durationFrame = (int)(cue.Duration * GASTimer.FrameRate);
        }
        
        public override void OnAdd()
        {
            _startFrame = GASTimer.CurrentFrameCount;
            
            var vfx = Object.Instantiate(cue.Visualization);
            vfx.transform.position = Owner.transform.position;
            _visualization = vfx.GetComponent<AreaVisualization>();
            _visualization.SetAreaSize(cue.Radius * 2);
        }

        public override void OnRemove()
        {
            Object.Destroy(_visualization.gameObject);
        }

        public override void OnGameplayEffectActivate()
        {
        }

        public override void OnGameplayEffectDeactivate()
        {
        }

        public override void OnTick()
        {
            _visualization.SetProgress((float)(GASTimer.CurrentFrameCount - _startFrame) / durationFrame);
        }
    }
}