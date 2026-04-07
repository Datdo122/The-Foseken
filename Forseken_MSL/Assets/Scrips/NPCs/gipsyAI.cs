using System;
using Unity.VisualScripting;
using UnityEngine;

public class gip : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbNPC;
    [SerializeField] private Animator anmNPC;

    [SerializeField] private CircleCollider2D colNPC;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anmNPC.SetFloat("idleCheck", 1f);
            Debug.Log ("Player entered the trigger");
        }
        
    }
}
