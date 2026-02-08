using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float direction;
    public GameObject ShootW;
    public GameObject prefabShootW;
    public Transform firePoint;  
    public Transform characterTransform;
    private Rigidbody2D rb;
    public float jump_power;
    Animator anim;
    public GameObject PanelGameover;
    private bool isDead = false;
    public int maxJumps = 2;   
    private int jumpCount = 0;  

    void Start()
    {
        speed = 17f;
        jump_power = 10f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
        anim.SetBool("isIdle", true);
        PanelGameover.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        //ANIMATOIN
        bool isMoving = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ||
        Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        anim.SetBool("isRunning", isMoving);
        anim.SetBool("isIdle", !isMoving);

        bool isAttacking = Input.GetKey(KeyCode.Return);
        anim.SetBool("isShooting", isAttacking);
        anim.SetBool("isIdle", !isAttacking);
    
        //MOVE     
        //Right
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            transform.position += new Vector3(speed*Time.deltaTime,0,0);
            transform.localScale = new Vector3(1,1,1);
        }
        else{
        }
        //Left
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            transform.position -= new Vector3(speed*Time.deltaTime,0,0);    
            transform.localScale =  new Vector3(-1,1,1);
        }

        //JUMP
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps){
            rb.velocity = new Vector3(rb.velocity.x, jump_power);
            jumpCount++;
        }


        //ROTATE
        GameObject.Find("gear").transform.Rotate(0,0,(float)0.5);
        if (GameObject.Find("Heart") != null)
            GameObject.Find("Heart").transform.Rotate(0,0,(float)0.5);

        //SHOOT WOOD
        if(Input.GetKeyDown(KeyCode.Return)){
            ShootW = Instantiate(prefabShootW, firePoint.position, firePoint.rotation) as GameObject;
            //ShootW = Instantiate(prefabShootW, firePoint.position, Quaternion.identity) as GameObject;
            GetComponent<AudioSource>().Play();
            anim.SetTrigger("isShooting");
        }

        // Player movement limit
        if(transform.position.x > 105.3f)   // Right
            transform.position = new Vector3(105.3f, transform.position.y, transform.position.z);

        if(transform.position.x < -10)  // Left 
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);

        if(transform.position.y > 5.3f)   // Up
            transform.position = new Vector3(transform.position.x, 5.3f, transform.position.z);

        if(transform.position.y < -7)   // Down
            transform.position = new Vector3(transform.position.x, -7, transform.position.z);
    }
       //ANYTHING OUT OF UPDATE HERE:____________________________________________________________________________________________________

        private void OnCollisionEnter2D(Collision2D collision){
            if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BigEnemy"){
                isDead = true;
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isShooting", false);
                anim.SetBool("IsDying", true);
                PanelGameover.SetActive(true);
            }

            if(collision.gameObject.CompareTag("Ground"))
            {
                jumpCount = 0; 
            }

    }
}