using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Applicacion2Ejer
{
    [Serializable]
    class ArchivoSecuencialSerializadoBinario<T>
    {

        private string _strNombreArchivo;

        public string NombreArchivo
        {
            get { return _strNombreArchivo; }
            set { _strNombreArchivo = value; }
        }

        //public string _strNombreArchivo @"C:\Users\doloresmargarita\source\repos\ProyectoP";
        private System.IO.FileStream flujo;
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter Seriador;
        public ArchivoSecuencialSerializadoBinario(string x)
        {
            NombreArchivo = x;
        }

        private void Crear()
        {
            flujo = new FileStream(NombreArchivo, FileMode.Create);
            Seriador = new BinaryFormatter();
        }
        public void AbrirModoEscritura()
        {
            if (File.Exists(NombreArchivo))
            {
                flujo = new FileStream(NombreArchivo, FileMode.Append);
                Seriador = new BinaryFormatter();
            }
            else
            {
                Crear();
            }
        }
        public void AbrirModoLectura()
        {
            if (File.Exists(NombreArchivo))
            {
                flujo = new FileStream(NombreArchivo, FileMode.Open);
                Seriador = new BinaryFormatter();
            }
            else
            {
                throw new Exception($"No existe el archivo {NombreArchivo}");
            }
        }
        public void AbrirModoLecturayEscritura()
        {
            if (File.Exists(NombreArchivo))
            {
                flujo = new FileStream(NombreArchivo, FileMode.Open, FileAccess.ReadWrite);
                Seriador = new BinaryFormatter();
            }
            else
            {
                //throw new Exception($"No existe el archivo {NombreArchivo}");
                Crear();
            }
            Seriador = new BinaryFormatter();
        }
        public void GrabarObjeto(T miObjeto)
        {
            Seriador.Serialize(flujo, miObjeto);
        }
        public T LeerObjetosx()
        {
            try
            {
                T miObjeto;
                miObjeto = (T)Seriador.Deserialize(flujo);//Error
                return (miObjeto);
            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public T LeerObjetos()
        {
            try
            {
                //T miObjeto;
                //miObjeto = (T)Seriador.Deserialize(flujo);//Error
                //return (miObjeto); 

                {
                    var B = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    //do
                    {
                        T obj = (T)B.Deserialize(flujo);
                        return (obj);
                    }

                }


            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public bool FinArchivo
        {
            get
            {
                if (flujo.Position >= flujo.Length)
                {
                    return true;
                }
                else return false;
            }
        }
        public void Cerrar()
        {
            if (flujo != null)
            {
                flujo.Close();
            }
        }
        ~ArchivoSecuencialSerializadoBinario()
        {
            Cerrar();
        }

    }
}
