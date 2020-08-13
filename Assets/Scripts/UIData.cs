using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIData : MonoBehaviour {
    public Slider hpSlider;
    public Text coinText;
    public Text gemText;
   
    public GameObject childgen;





    private void OnEnable()
    {

    
    }
    void Start () {

          hpSlider = GameObject.Find("Canvas/MainMenuPanel(Clone)/DataPanel/Slider").GetComponent<Slider>();

        // print(hpSlider.name);
        //   print(hpSlider.value);
        coinText = GameObject.Find("Canvas/MainMenuPanel(Clone)/DataPanel/CoinImage/Text").GetComponent<Text>();
        gemText= GameObject.Find("Canvas/MainMenuPanel(Clone)/DataPanel/GemImage/Text").GetComponent<Text>();
    }

    private void Update()
    {
        hpSlider = GameObject.Find("Canvas/MainMenuPanel(Clone)/DataPanel/Slider").GetComponent<Slider>();

        // print(hpSlider.name);
        //   print(hpSlider.value);
        coinText = GameObject.Find("Canvas/MainMenuPanel(Clone)/DataPanel/CoinImage/Text").GetComponent<Text>();
        gemText = GameObject.Find("Canvas/MainMenuPanel(Clone)/DataPanel/GemImage/Text").GetComponent<Text>();
        //hpSlider.value = PlayerData.Instance.PlaHp / 100;
        
      //  coinText.text = PlayerData.Instance.coinNum.ToString();
     //   gemText.text = PlayerData.Instance.gemNum.ToString();
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
