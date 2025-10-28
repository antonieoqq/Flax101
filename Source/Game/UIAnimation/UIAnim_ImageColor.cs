using FlaxEngine;
using FlaxEngine.GUI;

namespace Game;

/// <summary>
/// UIAnim_ImageColor class.
/// </summary>
[ContentContextMenu("New/UI/Animation/ImageColor")]
public class UIAnim_ImageColor : UIAnim_Base<Color>
{
    public override bool ValidCheck(UIControl target)
    {
        return target?.Control as Image != null;
    }

    public override Color ReadCurrentValue(UIControl target)
    {
        var img = target?.Control as Image;
        return img.Color;
    }

    public override void ApplyVaryingValue(UIControl target, Color value)
    {
        var img = target?.Control as Image;
        img.Color = value;
    }

    protected override Color GetVaryingValue(float normalizedTime)
    {
        return Color.Lerp(ValidStart, End, normalizedTime);
    }

}
