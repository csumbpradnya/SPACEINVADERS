using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    private int enemyHealth = 40;
    private Rigidbody2D enemy;
    private ScoreManager scoreManager;
    
    public AudioSource audioSrc;
    public AudioClip destroyAudio;
    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>(); 
        scoreManager = GameObject.Find("Text (TMP)").GetComponent<ScoreManager>();
        audioSrc = GetComponent<AudioSource>();
    }

    //-----------------------------------------------------------------------------
    void OnCollisionEnter2D(Collision2D collision)
    {
        // todo - trigger death animation
        if (collision.gameObject.tag == "friendly")
        {
            Destroy(collision.gameObject); // destroy bullet
            if (enemyHealth > 20)
            {
                enemyHealth = enemyHealth - 20;
            }
            else if (enemyHealth <= 20)
            {
                if (enemy.gameObject.tag == "enemy1")
                {
                    scoreManager.scoreEnemy1();
                }
                else if (enemy.gameObject.tag == "enemy2")
                {
                    scoreManager.scoreEnemy2();
                }
                else if (enemy.gameObject.tag == "enemy3")
                {
                    scoreManager.scoreEnemy3();
                }
                else if (enemy.gameObject.tag == "enemy4")
                {
                    scoreManager.scoreEnemy4();
                }
                
                scoreManager.HighScore();
                
                audioSrc.clip = destroyAudio;
                audioSrc.Play();
                StartCoroutine(Destroytimer());
            }
        }
    }

    IEnumerator Destroytimer()
    {
        enemy.GetComponent<Animator>().SetTrigger("DestroyT");
        yield return new WaitForSeconds(4);
        Destroy(enemy.gameObject);
    }
}
