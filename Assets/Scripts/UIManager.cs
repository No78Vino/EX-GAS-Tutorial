using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text hp;
    [SerializeField] private Text score;
    [SerializeField] private Text sweepCd;

    [SerializeField] private GameObject resultWindow;
    [SerializeField] private Text resultWindowScore;
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetHp(int hpValue)
    {
        hp.text = $"HP: {hpValue}/100";
    }

    public void SetScore(int scoreValue)
    {
        score.text = $"Score: {scoreValue}";
        resultWindowScore.text = $"Score: {scoreValue}";
    }

    public void SetSweepCd(float cd)
    {
        sweepCd.text = $"横扫CD: {cd}";
    }

    public void ShowResultWindow()
    {
        resultWindow.SetActive(true);
    }

    public void HideResultWindow()
    {
        resultWindow.SetActive(false);
    }

    public void Play()
    {
        GameRunner.Instance.StartGame();
    }
}