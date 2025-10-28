using FlaxEngine;

namespace Game;

/// <summary>
/// UIAnim_Base class.
/// </summary>
public abstract class UIAnim_Base
{
    public JsonAssetReference<TimeVarying> Varying;

    private float _delay;
    public float Delay { get => _delay; set => _delay = Mathf.Max(value, 0); }

    public bool CurrAsStart { get; set; } = true;

    public float Duration => Varying.Instance?.Duration ?? 0;

    public abstract bool ValidCheck(UIControl target);
    protected abstract void PlayAtT(UIControl target, float t);

    public virtual void OnInit() { }
    public virtual void OnStart(UIControl target) { }

    public (float t, int looped) GetT(float time)
    {
        var delayedTime = GetDelayedTime(time);
        return Varying.Instance?.GetLerpTByTime(delayedTime) ?? (1f, 1);
    }

    public bool IsOutOfTime(float time)
    {
        var delayedTime = GetDelayedTime(time);
        return delayedTime >= Duration;
    }

    /// <returns>looped times</returns>
    public int Play(UIControl target, float time)
    {
        if (!ValidCheck(target)) return 1;

        //var (normTime, loopedTimes) = GetNormalizedTime(time);
        var (t, looped) = GetT(time);
        PlayAtT(target, t);
        return looped;
    }

    public void EndImmediately(UIControl target)
    {
        if (!ValidCheck(target)) return;
        PlayAtT(target, 1);
    }

    float GetDelayedTime(float time)
    {
        return time - Delay;
    }

}

public abstract class UIAnim_Base<TVal> : UIAnim_Base
{
    public TVal Start;
    public TVal End;

    TVal _readStart;

    public TVal ValidStart => CurrAsStart ? _readStart : Start;

    public abstract TVal ReadCurrentValue(UIControl target);
    public abstract void ApplyVaryingValue(UIControl target, TVal value);
    protected abstract TVal GetVaryingValue(float normalizedTime);

    public override void OnStart(UIControl target)
    {
        base.OnStart(target);
        _readStart = ReadCurrentValue(target);
    }

    protected sealed override void PlayAtT(UIControl target, float normTime)
    {
        var value = GetVaryingValue(normTime);
        ApplyVaryingValue(target, value);
    }
}

