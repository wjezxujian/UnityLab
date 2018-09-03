using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveForTime : MonoBehaviour
{

    // Use this for initialization
    void OnEnable()
    {
        Invoke("Deactive", 3);
    }

    // Update is called once per frame
    void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}
