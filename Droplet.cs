using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;
    private Animator anim;

    private string SPLASH_ANIMATION = "Splashing";

    private string GROUND_TAG = "Ground";
    private bool isGrounded;

    private string PLAYER_TAG = "Player";

    public int minDirtiness = 0;
    public int currentDirtiness;
    public PantyBar pantyBar;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        currentDirtiness = 0;
        pantyBar.SetDirtiness(currentDirtiness);
    }

    void Update()
    {
        myBody.velocity = new Vector2(myBody.velocity.x, speed);
        StartCoroutine(DissolveDroplet());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Droplet contact with player
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            Destroy(gameObject);
            Score.scoreValue += 1;
        }
        //Droplet contact with ground
        else if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            anim.SetBool(SPLASH_ANIMATION, true);
            isGrounded = true;

            currentDirtiness += 1;
            pantyBar.SetDirtiness(currentDirtiness);
        }
        else
        {
            anim.SetBool(SPLASH_ANIMATION, false);
            isGrounded = false;
        }
    }

    IEnumerator DissolveDroplet()
    {
        while (isGrounded == true)
        {
            yield return new WaitForSeconds(0.4f);
            Destroy(gameObject);
        }
    }
}
