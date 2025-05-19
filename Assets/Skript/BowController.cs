using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public AudioSource bowShotSound;
    public GameObject arrowReady;
    public ScoreManager scoreManager;

    private float arrowSpeed = 40f;

    // 👉 Добавляем переменные для автодвижения лука:
    private float autoMoveSpeed = 0f;       // текущая скорость автодвижения
    private float autoMoveAmplitude = 2f;   // амплитуда колебаний (размах влево-вправо)
    private Vector3 startPosition;          // исходная позиция лука
    private bool isAutoMoving = false;      // включено ли автодвижение

    void Start()
    {
        startPosition = transform.position; // ✅ сохраняем начальную позицию лука
        arrowReady.SetActive(true);         // Показываем стрелу на луке
    }

    void Update()
    {
       // Выстрел по пробелу (ПК) и по касанию (мобильные устройства)
if ((Input.GetKeyDown(KeyCode.Space) || 
    (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) 
    && !bowShotSound.isPlaying)
{
    ShootArrow();
}

        // 👉 Управление стрелками на ПК для теста:
        float moveX = Input.GetAxisRaw("Horizontal");
        if (moveX != 0)
        {
            transform.position += new Vector3(moveX, 0, 0) * Time.deltaTime * 5f;
        }

        // 👉 Включаем автодвижение после 50 очков:
        if (GameManager.instance.GetScore() >= 50)
        {
            isAutoMoving = true;

            // Увеличиваем скорость каждые 10 очков
            int bonusSpeed = (GameManager.instance.GetScore() - 50) / 10;
            autoMoveSpeed = 1.5f + bonusSpeed * 0.5f; // начальная скорость 0.5, увеличивается
        }

        // 👉 Выполняем автодвижение, если оно активно
        if (isAutoMoving)
        {
            float offset = Mathf.PingPong(Time.time * autoMoveSpeed, autoMoveAmplitude * 2) - autoMoveAmplitude;
            transform.position = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
        }
    }

    void ShootArrow()
    {
        bowShotSound.Play();
        arrowReady.SetActive(false);

        
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);
        arrow.GetComponent<Arrow>().scoreManager = scoreManager;
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * arrowSpeed;

        Debug.Log("Стрела вылетела!");
        Invoke(nameof(ShowArrowOnBow), 1f);
    }

    void ShowArrowOnBow()
    {
        arrowReady.SetActive(true);
    }
}
