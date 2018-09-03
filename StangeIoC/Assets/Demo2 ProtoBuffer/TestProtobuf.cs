using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ProtoBuf;

public class TestProtobuf : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        DeSerialize();







    }

    void Serialize()
    {
        //序列化
        User user = new User();
        user.ID = 100;
        user.UserName = "siki";
        user.Password = "123456";
        user.Level = 100;
        user._UserType = User.UserType.Master;

        using (FileStream fs = File.Create(Application.dataPath + "/user.bin"))
        {
            Serializer.Serialize<User>(fs, user);
        }
    }

    void DeSerialize()
    {
        //反序列化
        User user = null;
        using (var fs = File.OpenRead(Application.dataPath + "/user.bin"))
        {
            user = Serializer.Deserialize<User>(fs);
        }

        print(user.ID);
        print(user.UserName);
        print(user._UserType);
        print(user.Password);
        print(user.Level);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
