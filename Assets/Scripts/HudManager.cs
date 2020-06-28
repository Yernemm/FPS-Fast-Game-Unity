using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    public Text healthText;
    public Text deadText;

    private GameObject player;
    
    public Image crosshair;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStats ps = player.GetComponent<PlayerStats>();
        GrapplingHook gh = player.GetComponent<GrapplingHook>();
        healthText.text = "Helf: " + ps.getHealth();
        if(ps.isDead()){
            deadText.enabled = true;
        }
        if(gh.canHook()){
            crosshair.color = new Color(0f,0f,0f,255f);  
            crosshair.rectTransform.localScale = new Vector3(1,1,1);
        } else{
            crosshair.color = new Color(255f,255f,255f,20f);  
            crosshair.rectTransform.localScale = new Vector3(0.5f,0.5f,1);
        }
    }
}
