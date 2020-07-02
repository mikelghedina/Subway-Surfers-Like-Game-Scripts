using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    public int damage = 1;
    public ScoreManager ScManager;
    private Rigidbody rb;
    public float speed = 5f;
    public float jumpForce = 5f;
    private bool isGrounded;

    public Material colorSwitch;
    public Material defaultMaterial;
    float duration = 1f;
    Renderer rend;
    

    public ParticleSystem explosion;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Jump();
    }
    
    private void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3 (moveHorizontal, 0f, moveVertical);
        

        rb.AddForce(playerMovement * speed);
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag ==("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
        
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
            
        }
        
    }
    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacles")
        {
            ScManager.health -= damage;
            Instantiate(explosion, transform.position, transform.rotation);

            while (true)
            {
                StartCoroutine(SwitchColor());
                break;
            }
           
            if (ScManager.health <= 0)
            {
                
                SceneManager.LoadScene("Menu");
            }
            
            
        }
        if (collision.gameObject.tag == "Gameover")
        {
            SceneManager.LoadScene("Menu");
        }
    }
    
    IEnumerator SwitchColor()
    {
        rend.material = colorSwitch;
        yield return new WaitForSeconds(duration);
        rend.material = defaultMaterial;
    }
}
