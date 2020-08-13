using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyCon : MonoBehaviour {
    private float EnemySpeed = 2.5f;
    private bool IsWall = false;
    private Rigidbody2D enemyrig;
    private  RaycastHit2D hit;
    private int wallLayerMsk=8;
    private Vector2 enemyPos;
     
    public float triggerTime = 0;
    public float rayValue=1.3f;
    public float fallSpeed = 6f;
    public GameObject lxgo;

    void Start () {

        enemyrig = GetComponent<Rigidbody2D>();
        wallLayerMsk = LayerMask.GetMask("Wall");

        //StartCoroutine("Findaa");
        //if (lxgo!=null)
        //print(AssetDatabase.GetAssetPath(lxgo));
    }
	
	//IEnumerator Findaa()
 //   {
 //       yield return new WaitForSeconds(0.5f);
 //       lxgo = GameObject.Find("Canvas").transform.Find("MainMenuPanel(Clone)").gameObject;

 //   }



	void Update () {

        RayTest();
       // enemyrig.velocity = new Vector2(EnemySpeed, enemyrig.velocity.y);
           EnemyMove();
        triggerTime += Time.deltaTime;
    }
    public void EnemyMove()
    {
        enemyPos.x = transform.position.x;
        enemyPos.y = transform.position.y;

        /////射线检测有问题
        //if (this.transform.localScale.x < 0)
        //{
        //    hitinfo = Physics2D.Raycast(enemyPos - new Vector2(0, 1), Vector2.up, 10f);
        //    Debug.DrawLine(enemyPos, hitinfo.point, Color.red);//画线显示
        //    if (hitinfo.collider != null)
        //    {
        //        print(hitinfo.collider.ToString());
        //        if (hitinfo.collider.tag == Tags.Wall)
        //        {
        //            IsWall = true;
        //        }
        //        else { IsWall = false; }
        //    }
        //}
        //if (this.transform.localScale.x > 0)
        //{
        //    hitinfo = Physics2D.Raycast(enemyPos - new Vector2(1, 0), Vector2.down, 10f);
        //    Debug.DrawLine(enemyPos, hitinfo.point, Color.red);//画线显示
        //    if (hitinfo.collider != null)
        //    {
        //        print(hitinfo.collider.tag);
        //        print(hitinfo.collider.ToString());
        //        if (hitinfo.collider.tag == Tags.Wall)
        //        {
        //            IsWall = true;
        //        }
        //        else { IsWall = false; }
        //    }
        //}

        //print(IsWall);


        if (this.tag == Tags.Enamy)
        {
            if (this.transform.localScale.x < 0)
            {
               // GetComponent<Rigidbody2D>().velocity = new Vector2(EnemySpeed, enemyrig.velocity.y);
                 //print("移动1");
                enemyrig.velocity = new Vector2(EnemySpeed, enemyrig.velocity.y);

            }
            else
            {
              // GetComponent<Rigidbody2D>().velocity = new Vector2(-EnemySpeed, enemyrig.velocity.y);
                enemyrig.velocity = new Vector2(-EnemySpeed   , enemyrig.velocity.y);

              // print("移动w" + enemyrig.velocity);
            }


            if (IsWall)   //控制人物转向和速度方向一致
            {
                this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }

           

        }





        }


    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("碰撞到wall");
    //    if (collision.gameObject.tag == Tags.Wall && triggerTime > 0.5f)
    //    {
    //        // enemyrig.velocity = new Vector2(enemyrig.velocity.x, enemyrig.velocity.y);
    //        this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    //        print("转向" + transform.localScale.x);
    //        triggerTime = 0;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  print("碰撞到wall");
        if (collision.gameObject.tag == Tags.Wall && triggerTime > 0.5f)
        {
            // enemyrig.velocity = new Vector2(enemyrig.velocity.x, enemyrig.velocity.y);
            this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
          //  print("转向" + transform.localScale.x);
            triggerTime = 0;
        }

        if (collision.gameObject.tag == Tags.Player)
        {
            
            PlayerData.plaHp= Mathf.Clamp(PlayerData.plaHp - Random.Range(6, 20), 0, 100);

        }
    }
    void RayTest()
    {
       
        ///  RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, raydown, 0), Vector2.down, 5, wallLayerMsk);

        if (transform.localScale.x > 0)
        {
            hit = Physics2D.Raycast(transform.position - new Vector3(0.5f, 0, 0), Vector2.down, rayValue, wallLayerMsk);
            Debug.DrawRay(transform.position - new Vector3(0.5f, 0, 0), Vector2.down, Color.red);//绘制射线

        }
        else
        {
            hit = Physics2D.Raycast(transform.position - new Vector3(-0.5f, 0, 0), Vector2.down, rayValue, wallLayerMsk);
            Debug.DrawRay(transform.position - new Vector3(-0.5f, 0, 0), Vector2.down, Color.red);//绘制射线

        }
        if (hit.collider == null )
        {
           
        //      print("下落");
            
            transform.Translate(Vector3.down * Time.deltaTime * fallSpeed, Space.World);

        }

        if (hit.collider != null)
        {
          //  Debug.Log(hit.collider.tag + "  " + hit.collider.name);
            if (hit.collider.tag != Tags.Wall)
            {
                this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }


        }



    }

    void UnSpawnItem()
    {
        //ObjectPool.Instance.UnSpawn(gameObject);
        //print("回收  " + gameObject.name);
        Destroy(gameObject);
    }




}
