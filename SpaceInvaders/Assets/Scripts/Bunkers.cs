using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunkers : MonoBehaviour
{
    private int bunkerHealth = 100;
    private Rigidbody2D bunker;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject); // destroy bullet
        bunkerHealth = bunkerHealth - 20;
        if (bunkerHealth == 20)
        {
            Destroy(bunker.gameObject);
        }
    }
    private void Start()
    {
        bunker = GetComponent<Rigidbody2D>();
    }
}
