using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFEllipseView.CustomControls;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Graphics;
using XFEllipseView.Droid.CustomControls;
using Xamarin.Forms;

//一定要在 namespace 之外，宣告這個 Renderer 類別
[assembly: ExportRenderer(typeof(EllipseView), typeof(EllipseRenderer))]
namespace XFEllipseView.Droid.CustomControls
{
    public class EllipseRenderer : VisualElementRenderer<EllipseView>
    {
        /// <summary>
        /// 這個方法存在的目的，是為了避免 Linker 將這個類別與方法移除，造成應用程式閃退
        /// 為什麼呢?
        /// </summary>
        public static void Init()
        {

        }

        public EllipseRenderer()
        {
            this.SetWillNotDraw(false);
        }

        /// <summary>
        /// 當屬性有變動的時候，將會在這個方法中進行相關異動處理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            // 判斷是否有變更這個橢圓形的顏色
            if (e.PropertyName == EllipseView.ColorProperty.PropertyName)
            {
                // 當執行底下方法，將會驅動 OnDraw 方法被執行
                this.Invalidate(); // Force a call to OnDraw
            }
        }

        /// <summary>
        /// 使用 Android API，進行繪製出橢圓形
        /// </summary>
        /// <param name="canvas"></param>
        protected override void OnDraw(Canvas canvas)
        {
            var element = this.Element;
            var rect = new Rect();
            this.GetDrawingRect(rect);

            var paint = new Paint()
            {
                Color = element.Color.ToAndroid(),
                AntiAlias = true
            };

            canvas.DrawOval(new RectF(rect), paint);
        }
    }
}