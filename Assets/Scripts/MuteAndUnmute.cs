using UnityEngine;
using UnityEngine.UI;

public class MuteAndUnmute : MonoBehaviour
{
    public AudioSource audioSource;
    public Image buttonImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private bool isMuted = false;
    private const string MutePreferenceKey = "IsMuted";

    void Start()
    {
        GameObject audioSourceObject = GameObject.FindGameObjectWithTag("BG_MUSIC_CREATED");
        if (audioSourceObject != null)
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("������ � ����� 'BG_MUSIC_CREATED' �� ������.");
        }

        if (audioSource == null)
        {
            Debug.LogError("��������� AudioSource �� ������ �� ������� � ����� 'BG_MUSIC_CREATED'.");
        }
        else
        {
            if (audioSource == null || buttonImage == null)
            {
                Debug.LogError("AudioSource ��� Image �� ���������!");
            }
            isMuted = PlayerPrefs.GetInt(MutePreferenceKey, 0) == 1;
            audioSource.mute = isMuted;
            buttonImage.sprite = isMuted ? soundOffSprite : soundOnSprite;
        }
    }

    public void ToggleAudioAndImage()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
        buttonImage.sprite = isMuted ? soundOffSprite : soundOnSprite;
        PlayerPrefs.SetInt(MutePreferenceKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}
