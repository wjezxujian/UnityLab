using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class DM06Composite : MonoBehaviour
{
    void Start()
    {
        DMComposite root = new DMComposite("Root");

        DMLeaf leaf1 = new DMLeaf("GameObject");
        DMLeaf leaf2 = new DMLeaf("GameObject (2)");
        DMComposite gameObject1 = new DMComposite("GameObject (1)");

        root.Add(leaf1);
        root.Add(gameObject1);
        root.Add(leaf2);

        DMLeaf child1 = new DMLeaf("GameObject");
        DMLeaf child2 = new DMLeaf("GameObject (1)");
        gameObject1.Add(child1);
        gameObject1.Add(child2);

        ReadComPonent(root);
    }

    private void ReadComPonent(DMComponent component)
    {
        Debug.Log(component.name);

        List<DMComponent> children = component.children;
        if (children == null || children.Count == 0)
            return;

        foreach(DMComponent child in children)
        {
            ReadComPonent(child);
        }
    }
}

public abstract class DMComponent
{
    protected string mName;
    public string name { get { return mName; } }
    public DMComponent(string name)
    {
        mName = name;
        mChildren = new List<DMComponent>();
    }

    protected List<DMComponent> mChildren;
    public List<DMComponent> children { get { return mChildren; } }
    public abstract void Add(DMComponent c);
    public abstract void RemoveChild(DMComponent c);
    public abstract DMComponent GetChild(int index);
}



public class DMLeaf : DMComponent
{
    public DMLeaf(string name) : base(name)
    {

    }

    public override void Add(DMComponent c)
    {
        return;
    }

    public override DMComponent GetChild(int index)
    {
        return null;
    }

    public override void RemoveChild(DMComponent c)
    {
        return;
    }
}

public class DMComposite : DMComponent
{
    public DMComposite(string name) : base(name)
    {

    }

    public override void Add(DMComponent c)
    {
        mChildren.Add(c);
    }

    public override DMComponent GetChild(int index)
    {
        return mChildren[index];
    }

    public override void RemoveChild(DMComponent c)
    {
        mChildren.Remove(c);
    }
}
