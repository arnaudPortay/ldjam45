using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunetteScript : Ability
{
    public SpriteRenderer image;
    public Sprite neatSprite;

    protected override void InitAbility()
    {
        if (image != null && neatSprite != null)
        {
            image.sprite = neatSprite;
        }
    }

    public override string GetPickUpText()
    {
        return "Vision ability acquired";
    }

    public override string GetPresentationText()
    {
        return "You can see the world completely sharp.";
    }
}
