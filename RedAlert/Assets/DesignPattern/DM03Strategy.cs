using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM03Strategy : MonoBehaviour
{
    private void Start()
    {
        StrategyContext context = new StrategyContext();
        context.strategy = new ConcreateStrategyB();
        context.Cal();
    }
}

public class StrategyContext
{
    public IStrategy strategy;
    public void Cal()
    {
        strategy.Cal();
    }
}

public interface IStrategy
{
    void Cal();
}

public class ConcreateStrategyA : IStrategy
{
    public void Cal()
    {
        Debug.Log("使用A策略计算");
    }
}

public class ConcreateStrategyB : IStrategy
{
    public void Cal()
    {
        Debug.Log("使用B策略计算");
    }
}