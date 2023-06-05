using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;
using UnityEngine;

public class CharaterSystem : MonoBehaviour
{
    private NavMeshAgent _navmeshAgent;
    
    #region Unity API
    
    void Start()
    {
        _navmeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        if (!Input.GetMouseButtonDown(0)) return;
        
        RaycastHit hit;
        Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(pos, out hit)) return;
            
        _navmeshAgent.SetDestination(hit.point);

    }

    #endregion

}
