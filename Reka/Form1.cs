
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Reka
{


    public partial class Form1 : Form
    {

        private List<XML.Daten.Reka.ReservationsKapsel> m_lsData;

        public Form1()
        {
            InitializeComponent();
            this.m_lsData = GetReservationList();
            if (this.m_lsData != null && this.m_lsData.Count > 0)
            {
                this.dgvHead.DataSource = m_lsData[0].Kopf.DefaultView;
                this.dgvData.DataSource = m_lsData[0].ReservationsDaten.DefaultView;
            }
        } // End Constructor


        public static List<XML.Daten.Reka.ReservationsKapsel> GetReservationList()
        {
            List<XML.Daten.Reka.ReservationsKapsel> ls = new List<XML.Daten.Reka.ReservationsKapsel>();
            XML.Daten.Reka.Response resp = XML.Daten.Reka.Test_ReadResponse();

            for (int i = 0; i < resp.Deduction.Reservation.Count; ++i)
            {
                XML.Daten.Reka.ReservationsKapsel res = new XML.Daten.Reka.ReservationsKapsel(resp.Deduction.Reservation[i]);
                ls.Add(res);
            }

            return ls;
        } // End Function GetReservationList


        private void txtArrayIndexNumber_TextChanged(object sender, EventArgs e)
        {

            foreach (char chr in this.txtArrayIndexNumber.Text)
            {
                if (!char.IsControl(chr) && !char.IsDigit(chr)) // && e.KeyChar != '.')
                {
                    this.txtArrayIndexNumber.Text = "0";
                    Console.WriteLine("Don't pase a non-number");
                    return;
                }

            } // Next chr

        } // End Sub txtArrayIndexNumber_TextChanged 


        private void txtArrayIndexNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        } // End Sub txtArrayIndexNumber_KeyPress 


        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int iCurrentIndex;
            Int32.TryParse(this.txtArrayIndexNumber.Text, out iCurrentIndex);

            if (iCurrentIndex == 0)
            {
                System.Windows.Forms.MessageBox.Show("Beginning reached");
                return;
            }

            if (iCurrentIndex > m_lsData.Count - 1)
            {
                System.Windows.Forms.MessageBox.Show("There is no " + iCurrentIndex.ToString() + "th entry.");
                return;
            }


            iCurrentIndex--;
            this.txtArrayIndexNumber.Text = iCurrentIndex.ToString();

            this.dgvHead.DataSource = m_lsData[iCurrentIndex].Kopf.DefaultView;
            this.dgvData.DataSource = m_lsData[iCurrentIndex].ReservationsDaten.DefaultView;
            // TODO:
        } // End Sub btnPrevious_Click


        private void btnNext_Click(object sender, EventArgs e)
        {
            int iCurrentIndex;
            Int32.TryParse(this.txtArrayIndexNumber.Text, out iCurrentIndex);

            if (iCurrentIndex == m_lsData.Count -1)
            {
                System.Windows.Forms.MessageBox.Show("End reached");
                return;
            }


            if (iCurrentIndex > m_lsData.Count - 1)
            {
                System.Windows.Forms.MessageBox.Show("There is no " + iCurrentIndex.ToString() + "th entry.");
                return;
            }


            iCurrentIndex++;
            this.txtArrayIndexNumber.Text = iCurrentIndex.ToString();

            this.dgvHead.DataSource = m_lsData[iCurrentIndex].Kopf.DefaultView;
            this.dgvData.DataSource = m_lsData[iCurrentIndex].ReservationsDaten.DefaultView;
        } // End Sub btnNext_Click


    }


}
