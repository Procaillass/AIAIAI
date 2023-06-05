using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AiPersonBrain : MonoBehaviour
{

    #region Public Members

    public Transform player; // La reference au GameObject du joueur
    public float moveDistance = 20f; // La distance que le personnage doit se d�placer

    #endregion

    #region Unity API

    void Start()
    {
        _navmeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Calculez la position de destination dans la direction opposée à celle de la vue du joueur
        Vector3 oppositeDirection = player.forward * -1;
        Vector3 destination = transform.position + oppositeDirection * moveDistance;

        // Deplacez le personnage vers la destination
        _navmeshAgent.SetDestination(destination);
    }


    void Update()
    {

        if (!Input.GetMouseButtonDown(1)) return;

        RaycastHit hit;
        Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(pos, out hit)) return;

        _navmeshAgent.SetDestination(hit.point);

    }
    #endregion
    #region Main Methods




    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members

    private UnityEngine.AI.NavMeshAgent _navmeshAgent;
    
    #endregion


}
