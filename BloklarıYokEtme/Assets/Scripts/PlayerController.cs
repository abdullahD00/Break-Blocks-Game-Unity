using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D MyBody;
    [SerializeField] float Speed;
    private float SpeedX;
    private Vector3 DefaultLocalScale;
    [SerializeField] float JumpPower;
    public bool OnGround;
    [SerializeField] bool CanDoubleJump;
    [SerializeField] GameObject Arrow;
    private Vector3 DefaultLocalScaleArrow;
    [SerializeField] float ArrowSpeed;
    [SerializeField] bool Attacked;
    [SerializeField] float CurrentAttackTimer;
    [SerializeField] float DefaultAttackTimer;
    private Animator MyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        Attacked = false;
        MyBody = GetComponent<Rigidbody2D>();
        DefaultLocalScale = transform.localScale;
        MyAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SpeedX = Input.GetAxis("Horizontal");
        MyAnimator.SetFloat("Speed", Mathf.Abs(SpeedX));
        MyBody.velocity = new Vector2(SpeedX * Speed, MyBody.velocity.y);

        if (SpeedX > 0)
        {
            MyBody.transform.localScale = new Vector3(DefaultLocalScale.x, DefaultLocalScale.y, DefaultLocalScale.z);
        }
        else if (SpeedX < 0)
        {
            MyBody.transform.localScale = new Vector3(-DefaultLocalScale.x, DefaultLocalScale.y, DefaultLocalScale.z);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (OnGround == true)
            {
                MyBody.velocity = new Vector2(MyBody.velocity.x, JumpPower);
                CanDoubleJump = true;
                MyAnimator.SetTrigger("Jump");
            }
            else
            {
                if (CanDoubleJump == true)
                {
                    MyBody.velocity = new Vector2(MyBody.velocity.x, JumpPower);
                    CanDoubleJump = false;
                }
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Attacked == false)
            {   
                
                
                
                Invoke("fire", 0.5f);
                //ınvoke yapınca diğer fonskiyonu sildim çünkü ınvoke içinde fonksiyon yine çalışıyor
                Attacked = true;
                MyAnimator.SetTrigger("Attack");
            }

           
           
        }
        if (Attacked==true)
        {
            CurrentAttackTimer = CurrentAttackTimer - Time.deltaTime;
        }
        else
        {
            CurrentAttackTimer = DefaultAttackTimer;
        }
        if (CurrentAttackTimer<0)
        {
            Attacked = false;
        }



    }
    private void fire()
    {
            if (transform.localScale.x>0)
            {
            GameObject Okumuz = Instantiate(Arrow,transform.position, Quaternion.identity);
                
                Okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
            }
            else if (transform.localScale.x<0)
            {
                GameObject Okumuz = Instantiate(Arrow, transform.position, Quaternion.identity);
                Okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
                Okumuz.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
       
    }

    private void Die()
    {  
        MyAnimator.SetTrigger("Dıe");
        MyAnimator.SetFloat("Speed", 0f);
        MyAnimator.SetFloat("Jump", 0f);
        enabled = false;
        MyBody.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" )
        {
            Die();
           
        }
    }

}
