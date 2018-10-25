using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class EnemyFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        throw new NotImplementedException();
    }
}
