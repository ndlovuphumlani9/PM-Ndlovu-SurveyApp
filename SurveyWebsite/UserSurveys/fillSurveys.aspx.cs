using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SurveyWebsite.UserSurveys
{
    public partial class fillSurveys : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SurveyDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Btnsubmit_Click(object sender, EventArgs e)
        {
            string ckbSelecFood = "";
            int i;
            for (i = 0; i < ckbFavFood.Items.Count;i++ )
            {
                if (ckbFavFood.Items[i].Selected)
                {
                    if (ckbSelecFood == "")
                    {
                        ckbSelecFood = ckbFavFood.Items[i].Text;
                    }
                    else
                    {
                        ckbSelecFood += ", " + ckbFavFood.Items[i].Text;
                    }
                }

            }

            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO tblSurvey (surname,first_name,phoneNum,date,age,favFood,eatOut,watcMovies,watcTV,listenRadio) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + ckbSelecFood + "','" + RadioButtonEatOut.SelectedValue + "','" + RadioButtonMovies.SelectedValue + "','" + RadioButtonTv.SelectedValue + "','" + RadioButtonFM.SelectedValue + "')";
                cmd.ExecuteNonQuery();
                lblSub.Visible = true;
                lblSub.Text = "Survey Submitted Successfull !!";
                
               
            }
            catch (Exception ex)
            {
                conn.Close();
                lblerr.Visible = true;
                lblerr.Text = "Could Not Submit!! Please Contact with the Admin";
            }

        }

    }
  }