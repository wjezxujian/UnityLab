using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DestoryForTime : MonoBehaviour
{
    private float m_time = 1;

    public float time { set { m_time = value; } get { return m_time; } }

    private void Start()
    {
        Invoke("OnDestroy", m_time);
    }

    private void OnDestroy()
    {
        GameObject.DestroyImmediate(this.gameObject);
    }
}
