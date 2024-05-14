using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Ссылка на текстовое поле для отображения счета
    public TextMeshProUGUI bestScoreText;  //сделать ввывод таблицы ласт рекордов
    public TextMeshProUGUI scoreTextNormal; // Ссылка на текстовое поле для отображения счета
    public TextMeshProUGUI bestScoreTextNormal;  //сделать ввывод таблицы ласт рекордов
    
    private int score = 0; // Переменная для хранения счета
    private int bestScore = 0; // Переменная для хранения лучшего счета
    private int scoreNormal = 0; // Переменная для хранения счета
    private int bestScoreNormal = 0; // Переменная для хранения лучшего счета

    


    

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreText();
        bestScoreNormal = PlayerPrefs.GetInt("BestScoreNormal", 0);
        UpdateScoreTextNormal();
    }

    // Функция для увеличения счета
    public void AddScore(int points)
    {
        score += points;
        if (score > bestScore)
        {
            bestScore = score; // Обновление лучшего счета, если текущий счет превышает его
            PlayerPrefs.SetInt("BestScore", bestScore); // Сохранение лучшего счета
        }
        UpdateScoreText();
    }

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
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        if (bestScoreText != null)
        {
            bestScoreText.text = "BestScore: " + bestScore;
        }
    }

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

    
    

