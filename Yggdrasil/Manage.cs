﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Yggdrasil.Model;

namespace Yggdrasil
{
    public partial class Manage : Form
    {
        private static string connDatabase = "yggdrasil";
        private static string connHost = "www.irran.top";
        private static string connUser = "yggdrasil";
        private static string connPassword = "admin";
        private static string connStr = string.Format("Database={0};Data Source={1};User Id={2};Password={3};Charset=utf8", connDatabase, connHost, connUser, connPassword);
        private static string sqlStr = "SELECT b.book_id,b.book_name,bt.type_id,t.type_name,b.publisher_id,p.publisher_name,b.book_status,b.create_date,b.modify_date " +
                                        "FROM book b " +
                                        "LEFT JOIN publisher p " +
                                        "ON b.publisher_id = p.publisher_id " +
                                        "LEFT JOIN book_type bt " +
                                        "ON bt.book_id = b.book_id " +
                                        "LEFT JOIN type t " +
                                        "ON t.type_id = bt.type_id " +
                                        "WHERE t.ptype_id is null " +
                                        "ORDER BY b.book_id ";
        private string[,] changedItem;
        private ArrayList bookList = new ArrayList();
        private static int column;
        private static int row;
        private Form mainForm;
        private static DataGridView theView;

        MySqlConnection conn;

        public Manage()
        {
            InitializeComponent();
        }

        public Manage(Form theForm)
        {
            InitializeComponent();
            mainForm = theForm;
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();

            sda.Fill(ds);
            booksView.DataSource = ds.Tables[0];
            booksView.RowHeadersVisible = false;
            booksView.Columns[0].ReadOnly = true;
            booksView.Columns[2].ReadOnly = true;
            booksView.Columns[4].ReadOnly = true;
            booksView.Columns[7].ReadOnly = true;
            booksView.Columns[8].ReadOnly = true;

            column = booksView.ColumnCount;
            row = booksView.RowCount;
            changedItem = new string[column,row];
            theView = booksView;
        }

        private void dbUpdate()
        {
            conn.Open();
            MySqlCommand cmd;
            int bookId;
            int otherId;
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j< column; j++)
                {
                    if(changedItem[j,i] != null)
                    {
                        switch (j)
                        {
                            case 1:
                                bookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                                string sqlStr1 = string.Format("UPDATE book " +
                                                               "SET book_name = '{0}' " +
                                                               "WHERE book_id = '{1}' ",changedItem[j,i],bookId);
                                cmd = new MySqlCommand(sqlStr1, conn);
                                if(cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("There is something wrong with updating!");
                                    break;
                                }
                                break;
                            case 4:
                                bookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                                otherId = Convert.ToInt32(changedItem[j, i]);
                                string sqlStr4 = string.Format("UPDATE book " +
                                                               "SET publisher_id = '{0}' " +
                                                               "WHERE book_id = '{1}' ", otherId, bookId);
                                cmd = new MySqlCommand(sqlStr4, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("There is something wrong with updating!");
                                    break;
                                }
                                break;
                            case 6:
                                bookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                                int status = Convert.ToInt32(changedItem[j, i]);
                                string sqlStr6 = string.Format("UPDATE book " +
                                                               "SET book_status = '{0}' " +
                                                               "WHERE book_id = '{1}' ", status, bookId);
                                cmd = new MySqlCommand(sqlStr6, conn);
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("There is something wrong with updating!");
                                    break;
                                }
                                break;
                        }
                        int theBookId = Convert.ToInt32(booksView[0, i].Value.ToString());
                        booksView[8, i].Value = System.DateTime.Now;
                        DatabaseUtility.updateModifyDateByBookId(theBookId);
                    }
                }
            }
            conn.Close();
        }


        private void booksView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int ecolumn = e.ColumnIndex;
            int erow = e.RowIndex;
            byte[] utf8 = Encoding.UTF8.GetBytes(booksView[ecolumn, erow].Value.ToString());
            string value = Encoding.UTF8.GetString(utf8);
            switch (ecolumn)
            {
                case 1:
                    if (value == "")
                    {
                        conn.Open();
                        MessageBox.Show("The cell can't be empty!");
                        int bookId11 = Convert.ToInt32(booksView[0, erow].Value.ToString());
                        string sql11 = string.Format("SELECT book_name FROM book WHERE book_id = '{0}' ", bookId11);
                        MySqlCommand cmd11 = conn.CreateCommand();
                        cmd11.CommandText = sql11;
                        MySqlDataReader reader11 = cmd11.ExecuteReader();
                        string oldBook = "";
                        while (reader11.Read())
                            oldBook = reader11.GetString("book_name");
                        reader11.Close();
                        conn.Close();
                        booksView[ecolumn, erow].Value = oldBook;
                        break;
                    }
                    else
                    {
                        changedItem[ecolumn, erow] = value;
                        break;
                    }
                case 3:
                    if (value != "")
                    {
                        conn.Open();

                        string tempSql1 = "SELECT type_name FROM type ";
                        string tempSql2 = string.Format("INSERT INTO type(type_name) values('{0}') ", value);

                        if (compareInDb(tempSql1, value, "type_name") == 0)
                        {
                            MySqlCommand tempCmd = new MySqlCommand(tempSql2, conn);
                            if (tempCmd.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("There is something wrong with inserting!");
                            }
                        }
                        string tempSql3 = string.Format("SELECT type_id FROM type WHERE type_name = '{0}' ", value);
                        MySqlCommand cmd3 = conn.CreateCommand();
                        cmd3.CommandText = tempSql3;
                        MySqlDataReader reader3 = cmd3.ExecuteReader();
                        int newTypeId = 0;
                        while (reader3.Read())
                            newTypeId = reader3.GetInt32(reader3.GetOrdinal("type_id"));
                        booksView[ecolumn - 1, erow].Value = newTypeId;
                        reader3.Close();


                        int theBookId = Convert.ToInt32(booksView[0, erow].Value.ToString());
                        string tempSql0 = "SELECT book_id,type_id FROM book_type ";
                        if (compareInBT(tempSql0, theBookId, newTypeId) == 0)
                        {
                            string sqlStr = string.Format("DELETE FROM book_type WHERE book_id = '{0}' ", theBookId);
                            MySqlCommand cmd0 = new MySqlCommand(sqlStr, conn);
                            if (cmd0.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("There is something wrong with inserting!");
                            }

                            string tempSql = string.Format("INSERT INTO book_type(book_id,type_id) values('{0}','{1}') ", theBookId, newTypeId);
                            MySqlCommand tempCmd = new MySqlCommand(tempSql, conn);
                            if (tempCmd.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("There is something wrong with inserting!");
                            }
                        }
                        else
                        {
                            changedItem[ecolumn - 1, erow] = newTypeId.ToString();
                        }
                        conn.Close();
                        break;
                    }
                    else
                    {
                        conn.Open();
                        MessageBox.Show("The cell can't be empty!");
                        int typeId = Convert.ToInt32(booksView[ecolumn - 1, erow].Value.ToString());
                        string sql12 = string.Format("SELECT type_name FROM type WHERE type_id = '{0}' ",typeId);
                        MySqlCommand cmd12 = conn.CreateCommand();
                        cmd12.CommandText = sql12;
                        MySqlDataReader reader12 = cmd12.ExecuteReader();
                        string oldType = "";
                        while (reader12.Read())
                            oldType = reader12.GetString("type_name");
                        reader12.Close();
                        conn.Close();
                        booksView[ecolumn, erow].Value = oldType;
                        break;
                    }
                case 5:
                    if (value != "")
                    {
                        conn.Open();

                        string tempSql4 = "SELECT publisher_name FROM publisher ";
                        string tempSql5 = string.Format("INSERT INTO publisher(publisher_name) values('{0}') ", value);

                        if (compareInDb(tempSql4, value, "publisher_name") == 0)
                        {
                            MySqlCommand tempCmd = new MySqlCommand(tempSql5, conn);
                            if (tempCmd.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("There is something wrong with inserting!");
                            }
                        }
                        string tempSql6 = string.Format("SELECT publisher_id FROM publisher WHERE publisher_name = '{0}' ", value);
                        MySqlCommand cmd6 = conn.CreateCommand();
                        cmd6.CommandText = tempSql6;
                        MySqlDataReader reader6 = cmd6.ExecuteReader();
                        int newPublisherId = 0;
                        while (reader6.Read())
                            newPublisherId = reader6.GetInt32(reader6.GetOrdinal("publisher_id"));
                        booksView[ecolumn - 1, erow].Value = newPublisherId;
                        changedItem[ecolumn - 1, erow] = newPublisherId.ToString();
                        reader6.Close();
                        conn.Close();
                        break;
                    }
                    else
                    {
                        conn.Open();
                        MessageBox.Show("The cell can't be empty!");
                        int publisherId = Convert.ToInt32(booksView[ecolumn - 1, erow].Value.ToString());
                        string sql13 = string.Format("SELECT publisher_name FROM publisher WHERE publisher_id = '{0}' ", publisherId);
                        MySqlCommand cmd13 = conn.CreateCommand();
                        cmd13.CommandText = sql13;
                        MySqlDataReader reader13 = cmd13.ExecuteReader();
                        string oldPublisher = "";
                        while (reader13.Read())
                            oldPublisher = reader13.GetString("publisher_name");
                        reader13.Close();
                        conn.Close();
                        booksView[ecolumn, erow].Value = oldPublisher;
                        break;
                    }
                case 6:
                    int status = Convert.ToInt32(value);
                    if (status == 0 || status == 1)
                    {
                        changedItem[ecolumn, erow] = value;
                    }
                    else
                    {
                        conn.Open();
                        MessageBox.Show("The status must be 0 or 1");
                        int bookId14 = Convert.ToInt32(booksView[0, erow].Value.ToString());
                        string tempSql7 = string.Format("SELECT book_status FROM book WHERE book_id = '{0}' ", bookId14);
                        MySqlCommand cmd7 = conn.CreateCommand();
                        cmd7.CommandText = tempSql7;
                        MySqlDataReader reader7 = cmd7.ExecuteReader();
                        int oldStatus = 0;
                        while (reader7.Read())
                            oldStatus = reader7.GetInt32(reader7.GetOrdinal("book_status"));
                        booksView[ecolumn, erow].Value = oldStatus;
                        reader7.Close();
                        conn.Close();
                    }
                    break;
            }
            
        }

        private int compareInDb(string sqlStr, string value,string goal)
        {
            int count = 0;
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlStr;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(reader.GetOrdinal(goal));
                if (name == value)
                    count++;
            }
            reader.Close();
            return count;
        }

        private int compareInBT(string sqlStr, int value, int theTypeId)
        {
            int count = 0;
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlStr;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int resultBI = reader.GetInt32(reader.GetOrdinal("book_id"));
                int resultTI = reader.GetInt32(reader.GetOrdinal("type_id"));
                if (resultBI == value && resultTI == theTypeId)
                    count++;
            }
            reader.Close();
            return count;
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            dbUpdate();
            MessageBox.Show("The modification is successful!");
            for(int i = 0; i < column; i++)
            {
                for(int j = 0; j < row; j++)
                {
                    changedItem[i,j] = null;
                }
            }

        }

        private void modifyChapterButton_Click(object sender, EventArgs e)
        {
            if (bookList.Count == 0)
            {
                MessageBox.Show("Please click the cell!");
            }
            else
            {
                int bookId = (int)bookList[0];
                int rowIndex = (int)bookList[1];
                Modify_Chapter chapter = new Modify_Chapter(bookId,rowIndex,this);
                chapter.Show();
                this.Enabled = false;
            }
        }

        private void booksView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bookList.Clear();
            if (e.RowIndex == -1)
                return;
            bookList.Add(Convert.ToInt32(booksView[0,e.RowIndex].Value));
            bookList.Add(Convert.ToInt32(e.RowIndex));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void booksView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
    || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void getReportButton_Click(object sender, EventArgs e)
        {
            frmBookReport tempForm = new frmBookReport(this);
            tempForm.Show();
            this.Enabled = false;
        }

        private void Manage_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Enabled = true;
        }
        
        public static DataGridView getView()
        {
            return theView;
        }

        private void TextBoxDec_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void booksView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
        }

        private void AddBookButton_Click(object sender, EventArgs e)
        {
            Add_Book addbookInterface = new Add_Book();
            addbookInterface.ShowDialog();        
        }
    }
}
