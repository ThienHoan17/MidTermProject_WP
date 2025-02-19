﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace MidTermProject
{
    public partial class FormShowData : Form
    {
        StudentFunction stuf = new StudentFunction();
        public FormShowData()
        {
            InitializeComponent();
        }

        private void FormShowData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentManageDataSet1.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentManageDataSet1.student);
            this.studentTableAdapter.Fill(this.studentManageDataSet1.student);
            SqlCommand command = new SqlCommand("SELECT * FROM student");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = stuf.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormEditRemove editRemove = new FormEditRemove();
            editRemove.ID_txt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            editRemove.fName_txt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            editRemove.lName_txt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            editRemove.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;

            if ((dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female"))
            {
                editRemove.fMale_rbtn.Checked = true;
            }
            editRemove.phone_txt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            editRemove.address_txt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            editRemove.picture_ptb.Image = Image.FromStream(picture);
            editRemove.Show(this);
        }

        private void reFresh_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM student");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = stuf.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
            FormMain fm = new FormMain();
            fm.Show();
        }
    }
}
