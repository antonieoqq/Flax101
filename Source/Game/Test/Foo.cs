using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlaxEngine;
using XDFLib;

namespace Game;

/// <summary>
/// Foo Script.
/// </summary>
[Category("Test")]
public class Foo : Script
{
    [Header("Time Varying")]
    public XMath.EEase EaseType;
    [Range(0, 2)]
    public float Duration = 1;
    public Vector3 StartValue = Vector3.Zero;
    public Vector3 EndValue = Vector3.Up;

    float _timer = 0;


    public BezierCurve<float> FloatCurve = new BezierCurve<float>(new BezierCurve<float>.Keyframe(0, 0), new BezierCurve<float>.Keyframe(1, 1));

    /// <inheritdoc/>
    public override void OnStart()
    {
        // Here you can add code that needs to be called when script is created, just before the first game update
    }

    /// <inheritdoc/>
    public override void OnEnable()
    {
        _timer = 0;
        // Here you can add code that needs to be called when script is enabled (eg. register for events)
    }

    /// <inheritdoc/>
    public override void OnDisable()
    {
        // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
    }

    /// <inheritdoc/>
    public override void OnUpdate()
    {
        _timer = Mathf.Clamp(_timer + Time.DeltaTime, 0, Duration);
        var t = Duration > 0 ? _timer / Duration : 1;
        var ease = XMath.Easing(t, EaseType);
        Actor.Position = Vector3.Lerp(StartValue, EndValue, (float)ease);
        // Here you can add code that needs to be called every frame
    }
}
