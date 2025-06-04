using UnityEngine;

public class PlayButtonController : MonoBehaviour
{
    public GameObject playButton;

    public void OnPlayPressed()
    {
        playButton.SetActive(false);
        Time.timeScale = 1f; // Запускаем игру
    }

    private void Start()
    {
        Time.timeScale = 0f; // Останавливаем игру при старте
    }
}