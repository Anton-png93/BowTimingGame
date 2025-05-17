using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public ObstacleMover[] obstacles; // Массив всех препятствий

    private int lastSpeedIncreaseScore = 0; // <--- ДОБАВЬ ЭТУ СТРОКУ
    private bool speedIncreased = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = 0;              // 👈 ЗДЕСЬ ставь нужное число (например, 100)
                                //UpdateScoreUI();          // ⬅ Обновляет текст на экране
    }

    public void AddScore(int points)
    {
        score += points;
        // UpdateScoreUI();

        // Проверяем, набрано ли ещё +10 очков с последнего ускорения
        if (score >= lastSpeedIncreaseScore + 10)
        {
            lastSpeedIncreaseScore = score;

            foreach (ObstacleMover mover in obstacles)
            {
               
             
            }

            Debug.Log("Скорость увеличена! Текущие очки: " + score);
        }
    }

    //void UpdateScoreUI()
    //{
    // scoreText.text = "SCORE: " + score.ToString();
    // }

    public int GetScore()  // ← ВСТАВЬ СЮДА
    {
        return score;
    }
    public void RestartGame()
{
    SceneManager.LoadScene("SampleScene");
}
    
}