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
    public Sprite guardBatonSprite;
    public Sprite firstAidKitSprite;
    public Sprite adrenalineShotSprite;
    public Sprite waterSprite;
    public Sprite currencySprite;



    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sparklesChild = transform.GetChild(0).gameObject;
    }

    public void updateCurrentSprite(string us)
    {


        if (us == "combShiv")
        {
            spriteRenderer.sprite = combShivSprite;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (us == "brassKnuckles")
        {
            spriteRenderer.sprite = brassKnucklesSprite;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (us == "guardBaton")
        {
            spriteRenderer.sprite = guardBatonSprite;
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        else if (us == "firstAidKit")
        {
            spriteRenderer.sprite = firstAidKitSprite;
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else if (us == "adrenalineShot")
        {
            spriteRenderer.sprite= adrenalineShotSprite;
            transform.localScale = new Vector3(0.35f, 0.35f, 1f);
        }
        else if (us == "water")
        {
            spriteRenderer.sprite = waterSprite;
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        else if (us == "currency")
        {
            spriteRenderer.sprite = currencySprite;
            transform.localScale = new Vector3(0.35f, 0.35f, 1f);
        }




    }

    public void startItemAnimation(string s)
    {

        //  get sprite of item gained
        updateCurrentSprite(s);
        spriteRenderer.enabled = true;


        sparklesChild.SetActive(true);

        
       
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
