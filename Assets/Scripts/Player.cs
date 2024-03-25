using GAS.Runtime;
using UnityEngine;

[RequireComponent(typeof(AbilitySystemComponent))]
public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerInput _input;
    private AbilitySystemComponent _asc;
    
     void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _asc = GetComponent<AbilitySystemComponent>();

        _input = new PlayerInput();
        _input.Enable();
        _input.Player.Move.performed += OnActivateMove;
        _input.Player.Move.canceled += OnDeactivateMove;
        _input.Player.Fire.performed += OnFire;
        _input.Player.Sweep.performed += OnSweep;
    }

    private void OnDestroy()
    {
        _input.Disable();
        _input.Player.Move.performed -= OnActivateMove;
        _input.Player.Move.canceled -= OnDeactivateMove;
        _input.Player.Fire.performed -= OnFire;
        _input.Player.Sweep.performed -= OnSweep;
        
        _asc.AttrSet<AS_Fight>().HP.UnregisterPostBaseValueChange(OnHpChange);
        _asc.AbilityContainer.AbilitySpecs()[GAbilityLib.Die.Name].UnregisterEndAbility(OnDie);
    }

    // Update is called once per frame
    void Update()
    {
        // Player朝向始终面向鼠标
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var dir = (mousePos - transform.position);
        dir.z = 0;
        dir = dir.normalized;
        transform.up = dir;
    }

    public void Init()
    {
        _asc.InitWithPreset(1);
        InitAttribute();
    }
    
    void InitAttribute()
    {
        _asc.AttrSet<AS_Fight>().InitHP(100);
        _asc.AttrSet<AS_Fight>().InitAtk(10);
        _asc.AttrSet<AS_Fight>().InitSpeed(8);
        
        _asc.AttrSet<AS_Fight>().HP.RegisterPostBaseValueChange(OnHpChange);
        _asc.AbilityContainer.AbilitySpecs()[GAbilityLib.Die.Name].RegisterEndAbility(OnDie);
    }

    private void OnDie()
    {
        GameRunner.Instance.GameOver();
        Destroy(gameObject);
    }

    void OnActivateMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var move = context.ReadValue<Vector2>();
        var velocity = _rb.velocity;
        velocity.x = move.x;
        velocity.y = move.y;
        velocity = velocity.normalized * _asc.AttrSet<AS_Fight>().Speed.CurrentValue;
        _rb.velocity = velocity;
    }
    
    void OnDeactivateMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _rb.velocity = Vector2.zero;
    }
    
    void OnFire(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _asc.TryActivateAbility(GAbilityLib.Fire.Name);
    }
    
    void OnSweep(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _asc.TryActivateAbility(GAbilityLib.Sweep.Name);
    }
    
    void OnHpChange(AttributeBase attributeBase,float oldValue, float newValue)
    {
        UIManager.Instance.SetHp((int)newValue);
        
        if (newValue <= 0)
        {
            _asc.TryActivateAbility(GAbilityLib.Die.Name);
        }
    }
}
