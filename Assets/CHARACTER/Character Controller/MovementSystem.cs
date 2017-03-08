using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour {

	public float force;
    public float jumpForce;
	public float speed = 2;

	public Animator anim;
	public bool attacking = false;

    public bool jumping = false;

	public GameObject hitbox;

    //Player info
    public int health;
    public string level;

    //public bool playerGrounded;
    public Rigidbody playerRB;

	// Bow and Arrow 
	public GameObject arrow;
	public Transform aim;

	void Start () {
        health = 10;
		speed = 3;
		force = speed * Time.deltaTime;
	}

	void Update () {
        
        float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		if (!attacking && Input.GetKeyDown (KeyCode.J)) {
			anim.SetTrigger("attack");
			attacking = true;
			anim.SetBool("walk", false);
			StartCoroutine(AttackDelay());
			hitbox.SetActive(true);
		}

		// Using Bow 
		if (!attacking && Input.GetKeyDown (KeyCode.K)) {
			anim.SetBool("walk", false);
			attacking = true;
			StartCoroutine(AttackDelay());
			GameObject newArrow;
			newArrow = (GameObject)Instantiate (arrow, aim.transform.position, aim.transform.rotation);
		}

        //Jumping
        if (!attacking && !jumping && Input.GetKeyDown(KeyCode.Space)) {
            anim.SetBool("walk", false);
            jumping = true;
            playerRB.AddForce(transform.up * jumpForce);
            StartCoroutine(JumpDelay());
            
        }

        if (!attacking) {
			Vector3 vNewInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			
			// Only do work if meaningful
			if(vNewInput.sqrMagnitude < 0.1f)
			{
				anim.SetBool("walk", false);
				return;

			} else {
				anim.SetBool("walk", true);
			}
	
			// Apply the transform to the object  
			var angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, angle, 0);

			transform.Translate (Vector3.forward * force);
		}


	}

	IEnumerator AttackDelay() {
		yield return new WaitForSeconds(0.3f);
		attacking = false;
		hitbox.SetActive(false);
	}

    IEnumerator JumpDelay() {
        yield return new WaitForSeconds(1.0f);
        jumping = false;
    }

    public void GetHurt() {
        health--;
        if (health < 1) {
            SceneManager.LoadScene(level);
        }

        
    }

	/*void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Floor") {
			playerGrounded = true;
		}
	}

	//Auto-Jumping
	void OnTriggerEnter(Collider other) { 
		if (other.gameObject.tag == "Gap") {
			playerGrounded = false;
			playerRB.AddForce(transform.up * jumpForce);
			playerRB.AddForce(transform.forward * jumpForce);
		}
	}*/
}
