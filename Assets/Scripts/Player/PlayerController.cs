using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb;
	private Animator anim;
	private float moveSpeed;
	private float dirX;
	private bool facingRight = true;
	private Vector3 localScale;
	

	public int myHealth;
	public int maxHealth = 5;
	public GameMaster gm;



	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		localScale = transform.localScale;
		moveSpeed = 1f;

		myHealth = maxHealth;
		gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<GameMaster>(); // coins
	}

	private void Update()
	{
		dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

		if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
		{
			rb.AddForce(Vector2.up * 700f);
		}
		
		
		if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
		{
			anim.SetBool("isRunning", true);
		}
		else
		{
			anim.SetBool("isRunning", false);
		}
		if (rb.velocity.y == 0)
		{
			anim.SetBool("isJumping", false);
			anim.SetBool("isFalling", false);
		}
		if (rb.velocity.y > 0)
		{
			anim.SetBool("isJumping", true);
		}
		if (rb.velocity.y < 0)
		{
			anim.SetBool("isJumping", false);
			anim.SetBool("isFalling", true);
		}
	}
	private void FixedUpdate()
	{
		rb.velocity = new Vector2(dirX, rb.velocity.y);
        //Health
        if (myHealth <= 0)
        {
			Death();
        }
	}
	private void LateUpdate()
	{
		if (dirX > 0)
		{
			facingRight = true;
		}
		else if(dirX < 0)
        {
			facingRight = false;
        }
		if(((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x >0)))
        {
			localScale.x *= -1;
			transform.localScale = localScale;
        }
	}
	public void Death()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
	public void Damage(int damage)
	{
		myHealth -= damage;
	}

    // Coin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coins"))
        {
			Destroy(collision.gameObject);
			gm.coins += 1;
        }
		if (collision.CompareTag("Heart"))
		{
			Destroy(collision.gameObject);
			myHealth++;
		}
		if (collision.CompareTag("Shoes"))
		{
			Destroy(collision.gameObject);
			moveSpeed = 2f;
			StartCoroutine(timecount(5));
		}
	}
	// time dem nguoc x2 toc do chay
    IEnumerator timecount (int time)
    {
		yield return new WaitForSeconds(time);
		moveSpeed = 2f;
		yield return 0;
	}
}
