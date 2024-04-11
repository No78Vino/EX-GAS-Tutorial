///////////////////////////////////
//// This is a generated file. ////
////     Do not modify it.     ////
///////////////////////////////////

using System;
using System.Collections.Generic;

namespace GAS.Runtime
{
    public class AS_Fight : AttributeSet
    {
        #region HP

        private AttributeBase _HP = new AttributeBase("AS_Fight", "HP");

        public AttributeBase HP => _HP;

        public void InitHP(float value)
        {
            _HP.SetBaseValue(value);
            _HP.SetCurrentValue(value);
        }

        public void SetCurrentHP(float value)
        {
            _HP.SetCurrentValue(value);
        }

        public void SetBaseHP(float value)
        {
            _HP.SetBaseValue(value);
        }

        #endregion HP

        #region Speed

        private AttributeBase _Speed = new AttributeBase("AS_Fight", "Speed");

        public AttributeBase Speed => _Speed;

        public void InitSpeed(float value)
        {
            _Speed.SetBaseValue(value);
            _Speed.SetCurrentValue(value);
        }

        public void SetCurrentSpeed(float value)
        {
            _Speed.SetCurrentValue(value);
        }

        public void SetBaseSpeed(float value)
        {
            _Speed.SetBaseValue(value);
        }

        #endregion Speed

        #region Atk

        private AttributeBase _Atk = new AttributeBase("AS_Fight", "Atk");

        public AttributeBase Atk => _Atk;

        public void InitAtk(float value)
        {
            _Atk.SetBaseValue(value);
            _Atk.SetCurrentValue(value);
        }

        public void SetCurrentAtk(float value)
        {
            _Atk.SetCurrentValue(value);
        }

        public void SetBaseAtk(float value)
        {
            _Atk.SetBaseValue(value);
        }

        #endregion Atk

        public override AttributeBase this[string key]
        {
            get
            {
                switch (key)
                {
                    case "HP":
                        return _HP;
                    case "Speed":
                        return _Speed;
                    case "Atk":
                        return _Atk;
                }

                return null;
            }
        }

        public override string[] AttributeNames { get; } =
        {
            "HP",
            "Speed",
            "Atk",
        };

        public override void SetOwner(AbilitySystemComponent owner)
        {
            _owner = owner;
            _HP.SetOwner(owner);
            _Speed.SetOwner(owner);
            _Atk.SetOwner(owner);
        }
    }
    public class AS_Bullet : AttributeSet
    {
        #region Atk

        private AttributeBase _Atk = new AttributeBase("AS_Bullet", "Atk");

        public AttributeBase Atk => _Atk;

        public void InitAtk(float value)
        {
            _Atk.SetBaseValue(value);
            _Atk.SetCurrentValue(value);
        }

        public void SetCurrentAtk(float value)
        {
            _Atk.SetCurrentValue(value);
        }

        public void SetBaseAtk(float value)
        {
            _Atk.SetBaseValue(value);
        }

        #endregion Atk

        public override AttributeBase this[string key]
        {
            get
            {
                switch (key)
                {
                    case "Atk":
                        return _Atk;
                }

                return null;
            }
        }

        public override string[] AttributeNames { get; } =
        {
            "Atk",
        };

        public override void SetOwner(AbilitySystemComponent owner)
        {
            _owner = owner;
            _Atk.SetOwner(owner);
        }
    }

    public static class GAttrSetLib
    {
        public static readonly Dictionary<string, Type> AttrSetTypeDict = new Dictionary<string, Type>()
        {
            { "Fight", typeof(AS_Fight) },
            { "Bullet", typeof(AS_Bullet) },
        };

        public static List<string> AttributeFullNames = new List<string>()
        {
            "AS_Fight.HP",
            "AS_Fight.Speed",
            "AS_Fight.Atk",
            "AS_Bullet.Atk",
        };
    }
}