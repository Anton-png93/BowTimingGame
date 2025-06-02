using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 2f; // скорость
    private Vector3 direction = Vector3.right;

    private float leftEdge;
    private float rightEdge;
    private float halfWidth;

    void Start()
    {
        // Находим размер объекта
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        halfWidth = sr.bounds.extents.x;

        // Получаем координаты краёв экрана в мировых координатах
        Camera cam = Camera.main;
        leftEdge = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + halfWidth;
        rightEdge = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - halfWidth;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x > rightEdge)
        {
            direction = Vector3.left;
        }
        else if (transform.position.x < leftEdge)
        {
            direction = Vector3.right;
        }
    }
}