using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int scoreTeamA = 0;
    public int scoreTeamB = 0;
    public float matchDuration = 300f; // 5 minutes default
    public float matchTimeRemaining;

    public Text teamAText;
    public Text teamBText;
    public Text timerText;

    public bool matchRunning = false;

    void Awake()
    {
        matchTimeRemaining = matchDuration;
    }

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (!matchRunning) return;
        matchTimeRemaining -= Time.deltaTime;
        if (matchTimeRemaining <= 0)
        {
            matchTimeRemaining = 0;
            matchRunning = false;
            // match end logic
        }
        UpdateUI();
    }

    public void StartMatch()
    {
        matchTimeRemaining = matchDuration;
        matchRunning = true;
        UpdateUI();
    }

    public void AddScoreTeamA(int amount = 1)
    {
        scoreTeamA += amount;
        UpdateUI();
    }

    public void AddScoreTeamB(int amount = 1)
    {
        scoreTeamB += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (teamAText != null) teamAText.text = scoreTeamA.ToString();
        if (teamBText != null) teamBText.text = scoreTeamB.ToString();
        if (timerText != null) timerText.text = FormatTime(matchTimeRemaining);
    }

    string FormatTime(float t)
    {
        int minutes = Mathf.FloorToInt(t / 60f);
        int seconds = Mathf.FloorToInt(t % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
