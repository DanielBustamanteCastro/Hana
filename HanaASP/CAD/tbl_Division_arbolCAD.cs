using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    public class tbl_Division_arbolCAD {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion_Hana"].ConnectionString);

    //BUsca el id de la division con el nombre de la division
    public int Buscar_id_Division(String division)
    {
        int id = 0;
        try
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "prc_SELECT_tbl_Division_arbol_con_id_Reino";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@division", division);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            foreach (var item in dr)
            {
                id = int.Parse(dr["id_division_arbol"].ToString());
            }
            con.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return id;
    }

        //Busca todas las divisiones dependientes del id del dominio
    public List<tbl_Division_arbol> Buscar_division(int id_reino)
    {
        List<tbl_Division_arbol> division = new List<tbl_Division_arbol>();
        try
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "prc_SELECT_tbl_Division_arbol_con_id_reino";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id_reino);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            foreach (var item in dr)
            {
                    tbl_Division_arbol da = new tbl_Division_arbol();
                    da.id_division_arbol=int.Parse(dr["id_division_arbol"].ToString());
                    da.division_arbol = dr["division_arbol"].ToString();
                    division.Add(da);
            }
            con.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return division;
    }
}
}
