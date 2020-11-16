using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAni : MonoBehaviour
{
    Animator anim;

    int animNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAni()
    {
        animNumber++;

        if (animNumber > 3) animNumber = 0;
        anim.SetInteger("aniNum", animNumber);
    }
}
