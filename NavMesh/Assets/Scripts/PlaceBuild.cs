using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlaceBuild : MonoBehaviour {
    public GameObject builderPrefab;
    private NavMeshSurface surface;

	// Use this for initialization
	void Start () {
        surface = GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                GameObject go = GameObject.Instantiate(builderPrefab, hit.point + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity);
                go.transform.parent = this.transform;
                surface.BuildNavMesh();
            }
             
        }
	}
}
