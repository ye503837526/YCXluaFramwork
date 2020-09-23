using MySql;
using SimServer.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlMgr.Instance.Init();
            FieldType.Init();
            LogicMain.Instance.Init();
            ServerSocket.Instance.Init();

          
            Console.ReadLine();
        
        }
    }
}
