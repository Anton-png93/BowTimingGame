using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public float spawnIntervalMin = 1f;
    public float spawnIntervalMax = 3f;
    public float spawnXRange = 2.5f;

    private bool canSpawn = false;

    void Update()
    {
        if (!canSpawn && GameManager.instance.GetScore() >= 80)
        {
            canSpawn = true;
            StartCoroutine(SpawnApples());
        }
    }

    System.Collections.IEnumerator SpawnApples()
    {
        while (true)
        {
            float delay = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(delay);

            float randomX = Random.Range(-spawnXRange, spawnXRange);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

            GameObject newApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity);

            Apple appleScript = newApple.GetComponent<Apple>();
            appleScript.scoreManager = FindObjectOfType<ScoreManager>();
            appleScript.timerManager = FindObjectOfType<TimerManager>();
           
            
        }
    }
}