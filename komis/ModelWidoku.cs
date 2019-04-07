using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Configuration;

namespace komis
{
    public class ModelWidoku
    {
        public SqlDataAdapter adapter;
        private SqlConnection con;
        private SqlCommand cmd;
        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();

        public ModelWidoku()
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BazaKontekst"].ConnectionString;
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public DataTable GetData(string selectCommand)
        {
            try
            {
                cmd.CommandText = selectCommand;
                adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                DataTable table = new DataTable();
                table.Locale = CultureInfo.InvariantCulture;
                adapter.Fill(table);
                bindingSource1.DataSource = table;
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                return table;
            }
            catch (SqlException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void SaveChanges(object sender)
        {
            adapter.Update((DataTable)bindingSource1.DataSource);
        }

        public void On_Closed(object sender)
        {
            con.Close();
        }

    }
}