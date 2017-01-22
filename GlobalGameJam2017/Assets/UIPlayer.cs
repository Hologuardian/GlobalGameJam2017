using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIPlayer : MonoBehaviour
{
    public static Dictionary<Player, UIPlayer> UIplayers = new Dictionary<Player, UIPlayer>();

    public enum Player { Pink = 0, Bub = 1 };
    public enum Input { rb = 0, rt = 3, lb = 2, lt = 1 };

    public bool exists = false;
    public Player player = Player.Pink;

    public Sprite portrait_disabled;
    public Sprite portrait_active;

    public Image portrait;
    public bool skill4_up;

    public Sprite skill1_active;
    public bool skill1_up;
    public Image skill1;

    public Sprite skill2_active;
    public bool skill2_up;
    public Image skill2;

    public Sprite skill3_active;
    public bool skill3_up;
    public Image skill3;

    public Image health;

    void Start()
    {
        UIplayers.Add(player, this);

        if (exists)
            Enable();
        else
            Disable();
    }

    public void Enable()
    {
        exists = true;
        portrait.sprite = portrait_active;
        skill1.enabled = skill2.enabled = skill3.enabled = health.enabled = true;
    }

    public void Disable()
    {
        exists = false;
        portrait.sprite = portrait_disabled;
        skill1.enabled = skill2.enabled = skill3.enabled = health.enabled = false;
    }

    private void EnableSkill(Image skill, Sprite active)
    {
        skill.sprite = active;
    }

    private void DisableSkill(Image skill, Sprite disable)
    {
        skill.sprite = disable;
    }

    public void ToggleSkill(Input skill)
    {
        switch (skill)
        {
            case Input.rb:
                if (skill1_up)
                {
                    DisableSkill(skill1, portrait_disabled);
                }
                else
                {
                    EnableSkill(skill1, skill1_active);
                }
                skill1_up = !skill1_up;
                break;
            case Input.lt:
                if (skill2_up)
                {
                    DisableSkill(skill2, portrait_disabled);
                }
                else
                {
                    EnableSkill(skill2, skill2_active);
                }
                skill2_up = !skill2_up;
                break;
            case Input.lb:
                if (skill3_up)
                {
                    DisableSkill(skill3, portrait_disabled);
                }
                else
                {
                    EnableSkill(skill3, skill3_active);
                }
                skill3_up = !skill3_up;
                break;
            case Input.rt:
                if (skill4_up)
                {
                    DisableSkill(portrait, portrait_disabled);
                }
                else
                {
                    EnableSkill(portrait, portrait_active);
                }
                skill4_up = !skill4_up;
                break;
        }
    }

    public void SetHealth(float percentage)
    {
        health.fillAmount = percentage;
    }
}
