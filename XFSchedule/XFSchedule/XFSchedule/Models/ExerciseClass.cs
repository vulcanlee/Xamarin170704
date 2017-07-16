using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFSchedule.Models
{
    public class ExerciseClass
    {
        public DateTime ClassTime { get; set; }
        public string ClassName { get; set; }
        public string Instructor { get; set; }

        /// <summary>
        /// 這筆紀錄是否是最後一筆
        /// 因為，最後一筆紀錄的視覺畫面會與其他記錄樣子不一樣
        /// </summary>
        public bool IsLast { get; set; } = false;
    }
}
