using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFromFile : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/scene/wall.unity3d");
        GameObject wallPrefab = ab.LoadAsset<GameObject>("Wall");
        Instantiate(wallPrefab);

        //Object[] objs = ab.LoadAllAssets();
        //foreach (Object o in objs)
        //{
        //    Instantiate(o);
        //}
    }
	
}
