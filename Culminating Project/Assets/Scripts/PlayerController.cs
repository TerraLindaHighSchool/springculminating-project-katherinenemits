using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float horizontalInput;
    public float speed = 10.0f;
    public float zRange = 3;

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public TextMeshProUGUI titleText;

    // allows the player to jump
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        //sets the score to 0 at begining of game; updates the score
        score = 0;
        UpdateScore(0);
    }



    // only allows the player to jump once at a time
    void Update()
    {
        //disables title text
        titleText.gameObject.SetActive(false);
        //makes player jump and updates score
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            UpdateScore(1);

        }
        //makes the player move left and right within a range
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(0, 0, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(0, 0, zRange);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            //checks if player is on the ground
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //end statement
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
            
            //makes the player stop running
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            restartButton.gameObject.SetActive(true);
            
        }
        else if (collision.gameObject.CompareTag("Cone"))
        {
            //end statement
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
            
            //makes the player stop running
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            restartButton.gameObject.SetActive(true);
        }
    }  
 
    //gets score to add and adds it to the score
    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    
}