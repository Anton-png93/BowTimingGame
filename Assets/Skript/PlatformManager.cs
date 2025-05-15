using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform[] spawnPoints;
    public int scorePerPlatform = 20;

    private int lastPlatformScore = 0;
    private int currentPlatformIndex = 0;

   void Start()
{
    if (currentPlatformIndex < spawnPoints.Length)
    {
        Instantiate(platformPrefab, spawnPoints[currentPlatformIndex].position, Quaternion.identity);
        currentPlatformIndex++;

        // ВАЖНО: сохраняем стартовый счёт
        lastPlatformScore = PlayerPrefs.GetInt("score", 0);
    }
}

    void Update()
    {
        int score = GameManager.instance.GetScore();

        if (score >= lastPlatformScore + scorePerPlatform &&
            currentPlatformIndex < spawnPoints.Length)
        {
            Debug.Log("Создаю платформу: " + currentPlatformIndex + " при счёте: " + score);

            Instantiate(platformPrefab, spawnPoints[currentPlatformIndex].position, Quaternion.identity);

            lastPlatformScore = score;
            currentPlatformIndex++;
        }
    }
}