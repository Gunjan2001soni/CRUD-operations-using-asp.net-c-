using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace GunjanForm
{
	public partial class detail_in_Grid : System.Web.UI.Page
	{
		MySqlConnection conn = new
		MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
				{
					BindGridView();

				}
			}
			catch (Exception ex)
			{
				ShowMessage(ex.Message);
			}
		}
		void ShowMessage(string msg)
		{
			//			ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script  

			//language = 'javascript' > alert('" + msg + "');</ script > ");  
		}
		/// <summary>  
		/// This Function is used TextBox Empty.  
		/// </summary>  
		private void BindGridView()
		{
			try
			{
				if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				MySqlCommand cmd = new MySqlCommand("Select * from details ORDER BY user_id DESC;",
conn);
				MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				adp.Fill(ds);
				GridViewuser.DataSource = ds;
				GridViewuser.DataBind();
				lbltotalcount.Text = GridViewuser.Rows.Count.ToString();
			}
			catch (MySqlException ex)
			{
				ShowMessage(ex.Message);
			}
			finally
			{
				if (conn.State == ConnectionState.Open)
				{
					conn.Close();
				}
			}
		}
        protected void GridViewuser_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewuser.SelectedRow;
           string ID= row.Cells[2].Text; 
			//Response.Redirect("userRegis.aspx");
			Response.Redirect(string.Format("~/userRegis.aspx?ID={0}", ID));

		}
		protected void GridViewuser_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				conn.Open();
				int user_id = Convert.ToInt32(GridViewuser.DataKeys[e.RowIndex].Value);
				MySqlCommand cmd = new MySqlCommand("Delete From details where user_id='" + user_id + "'",
conn);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				ShowMessage("Student Data Delete Successfully......!");
				GridViewuser.EditIndex = -1;
				BindGridView();
			}
			catch (MySqlException ex)
			{
				ShowMessage(ex.Message);
			}
			finally
			{
				conn.Close();
			}
		}
		protected void btnAddUser_Click(object sender, EventArgs e)
		{
			Response.Redirect("userRegis.aspx");
		}
	}
}