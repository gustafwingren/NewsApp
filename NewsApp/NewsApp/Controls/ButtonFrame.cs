using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace NewsApp.Controls
{
    public class ButtonFrame : Frame
    {
        public ButtonFrame()
        {
            HasShadow = true;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ContentProperty.PropertyName)
                ContentUpdated();
        }

        private void ContentUpdated()
        {
            BackgroundColor = Content.BackgroundColor;
        }
    }
}
