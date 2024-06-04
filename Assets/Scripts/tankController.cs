using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tankController : MonoBehaviour
{
    [SerializeField] Transform m_target;
    [SerializeField] float m_velocity = 0.3f;
    private Vector3 m_direction;
    private Vector3 m_directionNormalized;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_direction = m_target.position - transform.position;
        m_directionNormalized  = m_direction.normalized;
        //transform.rotation = Quaternion.LookRotation(m_directionNormalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(m_directionNormalized), 2f * Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(m_directionNormalized), 2f * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position,m_target.position, m_velocity * Time.deltaTime);
        //transform.Translate(m_directionNormalized * m_velocity *Time.deltaTime); // Dépendant de l'orientation et ca part dans tout les sens
        //transform.position += m_directionNormalized * m_velocity * Time.deltaTime;

    }
}
