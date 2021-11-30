using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private float jumpForce = 380f;

    private float gravityModifier = 0.9f;

    public bool gameOver = false;

    private float limY = 14f;
    private float limDownY = 0f;

    private AudioSource PlayerAudio;
    private AudioSource CameraAudio;


    // Sonidos
    public AudioClip jumpClip;
    public AudioClip explosionClip;






    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;


        PlayerAudio = GetComponent<AudioSource>();
        CameraAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        CameraAudio.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            PlayerAudio.PlayOneShot(jumpClip, 1f);
        }

        if (transform.position.y >= limY)
        {
            transform.position = new Vector3(transform.position.x, limY, transform.position.z);
        }

        if (transform.position.y <= limDownY && !gameOver)
        {
            gameOver = true;
            PlayerAudio.PlayOneShot(explosionClip, 1);
            
        }

    }



    private void OnCollisionEnter(Collision OtherCollider)
    {
        if (!gameOver)
        {

            if (OtherCollider.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
               
               // Repreoduccion de Audio
                CameraAudio.volume = 0.08f;
            }
        }

    }




    
}
