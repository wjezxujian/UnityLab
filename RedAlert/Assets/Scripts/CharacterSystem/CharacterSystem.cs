using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CharacterSystem : IGameSystem
{
    protected List<ICharacter> mEnemys = new List<ICharacter>();
    protected List<ICharacter> mSoldiers = new List<ICharacter>();

    public void AddEnemy(IEnemy enemy)
    {
        mEnemys.Add(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemys.Remove(enemy);
    }

    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }

    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }

  
    public override void Update()
    {
        UpdateEnemys();
        UpdateSoldiers();
    }

    protected void UpdateEnemys()
    {
        foreach (IEnemy e in mEnemys)
        {
            e.Update();
            e.UpdateFSMAI(mSoldiers);
        }
    }

    protected void UpdateSoldiers()
    {
        foreach (ISoldier s in mSoldiers)
        {
            s.Update();
            s.UpdateFSMAI(mEnemys);
        }
    }
}
