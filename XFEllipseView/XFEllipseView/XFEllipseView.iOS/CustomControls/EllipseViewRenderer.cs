using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using XFEllipseView.CustomControls;
using System.ComponentModel;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using XFEllipseView.iOS.CustomControls;
using Xamarin.Forms;

//一定要在 namespace 之外，宣告這個 Renderer 類別
[assembly: ExportRenderer(typeof(EllipseView), typeof(EllipseRenderer))]
namespace XFEllipseView.iOS.CustomControls
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
                this.SetNeedsDisplay(); // Force a call to Draw
            }
        }

        /// <summary>
        /// 使用 iOS API，進行繪製出橢圓形
        /// </summary>
        /// <param name="rect"></param>
        public override void Draw(CGRect rect)
        {
            using (var context = UIGraphics.GetCurrentContext())
            {
                var path = CGPath.EllipseFromRect(rect);
                context.AddPath(path);
                context.SetFillColor(this.Element.Color.ToCGColor());
                context.DrawPath(CGPathDrawingMode.Fill);
            }
        }
    }
}