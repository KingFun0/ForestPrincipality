using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerResources : MonoBehaviour
{
    public SqliteConnection dbConnection;
    private string path;


    public static string loginPlayer;
    public static int Tree, Gold, Lazur, Rubi, Coins;
    public TMP_Text playerText1, playerText2, playerText3, playerText4;
    private void Start()
    {
        LoadPlayerResources();
    }
    private void Awake()
    {
        SetConnection();
        
    }
    private void Update()
    {
        playerText1.text = Tree.ToString();
        playerText2.text = Gold.ToString();
        playerText3.text = Lazur.ToString();
        playerText4.text = Rubi.ToString();
        UpdatePlayerResources();
    }

    public void SetConnection()
    {
        path = Application.dataPath + "/BD/DataBase/db.db";
        dbConnection = new SqliteConnection("URI=file:" + path);

        dbConnection.Open();
        if (dbConnection.State == ConnectionState.Open)
        {
            Debug.Log("Да");
        }
        else
        {
            Debug.Log("Îøèáêà ïîäêëþ÷åíèÿ");
        }
    }

    public void UpdatePlayerResources()
    {
        // Проверяем, открыта ли соединение с базой данных
        if (dbConnection.State != ConnectionState.Open)
        {
            Debug.LogError("Соединение с базой данных не открыто.");
            return;
        }

        // SQL-запрос для обновления данных о ресурсах игрока
        string updateQuery = "UPDATE lal SET Tree = @tree, Gold = @gold, Lapis = @lapis, Ruby = @ruby, Coins = @coins WHERE login = @login";

        using (SqliteCommand cmd = new SqliteCommand(updateQuery, dbConnection))
        {
            // Добавляем параметры к запросу
            cmd.Parameters.AddWithValue("@tree", Tree);
            cmd.Parameters.AddWithValue("@gold", Gold);
            cmd.Parameters.AddWithValue("@lapis", Lazur);
            cmd.Parameters.AddWithValue("@ruby", Rubi);
            cmd.Parameters.AddWithValue("@coins", Coins);
            cmd.Parameters.AddWithValue("@login", loginPlayer);

            // Выполняем запрос
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Debug.Log("Данные о ресурсах игрока успешно обновлены.");
            }
            else
            {
                Debug.LogError("Ошибка обновления данных о ресурсах игрока.");
            }
        }
    }

    public void LoadPlayerResources()
    {
        string selectQuery = "SELECT Tree, Gold, Lapis, Ruby, Coins FROM lal WHERE login = @login";
        using (SqliteCommand cmd = new SqliteCommand(selectQuery, dbConnection))
        {
            cmd.Parameters.AddWithValue("@login", loginPlayer);
            using (SqliteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Tree = reader.GetInt32(0);
                    Gold = reader.GetInt32(1);
                    Lazur = reader.GetInt32(2);
                    Rubi = reader.GetInt32(3);
                    Coins = reader.GetInt32(4);

                    playerText1.text = Tree.ToString();
                    playerText2.text = Gold.ToString();
                    playerText3.text = Lazur.ToString();
                    playerText4.text = Rubi.ToString();
                }
                else
                {
                    Debug.LogError("Все загрузилось.");
                }
            }
        }
    }

}
