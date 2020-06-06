using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataTrans
{
    class TransItem
    {
        private string ID;
        private string MacString;
        private string IORow;
        private string LISString;
        private string Note;
        private string ActiveStatus;
        public TransItem(string ID, string MacString, string IORow, string LISString,string Note,string ActiveStatus)
        {
            this.ID = ID;
            this.MacString = MacString;
            this.IORow = IORow;
            this.LISString = LISString;
            this.Note = Note;
            this.ActiveStatus = ActiveStatus;
        }
        public TransItem(DataRow dr)
        {
            this.ID = dr["ID"].ToString();
            this.MacString = dr["MacString"].ToString();
            this.IORow = dr["IORow"].ToString();
            this.LISString = dr["LISString"].ToString();
            this.Note = dr["Note"].ToString();
            this.ActiveStatus = dr["ActiveStatus"].ToString();
        }

        public string getID()
        {
            return ID;
        }
        public string getMacString()
        {
            return MacString;
        }
        public string getIORow()
        {
            return IORow;
        }
        public string getLISString()
        {
            return LISString;
        }
        public string getNote()
        {
            return Note;
        }
        public string getAciveStatus()
        {
            return ActiveStatus;
        }
    }
}
