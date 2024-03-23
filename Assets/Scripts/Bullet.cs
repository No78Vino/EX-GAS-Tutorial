using GAS.Runtime;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(AbilitySystemComponent))]
public class Bullet : MonoBehaviour
{
    private AbilitySystemComponent _asc;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _asc = gameObject.GetComponent<AbilitySystemComponent>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 position, float rotation, float speed, int damage)
    {
        // TODO 设置出生点，方向，速度
        transform.position = position;
        transform.localEulerAngles = new Vector3(0, 0, rotation);
        _rb.velocity = transform.up * speed;
        
        // TODO 设置伤害
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // TODO 伤害计算
        
        // 销毁自己
        Destroy(gameObject);
    }
}
