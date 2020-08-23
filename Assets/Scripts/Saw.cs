using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {
   
    private bool IsWall = false;
    private Rigidbody2D enemyrig;
    private RaycastHit2D hitinfo;
    private Vector2 enemyPos;

    public float SawMoveSpeed = 3.5f;
    public float SawSelfSpeed = 270f;
    public float MaxY = 4f;
    public float MinY = -4f;
    public Transform SawPos;
    public GameObject target;
    public string sawroute;

    public bool IsRo = false;

    public int random;
    CircleCollider2D circollier;
    private void OnEnable()
    {

      
        circollier = gameObject.GetComponent<CircleCollider2D>();
        SawPos = GetComponent<Transform>();
         sawroute = gameObject.name + "/Saw";   
          target = transform.Find("Saw").gameObject;
            random = Random.Range(1, 5);

        target.SetActive(true);
        circollier.enabled = true;
    }
 


    void FindTarget()
    {
        SawPos = GetComponent<Transform>();
        sawroute = gameObject.name + "/Saw";
        target = transform.Find("Saw").gameObject;
        // target = GameObject.Find(sawroute);
    }
 
    void Update () {
 
        SawMove();

    }
    void SawMove()
    {
      //  print("旋转开始");
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 1f, 0), Vector2.down, 0.5f);

        if (hit.collider != null)
        {
            if (hit.collider.tag == Tags.Wall)
            {
                SawMoveSpeed = -SawMoveSpeed;
            }
        
        }
        //注意不能直接将脚本赋值到齿轮上，因为在旋转的时候要改变齿轮的rotation.z值
        if (target != null)
        {
            if (!PlayerData.m_IsPause)
            {
                target.transform.Rotate(Vector3.forward, SawSelfSpeed * Time.deltaTime); //使得齿轮旋转 
                
             //   print("开始旋转1");
            }

        }
        else
        {
            FindTarget();
            if (!PlayerData.m_IsPause)
            {
                target.transform.Rotate(Vector3.forward, SawSelfSpeed * Time.deltaTime); //使得齿轮旋转 
               // print("开始旋转2");
            }
           
        }

     //   int random = Random.Range(0, 4);
        if (random == 1&& !PlayerData.m_IsPause)
        {
            if (target != null)
                transform.Translate(Vector3.down * SawMoveSpeed * Time.deltaTime);// 使得齿轮父物体向上移动
            else
            {
                FindTarget();
                transform.Translate(Vector3.down * SawMoveSpeed * Time.deltaTime);// 使得齿轮父物体向上移动
            }
        }
        else if (random == 2&& !PlayerData.m_IsPause)
        {
            if (target != null)
                transform.Translate(Vector3.left * SawMoveSpeed * Time.deltaTime);// 使得齿轮父物体向左 移动
            else
            {
                FindTarget();
                transform.Translate(Vector3.left * SawMoveSpeed * Time.deltaTime);// 使得齿轮父物体向左移动
            }
        }
        else if(random==3&& !PlayerData.m_IsPause)
        {
            if (target != null)
                transform.Translate(Vector3.right * SawMoveSpeed * Time.deltaTime);// 使得齿轮父物体向右移动
            else
            {
                FindTarget();
                transform.Translate(Vector3.right * SawMoveSpeed * Time.deltaTime);// 使得齿轮父物体向右移动
            }
        }
        else
        {
            if (target != null&&!PlayerData.m_IsPause)
                transform.Translate(Vector3.up * SawMoveSpeed * Time.deltaTime);// 使得齿轮父物体向上移动

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == Tags.Wall)
        {
            SawMoveSpeed = -SawMoveSpeed;
            print("碰撞到wall");
        }
        if (collision.gameObject.tag == Tags.Player)
        {
            int random = Random.Range(0, 10);
           
            PlayerData.plaHp = Mathf.Clamp(PlayerData.plaHp - random, 0, 100);

        }

    }

    void UnSpawnItem()
    {
        target.SetActive(false);
        circollier.enabled = false;
    }




}
