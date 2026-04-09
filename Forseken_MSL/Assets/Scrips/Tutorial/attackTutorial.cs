using UnityEngine;
using TMPro;

public class attackTutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject[] text;
    [SerializeField] GameObject textHoldcount;
    public TextMeshProUGUI textHold;
    [SerializeField] GameObject cutscene;
    [SerializeField] GameObject player;
    public float holdTime = 3f;
    public float timer = 0f;
    public bool isHolding = false;

    public bool isskip = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isskip == true)
        {
            isHolding = true;
            text[3].SetActive(false);
            timer += Time.deltaTime;
            textHoldcount.SetActive(true);
            textHold.text = Mathf.Ceil(holdTime - timer).ToString();
            if (timer >= holdTime)
            {
                ExcuteAction();
            }
        }
        else
        {
            isHolding = false;
            text[3].SetActive(true);
            timer = 0f;
            textHoldcount.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cutscene.SetActive(true);
            player.SetActive(false);
            isskip = true;
        }
    }

    void ExcuteAction()
    {
        player.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
    
    void enableText0()
    {  
        text[0].SetActive(true);
        
    }
    void enableText1()
    {  
        text[1].SetActive(true);
    }
    void enableText2()
    {  
        text[2].SetActive(true);
    }
    void disenableText0()
    {  
        text[0].SetActive(false);
    }
    void disenableText1()
    {  
        text[1].SetActive(false);
    }
    void disenableText2()
    {  
        text[2].SetActive(false);
    }

    void endCutscene()
    {
        player.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
