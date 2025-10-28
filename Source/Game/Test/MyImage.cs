// Copyright (C) 2025 XDF. All rights reserved.

using FlaxEngine;
using FlaxEngine.GUI;

namespace Game;

/// <summary>
/// MyImage class.
/// </summary>
public class MyImage : Control
{
    public IBrush Brush { get; set; }
    public Color Tint { get; set; } = Color.White;
    
    public string FillParamName { get; set; } = string.Empty;
    [Range(0f, 1f)]
    public float FillAmount { get; set; } = 1;


    MaterialParameter _fillParam;

    public override void Draw()
    {
        base.Draw();
        if (Brush == null) { return; }

        TrySetImageFill(FillAmount);

        var rect = new Rectangle(Float2.Zero, base.Size);
        Brush.Draw(rect, Tint);
    }

    public void TrySetImageFill(float fill)
    {
        var param = GetFillParameter(FillParamName);
        if (param == null) return;
        param.Value = fill;
    }

    MaterialParameter GetFillParameter(string paramName)
    {
        if (_fillParam != null) { return _fillParam; }

        var matBrush = Brush as MaterialBrush;
        if (matBrush == null)
            return null;

        if (string.IsNullOrEmpty(paramName))
            return null;

        var param = matBrush.Material?.GetParameter(paramName);
        if (param == null)
            return null;

        _fillParam = param;
        _fillParam.IsOverride = true;
        return _fillParam;
    }

}
