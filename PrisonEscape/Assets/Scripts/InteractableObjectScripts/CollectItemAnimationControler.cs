using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemAnimationControler : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private GameObject sparklesChild;

    public Sprite combShivSprite;
    public Sprite brassKnucklesSprite;


    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sparklesChild = transform.GetChild(0).gameObject;
    }

    public void updateCurrentSprite()
    {


        if (Random.Range(0, 2) == 0)
        {
            spriteRenderer.sprite = combShivSprite;
        }
        else
        {
            spriteRenderer.sprite = brassKnucklesSprite;
        }

        

    }

    public void startItemAnimation()
    {
        spriteRenderer.enabled = true;
        sparklesChild.SetActive(true);

        //  get sprite of item gained
        updateCurrentSprite();
       
        //  leave idle
        animator.SetBool("IsAnimating", true);
        
    }

    //  referenced inside an animation event
    public void endOfItemAnimation()
    {
        //  return to idle
        animator.SetBool("IsAnimating", false);

        //  remove current weapon sprite
        spriteRenderer.sprite = null;
        
        //  disapear
        spriteRenderer.enabled = false;
        sparklesChild.SetActive(false);


    }





}
