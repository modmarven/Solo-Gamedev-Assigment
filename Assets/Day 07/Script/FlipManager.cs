using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipManager : MonoBehaviour
{
    private CharacterMovement characterMovement;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterMovement.horizontal < 0 && facingRight)
            FlipCharacter();
        else if (characterMovement.horizontal > 0 && !facingRight)
            FlipCharacter();
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
