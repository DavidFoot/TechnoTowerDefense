
using System;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField] Transform m_target;
    STATES currentState;
    private Vector3 m_directionNormalized;

    enum STATES
    {
        Rotating = 0,
        Launching = 1,
        Targeting = 2,
        Explosing = 3
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = STATES.Rotating;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case STATES.Rotating:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-90f, 0f, 0f), 60f * Time.deltaTime);
                if(transform.rotation == Quaternion.Euler(-90f, 0f, 0f)) currentState = STATES.Launching;
                break;
            case STATES.Launching:
                transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 20f;
                m_directionNormalized = Vector3.Normalize(m_target.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(m_directionNormalized),
                    90f * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, m_target.position, 4f * Time.deltaTime);

                if (transform.position.y >= 25) currentState = STATES.Targeting;
                break;
            case STATES.Targeting:
                m_directionNormalized = Vector3.Normalize(m_target.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(m_directionNormalized),
                    300f*Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, m_target.position, 18f * Time.deltaTime) ;
                if ((m_target.position - transform.position).magnitude <= 1) currentState = STATES.Explosing;
                break;
            case STATES.Explosing:
                gameObject.SetActive(false);
                break;
        }    }
}
