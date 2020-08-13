using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCherry : MonoBehaviour {
    public  int rondomnum;

    public string ResourcesDir = "objects";

    private void OnEnable()
    {
        rondomnum = Random.Range(1, 10);
        NewCherry("Cherry");

    }

    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void NewCherry(string objName )
    {
        if(rondomnum > 6)
        {
            string path = ResourcesDir + "/" + objName;
            GameObject go = Resources.Load<GameObject>(path);
            // print(transform.position.ToString());
            GameObject lxgo = Instantiate(go, transform);
            lxgo.transform.localPosition = Vector3.zero;
        }
    }


}
