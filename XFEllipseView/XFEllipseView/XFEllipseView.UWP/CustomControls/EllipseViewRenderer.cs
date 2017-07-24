using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Shapes;
using Xamarin.Forms.Platform.UWP;
using XFEllipseView.CustomControls;
using XFEllipseView.UWP.CustomControls;

//一定要在 namespace 之外，宣告這個 Renderer 類別
[assembly: ExportRenderer(typeof(EllipseView), typeof(EllipseViewRenderer))]
namespace XFEllipseView.UWP.CustomControls
{
    public class EllipseViewRenderer : ViewRenderer<EllipseView, Ellipse>
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
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<EllipseView> e)
        {
            base.OnElementChanged(e);

            var ellipse = new Ellipse();
            ellipse.DataContext = this.Element;
            //ellipse.SetBinding(Ellipse.FillProperty,
            //    new Binding() { Path=new Windows.UI.Xaml.PropertyPath("Color"), Converter = new ColorConverter() });

            this.SetNativeControl(ellipse);
        }
    }
}
