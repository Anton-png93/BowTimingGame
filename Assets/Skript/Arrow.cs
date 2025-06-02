using UnityEngine;

public class Arrow : MonoBehaviour
{
    public AudioSource hitSound;             // 🔊 Звук при попадании в мишень
    public AudioSource obstacleHitSound;     // 🔊 Звук при попадании в препятствие

    private Rigidbody2D rb;
    private bool hasHit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasHit) return;
        hasHit = true;

        // Полностью останавливаем физику стрелы
        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;
        rb.simulated = false;

        // Выключаем коллайдер
        GetComponent<Collider2D>().enabled = false;

        // Если попали в мишень
        if (collision.gameObject.CompareTag("Target"))
        {
            if (hitSound != null)
                hitSound.Play();

            Debug.Log("Попадание в мишень!");
            GameManager.instance.AddScore(2);

            // Прикрепляем стрелу к мишени
            transform.SetParent(collision.transform);
        }
        else
        {
            // Попали в препятствие
            if (obstacleHitSound != null)
                obstacleHitSound.Play();

            transform.SetParent(collision.transform);
            Debug.Log("Стрела врезалась в " + collision.gameObject.name + " и теперь двигается с ним");
        }
    }
}