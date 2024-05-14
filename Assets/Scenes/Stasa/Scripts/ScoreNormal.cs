using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreManagerNormal : MonoBehaviour
{
    
    public TextMeshProUGUI scoreTextNormal; // Ссылка на текстовое поле для отображения счета
    public TextMeshProUGUI bestScoreTextNormal;  //сделать ввывод таблицы ласт рекордов
    
    
    private int scoreNormal = 0; // Переменная для хранения счета
    private int bestScoreNormal = 0; // Переменная для хранения лучшего счета

    


    

    void Start()
    {
        
        bestScoreNormal = PlayerPrefs.GetInt("BestScoreNormal", 0);
        UpdateScoreTextNormal();
    }

    // Функция для увеличения счета
    

     public void AddScoreNormal(int points)
    {
        scoreNormal += points;
        if (scoreNormal > bestScoreNormal)
        {
            bestScoreNormal = scoreNormal; // Обновление лучшего счета, если текущий счет превышает его
            PlayerPrefs.SetInt("BestScoreNormal", bestScoreNormal); // Сохранение лучшего счета
        }
        UpdateScoreTextNormal();
    }

    // Функция для обновления текстового поля счета
    

    void UpdateScoreTextNormal()
    {
        if (scoreTextNormal != null)
        {
            scoreTextNormal.text = "ScoreNormal: " + scoreNormal;
        }

        if (bestScoreTextNormal != null)
        {
            bestScoreTextNormal.text = "BestScoreNormal: " + bestScoreNormal;
        }
    }
}

    
    

