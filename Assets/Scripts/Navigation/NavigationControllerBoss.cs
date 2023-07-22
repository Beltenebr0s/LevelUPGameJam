using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationControllerBoss : MonoBehaviour
{
    public List<Transform> navigationNodes;
    public Transform initialNode;
    public Transform finalNode;
    private int nodeIndex;

    public NavMeshAgent nav;

    private Transform target;

    public float stopDistance = 0.5f;
    
    public float waitTime = 5f;

    public bool goBack = false;

    void Start()
    {
        nodeIndex = 1;
        target = initialNode;
        nav = this.GetComponent<NavMeshAgent>();
        nav.SetDestination(target.position);
    }

    void Update()
    {
        if(nav.remainingDistance <= stopDistance)
        {
            if(target == finalNode)
            {
                StartCoroutine(BossWait());
                goBack = true;
            }
            else if (target == initialNode)
            {
                StartCoroutine(BossWait());
                goBack = false;
            }
            target = NextTarget();
            nav.SetDestination(target.position);
        }
    }

    private Transform NextTarget()
    {
        if(goBack)
        {
            nodeIndex--;
        }
        else
        {
            nodeIndex++;
        }
        return navigationNodes[nodeIndex];
    }

    private IEnumerator BossWait()
    {
        yield return new WaitForSeconds(waitTime);
    }
}
