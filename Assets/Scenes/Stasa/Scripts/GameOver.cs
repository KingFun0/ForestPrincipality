using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen; // Префаб экрана смерти (панель)
    public Button mainMenuButton; // Кнопка перехода в главное меню

    void Start()
    {
        // Скрываем экран смерти при старте
        if (deathScreen != null)
            deathScreen.SetActive(false);

        // Назначаем кнопку перехода в главное меню
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ShowDeathScreen();
        }
    }

    void ShowDeathScreen()
    {
        // Отображаем экран смерти
        if (deathScreen != null)
            deathScreen.SetActive(true);
            
    }

    void ReturnToMainMenu()
    {
        // Загрузка главного меню - замените "MainMenuScene" на имя вашей сцены главного меню
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
