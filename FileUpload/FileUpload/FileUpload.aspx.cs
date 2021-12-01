using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUpload
{
    public partial class FileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadFile();
        }
        void UploadFile()
        {
            try
            {
                if (fuFileUpload.HasFile)
                {
                    //Check Extension
                    string fileExtension = System.IO.Path.GetExtension(fuFileUpload.FileName);

                    if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".xls" && fileExtension.ToLower() != ".xlsx" && fileExtension.ToLower() != ".pptx")
                    {
                        lblMessage.Text = "Please select a valid file to upload.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        //check file size

                        //make a directory
                        string folderPath = Server.MapPath("~/UploadedFiles/");
                        //check if directory exists
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        //save file to folder
                        fuFileUpload.SaveAs(folderPath + Path.GetFileName(fuFileUpload.FileName));

                        //display message after upload
                        lblMessage.Text = "File " + Path.GetFileName(fuFileUpload.FileName) + "uploaded Successfully...";
                        lblMessage.ForeColor = System.Drawing.Color.Green;

                    }
                }
                else
                {
                    lblMessage.Text = "Please select a File";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sample.aspx");
        }
    }
}