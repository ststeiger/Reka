
using System;
using System.Collections.Generic;
using System.Text;


namespace Reka.XML.Daten
{


    public class Reka
    {


        public class ReservationsKapsel
        {
            public System.Data.DataTable Kopf = null;
            public System.Data.DataTable ReservationsDaten = null;


            private void BindHead(cReservation res)
            {
                this.Kopf = new System.Data.DataTable();
                Type t = typeof(cReservation);
                

                System.Reflection.FieldInfo[] fields = t.GetFields();
                foreach (System.Reflection.FieldInfo fi in fields)
                {
                    bool isEnumerable = typeof(System.Collections.IList).IsAssignableFrom(fi.FieldType);
                    // Console.WriteLine(fi.FieldType.IsValueType);

                    if(!isEnumerable)
                        Kopf.Columns.Add(fi.Name, fi.FieldType);
                } // Next fi


                System.Data.DataRow dr = this.Kopf.NewRow();

                foreach (var fi in fields)
                {
                    bool isEnumerable = typeof(System.Collections.IList).IsAssignableFrom(fi.FieldType);
                    if (isEnumerable)
                        continue;

                    object val = fi.GetValue(res);
                    dr[fi.Name] = val;
                } // Next fi 

                this.Kopf.Rows.Add(dr);
            } // End Sub BindHead


            public void BindData(cReservation res)
            {
                Type t = typeof(cRessource);
                System.Reflection.FieldInfo[] fields = t.GetFields();

                this.ReservationsDaten = new System.Data.DataTable();
                foreach (var fi in fields)
                {
                    ReservationsDaten.Columns.Add(fi.Name, fi.FieldType);
                } // Next fi


                System.Data.DataRow dr = null;
                for (int i = 0; i < res.Ressource.Count; ++i)
                {
                    dr = this.ReservationsDaten.NewRow();

                    foreach (System.Reflection.FieldInfo fi in fields)
                    {
                        object val = fi.GetValue(res.Ressource[i]);
                        dr[fi.Name] = val;
                    } // Next fi

                    this.ReservationsDaten.Rows.Add(dr);
                } // Next i

            } // End Sub BindData


            public ReservationsKapsel(cReservation res)
            {
                BindHead(res);
                BindData(res);
            } // End Constructor
            

        } // End Class ReservationsKapsel


        [System.Xml.Serialization.XmlRoot(ElementName = "Response")]
        public class Response
        {
            [System.Xml.Serialization.XmlElement()]
            public cDeduction Deduction = new cDeduction();
        }


        public class cDeduction
        {
            [System.Xml.Serialization.XmlElement()]
            public List<cReservation> Reservation = new List<cReservation>();


            [System.Xml.Serialization.XmlElement()]
            public cSumary Sumary = new cSumary();
        }


        public class cSumary
        {
            public double gesamt_price = 0.0;
            public double gesamt_rab_price = 0.0;
            public double gesamt_discount = 0.0;
            public double gesamt_res_price = 0.0;
        }


        // Reservierungskopf
        public class cReservation
        {

            [System.Xml.Serialization.XmlElement(ElementName = "V-Nr.")]
            public string V_Nr = "";

            [System.Xml.Serialization.XmlElement()]
            public int id = -1;


            [System.Xml.Serialization.XmlElement()]
            public List<cRessource> Ressource = new List<cRessource>();


            [System.Xml.Serialization.XmlElement()]
            public string lastname = "";

            [System.Xml.Serialization.XmlElement()]
            public string firstname = "";

            [System.Xml.Serialization.XmlElement()]
            public string begin = "";

            [System.Xml.Serialization.XmlElement()]
            public int branch = -1;

            [System.Xml.Serialization.XmlElement()]
            public string end = "";

            [System.Xml.Serialization.XmlElement()]
            public int return_branch = -1;

            [System.Xml.Serialization.XmlElement()]
            public string status = "";

            [System.Xml.Serialization.XmlElement()]
            public bool is_committed = false;

            [System.Xml.Serialization.XmlElement()]
            public bool is_returned = false;

            [System.Xml.Serialization.XmlElement()]
            public double discount_percent = 0.0;

            [System.Xml.Serialization.XmlElement()]
            public double price = 0.0;

            [System.Xml.Serialization.XmlElement()]
            public double reka = 0.0;

            [System.Xml.Serialization.XmlElement()]
            public double sum = 0.0;
        }


        // Daten 
        public class cRessource
        {
            [System.Xml.Serialization.XmlElement()]
            public string shortdescr = "";

            [System.Xml.Serialization.XmlElement()]
            public int id = -1;

            [System.Xml.Serialization.XmlElement()]
            public string price_rate = "";

            [System.Xml.Serialization.XmlElement()]
            public double rent = 0.0;

            [System.Xml.Serialization.XmlElement()]
            public string bonus_stk = "";

            [System.Xml.Serialization.XmlElement()]
            public string bonus_type = "";

            [System.Xml.Serialization.XmlElement()]
            public string bonus_descr = "";

            [System.Xml.Serialization.XmlElement()]
            public string bonus_nr = "";

            [System.Xml.Serialization.XmlElement()]
            public string bonus_value = "";
        }


        public static Response Test_ReadResponse()
        {
            System.Text.Encoding enc = System.Text.Encoding.UTF8;
            
            Response resp = null;
            string strFileName = @"reka_mod.xml";
            //resp = Tools.XML.Serialization.DeserializeFromFile<Response>(strFileName);

            string strText = System.IO.File.ReadAllText(strFileName, enc);
            resp = Tools.XML.Serialization.DeserializeFromXML<Response>(strText);
            return resp;

        }


        // global::Reka.XML.Daten.Reka.Test_Response();
        public static void Test_Response()
        {
            Response resp = new Response();

            resp.Deduction.Sumary.gesamt_discount = 100;

            cReservation rx = new cReservation();
            cRessource res = new cRessource();
            res.shortdescr = "Bullshit";
            rx.Ressource.Add(res);

            rx.id = 123;

            resp.Deduction.Reservation.Add(rx);

            string strFileName = @"D:\foobar.xml";
            Encoding enc = Encoding.GetEncoding("ISO-8859-1");
            


            Tools.XML.Serialization.SerializeToFile<Response>(resp, strFileName, enc);
            Tools.XML.Serialization.SerializeToTextWriter<Response>(resp, System.Console.Out);

            resp = null;
            resp = Tools.XML.Serialization.DeserializeFromFile<Response>(strFileName);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(resp);
        } // End Sub Write_TestSearchResultResponse


    } // End Class Reka


} // End Namespace Reka.XML.Daten
