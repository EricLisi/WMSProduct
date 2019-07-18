using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KgmSoft.Scan.Project
{
    public partial class FrmPwd : Form
    {
        public FrmPwd()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtpassword.Text == "51029010")
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    AppUtil.ShowError("密码输入不正确!");
                }
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPwd_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetCenter();
            }
            catch
            {

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void SetCenter()
        {
            int x, y;
            int swidth = Screen.PrimaryScreen.WorkingArea.Width;
            int sheight = Screen.PrimaryScreen.WorkingArea.Height;
            x = (swidth - this.Width) / 2;
            y = (sheight - this.Height) / 2;
            this.Location = new Point(x, y);
        }

        private void button_Click(object sender, EventArgs e)
        {

        }


    }
}