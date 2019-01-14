using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
using GiftIt.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(ShowHidePassEffect), "ShowHidePassEffect")]
namespace GiftIt.Droid.Effects
{
    public class ShowHidePassEffect : PlatformEffect
    {

        private Context context;

        protected override void OnAttached()
        {
            ConfigureControl();
        }

        protected override void OnDetached()
        {
        }

        private void ConfigureControl()
        {
            context = Android.App.Application.Context;

            Drawable img = ContextCompat.GetDrawable(context, Resource.Drawable.Group_23);

            var sd = new ScaleDrawable(img, 0, 35, 20);

            EditText editText = ((EditText)Control);
            editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, sd.Drawable, null);
            editText.SetOnTouchListener(new OnDrawableTouchListener());

        }
    }

    public class OnDrawableTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
    {
        private Context context;

        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            context = Android.App.Application.Context;

            if (v is EditText && e.Action == MotionEventActions.Up)
            {
                EditText editText = (EditText)v;
                if (e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
                {
                    Drawable img = ContextCompat.GetDrawable(context, Resource.Drawable.Group_23);

                    var sd = new ScaleDrawable(img, 0, 35, 20);

                    if (editText.TransformationMethod == null)
                    {
                        editText.TransformationMethod = PasswordTransformationMethod.Instance;
                        editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, sd.Drawable, null);
                    }
                    else
                    {
                        editText.TransformationMethod = null;
                        editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, sd.Drawable, null);
                    }

                    return true;
                }
            }

            return false;
        }
    }
}