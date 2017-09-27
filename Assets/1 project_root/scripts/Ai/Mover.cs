using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public Transform m_Target;
    public bool m_AutoStart = true;
    public float m_StartDelay = 0f;
    public float m_speed;
    public bool m_IsPlayMove = false;

    Transform _trans;
    Rigidbody _rigid;

    void Start()
    {
        _trans = transform;
        _rigid = GetComponent<Rigidbody>();

        if (m_AutoStart == true)
        {
            PlayMove();
        }
    }
    public void PlayMove()
    {
        Invoke("SetPlayMove", m_StartDelay);
    }
    void SetPlayMove()
    {
        
        m_IsPlayMove = true;
    }
    void moveStep()
    {
        Vector3 movement;
        if (m_Target != null)
        {
            _trans.LookAt(new Vector3(m_Target.position.x, _trans.position.y, m_Target.position.z ) );
            movement = _trans.forward;
        }else
        {
            movement = _trans.forward;
        }
        _rigid.velocity = movement * m_speed;

    }

    void LateUpdate()
    {
        if (m_IsPlayMove == true)
        {
            moveStep();
        }else
        {
            _rigid.velocity = Vector3.zero;
        }
    }
}
