using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFEllipseView.CustomControls
{
    //這裡產生一個客製化控制項，我們繼承了一個空的 View，
    //在這裡，我們將會在每個原生平台中，實作並繪製出一個橢圓的控制項出來
    public class EllipseView : View
    {
        //這個自訂控制項中，我們將會加入一個可綁定屬性，用於可以在 XAML或者透過資料綁定的方式，來指定這個橢圓形的顏色
        // 你可以使用程式碼片段 vlBindableProperty 快速產生底下的可綁定屬性宣告            
        #region Color BindableProperty
        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create("Color", // 屬性名稱 
                typeof(Color), // 回傳類型 
                typeof(EllipseView), // 宣告類型 
                Color.Black, // 預設值 
                propertyChanged: OnColorChanged);

        /// <summary>
        /// 在這裡定義出可以在 XAML 中，使用的屬性名稱
        /// </summary>
        public Color Color
        {
            set
            {
                SetValue(ColorProperty, value);
            }
            get
            {
                return (Color)GetValue(ColorProperty);
            }
        }

        /// <summary>
        /// 這個範例中，並沒有用到這個功能
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }
        #endregion

    }
}
