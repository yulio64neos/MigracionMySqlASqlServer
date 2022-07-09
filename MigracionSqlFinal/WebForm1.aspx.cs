using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MigracionDAL;
using MigracionDAL.Models;

namespace MigracionSqlFinal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Datos obj = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                GridView1.DataSource = obj.consultarEmpleado();
                GridView1.DataBind();
            }
        }

        protected void btnConexion_Click(object sender, EventArgs e)
        {
            string res = obj.RevisarConexionMysql();
            Response.Write("<script>alert('" + res + "')</script>");
        }

        protected void btnConexion2_Click(object sender, EventArgs e)
        {
            string res = obj.RevisaConexionSqlServer();
            Response.Write("<script>alert('" + res + "')</script>");
        }

        protected void btnMigracion_Click(object sender, EventArgs e)
        {
            obj.migracionSQL();
        }
    }
}