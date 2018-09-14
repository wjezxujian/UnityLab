using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSys : MonoBehaviour
{
    //资源Model Transform
    private Transform girlSourceTrans;
    //骨架物体，换装的目标
    private GameObject girlTarget;  
    //小女孩所有的资源信息
    private Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> girlData = new Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>();
    //小女孩的所有骨骼信息
    Transform[] girlHips;
    //换装骨骼身上的Skm信息
    private Dictionary<string, SkinnedMeshRenderer> girlSmr = new Dictionary<string, SkinnedMeshRenderer>();
    //初始化信息
    private string[,] girlStr = new string[,] { { "eyes", "1" } , { "hair", "1" } , { "top", "1" }, { "pants", "1" }, { "shoes", "1" }, { "face", "1" } };

    //资源Model Transform
    private Transform boySourceTrans;
    //骨架物体，换装的目标
    private GameObject boyTarget;
    //小男孩所有的资源信息
    private Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> boyData = new Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>();
    //小男孩的所有骨骼信息
    Transform[] boyHips;
    //换装骨骼身上的Skm信息
    private Dictionary<string, SkinnedMeshRenderer> boySmr = new Dictionary<string, SkinnedMeshRenderer>();
    //初始化信息
    private string[,] boyStr = new string[,] { { "eyes", "1" }, { "hair", "1" }, { "top", "1" }, { "pants", "1" }, { "shoes", "1" }, { "face", "1" } };

    private int nowCount = 0; //0代表女孩，1代表男孩

    // Use this for initialization
    void Start()
    {
        //GirlAvatar();
        BoyAvatar();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    int num = Random.Range(1, 7);
        //    ChangeMesh("top", num.ToString());
        //}
    }

    void GirlAvatar()
    {
        InstantiateGirl();

        SaveData(girlSourceTrans, girlData, girlTarget, girlSmr);
        InitAvatarGirl();
    }

    void BoyAvatar()
    {
        InstantiateBoy();

        SaveData(boySourceTrans, boyData, boyTarget, boySmr);
        InitAvatarBoy();

        //boyTarget.SetActive(false);
    }


    void InstantiateGirl ()
    {
        GameObject go = Instantiate(Resources.Load("FemaleModel")) as GameObject;
        girlSourceTrans = go.transform;
        go.SetActive(false);

        girlTarget = Instantiate(Resources.Load("FemaleTarget")) as GameObject;
        girlHips = girlTarget.GetComponentsInChildren<Transform>();
    }

    void InstantiateBoy()
    {
        GameObject go = Instantiate(Resources.Load("MaleModel")) as GameObject;
        boySourceTrans = go.transform;
        go.SetActive(false);

        boyTarget = Instantiate(Resources.Load("MaleTarget")) as GameObject;
        boyHips = boyTarget.GetComponentsInChildren<Transform>();
    }


    void SaveData(Transform sourceTrans, Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> data, 
        GameObject target, Dictionary<string, SkinnedMeshRenderer> smr)
    {
        if (sourceTrans == null)
            return;

        //遍历所有子物体有SkinnedMeshRender 进行存储
        SkinnedMeshRenderer[] parts = sourceTrans.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach(var part in parts)
        {
            string[] names = part.name.Split('-');

            if (!data.ContainsKey(names[0]))
            {
                //生成对应的部位，且只生成一个
                GameObject partGo = new GameObject();
                partGo.name = names[0];
                partGo.transform.parent = target.transform;
                //把骨骼Target身上的的SKM信息存储到
                smr.Add(names[0], partGo.AddComponent<SkinnedMeshRenderer>());


                data.Add(names[0], new Dictionary<string, SkinnedMeshRenderer>());
            }

            //存储所有的SKM信息到数据里面
            data[names[0]].Add(names[1], part);
        }
    }

    //传入部位，编号，从data里边拿取对应的skm
    void ChangeMesh(string part, string index, Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> data, 
        Transform[] hips, Dictionary<string, SkinnedMeshRenderer> smr)
    {
        //TODO 鲁棒性判断

        //获取要更换的部位
        SkinnedMeshRenderer skm = data[part][index];

        List<Transform> bones = new List<Transform>();

        foreach(var trans in skm.bones)
        {
            foreach(var bone in hips)
            {
                if (bone.name == trans.name)
                {
                    bones.Add(bone);
                    break;
                }
            }
        }

        //换装实现
        smr[part].bones = bones.ToArray();
        smr[part].materials = skm.materials;
        smr[part].sharedMesh = skm.sharedMesh;
    }

    //初始化骨架让他有mesh材质 骨骼信息
    void InitAvatarGirl()
    {
        int length = girlStr.GetLength(0);
        for (int i = 0; i < length; ++i)
        {
            //r
            ChangeMesh(girlStr[i, 0], girlStr[i, 1], girlData, girlHips, girlSmr);
        }
    }

    //初始化骨架让他有mesh材质 骨骼信息
    void InitAvatarBoy()
    {
        int length = boyStr.GetLength(0);
        for (int i = 0; i < length; ++i)
        {
            //r
            ChangeMesh(boyStr[i, 0], boyStr[i, 1], boyData, boyHips, boySmr);
        }
    }
}
