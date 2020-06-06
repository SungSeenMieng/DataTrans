using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataTrans
{
    class TransModule
    {
        private List<TransItem> translist=new List<TransItem>();
        public TransModule()
        {
            try
            {
                DataSet ds = AcceseDatabase.GetAll();
                for (int i = 0; i < ds.Tables["TransData"].Rows.Count; i++)
                {
                    TransItem transItem = new TransItem(ds.Tables["TransData"].Rows[i]);
                    translist.Add(transItem);
                }
            }
            catch (Exception) { }
        }
       
        public TransItem gettransitem(string ID)
        {
            TransItem retitem = new TransItem(null, null, null, null,null,null); ;
            foreach (TransItem item in translist)
            {
                if (item.getID() == ID)
                {
                    return item;
                }
            }
            return retitem;
        }
       
        public int gettranscount()
        {
            return translist.Count();
        }
        public void RefreshList()
        {
            try
            {
                translist.Clear();
                DataSet ds = AcceseDatabase.GetAll();

                for (int i = 0; i < ds.Tables["TransData"].Rows.Count; i++)
                {
                    TransItem transItem = new TransItem(ds.Tables["TransData"].Rows[i]);
                    translist.Add(transItem);
                }
            }
            catch (Exception)
            { 
            
            }
        }
        public string Trans(string input,string IO)
        {

            string output=input;
            foreach (TransItem item in translist)
            {
                string macstring=item.getMacString();
                string lisstring = item.getLISString();
                string io = item.getIORow();
                string status = item.getAciveStatus();
                if (input.Contains(macstring)&&io==IO&&status=="active")
                {
                    output=output.Replace(macstring, lisstring);
                }
            }
            return output;
        }
    }
}
