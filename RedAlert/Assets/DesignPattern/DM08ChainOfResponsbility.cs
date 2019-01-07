using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class DM08ChainOfResponsbility : MonoBehaviour
{
    private void Start()
    {
        char problem = 'c';

        //switch (problem)
        //{
        //    case 'a':
        //        new DMHandleA().Handle();
        //        break;
        //    case 'b':
        //        new DMHandleB().Handle();
        //        break;
        //    default:
        //        break;
        //}

        DMHandleA handlerA = new DMHandleA();
        DMHandleB handlerB = new DMHandleB();
        DMHandleC handlerC = new DMHandleC();
        handlerA.SetNextHandler(handlerB).SetNextHandler(handlerC); 
        handlerA.Handle(problem);
    }
}

public abstract class IDMHandler
{
    protected IDMHandler mNextHandler = null;

    public IDMHandler nextHandler
    {
        set
        {
            mNextHandler = value;
        }
    }

    public IDMHandler SetNextHandler(IDMHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }

    public virtual void Handle(char problem)
    {

    }
}


class DMHandleA : IDMHandler
{
    public override void Handle(char problem)
    {
        if(problem == 'a')
        {
            Debug.Log("处理完了A问题");
        }
        else
        {
            if(mNextHandler != null)
            {
                mNextHandler.Handle(problem);
            }
        }
        
    }
}

class DMHandleB : IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'b')
        {
            Debug.Log("处理完了B问题");
        }
        else
        {
            if (mNextHandler != null)
            {
                mNextHandler.Handle(problem);
            }
        }   
    }
}

class DMHandleC : IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'c')
        {
            Debug.Log("处理完了C问题");
        }
        else
        {
            if (mNextHandler != null)
            {
                mNextHandler.Handle(problem);
            }
        }
    }
}