using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFAttProp.AttachedProperties
{
    public enum EntryTypeEnum
    {
        None,
        Email,
        phone,
        number
    }
    public class EntryTypeAttached
    {
        #region EntryType 附加屬性 Attached Property
        public static readonly BindableProperty EntryTypeProperty =
               BindableProperty.CreateAttached(
                   propertyName: "EntryType",   // 屬性名稱 
                   returnType: typeof(EntryTypeEnum), // 回傳類型 
                   declaringType: typeof(Entry), // 宣告類型 
                   defaultValue: EntryTypeEnum.None, // 預設值 
                   propertyChanged: OnEntryTypeChanged  // 屬性值異動時，要執行的事件委派方法
               );

        public static void SetEntryType(BindableObject bindable, EntryTypeEnum entryType)
        {
            bindable.SetValue(EntryTypeProperty, entryType);
        }
        public static EntryTypeEnum GetEntryType(BindableObject bindable)
        {
            return (EntryTypeEnum)bindable.GetValue(EntryTypeProperty);
        }

        private static void OnEntryTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var fooEntry = bindable as Entry;
            if(fooEntry == null)
            {
                return;
            }

            var fooNewValue = (EntryTypeEnum)newValue;
            switch (fooNewValue)
            {
                case EntryTypeEnum.None:
                    break;
                case EntryTypeEnum.Email:
                    fooEntry.Placeholder = "請輸入電子郵件";
                    fooEntry.PlaceholderColor = Color.Red;
                    fooEntry.Keyboard = Keyboard.Email;
                    fooEntry.FontSize = 20;
                    break;
                case EntryTypeEnum.phone:
                    fooEntry.Placeholder = "請輸入電話號碼";
                    fooEntry.PlaceholderColor = Color.Green;
                    fooEntry.Keyboard = Keyboard.Telephone;
                    fooEntry.FontSize = 16;
                    break;
                case EntryTypeEnum.number:
                    fooEntry.Placeholder = "請輸入數值";
                    fooEntry.PlaceholderColor = Color.Blue;
                    fooEntry.Keyboard = Keyboard.Numeric;
                    fooEntry.FontSize = 28;
                    break;
                default:
                    break;
            }
        }
        #endregion

    }
}
