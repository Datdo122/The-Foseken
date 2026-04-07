using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TextMeshProUGUI textMesh;
    public AudioSource audioSource;
    public float hoverScale = 1.2f;
    private Vector3 originalScale;
    private string originalText;
    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalScale = transform.localScale;
        originalText = textMesh.text;

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * hoverScale;
        textMesh.text = "<u>" + originalText + "</u>";
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
        textMesh.text = originalText;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();
        string textName = gameObject.name; 
        if (textName == "New Game")
        {
            newGame();
        }
        else if (textName == "Continue")
        {
            continueGame();
        }
        else if (textName == "Options")
        {
            optionGame();
        }
        else if (textName == "Quit")
        {
            Application.Quit();
            Debug.Log("Quit Game");
        }
    }

    public void newGame()
    {
        SceneManager.LoadScene("Scenes_1");
    }
    public void continueGame()
    {
        Debug.Log("Continue Game");
    }
    public void optionGame()
    {
        Debug.Log("Options Game");
    }
}
