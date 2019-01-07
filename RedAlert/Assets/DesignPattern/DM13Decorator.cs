using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class DM13Decorator : MonoBehaviour
{
    private void Start()
    {
        Coffee coffee = new Espresso();
        coffee = coffee.AddDecorator(new Mocha());
        coffee = coffee.AddDecorator(new Mocha());
        coffee = coffee.AddDecorator(new Whip());

        Debug.Log("价格：" + coffee.Cost());
        Debug.Log("容量：" + coffee.Capacity());
    }
}

public abstract class Coffee
{
    public abstract double Cost();
    public abstract double Capacity();
    public Coffee AddDecorator(Decorator decoder)
    {
        decoder.coffee = this;
        return decoder;
    }
}

public class Espresso : Coffee
{
    public override double Capacity()
    {
        return 10;
    }

    public override double Cost()
    {
        return 2.5;
    }
}

public class Decaf : Coffee
{
    public override double Capacity()
    {
        return 10;
    }

    public override double Cost()
    {
        return 2;
    }
}

public class Decorator : Coffee
{
    protected Coffee mCoffee;

    public override double Cost()
    {
        return mCoffee.Cost();
    }

    public override double Capacity()
    {
        return mCoffee.Capacity();
    }

    public Coffee coffee { get { return mCoffee; } set { mCoffee = value; } }
}

public class Mocha : Decorator
{
    public override double Cost()
    {
        return mCoffee.Cost() + 0.1;
    }
}

public class Whip : Decorator
{
    public override double Cost()
    {
        return mCoffee.Cost() + 0.5;
    }
}

