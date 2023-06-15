using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject mainLight;
    public GameObject redLight;

    Rigidbody rb;
    Animator animator;

    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource enemyDeathSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (!Input.anyKey)
        {
            animator.SetInteger("state",0);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
            animator.SetInteger("state",1);
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            animator.SetInteger("state",1);
        }
    
        if (Input.GetButtonDown("Vertical"))
        {
            animator.SetInteger("state",1);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
            enemyDeathSound.Play();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            
            redLight.SetActive(true);
            mainLight.SetActive(false);
        }

        if (other.gameObject.CompareTag("Undo Trigger"))
        {
            
            redLight.SetActive(false);
            mainLight.SetActive(true);
        }
        
    }
}
