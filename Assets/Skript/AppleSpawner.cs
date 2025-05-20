using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;      // Префаб яблока
    public float spawnXMin = -2.5f;     // Левая граница появления
    public float spawnXMax = 2.5f;      // Правая граница появления

    private float timer;
    private float nextSpawnTime;
    private bool isSpawning = false;

    void Update()
    {
        if (!isSpawning && GameManager.instance.GetScore() >= 20)
        {
            isSpawning = true;
            SetNextSpawnTime();
        }

        if (!isSpawning) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnApple();
            SetNextSpawnTime();
        }
    }

    void SetNextSpawnTime()
    {
        timer = Random.Range(9f, 20f); // Случайное число от 5 до 8 секунд
    }

    void SpawnApple()
    {
        float x = Random.Range(spawnXMin, spawnXMax);
        Vector3 spawnPosition = new Vector3(x, transform.position.y, 0);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity);
    }
}