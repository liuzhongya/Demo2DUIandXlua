using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    private Animator anim;
    private Collider2D colli;
    public GameObject gems;
    public GameObject root;
    public string gemroute;
    private float gemwaittime=0.5f;
    public GameObject childgen;


    void Start () {
       // root = GameObject.Find("Reward");

        anim = GetComponent<Animator>();
        colli = GetComponent<BoxCollider2D>();
        //    gemroute ="Reward/" + gameObject.name + "/Gems";
        //  print(gemroute);
        //   gems = GameObject.Find(gemroute);
        //    gems.SetActive(false);

        //
        GetChildGen();


    }
    void GetChildGen()
    {
         
        foreach (Transform child in this.transform)
        {
            
            childgen = child.gameObject;
          //  Debug.Log(child.name+"   "+ childgen.name);
        }

    }

    IEnumerator  OpenChest()
    {
        anim.SetBool("IsOpen", true);
        //TODO播发声音
        yield return new WaitForSeconds(gemwaittime);
        //   gems.SetActive(true);
        childgen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.Player)
        {
            StartCoroutine("OpenChest");

        }
    }
    void UnSpawnItem()
    {
        
        Destroy(gameObject);
    }




}
