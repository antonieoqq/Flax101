using FlaxEngine;
using static XDFLib.XMath;

namespace Game;

/// <summary>
/// EaseVarying class.
/// </summary>
[ContentContextMenu("New/UI/TimeVarying/EaseVarying")]
public class EaseVarying : TimeVarying
{
    public EEase Ease { get; set; } = EEase.Linear;
    public bool Symmetry { get; set; } = false;

    public override (float percent, int looped) GetLerpTByTime(float time)
    {
        var (percent, looped) = GetNormalizedTime(time);
        percent = Symmetry ? GetSymmetryPercent(percent) : percent;
        return ((float)Easing(percent, Ease), looped);
    }

    float GetSymmetryPercent(float percent)
    {
        var p = percent * 2;
        return p > 1 ? 2 - p : p;
    }
}
