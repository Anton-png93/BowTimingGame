using UnityEngine;

public class TargetController : MonoBehaviour
{
    public ScoreManager scoreManager;

    private Vector3 startPosition;
    private float moveSpeed = 0f;
    private float moveAmplitude = 2f;
    private bool isAutoMoving = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Arrow"))
        {
            scoreManager.AddPoints(2);
            Debug.Log("Попадание в мишень!");
        }
    }

    void Update()
    {
        if (!isAutoMoving && GameManager.instance.GetScore() >= 100)
        {
            isAutoMoving = true;
        }

        if (isAutoMoving)
        {
            int bonusSpeed = (GameManager.instance.GetScore() - 100) / 10;
            moveSpeed = 0.5f + bonusSpeed * 0.1f;

            float offset = Mathf.PingPong(Time.time * moveSpeed, moveAmplitude * 2) - moveAmplitude;
            transform.position = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
        }
    }
}