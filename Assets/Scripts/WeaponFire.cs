using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public float damage = 1;
    public float range = 150f;
    LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Shooting();
    }

    void Shooting()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1"))
        {
            
            
            Physics.Raycast(this.transform.position, fwd, out hit, range);
            //Debug.Log("Player is shooting");
            //Debug.Log("Damage is" + damage);
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.DamgeRecieved(damage);
            }

            
            

            DrawingShot(this.transform.position, fwd, range, hit);

            
        }
    }

    void DrawingShot(Vector3 initial, Vector3 direction, float length, RaycastHit hit) {

        Vector3 endPosition = initial + (length * direction);

        if (Physics.Raycast(this.transform.position, direction, out hit, length))
        {
            endPosition = hit.point;
        }

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, initial);
        lineRenderer.SetPosition(1, endPosition);
    
        StartCoroutine(DrawDelay());
        
    }

    IEnumerator DrawDelay() {
        yield return new WaitForSeconds(0.25f);
        lineRenderer.positionCount = 0;
    }

    /*public void OnTriggerEnter(Collider collider)
    {
        SendMessageUpwards("DamageRecieved", damage);
    }
    */

}
