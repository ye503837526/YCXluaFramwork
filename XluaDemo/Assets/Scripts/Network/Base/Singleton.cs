using System;
using System.Collections.Generic;
using System.Linq;
namespace GameFramwork
{
    public class Singleton<T> where T : new()
    {
        private static T ms_instance;

        public static T Instance
        {
            get
            {
                if (ms_instance == null)
                {
                    ms_instance = new T();
                }

                return ms_instance;
            }
        }
    }
}
