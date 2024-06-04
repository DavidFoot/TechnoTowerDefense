using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private float m_fireRange;
    [SerializeField] private float m_lookRange;
    [SerializeField] private float m_rotationSpeedInDegrees = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var inputX = Input.GetAxis("Horizontal");
        //transform.rotation *= Quaternion.Euler(0, inputX * m_rotationSpeeInDegrees * Time.deltaTime,0);

        Vector3 direction = m_target.position - transform.position;
        var sqrMagnitude = direction.sqrMagnitude;
        //Debug.Log("Distance actuelle : " + sqrMagnitude + " Distance de detection :" + m_fireRange* m_fireRange);
        if (sqrMagnitude < m_fireRange * m_fireRange)
        {
            var normalizedDirection = Vector3.Normalize(direction);
            var forward = transform.forward;
            //Debug.Log("Dot : " + Vector3.Dot(forward, normalizedDirection) + " lookRange :" + m_lookRange);
            if (Vector3.Dot(forward, normalizedDirection) > m_lookRange)
            {
                //transform.rotation = Quaternion.LookRotation(normalizedDirection);
                //transform.rotation = Quaternion.Lerp(
                //        transform.rotation, 
                //        Quaternion.LookRotation(normalizedDirection),
                //        m_rotationSpeedInDegrees * Time.deltaTime);
                transform.rotation = Quaternion.RotateTowards(
                  transform.rotation,
                  Quaternion.LookRotation(normalizedDirection),
                  m_rotationSpeedInDegrees * Time.deltaTime);
            }
        }
    }
}
