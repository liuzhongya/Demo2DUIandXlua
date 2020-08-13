using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == Tags.Player)
        {
            //播发声音;TODO
            //增加金币数

            PlayerData.gemNum = PlayerData.gemNum + 1;


            Destroy(gameObject);
        }



    }
}
