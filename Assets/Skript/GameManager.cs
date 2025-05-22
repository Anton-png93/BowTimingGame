using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

  [SerializeField] private int score = 0;
    public TextMeshProUGUI scoreText;
    private ObstacleMover[] obstacles; // Массив всех препятствий

    private int lastSpeedIncreaseScore = 0; // <--- ДОБАВЬ ЭТУ СТРОКУ
    private bool speedIncreased = false;

    

    void Awake()
    {
        score = 0;              // 👈 ЗДЕСЬ ставь нужное число (например, 100)
         instance = this;                        //UpdateScoreUI();          // ⬅ Обновляет текст на экране
    }

    public void AddScore(int points)
    {
        score += points;
        // UpdateScoreUI();

        // Проверяем, набрано ли ещё +10 очков с последнего ускорения
        if (score >= lastSpeedIncreaseScore + 10)
        {
            lastSpeedIncreaseScore = score;

            obstacles = FindObjectsOfType<ObstacleMover>();
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