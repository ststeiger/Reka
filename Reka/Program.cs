
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Reka
{


    static class Program
    {


        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bShowForm = true;

            if (bShowForm)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }

            
            //XML.Daten.Reka.Test_Response();
            

            if (!bShowForm)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" --- Press any key to continue --- ");
                Console.ReadKey();
            }


        } // End Sub Main


    } // End Class Program


} // End Namespace Reka
