using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update

    public float radius = 10f;
    public float force = 50;

    public int damage = 20;

   
    void Start()
    {
        
        int hitcount = 0;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        Debug.Log(hitColliders);
        foreach (Collider c in hitColliders)
        {
            Debug.Log(hitcount);
            if(c.gameObject.name == "Player" && hitcount == 0){
                hitcount++;
                Debug.Log("player hit");
                Debug.Log(c.gameObject);
                PlayerController pc = c.GetComponent<PlayerController>();
                Vector3 direction = Vector3.Normalize(c.transform.position - transform.position);
                pc.velocity += direction * force;
                c.gameObject.GetComponent<PlayerStats>().damage(damage);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
