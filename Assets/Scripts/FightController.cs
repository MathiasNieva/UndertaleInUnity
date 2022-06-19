using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightController : MonoBehaviour
{
    public GameObject fightUi;
    public HeartMovement heart;
    public GameObject hpUi;
    public GameObject Atk1;
    Animator Atk1Animation;
    public GameObject Atk2;
    Animator Atk2Animation;
    private bool started = false;
    private bool atk1Finished = false;
    private bool atk2Finished = false;
    public ExitFight exit;
    public TextMeshProUGUI hpText;

    // Update is called once per frame
    void Update()
    {
        
        if (started && Atk1Animation.GetCurrentAnimatorStateInfo(0).IsName("BoneAttack1"))
        {
            Atk1Animation.SetBool("StartAtk1", false);
            atk1Finished = true;
        }
        else if (atk1Finished && !atk2Finished && Atk1Animation.GetCurrentAnimatorStateInfo(0).IsName("Wait"))
        {
            Atk2Animation.SetBool("StartAtk2", true);
        }

        if (started && Atk2Animation.GetCurrentAnimatorStateInfo(0).IsName("BoneAttack2"))
        {
            Atk2Animation.SetBool("StartAtk2", false);
            atk2Finished = true;
        }
        else if (atk2Finished && Atk2Animation.GetCurrentAnimatorStateInfo(0).IsName("Wait"))
        {
            hpText.text = "Victory!!!!!!";
            exit.Exit();
        }
    }

    public void StartFight()
    {
        fightUi.gameObject.SetActive(false);
        heart.gameObject.SetActive(true);
        hpUi.SetActive(true);
        heart.SetHeart();
        Atk1Animation = Atk1.GetComponent<Animator>();
        Atk1Animation.SetBool("StartAtk1", true);
        Atk2Animation = Atk2.GetComponent<Animator>();
        started = true;
    }
}
