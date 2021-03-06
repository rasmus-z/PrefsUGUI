﻿using System;
using UnityEngine;

namespace PrefsUGUI
{
    using Guis.Prefs;

    public static partial class Prefs
    {
        [Serializable]
        public abstract class PrefsGuiBase<ValType, GuiType> : PrefsValueBase<ValType> where GuiType : PrefsGuiBase
        {
            public override string GuiLabel => this.guiLabelPrefix + this.guiLabel + this.guiLabelSufix;
            public virtual string GuiLabelWithoutAffix => this.guiLabel;

            public virtual float BottomMargin
            {
                get { return this.gui == null ? 0f : this.gui.GetBottomMargin(); }
                set { this.gui?.SetBottomMargin(Mathf.Max(0f, value)); }
            }
            public virtual float TopMargin
            {
                get { return this.gui == null ? 0f : this.gui.GetTopMargin(); }
                set { this.gui?.SetTopMargin(Mathf.Max(0f, value)); }
            }
            public virtual bool VisibleGUI
            {
                get { return this.gui == null ? false : this.gui.gameObject.activeSelf; }
                set { this.gui?.gameObject.SetActive(value); }
            }
            public string GuiLabelPrefix
            {
                get { return this.guiLabelPrefix; }
                set
                {
                    this.guiLabelPrefix = value ?? "";
                    this.UpdateLabel();
                }
            }
            public string GuiLabelSufix
            {
                get { return this.guiLabelSufix; }
                set
                {
                    this.guiLabelSufix = value ?? "";
                    this.UpdateLabel();
                }
            }

            [SerializeField]
            protected string guiLabelPrefix = "";
            [SerializeField]
            protected string guiLabelSufix = "";

            protected GuiType gui = null;


            public PrefsGuiBase(string key, ValType defaultValue = default(ValType), GuiHierarchy hierarchy = null, string guiLabel = "")
                : base(key, defaultValue, hierarchy, guiLabel)
            {
            }

            protected override void Register()
            {
                base.Register();
                AddPrefs<GuiType>(this, gui =>
                {
                    this.gui = gui;
                    this.OnCreatedGuiInternal(gui);
                });
            }

            protected abstract void OnCreatedGuiInternal(GuiType gui);

            protected virtual void UpdateLabel()
                => this.gui?.SetLabel(this.GuiLabel);
        }
    }
}
