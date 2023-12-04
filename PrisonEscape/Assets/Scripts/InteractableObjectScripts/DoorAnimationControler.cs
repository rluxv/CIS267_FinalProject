using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationControler : MonoBehaviour
{
    private Animator animator;
    private GameObject doorColiderChild;
    private DoorColiderControler doorColiderControlerScript;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorColiderChild = transform.GetChild(0).gameObject;
        doorColiderControlerScript = doorColiderChild.GetComponent<DoorColiderControler>();
        animator.SetBool("IsDoorOpening", false);

    }


    //  this IS USED, 0 references in code, but is referenced by an event in the animation
    private void setDoorColiderInActive()
    {

        //  Wait till the animation is over
        doorColiderControlerScript.setColidersActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            animator.SetBool("IsDoorOpening", true);



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("INMATE"))
        {


            animator.SetBool("IsDoorOpening", false);

            //  do so imediately
            doorColiderControlerScript.setColidersActive(true);

        }
    }
}
