using System;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SurveyWebsite.UserSurveys
{
    public partial class SurveyResult : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SurveyDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //total surveys
                conn.Open();
                string survQuerySum = "SELECT COUNT(survey_id) FROM tblSurvey";
               SqlCommand surveyTot = new SqlCommand(survQuerySum, conn);
                int totalSurv = Convert.ToInt32(surveyTot.ExecuteScalar());
                lblsur.Visible = true;
                lblsur.Text = " =  " + totalSurv;

                //average age 
                string ageAverage = " SELECT SUM(age) FROM tblSurvey";
                SqlCommand ageCom = new SqlCommand(ageAverage, conn);
                int averAge = Convert.ToInt32(ageCom.ExecuteScalar());
                lblage.Visible = true;
                lblage.Text = " = " + (averAge / totalSurv);

                //oldest person to participate in the survey
                string HighestAge = "SELECT fName, age  FROM tblSurvey WHERE age  =(SELECT MAX(age)  FROM tblSurvey) ";
               SqlCommand ageCommand = new SqlCommand(HighestAge, conn);
                string oldest = ageCommand.ExecuteScalar().ToString();
                lblOld.Visible = true;
                lblOld.Text = " = " +  oldest;

                //youngest person who participated in the survey
                string lowestAge = "SELECT fName FROM tblSurvey WHERE age  =(SELECT MIN(age)  FROM tblSurvey)";
                SqlCommand lowestAgeC = new SqlCommand(lowestAge, conn);
                string youngest = lowestAgeC.ExecuteScalar().ToString();
                lblyoung.Visible = true;
                lblyoung.Text =" = " + youngest;

                //Percentage of peolple who like pizza
                string pizza = "SELECT COUNT(survey_id) FROM tblSurvey WHERE favFood = ' Pizza '";
                SqlCommand pizzaSQLC = new SqlCommand(pizza, conn);
                double pizzaPercent = Convert.ToDouble(pizzaSQLC.ExecuteScalar());
                //pizzaPercent = (pizzaPercent / totalSurv) * 100;
                //double pizzaRoundPercent = Math.Round((float)pizzaPercent, 1);
                lblpizz.Visible = true;
                lblpizz.Text = (pizzaPercent) + " %" ;

                //Percentage of peolple who like pasta
                string pasta = "SELECT COUNT(survey_id) FROM tblSurvey WHERE favFood =' Pasta '";
                SqlCommand pastaSQLC = new SqlCommand(pasta, conn);
                double pastaPercent = Convert.ToDouble(pastaSQLC.ExecuteScalar());
                //pastaPercent = (pastaPercent / totalSurv) * 100;
                //double pastaRoundPercent = Math.Round((float)pastaPercent, 1);
                lblpasta.Visible = true;
                lblpasta.Text = (pastaPercent / totalSurv) * 100 + " %";

                //Percentage of peolple who like Pap and wors
                string pap = "SELECT COUNT(survey_id) FROM tblSurvey WHERE favFood =' Pap and wors '";
                SqlCommand papSQLC = new SqlCommand(pap, conn);
                double papPercent = Convert.ToDouble(papSQLC.ExecuteScalar());
                //papPercent = (papPercent / totalSurv) * 100;
                //double papRoundPercent = Math.Round((float)papPercent, 1);
                lblpap.Visible = true;
                lblpap.Text = (papPercent / totalSurv) * 100 + " %";

                //Percentage of peolple who like to eat out
                string EatOut = "SELECT COUNT(survey_id) FROM tblSurvey WHERE eatOut =' Strongly Agree'";
                SqlCommand EatOutSQLC = new SqlCommand(EatOut, conn);
                double EatOutPercent = Convert.ToDouble(EatOutSQLC.ExecuteScalar());
                EatOutPercent = (EatOutPercent / totalSurv) * 100;
                double eatRoundPercent = Math.Round((Double)EatOutPercent, 1);
                lbleatout.Visible = true;
                lbleatout.Text = eatRoundPercent + " %";

                //Percentage of peolple who like to watch movies
                string movies = "SELECT COUNT(survey_id) FROM tblSurvey WHERE watcMovies =' Strongly Agree' OR watcMovies =' Agree' ";
                SqlCommand moviesSQLC = new SqlCommand(movies, conn);
                double moviesPercent = Convert.ToDouble(moviesSQLC.ExecuteScalar());
                moviesPercent = (moviesPercent / totalSurv) * 100;
                double moviesRoundPercent = Math.Round((Double)moviesPercent, 1);
                lblmovies.Visible = true;
                lblmovies.Text = moviesRoundPercent + " %";

                //Percentage of peolple who like to watch tv
                string tv = "SELECT COUNT(survey_id) FROM tblSurvey WHERE watcTV =' Strongly Agree' OR watcTV =' Agree'";
                SqlCommand tvSQLC = new SqlCommand(tv, conn);
                double tvPercent = Convert.ToDouble(tvSQLC.ExecuteScalar());
                tvPercent = (tvPercent / totalSurv) * 100;
                double tvRoundPercent = Math.Round((Double)tvPercent, 1);
                lbltv.Visible = true;
                lbltv.Text = tvRoundPercent + " %";

                //Percentage of peolple who like to listen to radio
                string radio = "SELECT COUNT(survey_id) FROM tblSurvey WHERE listenRadio =' Strongly Agree' OR listenRadio =' Agree'";
                SqlCommand radioSQLC = new SqlCommand(radio, conn);
                double radioPercent = Convert.ToDouble(radioSQLC.ExecuteScalar());
                radioPercent = (radioPercent / totalSurv) * 100;
                double radioRoundPercent = Math.Round((Double)radioPercent, 1);
                lblradio.Visible = true;
                lblradio.Text = radioRoundPercent + " %";


            }

            catch (Exception ex)
            {
                lblerr.Visible = true;
                lblerr.Text = "Something went wrong on the Database. Please contact the System Admin ";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}