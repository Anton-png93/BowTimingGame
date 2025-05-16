using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    public TimerManager timerManager; // ссылка на таймер

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddPoints(int amount)
    {
        score += amount;
        UpdateScoreUI();

        if (timerManager != null)
        {
            timerManager.AddTime(2f); // добавляем 2 секунды
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}