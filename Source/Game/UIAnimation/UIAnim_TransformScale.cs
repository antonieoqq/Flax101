// Copyright (C) 2025 XDF. All rights reserved.


using FlaxEngine;

namespace Game;

[ContentContextMenu("New/UI/Animation/TransformScale")]
public class UIAnim_TransformScale : UIAnim_Base<Float2>
{
    public override bool ValidCheck(UIControl target)
    {
        return target?.Control != null;
    }

    public override void ApplyVaryingValue(UIControl target, Float2 value)
    {
        target.Control.Scale = value;
    }

    public override Float2 ReadCurrentValue(UIControl target)
    {
        return target.Control.Scale;
    }

    protected override Float2 GetVaryingValue(float normalizedTime)
    {
        return Float2.Lerp(ValidStart, End, normalizedTime);
    }
}