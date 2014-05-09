
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
                    Console.WriteLine("Don't paste a non-number");
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


        

        private static System.Globalization.NumberFormatInfo CreateSwissNumberFormatInfo()
        {
            //System.Globalization.NumberFormatInfo nfi = (System.Globalization.NumberFormatInfo)System.Globalization.CultureInfo.InvariantCulture.NumberFormat.Clone();
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
            nfi.NumberGroupSeparator = "'";
            nfi.NumberDecimalSeparator = ".";

            nfi.CurrencyGroupSeparator = "'";
            nfi.CurrencyDecimalSeparator = ".";
            nfi.CurrencySymbol = "CHF";

            return nfi;
        } // End Function SetupNumberFormatInfo

        private static System.Globalization.NumberFormatInfo nfi = CreateSwissNumberFormatInfo();

        // http://stackoverflow.com/questions/20156/is-there-an-easy-way-to-create-ordinals-in-c
        public static string AddOrdinal(int num)
        {
            string minus = "";

            if (num < 0)
            {
                minus = "-";
                num *= -1;
            } // End if (num < 0)
                

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return minus + num.ToString("N0", nfi) + "th";
            } // End switch (num % 100)

            switch (num % 10)
            {
                case 1:
                    return minus + num.ToString("N0", nfi) + "st";
                case 2:
                    return minus + num.ToString("N0", nfi) + "nd";
                case 3:
                    return minus + num.ToString("N0", nfi) + "rd";
                default:
                    return minus + num.ToString("N0", nfi) + "th";
            } // End switch (num % 10)

        } // End Function AddOrdinal


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
                System.Windows.Forms.MessageBox.Show("There is no " + AddOrdinal(iCurrentIndex) + " entry.");
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
                System.Windows.Forms.MessageBox.Show("There is no " + AddOrdinal(iCurrentIndex) + " entry.");
                return;
            }


            iCurrentIndex++;
            this.txtArrayIndexNumber.Text = iCurrentIndex.ToString();

            this.dgvHead.DataSource = m_lsData[iCurrentIndex].Kopf.DefaultView;
            this.dgvData.DataSource = m_lsData[iCurrentIndex].ReservationsDaten.DefaultView;
        } // End Sub btnNext_Click


    }


}
