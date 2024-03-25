using System;
using System.Collections.Generic;
using GAS;
using UnityEngine;

public class GameRunner: MonoBehaviour
{
    public static GameRunner Instance { get; private set; }

    [SerializeField] private GameObject prefabPlayer;
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject prefabEnemyCold;

    private bool _isRunning;
    private const float EnemySpawnInterval = 1.5f;
    float _enemySpawnCounter = 0f;

    private int _score = 0;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        WaitForFirstGameStart();
    }

    private void Update()
    {
        if (_isRunning)
        {
            _enemySpawnCounter += Time.deltaTime;
            if (_enemySpawnCounter >= EnemySpawnInterval)
            {
                _enemySpawnCounter = 0;
                SpawnEnemy();
            }
        }
    }

    public void WaitForFirstGameStart()
    {
        // 显示开始界面
        UIManager.Instance.ShowResultWindow();
        // 暂停GAS
    }

    public void StartGame()
    {
        // 重置数据
        _score = 0;
        // 重置UI
        UIManager.Instance.HideResultWindow();
        UIManager.Instance.SetScore(_score);
        // 恢复GAS运行
        GameplayAbilitySystem.GAS.Unpause();
        
        // 重置Player和Enemy
        DestroyPlayer();
        DestroyEnemies();
        CreatePlayer();
        _isRunning = true;
    }

    public void GameOver()
    {
        _isRunning = false;
        // 显示结算界面
        UIManager.Instance.ShowResultWindow();
        // 暂停GAS
        GameplayAbilitySystem.GAS.Pause();
    }

    public void AddScore(int addScore=10)
    {
        _score += addScore;
        UIManager.Instance.SetScore(_score);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f,0.5f,0,0.5f);
        Gizmos.DrawCube(enemySpawnRect.center, enemySpawnRect.size);
    }

    #region Player Management

    private Player _player;
    [SerializeField] private Vector3 _playerSpawnPosition = Vector3.zero;
    public void CreatePlayer()
    {
        if (_player != null) return;
        var go = Instantiate(prefabPlayer);
        go.transform.position = _playerSpawnPosition;
        _player = go.GetComponent<Player>();
        _player.Init();
    }
    
    public void DestroyPlayer()
    {
        if (_player == null) return;
        Destroy(_player.gameObject);
        _player = null;
    }

    #endregion

    
    #region Enemy Managment

    private int _enemyCount = 0;
    private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private Rect enemySpawnRect;
    
    public void RegisterEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
    }
    
    public void UnregisterEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }
    
    private void SpawnEnemy()
    {
        var position = new Vector3(
            UnityEngine.Random.Range(enemySpawnRect.xMin, enemySpawnRect.xMax),
            UnityEngine.Random.Range(enemySpawnRect.yMin, enemySpawnRect.yMax),
            0);
        var go = Instantiate(_enemyCount % 4 == 3 ? prefabEnemyCold : prefabEnemy);
        go.transform.position = position;
        var enemy = go.GetComponent<Enemy>();
        enemy.Init(_player);

        _enemyCount++;
    }

    private void DestroyEnemies()
    {
        foreach (var enemy in _enemies)
        {
            Destroy(enemy.gameObject);
        }
        _enemies.Clear();
    }
    
    #endregion
}