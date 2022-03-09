using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int enemyHealth = 100;
    private Rigidbody2D enemy;
    private ScoreManager scoreManager;
    
    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>(); 
        scoreManager = GameObject.Find("Text (TMP)").GetComponent<ScoreManager>();
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
                Destroy(enemy.gameObject);
            }
            Debug.Log("Ouch!");
        }
    }
}
