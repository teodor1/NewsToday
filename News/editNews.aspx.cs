using NEWS;
using NEWS.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class editNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["id"];
            string v = Request.QueryString["v"];
            hfId.Value = id;
            loadData(id, v);
        }
    }

    protected void loadData(string id, string v)
    {
        NewsDAL news = new NewsDAL();
        NewsBSL n = news.getNews(id);
        if (id != "-1")
        {
            tbTitle.Text = n.Title;
            tbTexts.Text = n.Texts;
        }

        if (v == "1")
        {
            tbTitle.Enabled = false;
            tbTitle.CssClass = "userView Title";
            tbTexts.Enabled = false;
            tbTexts.CssClass = "userView";
            btnSave.Visible = false;
            btnDelete.Visible = false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        NewsBSL n = new NewsBSL();
        
        NewsDAL news = new NewsDAL();
        try
        {
            if (hfId.Value == "-1")
            {
                n.Status = 0;
                n.Title = tbTitle.Text;
                n.Texts = tbTexts.Text;
                n.CreateDate = Convert.ToDateTime(DateTime.Now).ToShortDateString().Remove((DateTime.Now.ToShortDateString().Length - 3));
                news.saveNews(n);
            }
            else
            {
                n.Status = 1;
                n.Title = tbTitle.Text;
                n.Texts = tbTexts.Text;
                news.saveNews(n);
            }
        }
        catch (Exception up)
        {
            lblMsg.Visible = true;
            lblMsg.Text = up.Message.ToString();

        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        NewsDAL news = new NewsDAL();
        try
        {
            news.deleteNews(hfId.Value);
            
        }
        catch (Exception up)
        {
            tbTitle.Text = "";
            tbTexts.Text = "";
            lblMsg.Visible = true;
            lblMsg.Text = up.Message.ToString();
        }
    }
}