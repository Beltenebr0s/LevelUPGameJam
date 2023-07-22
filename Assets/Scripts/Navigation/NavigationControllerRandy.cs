using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationControllerRandy : MonoBehaviour
{
    public enum NavigationArea
    {
        PREV_TO_COMPUTER,
        COMPUTER,
        DEFAULT
    }
    public Transform target;
    public Transform previousTarget;
    public NavMeshAgent nav;
    public List<Transform> defaultNavigationNodes;
    public float stopDistance = 0.5f;
    public NavigationArea currentArea;
    public Transform computerTransform;
    public Transform prevToComputerTransform;
    public bool goToComputer = false;

    void Start()
    {
        nav = this.GetComponent<NavMeshAgent>();
        target = defaultNavigationNodes[0];
        nav.SetDestination(target.position);
    }


    void Update()
    {
        if(nav.remainingDistance <= stopDistance)
        {
            if(currentArea == NavigationArea.DEFAULT)
            {
                if (Random.value <= 0.3)
                {
                    target = prevToComputerTransform;
                    currentArea = NavigationArea.PREV_TO_COMPUTER;
                }
                else 
                {
                    target = NextDefaultPosition();
                    if (target == prevToComputerTransform)
                    {
                        currentArea = NavigationArea.PREV_TO_COMPUTER;
                    }
                }
            }
            else if (currentArea == NavigationArea.PREV_TO_COMPUTER)
            {
                target = computerTransform;
                currentArea = NavigationArea.COMPUTER;
            }
            else if (currentArea == NavigationArea.COMPUTER)
            {
                target = defaultNavigationNodes[0];
                currentArea = NavigationArea.DEFAULT;
            }
            else
            {
                // Impossible case
            }
            nav.SetDestination(target.position);
        }

    }

    private Transform NextDefaultPosition()
    {
        Transform newPosition = defaultNavigationNodes[Random.Range(0, defaultNavigationNodes.Count)];
        for(int i=0; i < 3; i++)
        {
            if(newPosition == previousTarget)
            {
                newPosition = defaultNavigationNodes[Random.Range(0, defaultNavigationNodes.Count)];
            }
        }
        previousTarget = target;
        return newPosition;
    }
}
