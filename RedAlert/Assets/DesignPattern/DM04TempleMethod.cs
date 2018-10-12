using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM04TempleMethod : MonoBehaviour
{
    private void Start()
    {
        IPeople people = new NorthPeople();
        people.Eat();
    }
}

public abstract class IPeople
{
    public void Eat()
    {
        OrderFood();
        EatSomething();
        PayBill();
    }

    private void OrderFood()
    {
        Debug.Log("点单");
    }

    protected virtual void EatSomething()
    {

    }

    private void PayBill()
    {
        Debug.Log("埋单");
    }
}

public class NorthPeople : IPeople
{
    protected override void EatSomething()
    {
        Debug.Log("我在吃面条");
    }
}

public class SouthPeople : IPeople
{
    protected override void EatSomething()
    {
        Debug.Log("我在吃米饭");
    }
}
