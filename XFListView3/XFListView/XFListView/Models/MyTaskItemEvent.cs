using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFListView.Models
{

    public class MyTaskItemEvent : PubSubEvent<MyTaskItemPayload>
    {

    }

    public class MyTaskItemPayload
    {
        public MyTaskItem MyTaskItemSelected { get; set; }
        public string TaskMode { get; set; }
    }

}
