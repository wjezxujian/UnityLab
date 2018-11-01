using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class CharacterBuilderDirector
{
    public static ICharacter Construct(ICharacterBuilder builder)
    {
        builder.AddCharacterAttr();
        builder.AddGameObject();
        builder.AddWeapon();
        return builder.GetResult();
    }
}
