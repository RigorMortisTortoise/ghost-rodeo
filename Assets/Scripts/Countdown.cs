using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    private void Start()
    {
        this.gameObject.SetActive(true);
    }

    public void SetCountDown()
    {
        GameManager.instance.countDownDone = true;
        GameManager.instance.StartCoroutine("PlayTimer");
        this.gameObject.SetActive(false);
        Debug.Log("SetCountDown is working");
        
    }
}
