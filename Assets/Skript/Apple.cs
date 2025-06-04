using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioSource hitSource;
    public TimerManager timerManager;
    public ScoreManager scoreManager;
      void Start()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Target");
        if (target != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), target.GetComponent<Collider2D>());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Arrow"))
        {
            if (hitSource != null)
                hitSource.Play(); // Звук хруста

            if (timerManager != null)
                timerManager.AddTime(6f);   // +6 секунд

            if (scoreManager != null)
                scoreManager.AddPoints(6);  // +6 очков

            // Закрепляем стрелу на яблоке
            collision.collider.transform.SetParent(transform);
            collision.collider.attachedRigidbody.bodyType = RigidbodyType2D.Kinematic;
            collision.collider.attachedRigidbody.linearVelocity = Vector2.zero;
            collision.collider.attachedRigidbody.angularVelocity = 0f;
        }
    }
}