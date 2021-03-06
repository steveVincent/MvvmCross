// MvxUIButtonTitleTargetBinding.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding.Bindings.Target;
using MonoTouch.UIKit;

namespace Cirrious.MvvmCross.Binding.Touch.Target
{
    public class MvxUIButtonTitleTargetBinding : MvxTargetBinding
    {
        protected UIButton Button
        {
            get { return base.Target as UIButton; }
        }

        public MvxUIButtonTitleTargetBinding(UIButton button)
            : base(button)
        {
            if (button == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - UIButton is null in MvxUIButtonTitleTargetBinding");
            }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }

        public override System.Type TargetType
        {
            get { return typeof (string); }
        }

        public override void SetValue(object value)
        {
            var button = Button;
            if (button == null)
                return;

            button.SetTitle(value as string, UIControlState.Normal);
        }
    }
}