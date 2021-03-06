﻿using Android.Content;
using NewsApp.Controls;
using NewsApp.Droid.Renderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace NewsApp.Droid.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntry ExtendedEntryElement => Element as ExtendedEntry;

        public ExtendedEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.InputType |= Android.Text.InputTypes.TextFlagNoSuggestions;
                UpdateLineColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(nameof(ExtendedEntry.LineColorToApply)))
                UpdateLineColor();
        }

        private void UpdateLineColor()
        {
            Control?.Background?.SetColorFilter(ExtendedEntryElement.LineColorToApply.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcAtop);
        }
    }
}