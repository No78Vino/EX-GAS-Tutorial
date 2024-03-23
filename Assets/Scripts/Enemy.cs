using System;
using System.Collections;
using System.Collections.Generic;
using GAS.Runtime;
using UnityEditor.VersionControl;
using UnityEngine;

[RequireComponent(typeof(AbilitySystemComponent))]
public class Enemy : MonoBehaviour
{
    private AbilitySystemComponent _asc;
    private Player _player;
    private Rigidbody2D _rb;

    private const float BoomDistance = 2.5f;
    private void Awake()
    {
        _asc = gameObject.GetComponent<AbilitySystemComponent>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        
        GameRunner.Instance.RegisterEnemy(this);
    }

    private void OnDestroy()
    {
        GameRunner.Instance.UnregisterEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Chase()) Boom();
    }

    public void Init(Player player)
    {
        _player = player;
        // 初始化属性
        InitAttributes();
    }

    void InitAttributes()
    {
        // TODO  初始化属性 
    }
    
    bool Chase()
    {
        // 如果玩家为空，返回 false
        if (_player == null) return false;
        
        // 追击
        var delta = (Vector2)(_player.transform.position - transform.position);
        var speed = 2f; // 替换为
        _rb.velocity = delta.normalized * speed;
        
        // 计算玩家与自己的距离
        var distance = delta.magnitude;
        return distance < BoomDistance;
    }
    
    void Boom()
    {
        // TODO 发动爆炸技能
    }
}
