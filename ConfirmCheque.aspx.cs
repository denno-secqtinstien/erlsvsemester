using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace confirm_cheque
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.DataGrid MainGrid;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlImage IMG5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			SqlConnection con = new SqlConnection();
			con.ConnectionString = "data source=(local);initial catalog=tempdb;uid=SA;pwd=;";
			con.Open();
			string strCmd = "select * from booksonline";
			SqlCommand scmd = new SqlCommand(strCmd,con);
			scmd.ExecuteNonQuery();
			SqlDataAdapter da = new SqlDataAdapter("Select * from booksonline WHERE username ='"+ username +"' AND sysdate = {"+ Convert.ToString(d) +"}",con);
			DataSet ds = new DataSet();
			da.Fill(ds,"booksonline");
			MainGrid.DataSource = ds.Tables[0].DefaultView;
			MainGrid.DataBind();
			Label4.Text = "Rs. " + Convert.ToString(money);
			con.Close();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ThanksMessage.aspx");			
		}
	}
}
