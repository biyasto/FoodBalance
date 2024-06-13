using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Plate;
    [SerializeField] private FoodController food;
    // Start is called before the first frame update
    [SerializeField] public float speed = 1; // Adjustable movement speed
    public Vector3 movement;
    
    [SerializeField] private Rigidbody rb;
    private float timer = 0.3f;
    private float horizontal = 1f;
    float vertical = 0.4f;
    private float timerStart = 1f;

    private bool isStart = false;
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            food.ActiveFood();
            isStart = true;
        }
        
        if(!isStart) return;
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
 
    private bool isDone = false;
 
    void moveCharacter(Vector3 direction)
    {
        if (isDone) return;
        if (rb.transform.localPosition.x > 5.5)
        {
            rb.velocity = Vector3.zero;
            Destroy(Plate);
            food.CheckFood();
            isDone = true;
            return;
        }
        rb.velocity = direction * speed;
    }
}
