
using System;
using System.Collections.Generic;
using System.Text;


namespace Tools.XML
{

    // Tools.XML.Serialization
    public class Serialization
    {

        // Tools.XML.Serialization.GetConfigFileName
        public static string GetConfigFileName()
        {
            //Dim pc As Process = Process.GetCurrentProcess()
            //System.IO.File.WriteAllText("c:\temp\mylog1.txt", System.IO.Path.GetFileNameWithoutExtension(pc.MainModule.FileName) + ".xml")
            //System.IO.File.WriteAllText("c:\temp\mylog1.txt", System.IO.Path.GetFullPath(pc.MainModule.FileName) + ".xml")
            //System.IO.Directory.SetCurrentDirectory(pc.MainModule.FileName.Substring(0, pc.MainModule.FileName.LastIndexOf("\")))

            string strConfigFilenameAndPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            strConfigFilenameAndPath = System.IO.Path.Combine(strConfigFilenameAndPath, System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location));

            if (!System.IO.Directory.Exists(strConfigFilenameAndPath))
                System.IO.Directory.CreateDirectory(strConfigFilenameAndPath);

            strConfigFilenameAndPath = System.IO.Path.Combine(strConfigFilenameAndPath, "TestFile.xml");
            if (System.IO.File.Exists(strConfigFilenameAndPath))
                System.IO.File.Delete(strConfigFilenameAndPath);

            //string strConfigFilenameAndPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location) + ".exe.config";
            //".config.xml"

            //strConfigFilenameAndPath.Replace(System.IO.Path.AltDirectorySeparatorChar, System.IO.Path.DirectorySeparatorChar)
            //strConfigFilenameAndPath.Replace(System.IO.Path.DirectorySeparatorChar + System.IO.Path.DirectorySeparatorChar, System.IO.Path.DirectorySeparatorChar)
            //System.IO.File.WriteAllText("c:\temp\mylog.txt", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\" + System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location) + "config.xml")
            //System.IO.File.WriteAllText("c:\temp\mylog.txt", System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location) + ".xml")
            //Return System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location) + ".xml"
            //System.IO.File.WriteAllText("c:\temp\readxmlfrom.txt", strConfigFilenameAndPath)
            return strConfigFilenameAndPath;
        } // End Function GetConfigFileName


        public static void SerializeToFile<T>(T ThisTypeInstance)
        {
            SerializeToFile<T>(ThisTypeInstance, null);
        } // End Sub SerializeToFile


        public static void SerializeToFile<T>(T ThisTypeInstance, string strConfigFileNameAndPath)
        {
            System.Text.Encoding enc = System.Text.Encoding.UTF8;
            SerializeToFile<T>(ThisTypeInstance, strConfigFileNameAndPath, enc);
        } // End Sub SerializeToFile


        public static void SerializeToFile<T>(T ThisTypeInstance, string strConfigFileNameAndPath, System.Text.Encoding enc)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            if (string.IsNullOrEmpty(strConfigFileNameAndPath))
            {
                strConfigFileNameAndPath = GetConfigFileName();
            } // End if (string.IsNullOrEmpty(strConfigFileNameAndPath))



            using (System.IO.TextWriter twTextWriter = new System.IO.StreamWriter(strConfigFileNameAndPath, false, enc))
            {
                // http://stackoverflow.com/questions/760262/xmlserializer-remove-unnecessary-xsi-and-xsd-namespaces
                System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                ns.Add("", "");
                //serializer.Serialize(twTextWriter, ThisTypeInstance, ns);
                serializer.Serialize(twTextWriter, ThisTypeInstance, ns);
                twTextWriter.Close();
            } // End Using System.IO.TextWriter twTextWriter

        } // End Sub SerializeToFile


        public static string SerializeToString<T>(T ThisTypeInstance)
        {
            string strXML = null;
            
            using (System.IO.StringWriter swStringWriter = new System.IO.StringWriter())
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

                //System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                //ns.Add("", "");
                //serializer.Serialize(swStringWriter, ThisTypeInstance, ns);
                serializer.Serialize(swStringWriter, ThisTypeInstance);
                swStringWriter.Flush();
                
                strXML = swStringWriter.ToString();

                swStringWriter.Close();
            } // End Using System.IO.StringWriter swStringWriter

            return strXML;
        } // End Sub SerializeToString


        public static void SerializeToTextWriter<T>(T ThisTypeInstance, System.IO.TextWriter twOutput)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(twOutput, ThisTypeInstance, ns);
            //serializer.Serialize(twOutput, ThisTypeInstance);
        } // End Sub SerializeToTextWriter


        public static void SerializeListToFile<T>(List<T> ThisTypeInstance)
        {
            System.Text.Encoding enc = System.Text.Encoding.UTF8;
            SerializeListToFile<T>(ThisTypeInstance, enc);
        }


        public static void SerializeListToFile<T>(List<T> ThisTypeInstance, System.Text.Encoding enc)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));
            using (System.IO.TextWriter textWriter = new System.IO.StreamWriter(GetConfigFileName()))
            {
                serializer.Serialize(textWriter, ThisTypeInstance);

                textWriter.Close();
            } // End Using System.IO.TextWriter textWriter

        } // End Sub SerializeListToFile


        public static void MsgBox(object obj)
        {
            System.Windows.Forms.MessageBox.Show(obj.ToString());
        }


        public static T DeserializeFromFile<T>()
        {
            return DeserializeFromFile<T>(null);
        }


        public static T DeserializeFromFile<T>(string strFileNameAndPath)
        {
            System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            if (string.IsNullOrEmpty(strFileNameAndPath))
            {
                strFileNameAndPath = GetConfigFileName();
            }

            System.IO.StreamReader srEncodingReader = new System.IO.StreamReader(strFileNameAndPath, System.Text.Encoding.UTF8);
            T ThisType = default(T);

            ThisType = (T)deserializer.Deserialize(srEncodingReader);
            srEncodingReader.Close();
            srEncodingReader.Dispose();

            return ThisType;
        } // End Function DeserializeFromFile


        public static T DeserializeFromXML<T>(string strContent)
        {
            System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            if (string.IsNullOrEmpty(strContent))
            {
                return (T)(object)null;
            }

            System.IO.StringReader srEncodingReader = new System.IO.StringReader(strContent);
            T ThisType = default(T);


            ThisType = (T)deserializer.Deserialize(srEncodingReader);
            srEncodingReader.Close();
            srEncodingReader.Dispose();

            return ThisType;
        } // End Function DeserializeFromXML


        public static System.Collections.Generic.List<T> DeserializeListFromXMLfile<T>(string strFileNameAndPath = null)
        {
            System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Collections.Generic.List<T>));

            if (string.IsNullOrEmpty(strFileNameAndPath))
            {
                strFileNameAndPath = GetConfigFileName();
            }

            System.IO.StreamReader srEncodingReader = new System.IO.StreamReader(strFileNameAndPath, System.Text.Encoding.UTF8);
            System.Collections.Generic.List<T> ThisTypeList = null;
            ThisTypeList = (System.Collections.Generic.List<T>)deserializer.Deserialize(srEncodingReader);
            srEncodingReader.Close();
            srEncodingReader.Dispose();

            return ThisTypeList;
        } // End Function DeserializeListFromXMLfile


    } // End Class Serialization


} // End Namespace Tools.XML
