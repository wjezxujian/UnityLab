using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offense : MonoBehaviour
{
    public bool hasFlag = false;
    private Vector3 startPosition;
    private Quaternion startRotation;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Defense")
        {
            if(hasFlag)
            {
                hasFlag = false;
                CTFGameManager.Instance.DropFlag();

                if(transform.childCount > 0)
                {
                    Transform flagTrans = transform.GetChild(0);
                    flagTrans.GetComponent<Flag>().owner = null;
                    flagTrans.parent = null;
                
                }

                transform.position = startPosition;
                transform.rotation = startRotation;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
