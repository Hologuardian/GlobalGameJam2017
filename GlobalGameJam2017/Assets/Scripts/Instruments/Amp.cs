using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amp : MonoBehaviour {
    bool droped,Heal;
    public float HealAmount = 20;
    float AmpHealth;
    List<TopDownController> PlayersGettingHealed, PlayersGettingDamagePlus;
    Guitar Host;
    // Use this for initialization
    void Start () {
        PlayersGettingHealed = new List<TopDownController>();
        PlayersGettingDamagePlus = new List<TopDownController>();
	}
    public void Dropped(bool _Heal) {
        this.GetComponent<Renderer>().enabled = true;
        Heal = _Heal;
        print(Heal);
    }
	// Update is called once per frame
	void Update () {
        if (PlayersGettingHealed.Count > 0) {
            print("Hello");
            HealPlayers();
        }
        if (AmpHealth < 0) {
            Host.AmpDropped = false;
            Destroy(this.gameObject);

        }
	}

    void HealPlayers() {
        foreach (TopDownController player in PlayersGettingHealed) {
            player.Health += HealAmount * Time.deltaTime;
            print(player.Health);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            print(Heal);
            if (Heal)
            {
                PlayersGettingHealed.Add(other.GetComponent<TopDownController>());
                print(PlayersGettingHealed.Count);
            }
            else {
                PlayersGettingDamagePlus.Add(other.GetComponent<TopDownController>());
                
            }
        }
    }
    void onTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (Heal)
            {
                PlayersGettingHealed.Remove(other.GetComponent<TopDownController>());
            }
            else
            {
                PlayersGettingDamagePlus[PlayersGettingDamagePlus.IndexOf(other.GetComponent<TopDownController>())].GetComponent<Instrument>().DamageMuilty = 1;
                PlayersGettingDamagePlus.Add(other.GetComponent<TopDownController>()); 
            }
        }
    }
}
