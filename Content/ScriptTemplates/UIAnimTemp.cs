%copyright%
using FlaxEngine;
using FlaxEngine.GUI;

namespace %namespace%;

[ContentContextMenu("New/UI/Animation/%class%")]
public class %class% : UIAnim_Base<TVal>
{
    public override bool ValidCheck(UIControl target)
    {
        return target != null;
    }

    public override void ApplyVaryingValue(UIControl target, TVal value)
    {
    }

    public override TVal ReadCurrentValue(UIControl target)
    {
    }

    protected override TVal GetVaryingValue(float normalizedTime)
    {
    }
}