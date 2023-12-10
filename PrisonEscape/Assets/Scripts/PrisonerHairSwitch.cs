using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerHairSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Parent;
    private GuardAnimate GA;
    private RandomHairColor hair;
    private Vector2 currentDirection;
    private bool up, down, left, right;
    public GameObject HairLeft, HairRight, HairUp, HairDown;
    private SpriteRenderer Lcolor, Rcolor, Dcolor, Ucolor;
    void Start()
    {
        Parent = transform.parent.gameObject;
        GA = Parent.GetComponent<GuardAnimate>();
        hair = GetComponent<RandomHairColor>();
        
        Lcolor = HairLeft.GetComponent<SpriteRenderer>();
        Rcolor = HairRight.GetComponent<SpriteRenderer>();
        Ucolor = HairUp.GetComponent<SpriteRenderer>();
        Dcolor = HairDown.GetComponent<SpriteRenderer>();


        up = false;
        down = false;
        left = false;
        right = false;

        
    }

    // Update is called once per frame
    void Update()
    {
       colorHair();
       getDirection();
       hairSwitch();

    }

    private void colorHair()
    {
        Lcolor.color = hair.getColor();
        Rcolor.color = hair.getColor();
        Ucolor.color = hair.getColor();
        Dcolor.color = hair.getColor();
    }

    private void hairSwitch()
    {
        if (right)
        {
            HairRight.SetActive(true);
        }
        else { HairRight.SetActive(false);}

        if (left)
        {
            HairLeft.SetActive(true);
        }
        else { HairLeft.SetActive(false); }

        if (up)
        {
            HairUp.SetActive(true);
        }
        else { HairUp.SetActive(false); }

        if (down)
        {
            HairDown.SetActive(true);
        }
        else { HairDown.SetActive(false); }

    }

    private void getDirection()
    {

        currentDirection = GA.getCurrentDirection();

        if (currentDirection.x > .7)
        {
            right = true;
            //Debug.Log("Right" + right);
        }
        else { right = false; }
        //--------------------------------
        if (currentDirection.x < -.7)
        {
            left = true;
            //Debug.Log("left" + left);
        }
        else
        { left = false; }
        //------------------------------
        if (currentDirection.y > .7)
        {
            up = true;
            //Debug.Log("up" + up);
        }
        else { up = false; }
        //-------------------------------
        if (currentDirection.y < -.7)
        {
            down = true;
            //Debug.Log("down" + down);
        }
        else { down = false; }
    }
}

