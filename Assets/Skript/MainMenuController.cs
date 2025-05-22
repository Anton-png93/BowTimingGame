using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;         // Панель MainMenu
    public GameObject gameplayUI;       // Объект с игрой
    public GameObject[] gameObjectsToEnable;  // Объекты, которые включаются при старте

    void Start()
    {
        // 🧠 В начале скрываем игру, показываем меню
    Debug.Log("▶ Start вызван — показываю меню"); 
    gameplayUI.SetActive(false);
    mainMenu.SetActive(true);
    }

    public void OnPlayPressed()
    {
        Debug.Log("Кнопка PLAY нажата");
        // Скрываем меню, запускаем игру
        mainMenu.SetActive(false);
        gameplayUI.SetActive(true);
      

        // Включаем все нужные игровые объекты
        foreach (GameObject obj in gameObjectsToEnable)
        {
            if (obj == null)
            {
                Debug.LogError("❌ В списке gameObjectsToEnable есть пустой объект!");
            }
            else
            {
                Debug.Log("✅ Активирую: " + obj.name);
                obj.SetActive(true);
            }
        }
        TimerManager.instance.StartTimer();
    }
}