using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text recordText;         // Просто число без слова "RECORD"
    private int record = 0;
    public TimerManager timerManager;

    void Start()
    {
        UpdateScoreUI();
        UpdateRecordUI(); // Покажет 0 в начале
    }

    public void AddPoints(int amount)
    {
        score += amount;
        UpdateScoreUI();

        if (score > record)
        {
            record = score;
            UpdateRecordUI();
        }

        if (timerManager != null)
        {
            timerManager.AddTime(2f);
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateRecordUI()
    {
       recordText.text = ": " + record.ToString();
    }
}