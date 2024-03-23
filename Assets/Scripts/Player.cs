using System;
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
        _input.Player.Fire.performed += OnActivateFire;
        _input.Player.Fire.canceled += OnDeactivateFire;
        _input.Player.Sweep.performed += OnSweep;
    }

    private void OnDestroy()
    {
        _input.Disable();
        _input.Player.Move.performed -= OnActivateMove;
        _input.Player.Move.canceled -= OnDeactivateMove;
        _input.Player.Fire.performed -= OnActivateFire;
        _input.Player.Fire.canceled -= OnDeactivateFire;
        _input.Player.Sweep.performed -= OnSweep;
    }

    void OnEnable()
    {
        // _asc.AttrSet<AS_Fight>().HP.RegisterPostBaseValueChange(OnHpChange);
        // _asc.AttrSet<AS_Fight>().POSTURE.RegisterPostBaseValueChange(OnPostureChange);
    }

     void OnDisable()
    {
        // _asc.AttrSet<AS_Fight>().HP.UnregisterPostBaseValueChange(OnHpChange);
        // _asc.AttrSet<AS_Fight>().POSTURE.UnregisterPostBaseValueChange(OnPostureChange);
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
        // _asc.
        InitAttribute();
    }
    
    void InitAttribute()
    {
        // TODO  初始化属性 
    }
    
    void OnActivateMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // 移动
        var move = context.ReadValue<Vector2>();
        var velocity = _rb.velocity;
        velocity.x = move.x;
        velocity.y = move.y;
        velocity = velocity.normalized * 5;
        _rb.velocity = velocity;
    }
    
    void OnDeactivateMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // 停止移动
        _rb.velocity = Vector2.zero;
    }
    
    void OnActivateFire(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // TODO 开火
    }
    
    void OnDeactivateFire(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // TODO 停止开火
    }
    void OnSweep(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // TODO 横扫
    }
}
