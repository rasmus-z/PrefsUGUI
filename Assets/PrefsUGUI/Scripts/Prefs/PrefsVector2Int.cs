﻿using System;
using UnityEngine;

namespace PrefsUGUI
{
    using Guis.Prefs;

    [Serializable]
    public class PrefsVector2Int : Prefs.PrefsExtends<Vector2Int, PrefsGuiVector2Int>
    {
        public PrefsVector2Int(string key, Vector2Int defaultValue = default(Vector2Int), GuiHierarchy hierarchy = null, string guiLabel = "")
            : base(key, defaultValue, hierarchy, guiLabel) { }

        protected override void OnCreatedGuiInternal(PrefsGuiVector2Int gui)
        {
            gui.Initialize(this.guiLabel, this.Get(), () => this.DefaultValue);
        }
    }
}
