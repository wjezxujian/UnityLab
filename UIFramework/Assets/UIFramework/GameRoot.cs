using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //UIManager.Instance.Test();
        UIManager.Instance.PushPanel(UIPanelType.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
