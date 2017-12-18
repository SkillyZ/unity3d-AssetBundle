using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class LoadFromFile : MonoBehaviour {

    // Use this for initialization
    IEnumerator Start ()
    {
        string path = "AssetBundles/scene/wall.unity3d";
        //AssetBundle ab2 = AssetBundle.LoadFromFile("AssetBundles/share.unity3d");
        //AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/scene/wall.unity3d");
        //GameObject wallPrefab = ab.LoadAsset<GameObject>("Wall");
        //Instantiate(wallPrefab);

        //Object[] objs = ab.LoadAllAssets();
        //foreach (Object o in objs)
        //{
        //    Instantiate(o);
        //}

        //第一种
        //AssetBundleCreateRequest request =  AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        //yield return request;
        //AssetBundle ab = request.assetBundle; //IEnumerator
        //AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));

        //第二种
        //AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
        //yield return request;
        //AssetBundle ab = request.assetBundle;

        //第三种
        //while (Caching.ready == false)
        //{
        //    yield return null;
        //}
        //WWW www = WWW.LoadFromCacheOrDownload(@"file://D:\Program Files\unityproject\AssetBundleProject\AssetBundles\scene\wall.unity3d", 1);
        //yield return www;
        //if (string.IsNullOrEmpty(www.error) == false)
        //{
        //    Debug.Log(www.error); yield break;
        //}
        //AssetBundle ab = www.assetBundle;

        //第四种
        string uri = @"file:///D:\Program Files\unityproject\AssetBundleProject\AssetBundles\scene\wall.unity3d";
        UnityWebRequest request = UnityWebRequest.GetAssetBundle(uri);
#pragma warning disable CS0618 // 类型或成员已过时
        yield return request.Send();
#pragma warning restore CS0618 // 类型或成员已过时
        //AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;

        GameObject wallPrefab = ab.LoadAsset<GameObject>("Wall");
        Instantiate(wallPrefab);


        AssetBundle manifestAb = AssetBundle.LoadFromFile("AssetBundles/AssetBundles");
        AssetBundleManifest manifest = manifestAb.LoadAsset<AssetBundleManifest>("AssetBundles/AssetBundles");

        //foreach (string name in manifest.GetAllAssetBundles())
        //{
        //    print(name);
        //}

        string[] strs = manifest.GetAllDependencies("wall.unity3d");
        foreach (string name in strs)
        {
            print(name);
        }


    }

}
