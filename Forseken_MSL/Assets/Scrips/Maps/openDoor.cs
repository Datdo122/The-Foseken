using UnityEngine;

public class openDoor : MonoBehaviour
{
    [SerializeField] Animator animatorDoor;
    [SerializeField] GameObject textOpenDoor;
    public bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isOpen == true)
        {
            animatorDoor.SetBool("isOpen", true);
            textOpenDoor.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOpen = true;
            textOpenDoor.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOpen = false;
            textOpenDoor.SetActive(false);
        }
    }
}
