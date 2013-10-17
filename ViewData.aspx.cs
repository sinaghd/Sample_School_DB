using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewDataPage
{
    public partial class ViewDataClass : Page
    {        
        
        private OdbcConnection TempConn;
        private string isDisabled = String.Empty;

        private void ConnectToDB()
        {
            // Connect to database
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
            // Execute a SQL command    
            OdbcCommand TempCommand_2 = null;
            TempCommand_2 = new OdbcCommand();
            TempCommand_2.CommandText = TempDbExecute_sql;
            TempCommand_2.Connection = TempConn;
            TempCommand_2.ExecuteNonQuery();
        }


        private string getLevel(int x)
        {
            // Match level description to level number    
            switch (x)
            {
                case 1:
                    return "1.Beginner";
                case 2:
                    return "2.High Beginner";
                case 3:
                    return "3.Low Intermediate";
                case 4:
                    return "4.Intermediate";
                case 5:
                    return "5.High Intermediate";
                case 6:
                    return "6.Advanced";
                case 7:
                    return "7.High Advanced";
                default:
                    return "";
            }
        }


        private void SelectNames()
        {
            // Select last names from database in order to create shortcut "first letter" links
            string strSql = String.Empty;
            DataSet TempRs;

            strSql =
                "SELECT DISTINCT LEFT(LastName,1) AS LName FROM iic_students_basic  WHERE Status IN (1, 2, 6) ORDER BY LastName ASC";

            TempRs = TempRsFilled(strSql);

            foreach (DataRow iteration_row_2 in TempRs.Tables[0].Rows)
            {                
                //Add a couple of leading spaces
                var SpaceLabel = new Label();
                SpaceLabel.Text = "&nbsp;&nbsp;";                
                LastnameLinksPlaceHolder.Controls.Add(SpaceLabel);

                //Add link
                var HyperlinkItemContent = new HyperLink();
                HyperlinkItemContent.NavigateUrl = "javascript:document.frmIdx.ilike.value='" +
                                                   Convert.ToString(iteration_row_2["LName"]).ToUpper() +
                                                   "'; document.frmIdx.submit();";
                HyperlinkItemContent.Text = Convert.ToString(iteration_row_2["LName"]).ToUpper();
                LastnameLinksPlaceHolder.Controls.Add(HyperlinkItemContent);
            }
        }


        private void FillTable()
        {
            // Fill HTML table with students' data
            string CurrentLevel = String.Empty;
            string Email = String.Empty;
            string FirstName = String.Empty;
            string LastName = String.Empty;
            string Nickname = String.Empty;
            DateTime ProgramStartDate = DateTime.FromOADate(0);
            DateTime TuitionPaymentDate = DateTime.FromOADate(0);
            string Status = String.Empty;
            string StudentID = String.Empty;
            string StudentImage = String.Empty;
            string UrgentNote = String.Empty;
            string bgColor = String.Empty;
            string iLevel = String.Empty;
            string iLike = String.Empty;
            string iOrderBy = String.Empty;
            string iTransferout = String.Empty;
            string iUrgent = String.Empty;
            string isTransferout = String.Empty;
            string isUrgent = String.Empty;
            string isVacation = String.Empty;
            string bigSmileyImg = "/images/smiley-big.gif";
            string smallSmileyImg = "/images/smiley-small.gif"; 
            string imgPath = "/images/students/";
            decimal iNo = 1;
            string vacSql = String.Empty;
            DataSet TempRs;
            DataSet TempRsVac;            
            
            iLike = String.Format("{0}", Request.Form["ilike"]);
            iLevel = String.Format("{0}", Request.Form["level"]);
            iUrgent = String.Format("{0}", Request.Form["urgent"]);
            iTransferout = String.Format("{0}", Request.Form["transferout"]);
            iOrderBy = String.Format("{0}", Request.Form["orderby"]);

            TempRs = ProcessRequestFormData(iLike, iLevel, iUrgent, iTransferout, iOrderBy);
                        
            // Loop through students, extracting important information for table
            foreach (DataRow iteration_row_3 in TempRs.Tables[0].Rows)
            {
                StudentID = Convert.ToString(iteration_row_3["StudentID"]);
                LastName = Convert.ToString(iteration_row_3["LastName"]);
                FirstName = Convert.ToString(iteration_row_3["FirstName"]);

                Nickname = "<i>N/A</i>";                
                if (DBNull.Value.Equals(iteration_row_3["Nickname"]) ||
                    Convert.ToString(iteration_row_3["Nickname"]) != "")
                {
                    Nickname = Convert.ToString(iteration_row_3["Nickname"]);
                } 
                
                if (Convert.ToString(iteration_row_3["StudentImage"]) != "" ||
                    DBNull.Value.Equals(iteration_row_3["StudentImage"]))
                {
                    StudentImage = imgPath + Convert.ToString(iteration_row_3["StudentImage"]);
                    smallSmileyImg = StudentImage;
                }
                else
                {
                    StudentImage = bigSmileyImg;
                }

                Email = "<i>N/A</i>";
                
                if (DBNull.Value.Equals(iteration_row_3["Email"]) || Convert.ToString(iteration_row_3["Email"]) != "")
                {
                    Email = Convert.ToString(iteration_row_3["Email"]);
                }

                if (!(DBNull.Value.Equals(iteration_row_3["ProgramStartDate"])))
                {
                    ProgramStartDate = Convert.ToDateTime(iteration_row_3["ProgramStartDate"]);
                }

                if (!(DBNull.Value.Equals(iteration_row_3["TuitionPaymentDate"])))
                {
                    TuitionPaymentDate = Convert.ToDateTime(iteration_row_3["TuitionPaymentDate"]);
                }

                CurrentLevel = getLevel(Convert.ToInt32(iteration_row_3["CurrentLevel"]));
                Status = Convert.ToInt16(iteration_row_3["Status"]).ToString();
                isUrgent = Convert.ToInt16(iteration_row_3["isUrgent"]).ToString();
                isTransferout = Convert.ToInt16(iteration_row_3["isTransferout"]).ToString();

                // Extract information related to student's vacation history    
                vacSql = "SELECT * FROM iic_vacation a, iic_students_basic b ";
                vacSql = vacSql + "WHERE a.studentid = '" + StudentID + "' ";
                vacSql = vacSql + "AND b.studentid = '" + StudentID + "' ";
                vacSql = vacSql + "AND a.start_date <= CURDATE() ";
                vacSql = vacSql + "AND CURDATE() <= a.end_date ";
                vacSql = vacSql + "LIMIT 0, 1";

                TempRsVac = TempRsFilled(vacSql);

                isVacation = "";
                foreach (DataRow iteration_row_4 in TempRsVac.Tables[0].Rows)
                {
                    isVacation = "1"; // during vacation period
                }

                if (isUrgent == "1")
                {
                    if (Status == "0")
                    {
                        bgColor = "#CCCCCC";
                        UrgentNote = "Deleted Record";
                        isDisabled = "disabled";
                    }
                    else
                    {
                        bgColor = "#F75D59";
                        UrgentNote = "<font class='headtext' style='color:red'>" +
                                     Convert.ToString(iteration_row_3["UrgentNote"]) + "</font>";
                    }
                }
                else if (isVacation == "1")
                {
                    bgColor = "#9999FF";
                    UrgentNote = "";
                }
                else if (Status == "0")
                {
                    bgColor = "#CCCCCC";
                    UrgentNote = "Deleted Record";
                    isDisabled = "disabled";
                }
                else if (isTransferout == "1")
                {
                    bgColor = "#FFCC99";
                    UrgentNote = "<font class='headtext' style='color:red'>Transfering Out</font>";
                }
                else if (Status == "2")
                {
                    bgColor = "#B5EAAA";
                    UrgentNote = "Permanent Resident";
                }
                else if (Status == "3")
                {
                    bgColor = "#F9966B";
                    UrgentNote = "Inactive - Transfer In";
                }
                else if (Status == "4")
                {
                    bgColor = "#FAAFBE";
                    UrgentNote = "Inactive - Abroad";
                }
                else if (Status == "5")
                {
                    bgColor = "#FFE87C";
                    UrgentNote = "Inactive - Pending Change of Status";
                }
                else if (Status == "6")
                {
                    bgColor = "#34B91A";
                    UrgentNote = "Part-Time";
                }
                else
                {
                    if (bgColor == "#F75D59" || bgColor == "#B5EAAA" || bgColor == "#F9966B" || bgColor == "#FAAFBE" ||
                        bgColor == "#FFE87C" || bgColor == "#CFECEC")
                    {
                        bgColor = "#AFC7C7";
                    }
                    else
                    {
                        bgColor = "#CFECEC";
                    }

                    UrgentNote = "";
                }
                
                // Generate rows and cells.           
                string BlankCellStr =
                    "<img src='/images/blank.gif' width='1' height='1' style='background-color:white'>";
                string StudentImageStr =
                    "<a class='thumbnail' href='#thumb'><img src='/images/smiley-big.gif' style='width:22px; height:22px' border='0'><span class='textform' style='width:200px; height:150px'><img src='" +
                    StudentImage.Trim() + "' style='width:200px; height:150px'><br>" + UrgentNote + "</span></a>";

                //Add filler row          
                var tr = new TableRow();
                var c = new TableCell();
                tr.Height = 1;
                c.ColumnSpan = 17;
                c.Controls.Add(new LiteralControl(BlankCellStr));
                tr.Cells.Add(c);
                TableToFill.Rows.Add(tr);

                //Add content row
                var r = new TableRow();
                //Set attributes of row 
                r.Attributes["onclick"] = "selectRow(this, '" + StudentID + "', '" + bgColor + "'); return false;";
                r.Attributes["ondblclick"] = "opendialogWin('view', 'ViewDetailData.aspx'); return false;";
                r.Attributes["onmouseover"] = "Set(this,'hand'); return false;";
                //Set content for each cell in row              
                r.Cells.Add(CellWithContent(iNo.ToString(), 29, 22, "headtext"));
                r.Cells.Add(CellWithContent(BlankCellStr, 1, 22, ""));
                r.Cells.Add(CellWithContent(" " + LastName, 145, 22, "textform"));
                r.Cells.Add(CellWithContent(BlankCellStr, 1, 22, ""));
                r.Cells.Add(CellWithContent(" " + FirstName, 145, 22, "textform"));
                r.Cells.Add(CellWithContent(BlankCellStr, 1, 22, ""));
                r.Cells.Add(CellWithContent(StudentImageStr, 22, 22, "textform"));
                r.Cells.Add(CellWithContent(BlankCellStr, 1, 22, ""));
                r.Cells.Add(CellWithContent(" " + Nickname, 78, 22, "textform"));
                r.Cells.Add(CellWithContent(BlankCellStr, 1, 22, ""));
                r.Cells.Add(CellWithContent(" " + CurrentLevel, 120, 22, "textform"));
                r.Cells.Add(CellWithContent(BlankCellStr, 1, 22, ""));
                r.Cells.Add(CellWithContent(" " + Email, 250, 22, "textform"));
                r.Cells.Add(CellWithContent(BlankCellStr, 1, 22, ""));
                r.Cells.Add(CellWithContent(" " + ProgramStartDate.ToString("M/d/yyyy"), 90, 22, "textform"));
                r.Cells.Add(CellWithContent(BlankCellStr, 1, 22, ""));
                r.Cells.Add(CellWithContent(" " + TuitionPaymentDateStr(TuitionPaymentDate), 90, 22, "textform"));
                //Add row to table
                TableToFill.Rows.Add(r);

                //Iterate
                iNo++;
            }
        }


        private string TuitionPaymentDateStr(DateTime TuitionPaymentDateTime)
        {
            // Determine if student is late on payment, and if so by how many days
            string isLate = String.Empty;

            if (((TuitionPaymentDateTime - DateTime.Today).Days <= 0) && ((TuitionPaymentDateTime - DateTime.Today).Days > -8))
            {
                if ((int) TuitionPaymentDateTime.DayOfWeek == 1)
                {
                    isLate = " (" + ((TuitionPaymentDateTime - DateTime.Today).Days + 5) + ")";
                }
                else
                {
                    isLate = " (" + ((TuitionPaymentDateTime - DateTime.Today).Days + 7) + ")";
                }
            }
            else if ((TuitionPaymentDateTime - DateTime.Today).Days <= -8)
            {
                isLate = "<font color='red'> (L)</font>";
            }

            return TuitionPaymentDateTime.ToString("M/d/yyyy").Trim() + isLate;
        }


        private TableCell CellWithContent(string CellContent, short CellWidth, short CellHeight, string CellClass)
        // Generate a table cell with specified content
        {
            var tc = new TableCell();
            tc.Width = CellWidth;
            tc.Height = CellHeight;
            if (CellClass != "")
            {
                tc.CssClass = CellClass;
            }
            tc.Controls.Add(new LiteralControl(CellContent.Trim()));
            return tc;
        }


        private void UpdateButtons()
        {
            // Add client-side functionality to buttons    
            btnAdd.Attributes.Add("OnClientClick", "opendialogWin('add', 'EnterData.aspx'); return false;");
            btnViewDetial.Attributes.Add("OnClick", "return opendialogWin('view', 'ViewDetailData.aspx');");
            btnEdit.Attributes.Add("OnClientClick", "opendialogWin('edit', 'EditData.aspx'); return false;");
            btnDelete.Attributes.Add("OnClientClick", "deleteRecord('ViewData.aspx'); return false;");
            if (isDisabled == "disabled")
            {
                btnDelete.Attributes.Add("IsEnabled", "false");
            }
        }


        private DataSet ProcessRequestFormData(string iLike, string iLevel, string iUrgent, string iTransferout,
            string iOrderBy)
        {
            // Fill dataset with specific student information 
            string strSql = "SELECT * FROM iic_students_basic";

            if (iLike != "")
            {
                strSql = strSql + " WHERE UCase(LastName) LIKE '" + iLike + "%' AND Status IN (1,2,6)";
            }
            else if (iLevel != "")
            {
                strSql = strSql + " WHERE CurrentLevel = '" + iLevel + "' AND Status IN (1,2,6)";
            }
            else if (iUrgent != "")
            {
                strSql = strSql + " WHERE isUrgent = '" + iUrgent + "' AND Status IN (1,2,6)";
            }
            else if (iTransferout != "")
            {
                strSql = strSql + " WHERE isTransferout = '" + iTransferout + "' AND Status IN (1,2,6)";
            }            
            else
            {
                strSql = strSql + " WHERE Status IN (1,2,6)";
            }

            if (iOrderBy != "")
            {
                strSql = strSql + " ORDER BY " + iOrderBy + ", LastName ASC, FirstName ASC";
            }           
            else
            {
                strSql = strSql + " ORDER BY LastName ASC, FirstName ASC";
            }            

            ProcessRequestFormData = TempRsFilled(strSql);
        }


        private void Page_Load(object sender, EventArgs e)
        {            
            // On page load, do the following...
            string Auth_Id = String.Empty;  
            string isDelete = String.Empty;
            string stdid = String.Empty;
            string strSql = String.Empty;

            ConnectToDB();

            Session["TimeOut"] = 30;

            Auth_Id = String.Format("{0}", Session["Auth_Id"]);

            // If user not authorized, return to home page
            if (Auth_Id == "" || Auth_Id == DBNull.Value.ToString())
            {
                Response.Redirect("default.aspx");
            }

            // If user does not have adequate authorization, disable certain fields
            if (Convert.ToInt16(Double.Parse(Auth_Id)) != 1)
            {
                isDisabled = "disabled";
            }

            if (String.Format("{0}", Request.ServerVariables["REQUEST_METHOD"]) == "POST")
            {
                isDelete = String.Format("{0}", Request.Form["isDelete"]);
                stdid = String.Format("{0}", Request.Form["stdid"]);                

                if (isDelete == "yes" && stdid != "")
                {
                    // set student's status = 0 (0 = nothing, i.e. student is "deleted" from user's view, but still resides in database)
                    strSql = "UPDATE iic_students_basic SET Status=0 WHERE StudentID=" + stdid;

                    TempDbExecute(strSql);

                    isDelete = "";
                    stdid = "";
                }
            }

            SelectNames();

            FillTable();

            UpdateButtons();
        }
    } 
} 