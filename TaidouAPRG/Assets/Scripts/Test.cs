using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    public GameObject targetGameObject;
    public float timer = 2;
    public iTween.EaseType easyType;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            //iTween.MoveTo(gameObject, new Vector3(3, 0, 0), timer);

            //Hashtable args = new Hashtable();
            //args.Add("x", 3);
            //args.Add("time", 4);
            //args.Add("onUpdate", "OnUpdateFunction");
            //args.Add("onComplete", "OnCompleteFunction");
            //args.Add("onupdatetarget", this.gameObject);
            //args.Add("oncompletetarget", this.gameObject);
            //args.Add("looptype", iTween.LoopType.pingPong);
            ////args.Add("looptype", iTween.LoopType.none);


            Hashtable args = iTween.Hash("x", 3, "time", 2, "onUpdate", "OnUpdateFunction", "easytype", easyType,
                                            "onupdatetarget", this.gameObject, "looptype", iTween.LoopType.pingPong);

            iTween.MoveTo(targetGameObject, args);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            iTween.Stop();
            targetGameObject.transform.position = Vector3.zero;
        }
    }

    public void OnUpdateFunction()
    {
        print("update");
    }

    public void OnCompleteFunction()
    {
        print("complete");
    }
}
