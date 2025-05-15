using UnityEngine;

public class TargetController : MonoBehaviour
{
    private Vector3 startPosition;
    private float moveSpeed = 0f; // начальная скорость — ноль
    private float moveAmplitude = 2f; // амплитуда движения (насколько далеко двигается)
    private bool isAutoMoving = false;

    void Start()
    {
        startPosition = transform.position;
    }
    void OnCollisionEnter2D(Collision2D other)
{
    if (other.collider.CompareTag("Arrow"))
    {
        ScoreManager.instance.AddScore(2);
        Debug.Log("Попадание в мишень!");
    }
}


    void Update()
    {
        // Включаем движение после 100 очков
        if (!isAutoMoving && GameManager.instance.GetScore() >= 100)
        {
            isAutoMoving = true;
        }

        if (isAutoMoving)
        {
            // Увеличиваем скорость каждые +10 очков после 100
            int bonusSpeed = (GameManager.instance.GetScore() - 100) / 10;
            moveSpeed = 0.5f + bonusSpeed * 0.1f;

            // Двигаем мишень
            float offset = Mathf.PingPong(Time.time * moveSpeed, moveAmplitude * 2) - moveAmplitude;
            transform.position = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
        }
        
    }
}