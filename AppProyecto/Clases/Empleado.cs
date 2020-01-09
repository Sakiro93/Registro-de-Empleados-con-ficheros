using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppProyecto
{
    class Empleado
    {

        string _nombre;
        string _cedula;
        string _telefono;
        int _edad;
        string _puesto;
        double _sueldo;
        int _sexo;
        bool _seguro;


        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        public string cedula
        {
            get
            {
                return _cedula;
            }
            set
            {
                _cedula = value;
            }
        }

        public string telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }

        public int edad
        {
            get
            {
                return _edad;
            }
            set
            {
                _edad= value;
            }
        }

        public string puesto
        {
            get
            {
                return _puesto;
            }
            set
            {
                _puesto = value;
            }
        }


        public double  sueldo
        {
            get
            {
                return _sueldo;
            }
            set
            {
                _sueldo = value;
            }
        }

        public int  sexo
        {
            get
            {
                return _sexo;
            }
            set
            {
                _sexo = value;
            }
        }

        public Boolean seguro
        {
            get
            {
                return _seguro ;
            }
            set
            {
                _seguro = value;
            }
        }

        public Empleado()
        {

            this._nombre = "";
            this._cedula = "";
            this._telefono = "";
            this._edad = 0;
            this._puesto = "";
            this._sexo = 0;
            this._sueldo = 0;
            this._seguro = true ;
        
        }

       
        public Empleado(string nom , string ced, string tlf, int ed, string puest,int sx, double sld, bool seg)
        {

            this._nombre = nom;
            this._cedula = ced;
            this._telefono= tlf ;
            this._edad= ed;
            this._puesto = puest;
            this._sexo = sx;
            this._sueldo = sld;
            this._seguro = seg;
        }

 
        public String  cargarDatos()
        {
            string cadena ;
            cadena = _nombre   + ";" + _cedula  + ";" + _telefono + ";" + _edad + ";" + _puesto + ";" + _sexo + ";" + _sueldo + ";" + _seguro;
            return cadena;
        }
       
        
    }
}
