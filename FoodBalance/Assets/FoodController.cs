using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] private List<GameObject> FoodList;
    void Start()
    {
        
    }

    

    // Update is called once per frame
    public void CheckFood()
    {
        foreach (var food in FoodList)
        {
            if (food.GetComponentInChildren<Rigidbody>().transform.position.y < -2)
            {
                food.transform.gameObject.SetActive(false);
            }
        }
    }
    

    public void ActiveFood()
    {

        foreach (var food in FoodList)
        {
            food.GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                                                   RigidbodyConstraints.FreezeRotationY |
                                                                   RigidbodyConstraints
                                                                       .FreezePositionZ; 
        }
        
    }
}
