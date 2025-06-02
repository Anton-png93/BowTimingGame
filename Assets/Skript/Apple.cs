using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioSource hitSound;
    public TimerManager timerManager;
    public ScoreManager scoreManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Arrow"))
        {
            if (hitSound != null)
                hitSound.Play();

            if (timerManager != null)
                timerManager.AddTime(6f);

            if (scoreManager != null)
                scoreManager.AddPoints(6);

            Destroy(gameObject);
        }
    }
}