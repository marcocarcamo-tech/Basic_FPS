using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement variables
    public float speed;
    public CharacterController controller;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Personal solution, ti works but not the best option
     * void IsWalking()
    {
        bool vertical = Input.GetButton("Vertical");
        bool horizontal = Input.GetButton("Horizontal");

        if (vertical == true && Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        } else if (vertical == true && Input.GetAxisRaw("Vertical") < 0) {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }*/

    private void FixedUpdate()
    {
        IsWalking();
    }

    void IsWalking()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * x + transform.forward * z;
        rigidbody.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }

    


}
