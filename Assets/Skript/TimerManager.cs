using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public float startTime = 60f;
    private float currentTime;
    public TMP_Text timerText;
    public GameObject gameOverPanel;
    private bool isRunning = false;

    void Start()
    {
    currentTime = startTime;
    gameOverPanel.SetActive(false);
    StartTimer(); // ← добавь вот эту строку
    }
    

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;
            gameOverPanel.SetActive(true);
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
        isRunning = true;
        currentTime = startTime;
        Time.timeScale = 1f;
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
    }
}