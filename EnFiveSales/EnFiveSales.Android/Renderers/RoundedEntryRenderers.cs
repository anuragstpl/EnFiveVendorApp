using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using CoreGraphics;
using EnFiveSales.Controls;
using EnFiveSales.Droid.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedEntry),typeof(RoundedEntryRenderers))]
namespace EnFiveSales.Droid.Renderers
{
    public class RoundedEntryRenderers : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = (RoundedEntry)Element;
                if(view.IsCurvedCornersEnabled)
                {
                    var _gradientBackground = new GradientDrawable();
                    _gradientBackground.SetShape(ShapeType.Rectangle);
                    _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());
                    _gradientBackground.SetCornerRadius(DpToPixels(this.Context,Convert.ToSingle(view.CornerRadius)));
                    Control.SetBackground(_gradientBackground);
                }

                Control.SetPadding(
                    (int)DpToPixels(this.Context,Convert.ToSingle(12)),Control.PaddingTop,
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom);
            }
        }

        public static float DpToPixels(Context context,float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}