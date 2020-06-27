using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    public Text healthText;
    public Text deadText;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStats ps = player.GetComponent<PlayerStats>();
        healthText.text = "Helf: " + ps.getHealth();
        if(ps.isDead()){
            deadText.enabled = true;
        }
    }
}
