using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    public LineRenderer lineRenderer;
    private float ropeLength;
    private Vector3 ropeEnd;

    private bool attached = false;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       lineRenderer.SetPosition(0, transform.position);

        if(Input.GetMouseButtonDown(1)){
            //clicked

            

            RaycastHit hit;
            var ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if(Physics.Raycast(ray, out hit)){
                Debug.Log(hit.point);
                lineRenderer.SetPosition(1, hit.point);

                ropeLength = Vector3.Distance(transform.position, hit.point);
                ropeEnd = hit.point;
                lineRenderer.enabled = true;
                attached = true;
            }

            


        }else if(Input.GetMouseButton(1)){
            //held

           
             

        }else if(Input.GetMouseButtonUp(1)){
            //let go

            lineRenderer.enabled = false;
            attached = false;
        }
        
    }
    
    private void FixedUpdate() {
        if(Input.GetMouseButton(1)){
            if(Vector3.Distance(transform.position, ropeEnd) >= ropeLength && attached){

                    gameObject.GetComponent<PlayerController>().velocity +=  Vector3.Normalize(ropeEnd - transform.position) * 5f;

                }
        }
    }
}
