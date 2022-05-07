using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponentInChildren<Collider>();
    }

    private void Update()
    {
        if(health <= 0)
        {
            health = 0;
            Debug.Log("Targert health is" + health);
            Destroy(this.gameObject, 0.5f);

        }

    }
    public void DamgeRecieved(float damageAmount)
    {
        health -= damageAmount;
        

        
    }
}
