using GAS.Runtime;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(AbilitySystemComponent))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private GameplayEffectAsset geBulletDamage;
    private AbilitySystemComponent _asc;
    private Rigidbody2D _rb;
    private GameplayEffect _geBulletDamage;
    
    private void Awake()
    {
        _asc = gameObject.GetComponent<AbilitySystemComponent>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _geBulletDamage = new GameplayEffect(geBulletDamage);
    }

    public void Init(Vector2 position, Vector2 direction, float speed, float damage)
    {
        // 设置出生点，速度
        transform.position = position;
        _rb.velocity = direction * speed;
        
        // 设置伤害
        _asc.InitWithPreset(1);
        _asc.AttrSet<AS_Bullet>().InitAtk(damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 伤害生效
        if(other.gameObject.TryGetComponent(out AbilitySystemComponent enemy))
        {
            if (enemy.HasTag(GTagLib.Faction_Enemy))
            {
                _asc.ApplyGameplayEffectTo(_geBulletDamage, enemy);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
