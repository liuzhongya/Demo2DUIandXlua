using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCoinNum : MonoBehaviour {

    public Text coinText;
  
    public GameObject childgen;

    void Start () {
        GetChildGen();
        coinText = childgen.gameObject.GetComponent<Text>();
      
	}
	
	// Update is called once per frame
	void Update () {

        //   coinText.text = "" + PlayerData.Instance.CoinNum;
        coinText.text = PlayerData.coinNum + "";
    //    print(PlayerData.coinNum);

    }

    void GetChildGen()
    {

        foreach (Transform child in this.transform)
        {

            childgen = child.gameObject;
            //  Debug.Log(child.name+"   "+ childgen.name);
        }

    }
}
