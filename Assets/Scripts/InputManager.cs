using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public GameObject fx_Stars;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Mole")
                {
                    //instantiate fx at the point of the hit
                    Instantiate(fx_Stars, hit.point, Quaternion.identity);

                    MoleBehavior mole = hit.collider.gameObject.GetComponent<MoleBehavior>();
                    mole.SwitchCollider(0);
                    mole.anim.SetTrigger("Hit");
                  

                   // Debug.Log(hit.collider.gameObject + " got hit");
                }

                if(hit.collider.tag == "Horse")
                {
                    //instantiate fx at the point of the hit
                    Instantiate(fx_Stars, hit.point, Quaternion.identity);

                    MoleBehavior mole = hit.collider.gameObject.GetComponent<MoleBehavior>();
                    mole.SwitchCollider(0);
                    mole.anim.SetTrigger("HorseHit");

                   // Debug.Log(hit.collider.gameObject + " got hit");
                }
                
            }
        }
    }
}
