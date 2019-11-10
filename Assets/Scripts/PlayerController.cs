using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public Animator anim;
	public SpriteRenderer spriteRenderer;
	public Rigidbody2D rb2D;

	private bool walking = false;
	public float jumpForce;

	bool isJumping;

	public GameManager manager;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

		// if (Input.GetKey(KeyCode.Space)) {
		// 	//rb2D.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
		// 	rb2D.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);

			
		// }

		Jump();

		if (Input.GetKey(KeyCode.A)) {
			Vector2 v = transform.position;
			v.x -= 0.1f;
			transform.position = v;
			walking = true;
			spriteRenderer.flipX = true;
		} else if (Input.GetKey(KeyCode.D)) {
			Vector2 v = transform.position;
			v.x += 0.1f;
			transform.position = v;
			walking = true;
			spriteRenderer.flipX = false;
		}

		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) ) {
			walking = false;
		}

		anim.SetBool("walking", walking);
	
	}

	void Jump(){
		if(Input.GetKeyDown(KeyCode.Space) && !isJumping){
			isJumping = true;
			rb2D.AddForce(new Vector2 (rb2D.velocity.x, jumpForce));
			isJumping = false;
		}
	}

	void onCollisionEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Ground")){
			isJumping = false;

			rb2D.velocity = Vector2.zero;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			return;
		}
		
		if (collider.tag == "DeathCactus" || collider.tag == "DeathBase") {
			manager.AddLife(-1);
		}

		if (collider.tag == "PlataformaMovel") {
			gameObject.transform.parent = collider.transform;
		}

		
		if (collider.tag == "NextLevel") {
			manager.NextLevel();
			
		}

		if (collider.tag == "NextLevel2") {
			manager.NextLevel2();
			
		}
		if (collider.tag == "NextLevel3") {
			manager.NextLevel3();
			
		}

		if (collider.tag == "Life+") {
			manager.NextLevel3();
			
		}

		if (collider.tag == "Box1" || collider.tag == "Box2" || collider.tag == "Box3") {
			manager.OpenBox(+1);
			manager.HideBox(collider.tag);

			
		}
	}
	

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "PlataformaMovel") {
			gameObject.transform.parent = null;
		}
	}

}
