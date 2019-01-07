using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM11Vistor : MonoBehaviour
{
    private void Start()
    {
        DMShpere shpere1 = new DMShpere();
        DMCylinder cylinder = new DMCylinder();
        DMCube cube1 = new DMCube();
        DMCube cube2 = new DMCube();

        DMShapeContainer container = new DMShapeContainer();
        container.AddShape(shpere1);
        container.AddShape(cylinder);
        container.AddShape(cube1);
        container.AddShape(cube2);

        //int count = container.GetShapeCount();
        AmountVisitor amountVisitor = new AmountVisitor();
        container.RunVisitor(amountVisitor);
        int count = amountVisitor.amount;
        Debug.Log("图形总数:" + count);

        CubeAmountVisitor cubeAmountVisitor = new CubeAmountVisitor();
        container.RunVisitor(cubeAmountVisitor);
        int cubeCount = cubeAmountVisitor.amount;
        Debug.Log("Cube总数:" + cubeCount);

        EdgeVisitor edgeVisitor = new EdgeVisitor();
        container.RunVisitor(edgeVisitor);
        int edgeAmount = edgeVisitor.amount;
        Debug.Log("边总数:" + edgeAmount);

    }

}

class DMShapeContainer
{
    private List<IDMShape> mShapes = new List<IDMShape>();

    public void AddShape(IDMShape shape)
    {
        mShapes.Add(shape);
    }

    public void RunVisitor(IShapeVisitor visitor)
    {
        foreach(IDMShape shape in mShapes)
        {
            shape.RunVisitor(visitor);
        }
    }

    //public int GetShapeCount()
    //{
    //    return mShapes.Count;
    //}

    //public int GetVolum()
    //{
    //    int temp = 0;
    //    foreach(IDMShape shape in mShapes)
    //    {
    //        temp += shape.GetVolum();
    //    }

    //    return temp;
    //}
}

abstract class IDMShape
{
    //public abstract int GetVolum();
    public abstract void RunVisitor(IShapeVisitor visitor);
}

class DMShpere : IDMShape
{
    //public override int GetVolum()
    //{
    //    return 30;
    //}

    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitSphere(this);
    }
}

class DMCylinder : IDMShape
{
    //public override int GetVolum()
    //{
    //    return 20;
    //}

    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCylinder(this);
    }
}

class DMCube : IDMShape
{
    //public override int GetVolum()
    //{
    //    return 10;
    //}

    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCube(this);
    }
}

abstract class IShapeVisitor
{
    public abstract void VisitSphere(DMShpere sphere);
    public abstract void VisitCylinder(DMCylinder sphere);
    public abstract void VisitCube(DMCube sphere);
}

class AmountVisitor : IShapeVisitor
{
    public int amount;

    public override void VisitCube(DMCube sphere)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder sphere)
    {
        amount++;
    }

    public override void VisitSphere(DMShpere sphere)
    {
        amount++;
    }
}

class CubeAmountVisitor : IShapeVisitor
{
    public int amount = 0;

    public override void VisitCube(DMCube sphere)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder sphere)
    {      
    }

    public override void VisitSphere(DMShpere sphere)
    {       
    }
}

class EdgeVisitor : IShapeVisitor
{
    public int amount = 0;
    public override void VisitCube(DMCube sphere)
    {
        amount += 30;
    }

    public override void VisitCylinder(DMCylinder sphere)
    {
        amount += 4;
    }

    public override void VisitSphere(DMShpere sphere)
    {
        amount += 12;
    }
}
