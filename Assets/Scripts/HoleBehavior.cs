using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBehavior : MonoBehaviour
{

    public GameObject[] moles;
    public bool hasMole;

    // Start is called before the first frame update
    void Start()
    {
        if (!hasMole)
        {
            Invoke("Spawn", Random.Range(0f, 7f));
        }
 
    }

    void Spawn()
    {
        if(!hasMole && GameManager.instance.countDownDone == true)
        {
            //int num = Random.Range(0, moles.Length);
            int num = CalculateRarity();

            GameObject mole = Instantiate(moles[num], transform.position, Quaternion.identity) as GameObject;
            MoleBehavior moleB = mole.GetComponent<MoleBehavior>();
            moleB.myParent = this.gameObject;
            moleB.score = moleB.score * GameManager.currentLevel;
            hasMole = true;

            moleB.gotHit = false;
            Debug.Log(moleB.gotHit);
        }

        Invoke("Spawn", Random.Range(3f, 7f));

    }

    int CalculateRarity()
    {
        int num = Random.Range(1, 101);

        //1% chance, return the fourth (well, fifth) element in the Unity Editor
        if(num <= 1)
        {
            return 10;
        }

        else if (num <= 5)
        {
            return 9;
        }

        else if (num <= 8)
        {
            return 8;
        }

        else if (num <= 20)
        {
            //return bad mole?
            return 7;
        }

        else if (num <= 30)
        {
            return 6;
        }

        else if (num <= 40)
        {
            return 5;
        }

        else if (num <= 50)
        {
            return 4;
        }

        else if (num <= 60)
        {
            return 3;
        }

        else if (num <= 70)
        {
            return 2;
        }

        else if (num <= 80)
        {
            return 1;
        }

        return 0;
    }

}
