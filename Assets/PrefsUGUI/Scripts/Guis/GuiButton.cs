﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PrefsUGUI.Guis
{
    using Prefs;

    [AddComponentMenu("")]
    public class GuiButton : PrefsGuiBase
    {
        [SerializeField]
        protected Button button = null;

        protected UnityAction callback = null;


        public virtual void Initialize(string label, UnityAction callback)
        {
            this.SetLabel(label);

            this.button.onClick.AddListener(this.FireOnValueChanged);
            this.SetValue(callback);
        }

        public virtual void SetValue(UnityAction callback)
        {
            if(this.callback != null)
            {
                this.button.onClick.RemoveListener(this.callback);
            }

            this.callback = callback;
            this.button.onClick.AddListener(this.callback);
        }

        public override object GetValueObject()
            => this.callback;

        protected override void Reset()
        {
            base.Reset();
            this.button = GetComponentInChildren<Button>();
        }
    }
}
