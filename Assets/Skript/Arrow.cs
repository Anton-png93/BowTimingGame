using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public AudioSource appleHitSound;
    public AudioSource hitSound;             // 🔊 Звук при попадании в мишень
    public AudioSource obstacleHitSound;     // 🔊 Звук при попадании в препятствие

    private Rigidbody2D rb;
    private bool hasHit = false;
    public ScoreManager scoreManager; // ссылка на объект, который управляет очками

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
        if (collision.collider.CompareTag("Apple"))
        {
            // Ищем объект со звуком яблока
    GameObject appleGO = GameObject.Find("AppleSound");
    if (appleGO != null)
    {
        AudioSource source = appleGO.GetComponent<AudioSource>();
        if (source != null)
            source.Play();
    }

    scoreManager.AddPoints(6);
    TimerManager.instance.AddTime(6);

    Debug.Log("🍏 Попадание в яблоко! +6 очков и +6 секунд!");
    transform.SetParent(collision.transform);
    return;  
    }
    
        if (collision.gameObject.CompareTag("Target"))
        {
            if (hitSound != null)
                hitSound.Play();

            Debug.Log("Попадание в мишень!");
            GameManager.instance.AddScore(2);

            // Прикрепляем стрелу к мишени
            transform.SetParent(collision.transform);
        }
        else if (collision.collider.CompareTag("Platform"))
        {
            GameObject obstacleGO = GameObject.Find("ObstacleSound");

            if (obstacleGO != null)
            {
                AudioSource source = obstacleGO.GetComponent<AudioSource>();
                if (source != null)
                    source.Play();
            }

            // Отнимаем 1 секунду
            TimerManager.instance.AddTime(-1f);
            Debug.Log("Попала в платформу! -1 секунда");

            transform.SetParent(collision.transform);
            Debug.Log("Стрела врезалась в " + collision.gameObject.name + " и теперь двигается с ним");
        }
    }
}