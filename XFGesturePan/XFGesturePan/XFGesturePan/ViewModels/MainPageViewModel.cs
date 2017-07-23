using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFGesturePan.ViewModels
{

    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)

        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region CenterHeight
        private GridLength _CenterHeight = new GridLength(200);
        /// <summary>
        /// CenterHeight
        /// </summary>
        public GridLength CenterHeight
        {
            get { return this._CenterHeight; }
            set { this.SetProperty(ref this._CenterHeight, value); }
        }
        #endregion

        #region CenterWidth
        private GridLength _CenterWidth = new GridLength(200);
        /// <summary>
        /// CenterWidth
        /// </summary>
        public GridLength CenterWidth
        {
            get { return this._CenterWidth; }
            set { this.SetProperty(ref this._CenterWidth, value); }
        }
        #endregion

        #region RowTop
        private GridLength _RowTop = new GridLength(1, GridUnitType.Star);
        /// <summary>
        /// RowTop
        /// </summary>
        public GridLength RowTop
        {
            get { return this._RowTop; }
            set { this.SetProperty(ref this._RowTop, value); }
        }
        #endregion

        #region RowBottom
        private GridLength _RowBottom = new GridLength(1, GridUnitType.Star);
        /// <summary>
        /// RowBottom
        /// </summary>
        public GridLength RowBottom
        {
            get { return this._RowBottom; }
            set { this.SetProperty(ref this._RowBottom, value); }
        }
        #endregion

        #region ColumnLeft
        private GridLength _ColumnLeft = new GridLength(1, GridUnitType.Star);
        /// <summary>
        /// ColumnLeft
        /// </summary>
        public GridLength ColumnLeft
        {
            get { return this._ColumnLeft; }
            set { this.SetProperty(ref this._ColumnLeft, value); }
        }
        #endregion

        #region ColumnRight
        private GridLength _ColumnRight = new GridLength(1, GridUnitType.Star);
        /// <summary>
        /// ColumnRight
        /// </summary>
        public GridLength ColumnRight
        {
            get { return this._ColumnRight; }
            set { this.SetProperty(ref this._ColumnRight, value); }
        }
        #endregion


        #endregion

        #region Field 欄位

        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor 建構式
        public MainPageViewModel(INavigationService navigationService)
        {

            #region 相依性服務注入的物件

            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令

            #endregion

            #region 事件聚合器訂閱

            #endregion
        }

        #endregion

        #region Navigation Events (頁面導航事件)
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await ViewModelInit();
        }
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法

        /// <summary>
        /// ViewModel 資料初始化
        /// </summary>
        /// <returns></returns>
        private async Task ViewModelInit()
        {
            await Task.Delay(100);
        }
        #endregion

    }
}
