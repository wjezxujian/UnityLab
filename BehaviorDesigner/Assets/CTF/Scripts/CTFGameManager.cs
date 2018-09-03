using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CTFGameManager : MonoBehaviour
{
    private static CTFGameManager _instace;

    public static CTFGameManager Instance
    {
        get
        {
            return _instace;
        }
    }

    private List<BehaviorTree> flagNotTakenBehaviorTrees = new List<BehaviorTree>();
    private List<BehaviorTree> flagTakenBehaviorTrees = new List<BehaviorTree>();

    public void Awake()
    {
        _instace = this;
    }


    // Use this for initialization
    void Start()
    {
        //得到场景中所有的行为树
        BehaviorTree[] bts = FindObjectsOfType<BehaviorTree>();

        foreach(var bt in bts)
        {
            if(bt.Group == 1)
            {
                flagNotTakenBehaviorTrees.Add(bt);
            }
            else
            {
                flagTakenBehaviorTrees.Add(bt);
            }
        }

    }

    public void TakenFlag()
    {
        foreach(var bt in flagNotTakenBehaviorTrees)
        {
            if(BehaviorManager.instance.IsBehaviorEnabled(bt))
            {
                //禁用自身
                bt.DisableBehavior();
            }
        }

        foreach (var bt in flagTakenBehaviorTrees)
        {
            if (!BehaviorManager.instance.IsBehaviorEnabled(bt))
            {
                //启用自身
                bt.EnableBehavior();
            }
        }
    }

    public void DropFlag()
    {
        foreach (var bt in flagTakenBehaviorTrees)
        {
            if (BehaviorManager.instance.IsBehaviorEnabled(bt))
            {
                //禁用自身
                bt.DisableBehavior();
            }
        }

        foreach (var bt in flagNotTakenBehaviorTrees)
        {
            if (!BehaviorManager.instance.IsBehaviorEnabled(bt))
            {
                //启用自身
                bt.EnableBehavior();
            }
        }
    } 

    // Update is called once per frame
    void Update()
    {

    }
}
