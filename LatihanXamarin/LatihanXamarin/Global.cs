using System;
using System.Collections.Generic;
using System.Text;

namespace LatihanXamarin
{
    public class Global
    {
        private static Global _instance;
        public static Global Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new Global();
                }
                return _instance; 
            }
        }
        public string myData { get; set; }
    }
}
