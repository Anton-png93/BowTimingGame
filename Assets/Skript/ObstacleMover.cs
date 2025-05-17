using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float initialSpeed = 2f;   // 🟢 начальная скорость
    private float currentSpeed;       // 🔁 текущая скорость
    private Vector3 direction = Vector3.right;

    private float leftEdge;
    private float rightEdge;
    private float halfWidth;

    private int lastIncreasedScore = 0;

    void Start()
    {
        currentSpeed = initialSpeed;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        halfWidth = sr.bounds.extents.x;

        Camera cam = Camera.main;
        leftEdge = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + halfWidth;
        rightEdge = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - halfWidth;
    }

    void Update()
    {
        transform.Translate(direction * currentSpeed * Time.deltaTime);

        if (transform.position.x > rightEdge)
            direction = Vector3.left;
        else if (transform.position.x < leftEdge)
            direction = Vector3.right;

        int score = GameManager.instance.GetScore();
        if (score >= lastIncreasedScore + 10)
        {
            currentSpeed += 0.5f; // +0.5%
            lastIncreasedScore = score;

            Debug.Log($"🚀 Платформа ускорилась до {currentSpeed:F1} при счёте {score}");
        }
    }
}