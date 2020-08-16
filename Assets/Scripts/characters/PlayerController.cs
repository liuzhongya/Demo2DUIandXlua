using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float playerspeed = 4;
    private float playerjumpspeed = 8;
    private float rigSpeed;

    private Rigidbody2D playerrig;
    private Animator anim;
    private bool isGround = true;
    private bool IsContinuousJump = false;
    private bool IsBigger = false;
    private float horizontalMove;

    private int groundLayerMsk;

    [Header("Dash参数")]
    public float dashTime; //dash时长
    private float dashTimeLeft;//冲锋剩余时间
    private float lastDash=-10;
    public float dashCoolDown;
    public float dashSpeed;
    public bool isDashing;
    public float rayDown=0.5f;
    public float rayDeviation = 0.3f;
    RaycastHit2D hit;

    //private float maxY = 8;//跳起的最大高度
    //private float minY = -8;



    private void Start()
    {
        playerrig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
     
    }
 
    void Update()
    {
        UpdateAction();

        if (Input.GetKeyDown(KeyCode.J)){
            if (Time.time>=(lastDash+dashCoolDown))
            {
                ReadyToDash();
            }

        }
        if (Input.GetKeyDown(KeyCode.O))   //
        {
            PlayerData.m_IsPause = false ;

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerData.m_IsPause = true;

        }

        }
    public void UpdateAction()
    {  Dash();
            MovePlayer();
        if (!PlayerData.m_IsPause)
        {
            anim.speed = 1;
          
            playerrig.gravityScale = 1;
        }
        else
        {
            anim.speed = 0;
            playerrig.gravityScale = 0;
        }

    }

    public void MovePlayer()
    {
     
        if (!IsBigger)
        {
            playerspeed = 3.5f;
           playerjumpspeed = 7;
        }

        if (PlayerData.m_IsPause)
        {
            playerspeed = 0;
            playerjumpspeed = 0;
        }
        else
        {
           playerspeed = 4;
           playerjumpspeed = 8;
           }

       // print(isGround + "   " + IsContinuousJump);

        //得到刚体的速度
        rigSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;

        horizontalMove = Input.GetAxisRaw("Horizontal");
        float h = Input.GetAxis("Horizontal");
     //   float v = Input.GetAxis("Vertical");
     



        if (h > 0.1&&!PlayerData.m_IsPause)
        {
            transform.localScale = new Vector3(1, 1, 1);
          //  playerrig.velocity = new Vector2(h * playerspeed, playerrig.velocity.y);
        
            anim.SetInteger("Speed", 1);
        }
        else  if (h < -0.1 && !PlayerData.m_IsPause)
        {
            anim.SetInteger("Speed", 1);
            transform.localScale = new Vector3(-1, 1, 1);
          //  playerrig.velocity = new Vector2(playerspeed*h, playerrig.velocity.y);
        }

        else
        {
            anim.SetInteger("Speed", 0);
        }
 
        if(!PlayerData.m_IsPause)
        playerrig.velocity = new Vector2(playerspeed * h, playerrig.velocity.y);
        else
        {
            playerrig.velocity = Vector2.zero;
        }

        if (transform.localScale.x > 0)
        {
            hit = Physics2D.Raycast(transform.position - new Vector3(rayDeviation, rayDown, 0), Vector2.down, 0.5f);
            Debug.DrawRay(transform.position - new Vector3(rayDeviation, rayDown, 0), Vector2.down, Color.red);//绘制射线
        }
        else
        {
            hit = Physics2D.Raycast(transform.position - new Vector3(-rayDeviation, rayDown, 0), Vector2.down, 0.5f);
            Debug.DrawRay(transform.position - new Vector3(-rayDeviation, rayDown, 0), Vector2.down, Color.red);//绘制射线

        }
 
        if (hit.collider != null)
        {
           // print(hit.collider.tag);
            if (hit.collider.tag == Tags.Wall)
            {
                isGround = true;
                IsContinuousJump = true;
           
            }
            else
            {
                isGround = false;
            }
        }
        else
        {
      
            isGround = false;
        }
        if (isGround)
            anim.SetBool("IsJump", false);
        else
            anim.SetBool("IsJump", true);


        //   print(isGround);
        //对动画转化条件进行赋值，使人物进行跳跃
        if (Input.GetKeyDown(KeyCode.Space) &  isGround  )
        {

            if (!PlayerData.m_IsPause)
                playerrig.velocity = new Vector2(h * playerspeed, playerjumpspeed);
            else
            {
                playerrig.velocity = Vector2.zero;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) & !isGround  &&   IsContinuousJump)
        {

            if (!PlayerData.m_IsPause)
                playerrig.velocity = new Vector2(h * playerspeed, playerjumpspeed);
            else
            {
                playerrig.velocity = Vector2.zero;
            }
            IsContinuousJump = false;
        }

    }


    void ReadyToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
    }
    void Dash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                if(playerrig.velocity.y>0&&!isGround)
                {
                    playerrig.velocity = new Vector2(dashSpeed * horizontalMove, playerjumpspeed);
                }

                playerrig.velocity = new Vector2(dashSpeed * horizontalMove, playerrig.velocity.y);
                dashTimeLeft -= Time.deltaTime;
                ShadowPool.instance.GetFormPool();

            }
            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                if(!isGround)
                {
                    playerrig.velocity = new Vector2(dashSpeed * horizontalMove, playerspeed);

                }
            }
        }

    }

  



}