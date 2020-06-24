using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f);
    
        foreach (Collider c in hitColliders)
        {
            if(c.gameObject.name == "Player"){
                Debug.Log("player hit");
                PlayerController pc = c.GetComponent<PlayerController>();
                Vector3 direction = Vector3.Normalize(c.transform.position - transform.position);
                pc.velocity += direction * 50f;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
