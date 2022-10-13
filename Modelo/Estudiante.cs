using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace web_umg_bd
{
    public class Estudiante
    {
        ConexionBD conectar;
        private DataTable drop_ts(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select id_tipo_sangre as id,sangre from tipos_sangre;");
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void drop_ts(DropDownList drop){
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elige Tipo de sangre >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_ts();
            drop.DataTextField = "sangre";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        private DataTable grid_estudiantes() {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            String consulta = string.Format("select e.id_estudiante as id,e.carne,e.nombres,e.apellidos,e.direccion,e.telefono, e.correo_electronico,p.sangre,p.id_tipo_sangre,e.fecha_nacimiento from estudiantes as e inner join tipos_sangre as p on e.id_tipo_sangre = p.id_tipo_sangre;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void grid_estudiantes(GridView grid){
            grid.DataSource = grid_estudiantes();
            grid.DataBind();

        }
        public int agregar(string carne,string nombres,string apellidos,string direccion,string telefono,string correo_electronico,int id_tipo_sangre, string fecha)
        {
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("insert into estudiantes(carne,nombres,apellidos,direccion,telefono,correo_electronico,id_tipo_sangre,fecha_nacimiento) values('{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}');",carne,nombres,apellidos,direccion,telefono, correo_electronico, id_tipo_sangre,fecha);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);
            
            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;

        }
        public int modificar(int id,string carne, string nombres, string apellidos, string direccion, string telefono, string correo_electronico, int id_tipo_sangre, string fecha){
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("update estudiantes set carne = '{0}',nombres = '{1}',apellidos = '{2}',direccion='{3}',telefono='{4}',correo_electronico='{5}',id_tipo_sangre = {6},fecha_nacimiento='{7}' where id_estudiante = {8};", carne, nombres, apellidos, direccion, telefono, correo_electronico, id_tipo_sangre,fecha,id);
            MySqlCommand modificar = new MySqlCommand(strConsulta, conectar.conectar);

            modificar.Connection = conectar.conectar;
            no_ingreso = modificar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }
        public int eliminar(int id){
            int no_ingreso = 0;
        conectar = new ConexionBD();
        conectar.AbrirConexion();
            string strConsulta = string.Format("delete from estudiantes  where id_estudiante = {0};", id);
        MySqlCommand eliminar = new MySqlCommand(strConsulta, conectar.conectar);

            eliminar.Connection = conectar.conectar;
            no_ingreso = eliminar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }

}
}