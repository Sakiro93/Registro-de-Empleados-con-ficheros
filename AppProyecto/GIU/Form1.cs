using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics ;
using System.Collections ;
using System.Runtime;


namespace AppProyecto
{

    public partial class Form1 : Form
    {
        Empleado empleado = new Empleado();
        EmpleadoList list = new EmpleadoList();

     
        Controles control = new Controles();
        Boolean [] opciones;
        Button[] botones = new Button [5];
        string guardar = "";
       
        public Form1()
        {
            
            InitializeComponent();
            CenterToScreen();
            MaximizeBox = false ;
            MinimizeBox = false;

            opciones = new Boolean[] { true, false, false, false, true };
            cargarbotones();
            control.Botones(opciones ,botones );
            control.Groupbox (grpDatos, false);
            tooltip();
          
            cboPuesto.SelectedIndex = 0;
            control.limpiarcajas(grpDatos );
            control.limpiarcajas(grpDatos );

            list.cargartabla(TablaEmpleado );
        }
        private void tooltip()
        {
            tollMensaje.SetToolTip(btnSalir  , "Salir Del Formulario");
            tollMensaje.SetToolTip(btnNuevo, "Ingresar un Nuevo Empleado");
            tollMensaje.SetToolTip(btnEliminar , "Eliminar Empleado");
            tollMensaje.SetToolTip(btnModificar, "Modificar Empleado");
            tollMensaje.SetToolTip(btnGuardar, "Guardar Empleado");
            tollMensaje.ToolTipTitle = "Mantenimiento de Empleado";
            tollMensaje.ToolTipIcon = ToolTipIcon.Info;
            tollMensaje.BackColor = Color.Tomato;
        }

        private void cargarbotones()
        {
            botones[0] = btnNuevo;
            botones[1] = btnGuardar;
            botones[2] = btnEliminar;
            botones[3] = btnModificar;
            botones[4] = btnSalir ;
        }
    private void btnNuevo_Click(object sender, EventArgs e)
        {
            guardar = "N";
            control.limpiarcajas(grpDatos);
            opciones = new Boolean[] { true, true, false, false, true };
            control.Botones(opciones, botones);
            control.Groupbox (grpDatos, true );
        }

        private void TablaEmpleado_Click(object sender, EventArgs e)
        {
            opciones = new Boolean[] { true, false, true, true, true };
            control.Botones(opciones, botones);
            control.Groupbox(grpDatos, false);
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {

               if (MessageBox.Show("Desea Guardar los Datos", "Mantenimiento de Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int sexo;
                    ErrorCaja.Clear();

                    if (control.ValidaEntrada(ErrorCaja, grpDatos))
                    {
                  
                        string validar = txtNombre.Text   + ";" + txtTelefono.Text + ";" + txtCedula.Text;

                        if (list.datosrepetidos(validar,null))
                        {

                            if (rdbFemenino.Checked)
                            { sexo = 0; }
                            else
                            { sexo = 1; }
                            if (guardar == "N")
                            {
                                empleado = new Empleado(txtNombre.Text, txtCedula.Text, txtTelefono.Text, Convert.ToInt32(numEdad.Value), cboPuesto.Text, sexo, Convert.ToDouble(txtSueldo.Text), chkEstado.Checked);
                                list.guardar(empleado.cargarDatos());
                                MessageBox.Show("Registro Grabado Correctamente", "Mantenimiento de Empleado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            }
                            else
                            {
                                if (guardar == "M")
                                {

                                    empleado = new Empleado(txtNombre.Text, txtCedula.Text, txtTelefono.Text, Convert.ToInt32(numEdad.Value), cboPuesto.Text, sexo, Convert.ToDouble(txtSueldo.Text), chkEstado.Checked);
                                    list.modificar(modifica(), empleado.cargarDatos());
                                    MessageBox.Show("Registro Moddificado Correctamente", "Mantenimiento de Empleado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                                }
                            }

                        }
                        else
                        {
                              MessageBox.Show("Datos Repetidos", "Mantenimiento de Empleado ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }

                    
                        control.limpiarcajas(grpDatos);
                        list.cargartabla(TablaEmpleado);
                        opciones = new Boolean[] { true, false, false, false, true };
                        control.Botones(opciones, botones);
                        control.Groupbox(grpDatos, false);
                    }
                    else
                    {
                        MessageBox.Show("Datos Incorrectos", "Mantenimiento de Empleado ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    opciones = new Boolean[] { true, false, false, false, true };
                    control.Botones(opciones, botones);
                    control.Groupbox(grpDatos, false);
                    control.limpiarcajas(grpDatos);
                }

            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            elimina();
        }

        public void elimina()
        {

            int i = TablaEmpleado.CurrentRow.Index;

            if (Convert.ToString(TablaEmpleado.Rows[i].Cells[0].Value) != "")
            {
                string cedula = Convert.ToString(TablaEmpleado.Rows[i].Cells[1].Value);
                string estudiante = Convert.ToString(TablaEmpleado.Rows[i].Cells[0].Value);

                if (MessageBox.Show("Esta Seguro De Eliminar Al Empleado :"+ "\n"+ estudiante , "Sistema de Matriculacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (list.eliminar(cedula))
                    {
                        MessageBox.Show("Registro Eliminado Correctamente","Mantenimiento de Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        list.cargartabla(TablaEmpleado); 
                        control.limpiarcajas(grpDatos);
                    }
                    else
                    {
                        MessageBox.Show("Estudiante No Se Encuentra Registrado","Mantenimiento de Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                }
                else
                {
                    MessageBox.Show("Operacion Cancelada", "Mantenimiento de Empleado", MessageBoxButtons.OK, MessageBoxIcon.Hand );

                }
            }
        }

        private void TablaEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guardar = "";
            control.Groupbox(grpDatos, false);
            control.limpiarcajas(grpDatos);
            int i = TablaEmpleado.CurrentRow.Index;

            if (Convert.ToString(TablaEmpleado.Rows[i].Cells[0].Value) != "")
            {
           
                clik(i);
            }

            opciones = new Boolean[] { true, false, true, true, true };
            control.Botones(opciones, botones);
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            guardar = "M";
            control.Groupbox(grpDatos, true);
            opciones = new Boolean[] { false, true, true, true, true };
            control.Botones(opciones, botones);
        }

        public string  modifica()
        {
            int i = TablaEmpleado .CurrentRow.Index;
            string modific =  Convert.ToString ( TablaEmpleado.Rows[i].Cells[1].Value );
            return modific ;
      
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (rdBuscaNombre.Checked )
            {
                list.buscar(TablaEmpleado ,0,txtBuscar.Text);
            }
            if (rdBuscaCedula.Checked )
            {
                list.buscar(TablaEmpleado,1, txtBuscar.Text);
            }
            if (rdBuscaTelefono.Checked )
            {
                list.buscar(TablaEmpleado,2, txtBuscar.Text);
            }
            if (rdBuscaPuesto.Checked )
            {
                list.buscar(TablaEmpleado,4, txtBuscar.Text);
            }



        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
               
                e.Handled = true;
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit (e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit (e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
               
            }
        }

        private void clik(int i )
        {

            txtNombre.Text = Convert.ToString(TablaEmpleado.Rows[i].Cells[0].Value);
            txtTelefono.Text = Convert.ToString(TablaEmpleado.Rows[i].Cells[2].Value);
            cboPuesto.Text = Convert.ToString(TablaEmpleado.Rows[i].Cells[4].Value);
            txtSueldo.Text = Convert.ToString(TablaEmpleado.Rows[i].Cells[6].Value);
            txtCedula.Text = Convert.ToString(TablaEmpleado.Rows[i].Cells[1].Value);
            numEdad.Value = Convert.ToInt32(TablaEmpleado.Rows[i].Cells[3].Value);
            chkEstado.Checked  = Convert.ToBoolean(TablaEmpleado.Rows[i].Cells[7].Value);
            if (Convert.ToString(TablaEmpleado.Rows[i].Cells[5].Value)=="Femenino")
            {
                rdbFemenino.Checked = true;
            }
            else
            {
                rdbMasculino.Checked = true;
            }
            
        }

        private void cboPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
