using NUnit.Framework;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    
    [SerializeField] private GameObject checkPointActive;
    [SerializeField] private Animator animCheckPoint;
    public bool checkpoint = false;
    public bool isSavePoint = false;
    private float speedCheckPoint = 2f;
    private Vector3 targetPosition;
    public SaveGame saveGame;
    public int idCheckPoint = 0;
    private bool isRising = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSavePoint == true && Input.GetKeyDown(KeyCode.F) && checkpoint == false)
        {
            checkPointActive.SetActive(false);
            animCheckPoint.SetBool("checkPoint", true);
            checkpoint = true;
            isRising = true;
            targetPosition = transform.position + new Vector3(0f, 1f, 0f);
            saveGame.SavePosition(transform.position, idCheckPoint);
        }

        if (isRising)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, speedCheckPoint * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                transform.position = targetPosition;
                isRising = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && checkpoint == false)
        {
            checkPointActive.SetActive(true);
            isSavePoint = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && checkpoint == false)
        {
            checkPointActive.SetActive(false);
            isSavePoint = false;
        }
    }
}
