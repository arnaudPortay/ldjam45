using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LunetteScript : Ability
{
    public SpriteRenderer image;
    public Sprite neatSprite;

    public UnityEvent picked;

    protected override void InitAbility()
    {
        if (image != null && neatSprite != null)
        {
            image.sprite = neatSprite;
            picked.Invoke();
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
