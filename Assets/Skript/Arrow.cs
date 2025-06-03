using UnityEngine;

public class Arrow : MonoBehaviour
{
    public AudioSource hitSound;              // 🎯 Звук при попадании в мишень
    public AudioSource obstacleHitSound;      // 🧱 Звук при попадании в препятствие
    private AudioSource appleHitSource;         // 🍎 Звук хруста яблока

    private Rigidbody2D rb;
    private bool hasHit = false;

    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        appleHitSource = GameObject.Find("AppleHitSound")?.GetComponent<AudioSource>();
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

        // 🎯 Попал в мишень
        if (collision.gameObject.CompareTag("Target"))
        {
            if (hitSound != null)
                hitSound.Play();

            Debug.Log("Попадание в мишень!");
            GameManager.instance.AddScore(2);
            transform.SetParent(collision.transform);
        }

        // 🍎 Попал в яблоко
        else if (collision.gameObject.CompareTag("Apple"))
        {
            if (appleHitSource != null)
            appleHitSource.PlayOneShot(appleHitSource.clip);

            transform.SetParent(collision.transform);
            Debug.Log("Попадание в яблоко!");
        }

        // 🧱 Попал в другое препятствие
        else
        {
            if (obstacleHitSound != null)
                obstacleHitSound.PlayOneShot(obstacleHitSound.clip);

            transform.SetParent(collision.transform);
            Debug.Log("Стрела врезалась в " + collision.gameObject.name + " и теперь движется с ним");
        }
    }
}