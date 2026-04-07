using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TestAI : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform playerTransform;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(playerTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
