using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class LoadFromFileExample : MonoBehaviour {

    // Use this for initialization
    IEnumerator Start() {
        string path = "AssetBundles/scene/cube.unity3d";
        //AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/scene/cube.unity3d");
        //AssetBundle shareAB = AssetBundle.LoadFromFile("AssetBundles/scene/share");
        //GameObject wallPrefab = ab.LoadAsset<GameObject>("Cube");
        ////Object[] objs = ab.LoadAllAssets();
        //Instantiate(wallPrefab);

        ////foreach(Object obj in objs)
        ////{
        ////    Instantiate(obj);
        ////}

        //第一种加载AB的方式
        ////异步内存加载
        //AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        //yield return request;
        //AssetBundle ab = request.assetBundle;
        ////同步内存加载
        //AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));

        //第二种加载AB的方式LoadFromFile
        //AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
        //yield return request;
        //AssetBundle ab = request.assetBundle;

        //第三种加载AB的方式LoadFromCacheOrDownload
        //while (!Caching.ready)
        //{
        //    yield return null;
        //}
        ////file:// file:///
        ////var www = WWW.LoadFromCacheOrDownload(@"file://D:\Projects\AssetBundleProject\AssetBundles\scene\cube.unity3d", 1);
        //WWW www = WWW.LoadFromCacheOrDownload(@"http://localhost/AssetBundles/scene/cube.unity3d", 1);
        //yield return www;
        //if (!string.IsNullOrEmpty(www.error))
        //{
        //    Debug.Log(www.error);
        //    yield break;
        //}

        //AssetBundle ab = www.assetBundle;

        //第四种加载AB的方式 UnityWebRequest被2018弃用
        //string uri = @"file://D:\Projects\AssetBundleProject\AssetBundles\scene\cube.unity3d";
        //UnityWebRequest request = new UnityWebRequest(uri);
        //yield return request.SendWebRequest();
        ////AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        //AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;

        //第四种加载AB的方式 
        //string uri = @"file://D:\Projects\AssetBundleProject\AssetBundles\scene\cube.unity3d";
        string uri = @"http://localhost/AssetBundles/scene/cube.unity3d";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri);
        yield return request.SendWebRequest();
        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;


        GameObject wallPrefab = ab.LoadAsset<GameObject>("Cube");
        Instantiate(wallPrefab);


        AssetBundle manifestAB = AssetBundle.LoadFromFile("AssetBundles/AssetBundles");
        AssetBundleManifest manifest = manifestAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        foreach (string name in manifest.GetAllAssetBundles())
        {
            print(name);
        }

        string[] strs = manifest.GetAllDependencies("scene/cube.unity3d");
        foreach (string name in strs)
        {
            print(name);
            AssetBundle.LoadFromFile("AssetBundles/" + name);
        }


	}


}
