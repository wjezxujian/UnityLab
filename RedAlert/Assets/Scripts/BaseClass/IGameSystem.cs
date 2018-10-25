using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class IGameSystem
{
    public virtual void Init(){ }
    public virtual void Update(){ }
    public virtual void Release(){ }
}