using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour

{
    public static TimerManager instance;
    public GameObject GameOverCanvas;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalRecordText;

    private bool gameOverShown = false;
    public float startTime = 60f;
    private float currentTime;
    public TMP_Text timerText;
    public GameObject gameOverPanel;
    private bool isRunning = false;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentTime = startTime;
        gameOverPanel.SetActive(false);
       
    }


    void Update()
    {
         Debug.Log("🌀 Update работает");
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f && !gameOverShown)
        {
            currentTime = 0f;
            isRunning = false;
            gameOverShown = true;

            GameOverCanvas.SetActive(true);
            gameOverPanel.SetActive(true);
            foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Platform"))
                Destroy(platform);
            // Сохраняем рекорд, если текущий счёт больше
           int currentScore = 0;
        if (GameManager.instance != null)
        currentScore = GameManager.instance.GetScore();
            int bestScore = PlayerPrefs.GetInt("Record", 0);

            if (currentScore > bestScore)
            {
                PlayerPrefs.SetInt("Record", currentScore);
                PlayerPrefs.Save(); // Сохраняем изменения
            }

          if (finalScoreText != null)
            finalScoreText.text = " : " + GameManager.instance.GetScore().ToString();
            if (finalRecordText != null)
            finalRecordText.text = PlayerPrefs.GetInt("Record", 0).ToString();
            Time.timeScale = 0f;
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void StartTimer()
    
    {
    Debug.Log("🔥 StartTimer вызван");
    isRunning = true;
    currentTime = startTime;
    // Спавним первую платформу
    PlatformManager platformManager = FindObjectOfType<PlatformManager>();
    if (platformManager != null)
    {
        platformManager.SpawnFirstPlatform();
    }
    Time.timeScale = 1f;
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
    }
    public void RestartGame()
{
    Time.timeScale = 1f; // Сброс скорости игры на нормальную
    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезапуск текущей сцены
}
}