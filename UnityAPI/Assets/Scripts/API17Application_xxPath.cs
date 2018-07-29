using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API17Application_xxPath : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print(Application.dataPath);
        print(Application.streamingAssetsPath);
        print(Application.persistentDataPath);
        print(Application.temporaryCachePath);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
