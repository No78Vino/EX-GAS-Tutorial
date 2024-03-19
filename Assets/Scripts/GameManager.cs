public class GameManager
{
    private static GameManager _intance;

    public static GameManager Instance
    {
        get
        {
            if (_intance == null) _intance = new GameManager();
            return _intance;
        }
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