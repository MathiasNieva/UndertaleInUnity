using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 10;
    public int maxHp = 10;
    public TextMeshProUGUI hpText;
    public ExitFight exit;
    public AudioSource audioSource;
    public AudioClip takeDmgSound;
    // Start is called before the first frame update
    public void TakeDamage(int dmg)
    {
        audioSource.PlayOneShot(takeDmgSound);
        hp = hp - dmg;
        hpText.text = "HP " + hp.ToString() + "/10";
        if (hp <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        exit.Exit();
    }
}
