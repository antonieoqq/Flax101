using FlaxEngine;
using FlaxEngine.GUI;

namespace Game;

/// <summary>
/// ImageCtrl Script.
/// </summary>
public class ImageCtrl : Script
{
    public UIControl ImageFillTest;
    [Range(0f, 1f)]
    public float Fill;
    public UIAnimations UIAnims { get; set; } = new();

    MaterialParameter _fillParam;
    /// <inheritdoc/>
    public override void OnStart()
    {
        UIAnims.Init();

        CacheFillParameter("Fill");

        // Here you can add code that needs to be called when script is created, just before the first game update
    }

    /// <inheritdoc/>
    public override void OnEnable()
    {
        UIAnims.Start();

    }

    /// <inheritdoc/>
    public override void OnDisable()
    {
        // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
    }

    /// <inheritdoc/>
    public override void OnUpdate()
    {
        UIAnims.Update(Time.UnscaledDeltaTime);
        TrySetImageFill(Fill);
        // Here you can add code that needs to be called every frame

    }

    void CacheFillParameter(string paramName)
    {
        var matBrush = ImageFillTest.Get<Image>()?.Brush as MaterialBrush;
        if (matBrush == null) return;
        _fillParam = matBrush.Material?.GetParameter(paramName);
        if (_fillParam == null) return;
        _fillParam.IsOverride = true;
        _fillParam.Value = Fill;
    }

    void TrySetImageFill(float fill)
    {
        if (_fillParam == null) return;

        _fillParam.Value = fill;
    }
}
