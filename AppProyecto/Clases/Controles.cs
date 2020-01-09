using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Runtime;
namespace AppProyecto
{
    class Controles
    {

        public void Botones(Boolean[] Opciones, Button[] Botones)
        {
            for (int i = 0; i < Botones.Length; i++)
            {
                Botones[i].Enabled = Opciones[i];
            }
        }


        public void Groupbox(GroupBox Grupo, Boolean opcion )
        {
            Grupo.Enabled = opcion;
            
        }

        public Boolean  ValidaEntrada(ErrorProvider err, GroupBox grp) 
        {
        Boolean er = true;
       
            foreach ( Control   c in grp.Controls )
            {
                if (c is TextBox && c.Text == "")
                {
                    err.SetError(c, "Ingrese Datos");
                    er = false;
                }
                else
                {
                    if (c is ComboBox && c.Text == "")
                    {
                        err.SetError(c, "Ingrese Datos");
                        er = false;
                    }

                }
            }

        
        return er;
        }

        public void limpiarcajas( GroupBox grp)
        {
            foreach (Control c in grp.Controls)
            {
                if (c is TextBox )
                {
                    c.Text = "";
                }
               
            }
        }

      

    }
}
