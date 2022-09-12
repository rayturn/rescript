using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AppBuilder
{ 

    [MenuItem("Ni App/Build App")]
    public static void BuildApp()
    {
        string[] apps = System.IO.Directory.GetFiles("Assets/", "AppManifest.json", System.IO.SearchOption.AllDirectories);
        foreach(var appmanifest in apps)
        {
            BuildByAppManifest(appmanifest);
        }
        //BuildPipeline.BuildAssetBundles("",)
    }

    static void BuildByAppManifest(string manifest_file)
    {
        var json = System.IO.File.ReadAllText(manifest_file);
        AppManifest manifest = JsonUtility.FromJson<AppManifest>(json);
        Debug.LogFormat("APP:{0}",manifest);
        string approot = Directory.GetParent(manifest_file).FullName;

        List<AssetBundleBuild> bundleBuilds = new List<AssetBundleBuild>();
        bundleBuilds.Add(BuildMainAssetBundle(approot));
        string[] scenes = Directory.GetFiles(approot + "/Scenes", "*.unity", SearchOption.AllDirectories);
        foreach(var scene in scenes)
        {
            AssetBundleBuild bundleBuild = BuildScene(scene);
            bundleBuilds.Add(bundleBuild);
        }
        string outputPath = Path.Combine(Application.streamingAssetsPath,"app" ,manifest.package);
        Directory.CreateDirectory(outputPath);
        BuildPipeline.BuildAssetBundles(outputPath, bundleBuilds.ToArray(), BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);
    }

    private static AssetBundleBuild BuildScene(string scene)
    {
        scene = Path.GetRelativePath(Path.GetFullPath("."), scene).Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        Debug.LogFormat("BuildScene:{0}", scene);
        AssetBundleBuild build = new AssetBundleBuild()
        {
            assetBundleName = "scenes/" + Path.GetFileNameWithoutExtension(scene),
            assetNames = new string[] { scene }
        };
        return build;
    }



    private static AssetBundleBuild BuildMainAssetBundle(string approot)
    {
        string[] all = Directory.GetFiles(approot, "*", SearchOption.TopDirectoryOnly);
        List<string> buildAssets = new List<string>();
        List<string> dependencedAssets = new List<string>();
        for (int i = 0; i < all.Length; i++)
        {
            string asset = all[i];
            if (Path.GetExtension(asset) == ".meta") continue;
            if (Path.GetExtension(asset) == ".cs") continue;
            asset = Path.GetRelativePath(Path.GetFullPath("."), asset).Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var depends = AssetDatabase.GetDependencies(asset).ToList();
            foreach(var depend in depends)
            {
                if (Path.GetExtension(depend) == ".cs") continue;
                buildAssets.Add(depend);
            }
            Debug.LogFormat("assets:{0}", asset);
        }
        buildAssets = buildAssets.Distinct().ToList();
        Debug.LogFormat("BuildAssets:{0}", string.Join(", ", buildAssets));


        AssetBundleBuild build = new AssetBundleBuild()
        {
            assetBundleName = "app",
            assetNames = buildAssets.ToArray()
        };
        return build;
    }
}
