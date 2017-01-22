using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amp : MonoBehaviour {
    bool dropped,Heal;
    public float HealAmount = 20;
    float AmpHealth;
    List<TopDownController> Players;
    Guitar Host;
    // Use this for initialization
    void Start () {
        Players= new List<TopDownController>();
	}
    public void Dropped(bool _Heal) {
        dropped = true;
        Heal = _Heal;
        print(Heal);
    }
	// Update is called once per frame
	void Update () {
        if (dropped)
        {
            if (Players.Count > 0 && Heal)
            {
                HealPlayers();
            }
            if (AmpHealth < 0)
            {
                Host.AmpDropped = false;
                Destroy(this.gameObject);
            }
        }
	}

    void HealPlayers() {
        foreach (TopDownController player in Players) {
            player.Health += HealAmount * Time.deltaTime;
            //print(player.Health);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            Players.Add(other.GetComponent<TopDownController>());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Players.Remove(other.GetComponent<TopDownController>());
        }
    }
}
