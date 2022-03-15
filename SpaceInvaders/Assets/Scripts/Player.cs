using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;

    private Animator playerAnimator;
    private Rigidbody2D body;
    
    public AudioSource audioSrc;
    public AudioClip shootAudio;

    private int playerHealth = 20;
    //-----------------------------------------------------------------------------
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        float horizontalExtent = Camera.main.orthographicSize * Camera.main.aspect;
        if (Mathf.Abs(body.position.x) > horizontalExtent)
        {
            body.velocity = new Vector2(-body.velocity.x, body.velocity.y);
        }
        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector2.right * axis, ForceMode2D.Force);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // todo - trigger a "shoot" on the animator
            audioSrc.clip = shootAudio;
            audioSrc.Play();
            playerAnimator.SetTrigger("Shoot");
            GameObject bullet = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            bullet.tag = "friendly";
            Destroy(bullet, 6f);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject); // destroy bullet
        if (col.gameObject.tag == "enemy")
        {
            playerHealth = playerHealth - 10;
            if (playerHealth <= 10)
            {
                StartCoroutine(Destroytimer());
                SceneManager.LoadScene("Credits");
            }
        }
    }
    
    IEnumerator Destroytimer()
    {
        playerAnimator.SetTrigger("DestroyT");
        yield return new WaitForSeconds(4);
        Destroy(body.gameObject);
    }
    
    
}
