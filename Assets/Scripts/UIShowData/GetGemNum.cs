using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetGemNum : MonoBehaviour {
    public Text genText;
   
    public GameObject childgen;

    void Start () {
        GetChildGen();
        genText = childgen.gameObject.GetComponent<Text>();
       
    }

    void Update()
    {
       // print(PlayerData.coinNum);
        genText.text = PlayerData.gemNum.ToString();
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
