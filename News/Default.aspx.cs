using NEWS;
using NEWS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DALBase db = new DALBase();
        NewsDAL news = new NewsDAL();
        if (!IsPostBack)
        {
            Repeater1.DataSource = news.getAllNews();
            Repeater1.DataBind();
            if (User.Identity.Name != "admin")
            {
                btnNew.Visible = false;
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (User.Identity.Name != "admin")
        {
            e.Item.FindControl("btnEdit").Visible = false;
        }
    }
}