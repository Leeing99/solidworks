using SwAPIdiploma;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwAPIproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            try
            {
                PartModel pm = new PartModel();
                pm.Dim_A = Convert.ToDouble(txt_A.Text) / 1000;
                pm.Dim_B = Convert.ToDouble(txt_B.Text) / 1000;
                pm.Dim_H1 = Convert.ToDouble(txt_H1.Text) / 1000;
                pm.Dim_H2 = Convert.ToDouble(txt_H2.Text) / 1000;
                pm.Dim_D1 = Convert.ToDouble(txt_D1.Text) / 1000;
                pm.Dim_D2 = Convert.ToDouble(txt_D2.Text) / 1000;
                pm.Dim_D3 = Convert.ToDouble(txt_D3.Text) / 1000;
                pm.PartName = txt_Name.Text;

                pm.CreatePart();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
    }
}
