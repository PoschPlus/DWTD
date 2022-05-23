using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] string damageTag = "Damage";
    [SerializeField] int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == damageTag) { return; }
        health--;
    }*/
}
