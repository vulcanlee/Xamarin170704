using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XFEllipseView.ViewModels
{
    //定義徽章使用者控制項需要用到的 ViewModel 資料定義
    public class BadgeViewModel : BindableBase
    {
        #region Repositories (遠端或本地資料存取)

        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region BadgeColor 用於定義徽章圓形的圖片顏色
        private Color _BadgeColor=Color.Pink;
        /// <summary>
        /// BadgeColor
        /// </summary>
        public Color BadgeColor
        {
            get { return this._BadgeColor; }
            set { this.SetProperty(ref this._BadgeColor, value); }
        }
        #endregion

        #region BadgeText 用於定義徽章要顯示的文字
        private string _BadgeText="0";
        /// <summary>
        /// BadgeText
        /// </summary>
        public string BadgeText
        {
            get { return this._BadgeText; }
            set { this.SetProperty(ref this._BadgeText, value); }
        }
        #endregion

        #endregion

        #region Field 欄位

        #endregion

        #region Constructor 建構式
        public BadgeViewModel()
        {

            #region 相依性服務注入的物件

            #endregion

            #region 頁面中綁定的命令

            #endregion

            #region 事件聚合器訂閱

            #endregion
        }

        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法

        #endregion

    }
}
