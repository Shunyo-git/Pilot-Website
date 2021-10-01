using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Text;

public partial class Manager_ExecuteSqlInFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool ExecuteSqlInFile(string pathToScriptFile)
    {
        SqlConnection connection;

        try
        {
            StreamReader _reader = null;

            string sql = "";

            if (false == System.IO.File.Exists(pathToScriptFile))
            {
                throw new Exception("File " + pathToScriptFile + " does not exists");
            }
            using (Stream stream = System.IO.File.OpenRead(pathToScriptFile))
            {
                _reader = new StreamReader(stream);

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

                SqlCommand command = new SqlCommand();

                connection.Open();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                while (null != (sql = ReadNextStatementFromStream(_reader)))
                {
                    command.CommandText = sql;

                    command.ExecuteNonQuery();
                }

                _reader.Close();
                connection.Close();
            }


        }
        catch (Exception ex)
        {
            Response.Write("Error in file:" + pathToScriptFile + "<br/>" + "Message:" + ex.Message);
            return false;
        }
       

     
        return true;
    }

    private static string ReadNextStatementFromStream(StreamReader _reader)
    {
        try
        {
            StringBuilder sb = new StringBuilder();

            string lineOfText;

            while (true)
            {
                lineOfText = _reader.ReadLine();
                if (lineOfText == null)
                {

                    if (sb.Length > 0)
                    {
                        return sb.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }

                if (lineOfText.TrimEnd().ToUpper() == "GO")
                {
                    break;
                }

                sb.Append(lineOfText + Environment.NewLine);
            }

            return sb.ToString();
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    protected void btnExecute_Click(object sender, EventArgs e)
    {
        if (File.Exists(Server.MapPath(txtFileName.Text)))
        {
            if (ExecuteSqlInFile(Server.MapPath(txtFileName.Text)))
            {
                Response.Write("Execute Success!!"+ DateTime.Now.ToString());
            }
            else
            {
                Response.Write("Execute Error!!" + DateTime.Now.ToString());
            }
        }
        else {
            Response.Write("File Not Found!!" + DateTime.Now.ToString());
        }

    }
}
