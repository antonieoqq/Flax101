using FlaxEngine;
using XDFLib.Extensions;

namespace Game;

/// <summary>
/// TimeVarying class.
/// </summary>
public abstract class TimeVarying
{
    public const float MinDuration = 0.001f;
    public enum ELoopType
    {
        None,
        Loop,
        Yoyo,
    }

    float _duration = 1;
    public float Duration
    {
        get => _duration;
        set => _duration = Mathf.Max(MinDuration, value);
    }
    public ELoopType LoopType { get; set; } = ELoopType.None;

    public abstract (float percent, int looped) GetLerpTByTime(float time);

    public (float normTime, int looped) GetNormalizedTime(float time)
    {
        time = Mathf.Max(0, time);

        var normalized = time / Duration;
        var looped = Mathf.FloorToInt(normalized);
        var normTime = normalized - looped;

        switch (LoopType)
        {
            case ELoopType.Loop:
                return (normTime, looped);
            case ELoopType.Yoyo:
                return (looped.IsOdd() ? 1 - normTime : normTime, looped);
            case ELoopType.None:
            default:
                return (looped > 0 ? 1 : normTime, looped);
        }
    }
}
