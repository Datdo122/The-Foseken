using UnityEngine;

public class checkTutorial : MonoBehaviour
{
    [SerializeField] GameObject frameTutorial;
    void Start()
    {
        
    }
    void  OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            frameTutorial.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
