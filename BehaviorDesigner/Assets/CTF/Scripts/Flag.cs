using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Offense owner;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Offense")
        {
            //owner不等于空则交换，等于空触发获得旗帜状态机
            if(owner != null)
            {
                owner.hasFlag = false;
            }
            else
            {
                CTFGameManager.Instance.TakenFlag();
            }

            owner = other.GetComponent<Offense>();
            owner.hasFlag = true;
            transform.parent = other.transform;
        }
    }
}
