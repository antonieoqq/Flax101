using FlaxEditor.Content;
using FlaxEngine;
using System;
using System.Collections.Generic;

namespace Game;

/// <summary>
/// TempTestProxy class.
/// </summary>
[ContentContextMenu("New/C#/UI/Animation")]
public class UIAnimTempProxy : CSharpProxy
{
    public override string Name => "UIAnim";

    protected override void GetTemplatePath(out string path)
    {
        // Can use `Globals` class to get specific project folders
        path = "Content/ScriptTemplates/UIAnimTemp.cs";
    }
}