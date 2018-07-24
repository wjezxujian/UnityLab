using UnityEditor;
using System.IO;
public class CreateAssetBundles {

    [MenuItem("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles()
    {
        string dir = "AssetBundles";
        if(Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles("AssetBundles", BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
    }
}
