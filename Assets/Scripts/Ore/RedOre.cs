using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RedOre : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public string playerTag = "Player";
    public MeshRenderer rendererToHide;
    public MeshRenderer rendererToShow;
    public float gatheringRate = 1f;
    public int resourcePerGather = 1;
    public TextMeshProUGUI text;

    private bool isGathering = false;
    private float timer = 0f;
    private int sum = 0;
    PlayerResources Tree;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isGathering = true;
            HideObject();
            ShowObject();
            ChangeAnimation("Dizzy");
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag(playerTag))
        {
            isGathering = false;
            timer = 0f;
            HideShowObject();
            ShowHideObject();
        }
    }
    private void ChangeAnimation(string animation)
    {
        if (animator == null)
        {
            Debug.LogError("Animator component is not assigned.");
            return;
        }

        if (!animator.HasState(0, Animator.StringToHash(animation)))
        {
            Debug.LogError("Animation state '" + animation + "' not found.");
            return;
        }

        animator.Play(animation);

    }

    private void Update()
    {
        if (isGathering)
        {
            timer += Time.deltaTime;

            if (timer >= 1f / gatheringRate)
            {
                
                AddResources();
                PlayerResources.Rubi += resourcePerGather;
                timer = 0f;
            }
        }
    }

    private void AddResources()
    {
        Debug.Log("Игроку добавлено " + resourcePerGather + " рубина");
    }

    private void HideObject()
    {
        if (rendererToHide != null)
        {
            rendererToHide.enabled = false;
        }
    }

    private void ShowObject()
    {
        if (rendererToShow != null)
        {
            rendererToShow.enabled = true;
        }
    }
    private void ShowHideObject()
    {
        if (rendererToHide != null)
        {
            rendererToShow.enabled = false;
        }
    }
    private void HideShowObject()
    {
        if (rendererToShow != null)
        {
            rendererToHide.enabled = true;
        }
    }
}
