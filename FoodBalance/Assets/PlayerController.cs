using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float speed = 1; // Adjustable movement speed
    public Vector3 movement;
    
    [SerializeField] private Rigidbody rb;
    private float timer = 0.3f;
    private float horizontal = 1f;
    float vertical = 0.4f;
    private float timerStart = 1f;
    
    
    void Update()
    {
        timerStart -= Time.deltaTime;
        if (timerStart < 0)
        {
            timer += Time.deltaTime;
        }
        if(timer>.6f)
        {
            timer = 0;
            vertical *= -1;
        }
        movement = new Vector3(timerStart < 0?horizontal:0, timerStart < 0?vertical:0 ,0);
    }
 
 
    void FixedUpdate()
    {
        moveCharacter(movement);
    }
 
 
    void moveCharacter(Vector3 direction)
    {
        if (rb.transform.localPosition.x > 5.5)
        {
            rb.velocity = Vector3.zero;
            Destroy(this.gameObject);
            return;
        }
        rb.velocity = direction * speed;
    }
}
