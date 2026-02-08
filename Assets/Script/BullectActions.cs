using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BullectActions : MonoBehaviour
{
    public float bulletSpeed = 50f; 
    public float direction;
    public static int score;
    public static Text scoreText;
    private static int highScore = 0;
    private static int bigEnemy=0;
    Animator enemyAnim;


    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.Find("Zombie1").transform.localScale.x ;  
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //DESTROY BULLET
        if(direction > 0){
            transform.position += new Vector3(bulletSpeed * Time.deltaTime, 0 ,0);
            if(transform.position.x > 300)
                Destroy(gameObject);
        }
        else{
            transform.position += new Vector3(-bulletSpeed *Time.deltaTime, 0 ,0);
            if(transform.position.x < -100)
                Destroy(gameObject);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        // normal enemy
        if (collision.gameObject.tag == "Enemy")
        {
            UpdateScore(1);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        // big enemy
        if (collision.gameObject.tag == "BigEnemy")
        {
            bigEnemy++;
            if (bigEnemy>= 5)
            {
                bigEnemy=0;
                UpdateScore(5);
                Animator enemyAnim = collision.gameObject.GetComponent<Animator>();
                enemyAnim.SetBool("bigIsDying", true);
                AudioSource enemyAudio = collision.gameObject.GetComponent<AudioSource>();
                if (enemyAudio != null){
                    enemyAudio.Play();
                }

                Destroy(collision.gameObject, 1f);

            }
            Destroy(gameObject);
        }

        //Obsticle
        if (collision.gameObject.tag == "Obsticle")
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject);          
        }
    

        //Obsticle + Bonus
        if (collision.gameObject.tag == "ObsticleB"){
            // letting the bonus be devided from the box
            Transform bonus = collision.transform.Find("Bonus");
            if (bonus != null){
                bonus.SetParent(null);        // the bonus aint the child anymore
                bonus.gameObject.SetActive(true);
            }

            Destroy(collision.gameObject);    // destroyin the box 
            Destroy(gameObject);              // destroyin the bullet
        }
    }
        
        void OnTriggerEnter2D(Collider2D other){
            if (other.CompareTag("Bonus"))
            {
                UpdateScore(2);           
                Destroy(other.gameObject); // destroyin the bonus
            }
        }


    //SCORE
        public static void UpdateScore(int n){
            scoreText = GameObject.Find("scoreText").GetComponent<Text>();
            score += n;
            scoreText.text = "Score:" + score.ToString();
            if(score>highScore){
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
            }
        }

    }