using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiplomadoMVC_Crud_HTML_Helps_NoTipados.Models
{
    public class MantenimientoProducto
    {
        private SqlConnection con;
        
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConexionDB"].ToString();
            con = new SqlConnection(constr);
        }

        public int  Agregar (Productos prod)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Producto (Descripcion, Precio) values(@Descripcion, @Precio)", con);
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@Precio", SqlDbType.Float);
            comando.Parameters["@Descripcion"].Value = prod.Descripcion;
            comando.Parameters["@Precio"].Value = prod.Precio;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

         //Mostrar todos los registros de la DB
        public List<Productos> RecuperarTodos()
        {
            Conectar();
            List<Productos> productos = new List<Productos>();

            SqlCommand comando = new SqlCommand("Select Codigo, Descripcion, Precio From Producto", con);

            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            while(registros.Read())
            {
                Productos producto = new Productos
                {
                    Codigo = int.Parse(registros["Codigo"].ToString()),
                    Descripcion = registros["Descripcion"].ToString(),
                    Precio = float.Parse(registros["Precio"].ToString())
                };
                productos.Add(producto);
            }
            con.Close();
            return productos;
        }

        //Mostrar un registro especifico de la DB.
        public Productos Recuperar(int codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("Select Codigo, Descripcion, Precio From Producto where Codigo=@Codigo", con);
            comando.Parameters.Add("@Codigo", SqlDbType.Int);
            comando.Parameters["@Codigo"].Value = codigo;
            con.Open();
            SqlDataReader registro = comando.ExecuteReader();
            Productos producto = new Productos();

            if (registro.Read())
            {
                producto.Codigo = int.Parse(registro["Codigo"].ToString());
                producto.Descripcion = registro["Descripcion"].ToString();
                producto.Precio = float.Parse(registro["Precio"].ToString());
            }
            else
                producto = null;
            con.Close();
            return producto;
        }

        //Modificar un registro especifica
        public int Modificar(Productos producto)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("Update Producto set Descripcion=@Descripcion, Precio=@Precio where Codigo=@Codigo", con);

            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters["@Descripcion"].Value = producto.Descripcion;
            comando.Parameters.Add("@Precio", SqlDbType.VarChar);
            comando.Parameters["@Precio"].Value = producto.Precio;
            comando.Parameters.Add("@Codigo", SqlDbType.VarChar);
            comando.Parameters["@Codigo"].Value = producto.Codigo;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        //Borrar un registro especifico de la DB\
        public int Borrar(int Codigo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("Delete from Producto where Codigo=@Codigo", con);
            
            comando.Parameters.Add("@Codigo", SqlDbType.Int);
            comando.Parameters["@Codigo"].Value = Codigo;
            
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}