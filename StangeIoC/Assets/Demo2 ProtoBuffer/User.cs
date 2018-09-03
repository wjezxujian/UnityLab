using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;

[ProtoContract]
public class User 
{
    [ProtoMember(1)]
    public int ID { get; set; }
    [ProtoMember(2)]
    public string UserName { get; set; }
    [ProtoMember(3)]
    public string Password { get; set; }
    [ProtoMember(4)]
    public int Level { get; set; }
    [ProtoMember(5)]
    public UserType _UserType { get; set; }

    public enum UserType
    {
        Master,
        Warrior
    }
}
