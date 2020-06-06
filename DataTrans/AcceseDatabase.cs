using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataTrans
{
    class AcceseDatabase
    {
        static OleDbConnection conn;
        static OleDbCommand da;
        static string txtConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Config.mdb";
        public static DataSet GetAll()
        {
            try
            {
                conn = new OleDbConnection(txtConn);
                string txtCommand = "SELECT * FROM TransData";
                OleDbDataAdapter da = new OleDbDataAdapter(txtCommand, conn);
                DataSet ds = new DataSet("ds");
                da.Fill(ds, "TransData");
                conn.Close();
                return ds;
            }
            catch (Exception) { return null; }
        }
        public static void InsertItem(string macstring, string iorow, string lisstring, string note)
        {
            string txtCommand = "Insert Into TransData(MacString,IORow,LISString,[Note],ActiveStatus) Values(\"";
            txtCommand += macstring + "\",\"";
            txtCommand += iorow + "\",\"";
            txtCommand += lisstring + "\",\"";
            txtCommand += note + "\",\"";
            txtCommand += "active\")";
            Console.WriteLine(txtCommand);
            conn = new OleDbConnection(txtConn);
            conn.Open();
            da = new OleDbCommand();
            da.CommandText = txtCommand;
            da.Connection = conn;
            da.ExecuteNonQuery();
            conn.Close();
        }
        public static void RemoveItem(string id)
        {
            string txtCommand = "Delete From TransData Where ID=" + id;
            conn = new OleDbConnection(txtConn);
            conn.Open();
            da = new OleDbCommand();
            da.CommandText = txtCommand;
            da.Connection = conn;
            da.ExecuteNonQuery();
            conn.Close();
        }
        public static void ToggleActive(string id, string status)
        {
            string txtCommand = "Update TransData Set ActiveStatus=\"" + status + "\" Where ID=" + id;
            conn = new OleDbConnection(txtConn);
            conn.Open();
            da = new OleDbCommand();
            da.CommandText = txtCommand;
            da.Connection = conn;
            da.ExecuteNonQuery();
            conn.Close();
        }
      
    }
}
