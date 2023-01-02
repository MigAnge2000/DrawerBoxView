using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DemoDrawer2.CustomComponent;
using DemoDrawer2.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace DemoDrawer2.Droid
{
    public class CustomFrameRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        public CustomFrameRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            try
            {
                var elem = (CustomFrame)this.Element;
                if (elem != null)
                {
                    
                    CardElevation = 20f;
                    TranslationZ = 0;
                    SetZ(30f);
                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}