using UnityEngine.UI; // Для доступа к типу Button
using UnityEngine;

public class LockUnLockButton : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    public Image image;
    public Image image2;
    public Image image3;
    private void Start()
    {
        button1.enabled = false;
        button2.enabled = false;
        button3.enabled = false;
    }
    void Update()
    {
        CheckAndUnlockButtons();
    }

    void CheckAndUnlockButtons()
    {
        if (GameObject.Find("Musor7") == null || GameObject.Find("Musor6") == null)
        {
            button1.enabled = true; 
            image.enabled = false;
        }

        if (GameObject.Find("Musor5") == null || GameObject.Find("Musor4") == null || GameObject.Find("Musor3") == null)
        {
            button2.enabled = true;
            image2.enabled = false;
        }

        if (GameObject.Find("Musor") == null || GameObject.Find("Musor1") == null || GameObject.Find("Musor2") == null)
        {
            button3.enabled = true;
            image3.enabled = false;
        }
    }
}
