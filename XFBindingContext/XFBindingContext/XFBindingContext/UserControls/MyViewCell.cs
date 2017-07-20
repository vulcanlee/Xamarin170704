using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFBindingContext.UserControls
{
    public class MyViewCell : ViewCell
    {
        public string BindingContextType { get; set; }
        protected override void OnBindingContextChanged()
        {
            BindingContextType = this.BindingContext.GetType().Name;
            base.OnBindingContextChanged();
        }
    }
}
