using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFCustFont.CustomControls
{
    public class FontAwesomeLabel : Label
    {
        public FontAwesomeLabel()
        {
            FontFamily = Device.OnPlatform("fontawesome", "fontawesome", "/Assets/Fonts/fontawesome.ttf#FontAwesome");
        }
    }
}
