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
    public partial class WebForm1 : System.Web.UI.Page
    {
        MySqlConnection conn = new
        MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //	string ID = "1";
                    string ID = Request.QueryString["ID"];
                    if (ID != "0" && ID != null)
                    {
                        BindGridView(ID);
                    }

                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        //		#region show message  
        //		/// <summary>  
        //		/// This function is used for show message.  
        //		/// This function is used for show message.  
        //		/// </summary>  
        //		/// <param name="msg"></param>  
        void ShowMessage(string msg)
        {
            //			ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script  

            //language = 'javascript' > alert('" + msg + "');</ script > ");  
        }
        /// <summary>  
        /// This Function is used TextBox Empty.  
        /// </summary>  
        void clear()
        {
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            DropDownList1.Text = string.Empty;
            Genderfemale.Checked = false;
            Gendermale.Checked = false;
            txtName.Focus();
        }

        string gender = "";
        protected void btnSubmit_Click(object sender, EventArgs e)

        {
            if (Genderfemale.Checked == true)
            {
                gender = "Female";
            }
            else
            {
                gender = "Male";
            }
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into details (name,password,address,mobile,email,gender,subject )" +
                "values(@name,@Password, @Address, @Mobile, @Email,@Gender,@subject)", conn);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@mobile", "123");//txtMobile.Text
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@subject", DropDownList1.Text);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ShowMessage("Registered successfully......!");
                clear();
            }
            catch (MySqlException ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                conn.Close();
                Response.Redirect("detail_in_Grid.aspx");
            }
        }

        //		#endregion
        //		#region SelectedIndexChanged  
        //		/// <summary>  
        //		/// this code used to GridViewRow SelectedIndexChanged value show textbox  
        //		/// </summary>  
        //		/// <param name="sender"></param>  
        //		/// <param name="e"></param>  
        //		protected void GridViewStudent_SelectedIndexChanged(object sender, EventArgs e)
        //		{
        //			GridViewRow row = GridViewStudent.SelectedRow;
        //			lblSID.Text = row.Cells[2].Text;
        //			txtName.Text = row.Cells[3].Text;
        //			txtAddress.Text = row.Cells[4].Text;
        //			txtEmail.Text = row.Cells[5].Text;
        //			txtMobile.Text = row.Cells[6].Text;
        //			btnSubmit.Visible = false;
        //			btnUpdate.Visible = true;
        //		}
        //		#endregion
        //		#region Delete Student Data  
        //		/// <summary>  
        //		/// This code used to GridViewStudent_RowDeleting Student Data Delete  
        //		/// </summary>  
        //		/// <param name="sender"></param>  
        //		/// <param name="e"></param>  
        //		protected void GridViewStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //		{
        //			try
        //			{
        //				conn.Open();
        //				int SID = Convert.ToInt32(GridViewStudent.DataKeys[e.RowIndex].Value);
        //				MySqlCommand cmd = new MySqlCommand("Delete From student1 where SID='" + SID + "'",
        //conn);
        //				cmd.ExecuteNonQuery();
        //				cmd.Dispose();
        //				ShowMessage("Student Data Delete Successfully......!");
        //				GridViewStudent.EditIndex = -1;
        //				BindGridView();
        //			}
        //			catch (MySqlException ex)
        //			{
        //				ShowMessage(ex.Message);
        //			}
        //			finally
        //			{
        //				conn.Close();
        //			}
        //		}
        //		#endregion
        //		#region student data update  
        //		/// <summary>  
        //		/// This code used to student data update  
        //		/// </summary>  
        //		/// <param name="sender"></param>  
        //		/// <param name="e"></param>  
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Response.Redirect("detail_in_Grid.aspx");
            try
            {
                conn.Open();
                //string ID = Request.QueryString["ID"];
                //string SID = ID;
                string SID = lblSID.Text;
                //if (Genderfemale.Checked == true)
                //{
                //    gender = "Female";
                //}
                //else
                //{
                //    gender = "Male";
                //}
                MySqlCommand cmd = new MySqlCommand("update details Set " +
                "name = @name,password=@password, address = @address, mobile = @mobile, email = @email,gender=@gender,subject=@subject where user_id =@SID", conn);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@mobile", "123");
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@subject", DropDownList1.Text);
                cmd.Parameters.AddWithValue("@SID", SID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ShowMessage("Student Data update Successfully......!");
                //GridViewuser.EditIndex = -1;
                // BindGridView(SID);
                btnUpdate.Visible = false;
            }
            catch (MySqlException ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                conn.Close();
                Response.Redirect("detail_in_Grid.aspx");
            }
        }
        #region textbox clear  
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }
        #endregion

        private void BindGridView(string id)
        {
            try
            {


                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                MySqlCommand cmd = new MySqlCommand("Select * from details where user_id=@id;", conn);
                string SID = id;
                cmd.Parameters.AddWithValue("@id", SID);

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                lblSID.Text = ds.Tables[0].Rows[0][0].ToString();
                txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtPassword.Text = ds.Tables[0].Rows[0][2].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0][3].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][4].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0][5].ToString();
                DropDownList1.Text = ds.Tables[0].Rows[0][6].ToString();
                gender = ds.Tables[0].Rows[0][7].ToString();

                if (gender.Equals("Female"))
                {
                    Genderfemale.Checked = true;
                }
                else
                {
                    Gendermale.Checked = true;
                }
                //string value = "";
                //bool isChecked = Genderfemale.Checked;s
                //if (isChecked)
                //	value = Genderfemale.Text;
                //else
                //	value = Gendermale.Text;


                //            value= ds.Tables[0].Rows[0][7].ToString();
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
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

    }

}