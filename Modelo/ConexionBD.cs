using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
namespace web_umg_bd
{
    public class ConexionBD
    {
        private string cadena = "server=localhost; database=db_hospital user=usr_hospital; password=jojororu05";
        public MySqlConnection conectar = new MySqlConnection();
        

        public void AbrirConexion(){
            try {
                conectar.ConnectionString = cadena;
                conectar.Open();
               // System.Diagnostics.Debug.WriteLine("Conexion con exito");
               
            } 
            catch(Exception ex){
                System.Diagnostics.Debug.WriteLine(ex.Message);
               // Console.WriteLine(ex.StackTrace);
                
            }

        }
        public void CerarConexion(){
            
                if (conectar.State == ConnectionState.Open){
                conectar.Close();            }

        }
    }
}