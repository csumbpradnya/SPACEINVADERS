using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    private float timeSinceLastStep;
    public float secondsPerStep = 0.5f;
    private Vector2 marchDirection = Vector2.right;
    public float widthPerEnemy = 2f;
    public float heightPerEnemy = 2f;

    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastStep += Time.deltaTime;
        if (timeSinceLastStep > secondsPerStep)
        {
            timeSinceLastStep -= secondsPerStep;
            body.position += marchDirection * widthPerEnemy * 0.5f;
        }
        
        float horizontalExtent = Camera.main.orthographicSize * Camera.main.aspect - widthPerEnemy;
        
        if (Mathf.Abs(body.position.x) > horizontalExtent)
        {
            marchDirection *= -1f;
        }
    }
}
