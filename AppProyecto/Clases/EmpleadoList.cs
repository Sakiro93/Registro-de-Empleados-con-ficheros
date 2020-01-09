using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Dynamic;

namespace AppProyecto
{
    class EmpleadoList
    {

        private static  int j = Application.StartupPath.IndexOf("bin");
        private  string path = Application.StartupPath.Substring(0,j);


        public void guardar( string cadena)
        {
            StreamWriter dato= null;
            dato  = new StreamWriter(path +"/Datos/Empleado.txt", true);
            dato.WriteLine(cadena);
            dato.Close();
        }


        public bool eliminar( string cedula)
        {
            StreamReader empleadolect = new StreamReader(path + "/Datos/Empleado.txt", true);
            StreamWriter empleadoescr= new StreamWriter(path + "/Datos/temp.txt", true);
            string lector = null;
            bool enc = false;
            while (empleadolect.Peek() != -1)
            {
                lector = empleadolect.ReadLine();
                string[] datos = lector.Split(new char[] { ';' });
                if (datos[1].Equals(cedula))
                {
                    enc = true;
                }
                else
                {
                    empleadoescr.WriteLine(lector );
                }
            }
            // cerramos el fichero
            empleadolect.Close();
            empleadoescr.Close();
            if (enc)
            {
                File.Delete(path + "/Datos/Empleado.txt");
                File.Move(path + "/Datos/temp.txt", path + "/Datos/Empleado.txt");
            }
            return enc;
        }



        public void cargartabla(DataGridView dg)
        {
           
            try
            {
                StreamReader empleado = new StreamReader(path+"/Datos/Empleado.txt", true);
                string lector= "";
                dg.Rows.Clear();
                while(empleado.Peek() != -1)
                {
                    lector = empleado.ReadLine();
                    string[] datos = lector.Split(new char   [] { ';' });
                    dg.Rows.Add(datos[0], datos[1], datos[2], datos[3], datos[4], (datos[5] == "0" ? "Femenino" : "Masculino"), datos[6], Convert.ToBoolean(datos[7]));
                 
                }
                empleado.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el archivo Estudiante");
            }

        }

        public void modificar(string cadena, string modifica)
        {
            StreamReader empleadolect = new StreamReader(path + "/Datos/Empleado.txt", true);
            StreamWriter empleadoescr = new StreamWriter(path + "/Datos/temp.txt", true);
            string lector= null;
            while (empleadolect.Peek() != -1)
            {
                lector = empleadolect.ReadLine();
                string[] datos = lector.Split(new char[] { ';' });
                if (datos[1] != cadena)
                {
                    empleadoescr.WriteLine(lector );
                }
                else
                {
                    empleadoescr.WriteLine(modifica );
                }
            }
            empleadolect.Close();
            empleadoescr.Close();
            File.Delete(path + "/Datos/Empleado.txt");
            File.Move(path + "/Datos/temp.txt", path + "/Datos/Empleado.txt");
        }


        public void buscar(DataGridView dg, int i, string buscado)
        {
           
            try
            {
                StreamReader empleado = new StreamReader(path + "/Datos/Empleado.txt", true);
                string lector = null;
                dg.Rows.Clear();     
   
                while (empleado.Peek() != -1)
                {
                    lector = empleado.ReadLine();
                    string[] datos = lector.Split(new char[] { ';' });
                    if (datos[i].ToUpper().Contains(buscado.ToUpper()))
                    {
                
                        dg.Rows.Add(datos[0], datos[1], datos[2], datos[3], datos[4], (datos[5] == "0" ? "Femenino" : "Masculino"), datos[6], Convert.ToBoolean(datos[7]));
                       
                    }
                   
                }
                empleado.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay datos que consultar");
            }

        }

        public Boolean  datosrepetidos( string buscado, string M)
        {
            Boolean salida = true;
            try
            {
               
                StreamReader empleado = new StreamReader(path + "/Datos/Empleado.txt", true);
                string lector = null;
                string []vector = buscado.Split(new char[] { ';' });
                while (empleado.Peek() != -1)
                {
                    
                    lector = empleado.ReadLine();
                    string[] datos = lector.Split(new char[] { ';' });
                    if (datos[0].ToUpper() == vector[0].ToUpper())
                    {
                        salida = false ;
                    }
                    if (datos[2].ToUpper() == vector[1].ToUpper())
                    {
                        salida = false;
                    }
                    if (datos[1].ToUpper() == vector[2].ToUpper())
                    {
                        salida = false;
                    }

                }
                empleado.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay datos que consultar");
            }

            return salida ;
        }





    }

}
