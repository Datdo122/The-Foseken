using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameObject PTSText;
    public GameObject mainMenuPanel;
    public AudioSource audioSource;
    private bool isStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }
        if (PTSText != null)
        {
            PTSText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStarted && Input.anyKeyDown)
        {
            isStarted = true;
            StartMenu();
        }
    }

    void StartMenu()
    {
        isStarted = true;
        PTSText.SetActive(false);
        mainMenuPanel.SetActive(true);
        audioSource.Play();
    }
}
