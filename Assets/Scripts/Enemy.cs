using GAS.Runtime;
using UnityEngine;

[RequireComponent(typeof(AbilitySystemComponent))]
public class Enemy : MonoBehaviour
{
    private const float BoomDistance = 2.5f;
    protected AbilitySystemComponent _asc;
    private Player _player;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _asc = gameObject.GetComponent<AbilitySystemComponent>();
        _rb = gameObject.GetComponent<Rigidbody2D>();

        GameRunner.Instance.RegisterEnemy(this);
    }
    
    private void Update()
    {
        if (Chase()) Boom();
        
        if (_player != null)
        {
            var dir = (Vector2)(_player.transform.position - transform.position);
            dir.Normalize();
            transform.up = dir;
        }
    }

    private void OnDestroy()
    {
        GameRunner.Instance.UnregisterEnemy(this);
        _asc.AttrSet<AS_Fight>().HP.UnregisterPostBaseValueChange(OnHpChange);
        _asc.AbilityContainer.AbilitySpecs()[BombSkillName].UnregisterEndAbility(OnBombEnd);
        _asc.AbilityContainer.AbilitySpecs()[GAbilityLib.Die.Name].UnregisterEndAbility(OnBombEnd);
    }

    public void Init(Player player)
    {
        _player = player;

        _asc.InitWithPreset(1);
        InitAttributes();

        _asc.AbilityContainer.AbilitySpecs()[BombSkillName].RegisterEndAbility(OnBombEnd);
        _asc.AbilityContainer.AbilitySpecs()[GAbilityLib.Die.Name].RegisterEndAbility(OnBombEnd);
    }

    private void OnBombEnd()
    {
        Destroy(gameObject);
    }

    private void InitAttributes()
    {
        // 初始化属性 
        _asc.AttrSet<AS_Fight>().InitHP(10);
        _asc.AttrSet<AS_Fight>().InitAtk(20);
        _asc.AttrSet<AS_Fight>().InitSpeed(5);

        _asc.AttrSet<AS_Fight>().HP.RegisterPostBaseValueChange(OnHpChange);
    }

    private void OnHpChange(AttributeBase attributeBase, float oldValue, float newValue)
    {
        if (newValue <= 0) Die();
    }

    private bool Chase()
    {
        if (_player == null ||
            _asc.AttrSet<AS_Fight>().HP.CurrentValue <= 0 ||
            _asc.HasTag(GTagLib.Event_Ban_Move))
        {
            _rb.velocity =Vector2.zero;
            return false;
        }
        
        var delta = (Vector2)(_player.transform.position - transform.position);
        var speed = _asc.AttrSet<AS_Fight>().Speed.CurrentValue;
        _rb.velocity = delta.normalized * speed;
        
        var distance = delta.magnitude;
        return distance < BoomDistance;
    }

    protected virtual string BombSkillName => GAbilityLib.Bomb.Name;
    
    private void Boom()
    {
        _asc.TryActivateAbility(BombSkillName);
    }

    private void Die()
    {
        GameRunner.Instance.AddScore();
        _asc.TryActivateAbility(GAbilityLib.Die.Name);
    }
}