using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    public LineRenderer lineRenderer;
    private float ropeLength;
    private Vector3 ropeEnd;

    private bool attached = false;

    public GameObject hookFrom;

    public GameObject armJoint;

    public float handRotationSpeed;

     private Quaternion _lookRotation;
     private Vector3 _direction;

     public LayerMask playerMask;

     private Quaternion initialHandRotation;

     private GameObject hookedTo;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = false;
        initialHandRotation = armJoint.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
       lineRenderer.SetPosition(0, hookFrom.transform.position);

        if(Input.GetMouseButtonDown(1)){
            //clicked

            

            RaycastHit hit;
            var ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if(Physics.Raycast(ray, out hit, 250f, ~playerMask)){
                Debug.Log(hit.point);
                lineRenderer.SetPosition(1, hit.point);

                ropeLength = Vector3.Distance(transform.position, hit.point);
                ropeEnd = hit.point;

                

                lineRenderer.enabled = true;
                attached = true;
                hookedTo = hit.collider.gameObject;

                if(hookedTo.tag == "PowerCube"){
                    hookedTo.GetComponent<PowerBlockInteraction>().isPlayerAttached = true;
                }

            }

            


        }else if(Input.GetMouseButton(1)){
            //held

           if(attached){

               _direction = (ropeEnd - armJoint.transform.position).normalized;
                _lookRotation = Quaternion.LookRotation(_direction);
                armJoint.transform.rotation = _lookRotation; //Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * handRotationSpeed);

           }
             

        }else if(Input.GetMouseButtonUp(1)){
            //let go

            lineRenderer.enabled = false;
            attached = false;
            armJoint.transform.rotation = initialHandRotation;


             if(hookedTo.tag == "PowerCube"){
                    hookedTo.GetComponent<PowerBlockInteraction>().isPlayerAttached = false;
            }

        }
        
    }
    
    private void FixedUpdate() {
        if(Input.GetMouseButton(1)){
            if(Vector3.Distance(transform.position, ropeEnd) >= ropeLength && attached){

                    gameObject.GetComponent<PlayerController>().velocity +=  Vector3.Normalize(ropeEnd - transform.position) * 2f;
                    //

            }
            if(Vector3.Distance(transform.position + gameObject.GetComponent<PlayerController>().velocity, ropeEnd) >= ropeLength && attached){
                float initMag = Vector3.Magnitude(gameObject.GetComponent<PlayerController>().velocity);
                Vector3 ropeEndToExtendedVelocity = - ropeEnd + transform.position + gameObject.GetComponent<PlayerController>().velocity;
                float distanceSubtractor = Vector3.Magnitude(ropeEndToExtendedVelocity) - ropeLength;
                gameObject.GetComponent<PlayerController>().velocity -= Vector3.Normalize(ropeEndToExtendedVelocity) * distanceSubtractor; 
                gameObject.GetComponent<PlayerController>().velocity = Vector3.Normalize(gameObject.GetComponent<PlayerController>().velocity) * initMag;
            }
        }
    }
}
