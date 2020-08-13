using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HpSlider : MonoBehaviour {

    public Slider hpSlider;
  
    private void OnEnable()
    {

        hpSlider = GetComponent<Slider>();
        print(hpSlider.name);
        print(hpSlider.value);
     
       // print(PlayerData.plaHp);
    }

    void Start () {
	}

    private void Update()
    {
         hpSlider.value = PlayerData.plaHp / 100;
        //print(plaertData.PlaHp);
    }



}
