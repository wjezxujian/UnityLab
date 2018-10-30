using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class SoldierFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();

        ICharacterBuilder builder = new SoldierBuilder(character, typeof(T), weaponType, spawnPosition, lv);-

        return CharacterBuilderDirector.Construct(builder);
    }
}
