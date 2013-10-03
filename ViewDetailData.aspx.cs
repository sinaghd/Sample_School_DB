using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewDetailDataPage
{
    public partial class ViewDetailDataClass : Page
    {
        private readonly string bgColor = String.Empty;
        private string AcceptanceDate = String.Empty;
        private string Address = String.Empty;
        private string AdministrativeNotes = String.Empty;
        private string Auth_Id = String.Empty;
        private string ClassHoursHistory = String.Empty;
        private string Comments = String.Empty;
        private string CountryOfBirth = String.Empty;
        private string CurrentLevel = String.Empty;
        private string Email = String.Empty;
        private string EmergencyAddress = String.Empty;
        private string EmergencyContact = String.Empty;
        private string EmergencyNumber = String.Empty;
        private string FirstName = String.Empty;
        private string LastName = String.Empty;
        private string Nationality = String.Empty;
        private string Nickname = String.Empty;
        private string NotifyPayment = String.Empty;
        private string Phone = String.Empty;
        private string PhoneNumber = String.Empty;
        private string ProgramEndDate = String.Empty;
        private string ProgramStartDate = String.Empty;
        private string StudentImage = String.Empty;
        private OdbcConnection TempConn;
        private DataSet TempRs;
        private DataSet TempRsStd;
        private DataSet TempRsVac;
        private string TestScoreHistory = String.Empty;
        private string TuitionPaymentDate = String.Empty;
        private string TuitionPaymentNotes = String.Empty;
        private string VacationInfo = String.Empty;
        private string WarningLetterInfo = String.Empty;
        private string blankImg = String.Empty;
        private double earnedvac;
        private string iColor = String.Empty;
        private int iCount;
        private string iRecord = String.Empty;
        private string imgDelete = String.Empty;
        private string imgPath = String.Empty;
        private string isDelete = String.Empty;
        private float random_number;
        private string remainvac = String.Empty;
        private string smileyImg = String.Empty;
        private string status = String.Empty;
        private string stdSql = String.Empty;
        private string stdid = String.Empty;
        private string stdweek = String.Empty;
        private string strSql = String.Empty;
        private string vacSql = String.Empty;
        private string vacweek = String.Empty;
        private int weekleft;

            

        private string dateSlashFormat(string x)
        {
            // Convert date format to MM/DD/YYYY    
            short str1 = 0;
            short str2 = 0;
            short str3 = 0;

            if (x.Trim() != "")
            {
                str1 = (short) DateTime.Parse(x).Month;
                str2 = (short) DateTime.Parse(x).Day;
                str3 = (short) DateTime.Parse(x).Year;
                return str1 + "/" + str2 + "/" + str3;
            }
            return "";
        }


        private string getStatusName(string status)
        {
            // Get description of student status            
            TempRs = TempRsFilled("SELECT status_description FROM iic_students_status WHERE status_id=" + status);

            foreach (DataRow iteration_row in TempRs.Tables[0].Rows)
            {
                result = Convert.ToString(iteration_row["status_description"]);
            }
            return result;
        }


        private string getLevelName(string level)
        {
            // Get description of student level            
            TempRs = TempRsFilled("SELECT level_description FROM iic_students_level WHERE level_id=" + level);

            foreach (DataRow iteration_row in TempRs.Tables[0].Rows)
            {
                result = Convert.ToString(iteration_row["level_description"]);
            }
            return result;
        }


        private void ConnectToDB()
        {
            //Connect to Database
            string sConnection = String.Empty;
            sConnection = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            TempConn = new OdbcConnection();
            TempConn.ConnectionString = sConnection;
            TempConn.Open();
        }


        private DataSet TempRsFilled(string TempRsFilled_sql)
        {
            // Fill a dataset    
            OdbcCommand TempRsFilled_Command = null;
            TempRsFilled_Command = new OdbcCommand();
            TempRsFilled_Command.CommandText = TempRsFilled_sql;
            OdbcDataAdapter TempRsFilled_DataAdapater = null;
            TempRsFilled_DataAdapater = new OdbcDataAdapter();
            TempRsFilled_DataAdapater.SelectCommand = TempRsFilled_Command;
            TempRsFilled_DataAdapater.SelectCommand.Connection = TempConn;
            DataSet TempRsFilled_Dataset = null;
            TempRsFilled_Dataset = new DataSet();
            TempRsFilled_DataAdapater.Fill(TempRsFilled_Dataset);
            return TempRsFilled_Dataset;
        }


        private void TempDbExecute(string TempDbExecute_sql)
        {
            // Execute a SQ: command
            OdbcCommand TempCommand_2 = null;
            TempCommand_2 = new OdbcCommand();
            TempCommand_2.CommandText = TempDbExecute_sql;
            TempCommand_2.Connection = TempConn;
            TempCommand_2.ExecuteNonQuery();
        }


        private void closeWindow()
        {
            // Create a javascript closeWindow script from server
            AddJS("LoginAgainPopupAlert", "alert('Please login again.'); window.parent.close();");
        } 


        private void AddJS(string csname, string cscontent)
        {
            // Create and execute javascript block
            Type cstype = GetType();
            ClientScriptManager cs = Page.ClientScript;
            if (!cs.IsClientScriptBlockRegistered(cstype, csname))
            {
                cs.RegisterStartupScript(cstype, csname, cscontent, true);
            }
        }



        private void CalculateRemainingVacation()
        {
            // Calculate remaining number of weeks of earned vacation
            vacSql = "SELECT SUM(weeks) as weeks FROM iic_vacation WHERE StudentID = " + stdid;

            TempRsVac = TempRsFilled(vacSql);

            foreach (DataRow iteration_row_3 in TempRsVac.Tables[0].Rows)
            {
                vacweek = Convert.ToString(iteration_row_3["weeks"]);
            }

            if (vacweek == "" || Convert.IsDBNull(vacweek))
            {
                vacweek = "0";
            }

            earnedvac = 0;

            if (Convert.ToInt16(Double.Parse(stdweek)) >= 36)
            {
                for (iCount = 1; iCount <= Convert.ToInt16(Double.Parse(stdweek)); iCount++)
                {
                    if (((short) iCount)%36 == 0)
                    {
                        earnedvac++;
                    }
                }

                earnedvac *= 5;
                weekleft = Convert.ToInt16(Double.Parse(stdweek))%36;
            }
            else if (Convert.ToInt16(Double.Parse(stdweek)) > 31)
            {
                for (iCount = 1; iCount <= Convert.ToInt16(Double.Parse(stdweek)); iCount++)
                {
                    if (((short) iCount)%32 == 0)
                    {
                        earnedvac++;
                    }
                }

                earnedvac *= 4;
                weekleft = Convert.ToInt16(Double.Parse(stdweek))%32;
            }
            else if (Convert.ToInt16(Double.Parse(stdweek)) > 27)
            {
                for (iCount = 1; iCount <= Convert.ToInt16(Double.Parse(stdweek)); iCount++)
                {
                    if (((short) iCount)%28 == 0)
                    {
                        earnedvac++;
                    }
                }

                earnedvac *= 3;
                weekleft = Convert.ToInt16(Double.Parse(stdweek))%28;
            }
            else if (Convert.ToInt16(Double.Parse(stdweek)) >= 20)
            {
                for (iCount = 1; iCount <= Convert.ToInt16(Double.Parse(stdweek)); iCount++)
                {
                    if (((short) iCount)%20 == 0)
                    {
                        earnedvac++;
                    }
                }

                earnedvac *= 2;
                weekleft = Convert.ToInt16(Double.Parse(stdweek))%20;
            }
            else
            {
                earnedvac = 0;
            }

            if (earnedvac > 0)
            {
                if (((short) weekleft) > 31)
                {
                    earnedvac += 4;
                }
                else if (((short) weekleft) > 27)
                {
                    earnedvac += 3;
                }
                else if (((short) weekleft) >= 20)
                {
                    earnedvac += 2;
                }
            }

            remainvac = Convert.ToInt16(earnedvac - Double.Parse(vacweek)).ToString();

            if (remainvac == "" || Convert.IsDBNull(remainvac))
            {
                remainvac = "0";
            }
        }


        private void ProcessFormData()
        {
            // Process form data
            if (String.Format("{0}", Request.ServerVariables["REQUEST_METHOD"]) == "POST")
            {
                stdid = String.Format("{0}", Request.Form["stdid"]);
                isDelete = String.Format("{0}", Request.Form["isDelete"]);
                iRecord = String.Format("{0}", Request.Form["iRecord"]);

                if (isDelete != "")
                {
                    strSql = "DELETE FROM iic_vacation WHERE id='" + iRecord + "' AND StudentID='" + stdid + "'";
                    TempDbExecute(strSql);
                    ClientScriptManager cs = Page.ClientScript;
                    AddJS("DeletedPopupAlert", "alert('The record has been deleted.');");
                }
            }
            else
            {
                stdid = String.Format("{0}", Request.QueryString["stdid"]);
            }


            //Extract all basic information related to the particular student
            strSql = "SELECT * FROM iic_students_basic WHERE StudentID=" + stdid;

            TempRs = TempRsFilled(strSql);

            foreach (DataRow iteration_row in TempRs.Tables[0].Rows)
            {
                LastName = Convert.ToString(iteration_row["LastName"]);
                FirstName = Convert.ToString(iteration_row["FirstName"]);
                Nickname = Convert.ToString(iteration_row["Nickname"]);
                status = Convert.ToString(iteration_row["Status"]);

                StudentImage = smileyImg;

                if (Convert.ToString(iteration_row["StudentImage"]) != "" ||
                    DBNull.Value.Equals(iteration_row["StudentImage"]))
                {
                    StudentImage = imgPath + Convert.ToString(iteration_row["StudentImage"]);
                }

                Address = Convert.ToString(iteration_row["Address"]);
                PhoneNumber = Convert.ToString(iteration_row["PhoneNumber"]);
                Email = Convert.ToString(iteration_row["Email"]);
                CountryOfBirth = Convert.ToString(iteration_row["CountryOfBirth"]);
                Nationality = Convert.ToString(iteration_row["Nationality"]);
                EmergencyContact = Convert.ToString(iteration_row["EmergencyContact"]);
                EmergencyAddress = Convert.ToString(iteration_row["EmergencyAddress"]);
                EmergencyNumber = Convert.ToString(iteration_row["EmergencyNumber"]);
                AcceptanceDate = dateSlashFormat(Convert.ToString(iteration_row["AcceptanceDate"]));
                ProgramStartDate = dateSlashFormat(Convert.ToString(iteration_row["ProgramStartDate"]));
                ProgramEndDate = dateSlashFormat(Convert.ToString(iteration_row["ProgramEndDate"]));
                TestScoreHistory = Convert.ToString(iteration_row["TestScoreHistory"]);
                CurrentLevel = Convert.ToString(iteration_row["CurrentLevel"]);
                TuitionPaymentDate = dateSlashFormat(Convert.ToString(iteration_row["TuitionPaymentDate"]));
                TuitionPaymentNotes = Convert.ToString(iteration_row["TuitionPaymentNotes"]);
                ClassHoursHistory = Convert.ToString(iteration_row["ClassHoursHistory"]);
                VacationInfo = Convert.ToString(iteration_row["VacationInfo"]);
                WarningLetterInfo = Convert.ToString(iteration_row["WarningLetterInfo"]);
                Comments = Convert.ToString(iteration_row["Comments"]);
                AdministrativeNotes = Convert.ToString(iteration_row["AdministrativeNotes"]);
                NotifyPayment = Convert.ToString(iteration_row["Notify_Payment"]);
            }

            stdSql = "SELECT lastname, firstname, FLOOR( DATEDIFF( CURDATE( ) , PROGRAMSTARTDATE ) /7 ) AS weeks ";
            stdSql = stdSql + "FROM iic_students_basic ";
            stdSql = stdSql + "WHERE STATUS IN (1) ";
            stdSql = stdSql + "AND StudentID=" + stdid;

            TempRsStd = TempRsFilled(stdSql);

            foreach (DataRow iteration_row_2 in TempRsStd.Tables[0].Rows)
            {
                stdweek = Convert.ToString(iteration_row_2["weeks"]);
            }

            if (stdweek == "" || Convert.IsDBNull(stdweek))
            {
                stdweek = "0";
            }
            
            // Calculate remaining vacation
            CalculateRemainingVacation();          
        }


        private TableRow TableOpeningRow()
        {
           // Generate a standard opening table row 
            var TempTR = new TableRow();
            TempTR.Style["background-color"] = bgColor;
            TempTR.Style["color"] = "#000000";
            return TempTR;
        }


        private TableRow TableClosingRow(short TempColSpan)
        {
            // Generate a standard closing table row
            var TempTR = new TableRow();
            var TempTC = new TableCell();
            TempTC.ColumnSpan = TempColSpan;
            TempTC.Controls.Add(
                new LiteralControl(
                    "<img src='/images/blank.gif' width='100%' height='1' style='background-color:white'>"));
            TempTR.Cells.Add(TempTC);
            return TempTR;
        }


        private void OutputToTable()
        {
            //Add basic student information values to table cells
            TableRow StdTR = null;
            
            StdImage.ImageUrl = StudentImage;
            StudentID.Value = stdid;
            FirstAndLastName.Controls.Add(new LiteralControl(LastName.ToUpper() + ", " + FirstName.ToUpper()));
            StdNickname.Controls.Add(new LiteralControl(Nickname));

            if (status == "0")
            {
                status = "DELETED";
                iColor = "red";
            }
            else
            {
                status = getStatusName(status);
                iColor = "blue";
            }

            StdStatus.Style["color"] = iColor;
            StdStatus.Controls.Add(new LiteralControl(status));
            StdAddress.Controls.Add(new LiteralControl(Address));
            StdPhone.Controls.Add(new LiteralControl(PhoneNumber));
            StdEmail.Controls.Add(new LiteralControl(Email));
            StdCOB.Controls.Add(new LiteralControl(CountryOfBirth));
            StdNationality.Controls.Add(new LiteralControl(Nationality));
            StdEmergencyContact.Controls.Add(new LiteralControl(EmergencyContact));
            StdEmergencyAddress.Controls.Add(new LiteralControl(EmergencyAddress));
            StdEmergencyNumber.Controls.Add(new LiteralControl(EmergencyNumber));
            StdProgramStartDate.Controls.Add(new LiteralControl(ProgramStartDate));
            StdProgramEndDate.Controls.Add(new LiteralControl(ProgramEndDate));
            StdScore.Controls.Add(new LiteralControl(TestScoreHistory));
            StdLevel.Controls.Add(new LiteralControl(getLevelName(CurrentLevel)));
            StdTuitionDate.Controls.Add(new LiteralControl(TuitionPaymentDate));
            StdWeeks.Controls.Add(new LiteralControl(stdweek + " Week(s)"));
            StdEarnedVacation.Controls.Add(new LiteralControl(earnedvac + " Week(s)"));
            StdRemainingVacation.Controls.Add(new LiteralControl(remainvac + " Week(s)"));
            StdNotifiedPayment.Controls.Add(new LiteralControl(NotifyPayment));


            //Add rows to tuition history table
            strSql =
                "SELECT random_number, print_date, total_fee, (out_fee + out_dep + mail_fee) as overseas, (trans_fee + trans_dep) as transfer, tuition_fee, late_fee, (other_fee + other_other_fee) as other_fee, weeks_num, date_from, date_to, note ";
            strSql = strSql + "FROM iic_invoice_logs ";
            strSql = strSql + "WHERE stdid=" + stdid + " ORDER BY id DESC";

            TempRs = TempRsFilled(strSql);
            string FullBlankImg = "<img src='/images/blank.gif' width='1' height='1'>";

            foreach (DataRow iteration_row_4 in TempRs.Tables[0].Rows)
            {
                random_number = Convert.ToSingle(iteration_row_4["random_number"]);


                StdTR = TableOpeningRow();
                StdTR.Attributes["onclick"] = "selectRow(this, '" + random_number + "', '#E0E0E0'); return false;";
                StdTR.Cells.Add(CellWithContent(dateSlashFormat(Convert.ToString(iteration_row_4["print_date"])), 70, 0,
                    "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));

                var tctext = new StringBuilder();
                tctext.Append("<a class='thumbnail' href='#thumb'>detail");
                tctext.Append("<span class='textform' style='width:170px; height:70px'>");
                tctext.Append("<table width='170' border='0' cellpadding='0' cellspacing='0'>");
                tctext.Append(
                    "<tr><td width='100' class='textform' align='right'>Outside USA :</td><td width='10'></td><td width='60' class='textform' align='right'>" +
                    iteration_row_4["overseas"] + "</td></tr>");
                tctext.Append(
                    "<tr><td width='100' class='textform' align='right'>Transfer In :</td><td width='10'></td><td width='60' class='textform' align='right'>" +
                    iteration_row_4["transfer"] + "</td></tr>");
                tctext.Append(
                    "<tr><td width='100' class='textform' align='right'>Tuition :</td><td width='10'></td><td width='60' class='textform' align='right'>" +
                    iteration_row_4["tuition_fee"] + "</td></tr>");
                tctext.Append(
                    "<tr><td width='100' class='textform' align='right'>Late Fee :</td><td width='10'></td><td width='60' class='textform' align='right'>" +
                    iteration_row_4["late_fee"] + "</td></tr>");
                tctext.Append(
                    "<tr><td width='100' class='textform' align='right'>Other Fee :</td><td width='10'></td><td width='60' class='textform' align='right'>" +
                    iteration_row_4["other_fee"] + "</td></tr>");
                tctext.Append("</table>");
                tctext.Append("</span>");
                tctext.Append("</a>");

                StdTR.Cells.Add(CellWithContent(tctext.ToString(), 50, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(CellWithContent(iteration_row_4["total_fee"].ToString(), 50, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(CellWithContent(iteration_row_4["weeks_num"].ToString(), 50, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(
                    CellWithContent(
                        dateSlashFormat(Convert.ToString(iteration_row_4["date_from"])) + " - " +
                        dateSlashFormat(Convert.ToString(iteration_row_4["date_to"])), 50, 0, "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(CellWithContent(iteration_row_4["note"].ToString(), 50, 0, "textform"));

                StdTable1.Rows.Add(StdTR);

                StdTR = TableClosingRow(11);
                StdTable1.Rows.Add(StdTR);
            }


           //Add rows to vacation table
            strSql = "SELECT * FROM iic_vacation WHERE StudentID=" + stdid + " ORDER BY start_date DESC";

            TempRs = TempRsFilled(strSql);

            foreach (DataRow iteration_row_5 in TempRs.Tables[0].Rows)
            {
                StdTR = TableOpeningRow();
                StdTR.Attributes["onmouseover"] = "Set(this,'hand'); return false;";
                StdTR.Cells.Add(CellWithContent(dateSlashFormat(Convert.ToString(iteration_row_5["start_date"])), 100, 0,
                    "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(CellWithContent(dateSlashFormat(Convert.ToString(iteration_row_5["end_date"])), 100, 0,
                    "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(CellWithContent(dateSlashFormat(Convert.ToString(iteration_row_5["weeks"])), 100, 0,
                    "textform"));
                StdTR.Cells.Add(CellWithContent(FullBlankImg, 1, 1, ""));
                StdTR.Cells.Add(
                    CellWithContent(
                        "<img src='" + imgDelete + @"' width='16' height='16' border='0' onclick=""delRecord('" +
                        Convert.ToInt16(Session["Auth_Id"]) + "', '" + iteration_row_5["id"] + @"'); return false;"">",
                        50, 0, "textform"));
                StdTable2.Rows.Add(StdTR);

                StdTR = TableClosingRow(7);
                StdTable2.Rows.Add(StdTR);
            }

           //Add tab label values
            LabelTuitionPaymentNotes.Text = TuitionPaymentNotes;
            LabelClassHoursHistory.Text = ClassHoursHistory;
            LabelWarningLetterInfo.Text = WarningLetterInfo.ToUpper();
            LabelComments.Text = Comments.ToUpper();
            LabelAdministrativeNotes.Text = AdministrativeNotes;
        }


        private TableCell CellWithContent(string CellContent, short CellWidth, short CellHeight, string CellClass)
        {
            // Generate table cell with specified content
            var tc = new TableCell();
            if (CellWidth != 0)
            {
                tc.Width = CellWidth;
            }
            if (CellHeight != 0)
            {
                tc.Height = CellHeight;
            }
            if (CellClass != "")
            {
                tc.CssClass = CellClass;
            }
            tc.Controls.Add(new LiteralControl(CellContent.Trim()));
            return tc;
        }


        private void Page_Load(object sender, EventArgs e)
        {
           // On page load, do the following..
            ConnectToDB();

            Auth_Id = String.Format("{0}", Session["Auth_Id"]);

            if (Auth_Id == "" || Auth_Id == DBNull.Value.ToString())
            {
                closeWindow();
            }
            smileyImg = "/images/smiley-big.gif";
            blankImg = "/images/blank.gif";
            imgPath = "/images/students/";
            imgDelete = "/images/record_delete.gif";

            ProcessFormData();

            OutputToTable();
        }
    }
}