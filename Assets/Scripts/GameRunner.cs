using System;
using UnityEngine;

public class GameRunner: MonoBehaviour
{
    public static GameRunner Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        WaitForFirstGameStart();
    }

    public void WaitForFirstGameStart()
    {
        // 显示开始界面
        // 暂停GAS
    }

    public void StartGame()
    {
        // 重置UI
        // 恢复GAS运行
        // TODO 重置Player和Enemy
    }

    public void GameOver(bool isWin)
    {
        // 显示结算界面
        // 暂停GAS
    }
}