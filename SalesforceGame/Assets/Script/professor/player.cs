using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {
    
    public GameObject particle_shoot;
    public GameObject particle_damage;
    public GameObject particle_coin;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public bool isGrounded;
    public float jumpForce;
    public float speed;
    Rigidbody2D rb;

    private GameObject child;

    private GameObject score;

    private int scorePoint = 0;

    private bool jump = false;

    private Animator animator;

    public float offsetShoot=0;

    private float oldX=0;

    private float x = 0;

    private bool alreadyCol = false;

    private float life = 3;
    private bool start = false;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        isGrounded = true;

        score = GameObject.Find("score");
    }
	
	// Update is called once per frame zas
	void Update () {
        if (start) {

            if (Input.GetButtonDown("Jump") && isGrounded) { // isGrounded
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;

            }

            if (Input.GetButtonDown("Fire1")) {

                GameObject shoot = Instantiate(particle_shoot);

                Vector2 position = new Vector3(transform.position.x + offsetShoot, transform.position.y + 0, 3f);

                shoot.GetComponent<Transform>().position = position;

                if (animator.GetInteger("Direction") == 1 || animator.GetInteger("Direction") == 7)
                    shoot.GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpForce * -1, ForceMode2D.Impulse);
                if (animator.GetInteger("Direction") == 2 || animator.GetInteger("Direction") == 8)
                    shoot.GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);


                Physics2D.IgnoreCollision(shoot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }

        }
    }

    void FixedUpdate() {
        if (start) {
            if (life > 0 && life < 99) {
                x = Input.GetAxis("Horizontal");



                if (x < 0f) {
                    animator.SetInteger("Direction", 1);
                } else if (x > 0f) {
                    animator.SetInteger("Direction", 2);
                } else {
                    if(animator.GetInteger("Direction")==1)
                        animator.SetInteger("Direction", 7);

                    if (animator.GetInteger("Direction") == 2)
                        animator.SetInteger("Direction", 8);
                }



                Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
                rb.velocity = move;

            } else {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.GetComponent<SpriteRenderer>().enabled=false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll) {
     }

    void OnCollisionEnter2D(Collision2D coll) {
        //  if(coll.gameObject.tag == "Enemy")
        // isDead = true; //coll.gameObject.SendMessage("ApplyDamage", 10);
        if (coll.gameObject.layer == 8 ) {
            isGrounded = true;
        }

        if (coll.gameObject.tag == "ignore") {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        
        if (coll.gameObject.tag == "Enemy" ) {
            float force = 500;

            life--;

            // Calculate Angle Between the collision point and the player
            Vector2 dir = coll.contacts[0].point - (Vector2)transform.position;

            GameObject shoot = Instantiate(particle_damage);

            shoot.transform.position = transform.position;

            if (coll.gameObject.GetComponent<Transform>().position.x>this.transform.position.x) {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * 3000);

                Debug.Log("CHOQUE left");
            }else if (coll.gameObject.GetComponent<Transform>().position.x < this.transform.position.x) {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 3000);

                Debug.Log("CHOQUE right");
            }else if (coll.gameObject.GetComponent<Transform>().position.y < this.transform.position.y) {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3000);

                Debug.Log("CHOQUE up");
            }

            // We then get the opposite (-Vector3) and normalize it
            //dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            // GetComponent<Rigidbody2D>().AddForce(dir * force);


        }

    }

   

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "plataform") {
            Physics2D.IgnoreCollision(coll.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (coll.gameObject.tag == "coin") {
            scorePoint++;
            score.GetComponent<Text>().text = scorePoint.ToString();

            GameObject coin = Instantiate(particle_coin);

            coin.GetComponent<Transform>().position = coll.GetComponent<Transform>().position;

            coll.gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "fin") {
            this.GetComponent<Rigidbody2D>().velocity=new Vector2(0, 0); ;
            life = 99;
            start = false;
            animator.SetInteger("Direction", 10);
        }

    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "plataform") {
            Physics2D.IgnoreCollision(coll.GetComponent<Collider2D>(), GetComponent<Collider2D>(),false);
        }
    }

    public int checkLife() {
        return (int)life;
    }

    public void SetplayerStart(bool s) {
        start = s;
    }
}
