using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehavior : MonoBehaviour
{

    Collider col;
    public int hitPoints = 1;
    public int score = 1;
    [HideInInspector]public GameObject myParent;

    [HideInInspector] public Animator anim;

    public GameObject popupText;

    private void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
        anim = GetComponent<Animator>();
    }

    public void DestroyObj()
    {
        myParent.GetComponent<HoleBehavior>().hasMole = false;
        Destroy(gameObject);
    }
    public void SwitchCollider(int num)
    {
        col.enabled = (num == 0) ? false : true;


    }
    //for points later on
    public void GotHit()
    {
        hitPoints--;

        if (hitPoints > 0)
        {
            col.enabled = true;
        }

        else
        {
            myParent.GetComponent <HoleBehavior>().hasMole = false;
            ScoreManager.AddScore(score);

            GameObject pop = Instantiate(popupText) as GameObject;
            pop.transform.SetParent(UIManager.instance.transform, false);
            //position of mole gets translated from world point to screen point
            pop.transform.position = Camera.main.WorldToScreenPoint(transform.position);

            PopupText popText = pop.GetComponent<PopupText>();
            popText.ShowText(score);

            Destroy(gameObject);
        }
    }



}
