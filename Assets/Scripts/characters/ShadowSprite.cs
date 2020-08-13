using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour {

    private Transform player;
    private SpriteRenderer playerSprite;
    private SpriteRenderer thisSprite;

    private Color color;

    [Header("时间控制参数")]
    public float activeTime; //显示时间
    public float activeStart;// 开始显示的时间点


    [Header("不透明度控制")]
    private float alpha;
    public float alphaSet;
    public float alphaMultiplier;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;
        transform.position = player.position;
        transform.localScale = player.localScale;
        transform.rotation = player.rotation;

        activeStart = Time.time;


    }


    void Update () {

        alpha *= alphaMultiplier;
        color = new Color(1, 1,1 ,alpha);
        thisSprite.color = color;

        if(Time.time >=activeStart+activeTime)
        {
            //返回对象chi
            ShadowPool.instance.ReturnPool(this.gameObject);


        }

		
	}
}
