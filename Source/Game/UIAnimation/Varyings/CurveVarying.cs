using FlaxEngine;

namespace Game;

/// <summary>
/// CurveVarying class.
/// </summary>
[ContentContextMenu("New/UI/TimeVarying/CurveVarying")]
public class CurveVarying : TimeVarying
{
    public BezierCurve<float> FloatCurve = new BezierCurve<float>(new BezierCurve<float>.Keyframe(0, 0), new BezierCurve<float>.Keyframe(1, 1));

    public override (float percent, int looped) GetLerpTByTime(float time)
    {
        var (percent, looped) = GetNormalizedTime(time);
        if (FloatCurve.Keyframes.Length == 0)
        {
            return (percent, looped);
        }
        else
        {
            FloatCurve.Evaluate(out var val, percent, loop: false);
            return (val, looped);
        }
    }
}
