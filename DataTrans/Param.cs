using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace DataTrans
{
    class Param
    {
        public Socket conn { get; set; }
        public FileStream fsw { get; set; }
    }
}
