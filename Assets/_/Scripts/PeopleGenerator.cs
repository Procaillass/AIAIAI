using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleGenerator : MonoBehaviour
{
    #region Public Members

    public GameObject m_Person;
    public int m_maxPersons = 5;

    public float m_rangeMin;
    public float m_rangeMax;
    public Transform m_playerTransform;

    #endregion

    #region Unity API
       void Start()
    {
        m_persons = new List<GameObject>();
    }

    void Update()
    {
        while (m_persons.Count < m_maxPersons)
        {
            GeneratePeople();
        }

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        for (int i = m_persons.Count - 1; i >= 0; i--)
        {
            if (Vector3.Distance(m_persons[i].transform.position, m_playerTransform.position) > m_rangeMax ||
                !GeometryUtility.TestPlanesAABB(planes, m_persons[i].GetComponent<Renderer>().bounds))
            {
                Destroy(m_persons[i]);
                m_persons.RemoveAt(i);
            }
        }
    }
    #endregion

    #region Main Methods

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(m_playerTransform.position, m_rangeMin);
        Gizmos.DrawWireSphere(m_playerTransform.position, m_rangeMax);
    }

    public void GeneratePeople()
    {
        //angle et distance
        float angle = Random.Range(0f, 360f);
        float distance = Random.Range(m_rangeMin, m_rangeMax);

        // Converti polar en Cartesian
        float x = distance * Mathf.Cos(angle);
        float z = distance * Mathf.Sin(angle);

        Vector3 randomSpawnPosition = new Vector3(x, 1, z) + m_playerTransform.position;

        
        RaycastHit hit;
        if (!Physics.Raycast(randomSpawnPosition + Vector3.up * 100, Vector3.down, out hit)) return;
        if (!hit.collider.CompareTag("Trotoire")) return;
        randomSpawnPosition.y = hit.point.y + 1;
                
        Vector3 directionToPlayer = (m_playerTransform.position - randomSpawnPosition).normalized;

        Quaternion rotation = Quaternion.LookRotation(directionToPlayer);

       
        GameObject person = Instantiate(m_Person, randomSpawnPosition, rotation);
        m_persons.Add(person);
    }
    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members

    private List<GameObject> m_persons;
    #endregion
}
