using System.Threading.Tasks;
using Xamarin.Forms;
using XFGesturePan.ViewModels;

namespace XFGesturePan.Views
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// 這個頁面會用到的 ViewModel
        /// </summary>
        MainPageViewModel fooMainPageViewModel;

        // 定義各種運算用到的變數
        double ImageHeight, ImageWidth, OffsetTotal_dx, OffsetTotal_dy, OffsetMoving_dx, OffsetMoving_dy;
        double OriginalHeight, OriginWidth;
        public MainPage()
        {
            InitializeComponent();

            // 取得這個 View 使用的 ViewModel
            fooMainPageViewModel = this.BindingContext as MainPageViewModel;

            #region 設定要要擷取或者可以看到的圖片範圍大小
            fooMainPageViewModel.CenterHeight = new GridLength(200);
            fooMainPageViewModel.CenterWidth = new GridLength(200);
            #endregion
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(500);
            // 取得現在顯示圖片的設計尺寸高度與寬度
            ImageWidth = PhotoImage.Width;
            ImageHeight = PhotoImage.Height;
            Init();
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    //將手勢操作的偏移量先歸零
                    OffsetMoving_dx = 0;
                    OffsetMoving_dy = 0;
                    break;

                case GestureStatus.Running:
                    // 取得正在手勢操作的偏移量
                    OffsetMoving_dx = e.TotalX;
                    OffsetMoving_dy = e.TotalY;
                    Refresh();
                    break;

                case GestureStatus.Canceled:
                    // 操作取消，剛剛的手勢操作，歸零
                    OffsetMoving_dx = 0;
                    OffsetMoving_dy = 0;
                    // 依據偏移量，計算出 Grid 的 Row / Column 的實際需要高度與寬度
                    Refresh();
                    break;

                case GestureStatus.Completed:
                    // 手勢操作完成，將此次手勢操作的位置偏移量，加總到實際位置偏移量中
                    OffsetTotal_dx += OffsetMoving_dx;
                    OffsetTotal_dy += OffsetMoving_dy;
                    // 將手勢位置偏移量歸零
                    OffsetMoving_dx = 0;
                    OffsetMoving_dy = 0;
                    // 依據偏移量，計算出 Grid 的 Row / Column 的實際需要高度與寬度
                    Refresh();
                    break;
            }
        }

        /// <summary>
        /// 依據偏移量，計算出 Grid 的 Row / Column 的實際需要高度與寬度
        /// </summary>
        void Refresh()
        {
            GridLength fooGridLength;
            double fooValue = 0;
            fooValue = OriginalHeight + (OffsetTotal_dy + OffsetMoving_dy);
            fooGridLength = new GridLength(fooValue);
            fooMainPageViewModel.RowTop = fooGridLength;
            fooValue = OriginalHeight - (OffsetTotal_dy + OffsetMoving_dy);
            fooGridLength = new GridLength(fooValue);
            fooMainPageViewModel.RowBottom = fooGridLength;

            fooValue = OriginWidth + (OffsetTotal_dx + OffsetMoving_dx);
            fooGridLength = new GridLength(fooValue);
            fooMainPageViewModel.ColumnLeft = fooGridLength;
            fooValue = OriginWidth - (OffsetTotal_dx + OffsetMoving_dx);
            fooGridLength = new GridLength(fooValue);
            fooMainPageViewModel.ColumnRight = fooGridLength;
        }

        void Init()
        {
            GridLength fooGridLength;
            OriginalHeight = (ImageHeight - fooMainPageViewModel.CenterHeight.Value) / 2;
            OriginWidth = (ImageWidth - fooMainPageViewModel.CenterWidth.Value) / 2;
            fooGridLength = new GridLength(OriginalHeight);
            fooMainPageViewModel.RowTop = fooGridLength;
            fooMainPageViewModel.RowBottom = fooGridLength;
            fooGridLength = new GridLength(OriginWidth);
            fooMainPageViewModel.ColumnLeft = fooGridLength;
            fooMainPageViewModel.ColumnRight = fooGridLength;

            OffsetMoving_dx = 0;
            OffsetMoving_dy = 0;
            OffsetTotal_dx = 0;
            OffsetTotal_dy = 0;
        }
    }
}
