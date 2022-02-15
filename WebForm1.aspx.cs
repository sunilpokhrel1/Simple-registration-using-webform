using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASSIGNMENTTASK
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid_view();
            }
        }
        void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public void grid_view()
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand("employee_grid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grd.DataSource = ds;
                grd.DataBind();
            }
            CloseConnection();
        }
        protected void btninsert_Click(object sender, EventArgs e)
        {
            if (btninsert.Text == "Insert")
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("employee_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ename", txtname.Text);
                cmd.Parameters.AddWithValue("@eadress", txtaddress.Text);
                cmd.Parameters.AddWithValue("@emob", txtphone.Text);
                cmd.ExecuteNonQuery();
                CloseConnection();
                grid_view();
            }
            else if (btninsert.Text == "Update")
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("employee_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", ViewState["abc"]);
                cmd.Parameters.AddWithValue("@ename", txtname.Text);
                cmd.Parameters.AddWithValue("@eadress", txtaddress.Text);
                cmd.Parameters.AddWithValue("@emob", txtphone.Text);
                cmd.ExecuteNonQuery();
                CloseConnection();
                grid_view();
            }
        }
        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EDT")
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("employee_Edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                CloseConnection();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtname.Text = ds.Tables[0].Rows[0]["ename"].ToString();
                    txtaddress.Text = ds.Tables[0].Rows[0]["eadress"].ToString();
                    txtphone.Text = ds.Tables[0].Rows[0]["emob"].ToString();
                }
                grid_view();
            }
            else
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("employee_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                CloseConnection();
                grid_view();
            }
            btninsert.Text = "Update";
            ViewState["abc"] = e.CommandArgument;
        }
    }
}
