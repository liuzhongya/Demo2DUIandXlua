using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadChange : MonoBehaviour {
    public GameObject roadNow;
    public GameObject roadNext;
    public  GameObject parent;
    public int lx=0;
    public float cameraPosX;

    CameraFollow getxPos = new CameraFollow();

    void Start () {
 
        if (parent==null)
        {
            parent = new GameObject();
            parent.transform.position = new Vector3(0,0,0); // Vector3.zero;
            parent.name = "Road";
         //   print(parent.transform.position.ToString());
        }
       
        roadNow = ObjectPool.Instance.Spawn("GameBackground1", parent.transform);
        roadNow.transform.position = parent.transform.position;
       
        roadNext = ObjectPool.Instance. Spawn("GameBackground2", parent.transform);
         roadNext.transform.position = roadNow.transform.position + new Vector3(38, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.road)
        {
            // GameObject go = collision.transform.parent.gameObject;
            //   ObjectPool.Instance.UnSpawn(collision.transform.parent.gameObject);
            ObjectPool.Instance.UnSpawn(collision.gameObject);

            //创建新的
            SpawnNewRoad();
                CameraFollow cameera=new CameraFollow();
            //  CameraFollow.minPosx= collision.transform.position.x + 28;
            // cameera.MinPosx =collision.transform.position.x+28;

            // getxPos.SetMinPosx(collision.transform.position.x + 28);
            CameraFollow.IsChangeMinPosx = true;
        }

    }

    void SpawnNewRoad()
    {
        int random = Random.Range(1, 4);
        string nextbg = "GameBackground" + random;
        //生成新的游戏对象
        roadNow = roadNext;
        roadNext = ObjectPool.Instance.Spawn(nextbg, parent.transform);
        roadNext.transform.position = roadNow.transform.position + new Vector3(38, 0, 0);


    }



}
