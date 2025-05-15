using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;

    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}