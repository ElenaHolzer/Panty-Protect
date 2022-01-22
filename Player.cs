using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private string DROPLET_TAG = "Droplet";

    public int minFullness = 0;
    public int currentFullness;
    public PadBar padBar;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentFullness = minFullness;
        padBar.SetMinFullness(minFullness);
    }

    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && currentFullness >= 10)
        {
            currentFullness = 0;
            padBar.SetFullness(0);
        }
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if(movementX > 0 || movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Droplet contact with player
        if (collision.gameObject.CompareTag(DROPLET_TAG))
        {
            currentFullness += 1;
            padBar.SetFullness(currentFullness);
        }
    }
}
