using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float speed = 1; // Adjustable movement speed
    public Vector3 movement;
    
    [SerializeField] private Rigidbody rb;
    private float timer = 0.4f;
    private float horizontal = 1f;
    float vertical = 0.5f;
    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>.8f)
        {
            timer = 0;
            vertical *= -1;
        }
        movement = new Vector3(horizontal, vertical ,0);
    }
 
 
    void FixedUpdate()
    {
        moveCharacter(movement);
    }
 
 
    void moveCharacter(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }
}
