using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using ADOX;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormRes : Form
    {
        string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=DBRes.mdb;";
        string CommandText;
        public int error;
        public string time;
        public int n;
        public FormRes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = ConnectionString;
            try
            {
                //пробуем подключится
                conn.Open();
            }
            catch
            {
                this.Close();
                button1.Text = "error";
                return;
            }

            OleDbCommand cmd = new OleDbCommand("Insert into ResultsGame" +
                "(Имя,Ошибки,Время, Поле) Values (@NAME,@ERROR,@TIME, @FIELD)", conn);

            OleDbParameter param = new OleDbParameter();

            param = new OleDbParameter();
            //задаем имя параметра
            param.ParameterName = "@NAME";
            //задаем значение параметра
            param.Value = textBox1.Text;
            //задаем тип параметра
            param.OleDbType = OleDbType.VarWChar;
            //передаем параметр объекту класса SqlCommand
            cmd.Parameters.Add(param);
            //переопределяем объект класса SqlParameter
            param = new OleDbParameter();
            //задаем имя параметра
            param.ParameterName = "@ERROR";
            //задаем значение параметра
            param.Value = error;
            //задаем тип параметра
            param.OleDbType = OleDbType.SmallInt;
            //передаем параметр объекту класса SqlCommand
            cmd.Parameters.Add(param);
            param = new OleDbParameter();
            param.ParameterName = "@TIME";
            param.Value = time;
            param.OleDbType = OleDbType.VarWChar;
            cmd.Parameters.Add(param);
            param = new OleDbParameter();
            param.ParameterName = "@FIELD";
            param.Value = n;
            param.OleDbType = OleDbType.SmallInt;
            cmd.Parameters.Add(param);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Не удалось внести изменения", "Изменение записи");
                return;
            }

            conn.Close();
            conn.Dispose();
            param = null;
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(CommandText, ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "ResultsGame");
            dataGridView1.DataSource = ds.Tables["ResultsGame"].DefaultView;
            button1.Enabled = false;
        }

        private void FormRes_Shown(object sender, EventArgs e)
        {
            CommandText = "SELECT [ID], Имя, Ошибки, Время, Поле FROM ResultsGame WHERE Поле like " + n;
            label2.Text += time;
            label3.Text += error.ToString();

            try
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(CommandText, ConnectionString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "ResultsGame");
                dataGridView1.DataSource = ds.Tables["ResultsGame"].DefaultView;
            }
            catch
            {
                Catalog cat = new Catalog();
                cat.Create(ConnectionString + "Jet OLEDB:Engine Type=5");
                Table table = new Table();
                table.Name = "ResultsGame";
                table.Columns.Append("ID", DataTypeEnum.adInteger, 8);
                table.Columns.Append("Имя", DataTypeEnum.adVarWChar, 10);
                table.Columns.Append("Ошибки", DataTypeEnum.adSmallInt, 3);
                table.Columns.Append("Время", DataTypeEnum.adVarWChar, 8);
                table.Columns.Append("Поле", DataTypeEnum.adSmallInt, 1);
                table.Columns[0].ParentCatalog = cat;
                table.Columns[0].Properties["Autoincrement"].Value = true;
                cat.Tables.Append((object)table);

                Index primKeyIdx = new Index();
                primKeyIdx.Name = "ID";
                primKeyIdx.Unique = true;
                primKeyIdx.PrimaryKey = true;
                primKeyIdx.Columns.Append("ID", ADOX.DataTypeEnum.adInteger, 8);

                // Append the index to table.
                table.Indexes.Append((object)primKeyIdx, null);
                cat = null;
                table = null;
                primKeyIdx = null;
                MessageBox.Show("База данных создана.", "База данных");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
