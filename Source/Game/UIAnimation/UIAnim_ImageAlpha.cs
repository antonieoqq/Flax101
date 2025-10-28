using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game;

/// <summary>
/// UIAnim_ImageAlpha class.
/// </summary>
[ContentContextMenu("New/UI/Animation/ImageAlpha")]
public class UIAnim_ImageAlpha : UIAnim_Base<float>
{
    public override bool ValidCheck(UIControl target)
    {
        return target?.Get<Image>() != null;
    }

    protected override float GetVaryingValue(float normalizedTime)
    {
        return Mathf.Lerp(ValidStart, End, normalizedTime);
    }

    public override float ReadCurrentValue(UIControl target)
    {
        var img = target.Get<Image>();
        return img.Color.A;
    }

    public override void ApplyVaryingValue(UIControl target, float value)
    {
        var img = target.Get<Image>();
        var newColor = img.Color;
        newColor.A = value;
        img.Color = newColor;
    }

}
