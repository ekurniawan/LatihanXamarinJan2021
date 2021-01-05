using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanXamarin
{
    public class MyPageMasterMenuItem
    {
        public MyPageMasterMenuItem()
        {
            TargetType = typeof(MyPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public string ImageIcon { get; set; }
    }
}