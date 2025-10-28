using FlaxEditor;
using FlaxEngine;
using System;
using System.Collections.Generic;

namespace Game;

/// <summary>
/// TestEditorPlugin class.
/// </summary>
public class SrcTempProxyEditorPlugin : EditorPlugin
{
    public override void InitializeEditor()
    {
        base.InitializeEditor();

        Editor.ContentDatabase.AddProxy(new UIAnimTempProxy());
        Editor.ContentDatabase.Rebuild(true);
    }
}