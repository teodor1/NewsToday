using NEWS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NEWS
{
    public class NewsDAL : DALBase
    {
        public NewsBSL getNews(string id)
        {
            NewsBSL news = new NewsBSL();

            string sqlGet = @"select id, title, texts, create_date from news where id = " + id;
            DataTable dtNews = new DataTable();
            dtNews = GetDataTable(sqlGet);

            if (dtNews.Rows.Count > 0)
            {
                DataRow r = dtNews.Rows[0];
                news.Id = Convert.ToInt32(r["id"]);
                news.Title = r["title"].ToString();
                news.Texts = r["texts"].ToString();
                news.CreateDate = r["create_date"].ToString();
            }
            return news;
        }

        public List<NewsBSL> getAllNews()
        {
            const string sql = @"select top 3 id, title, texts, create_date from news order by create_date asc";
            DataTable Dt = new DataTable();
            Dt = GetDataTable(sql);
            List<NewsBSL> newsList = new List<NewsBSL>(Dt.Rows.Count);
            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow r in Dt.Rows)
                {
                    NewsBSL news = new NewsBSL();
                    news.Id = Convert.ToInt32(r["id"]);
                    news.Title = r["title"].ToString();
                    news.Texts = r["texts"].ToString();
                    news.CreateDate = r["create_date"].ToString();
                    newsList.Add(news);
                }
            }
            return newsList;
        }

        public void saveNews(NewsBSL news)
        {
            if (news.Status == 0)
            {
                string sqlInsert = @"insert into news(title, texts, create_date)
values('" + news.Title + "', '" + news.Texts + "', '" + news.CreateDate + "')";

                ExecuteScalar(sqlInsert);
                throw new Exception("Успешно добавена новина.");
            }
            else if (news.Status == 1)
            {
                string sqlUpdate = @"update news set title = '" + news.Title + "', texts = '" + news.Texts + "' where id = " + news.Id;

                ExecuteScalar(sqlUpdate);
                throw new Exception("Успешно редактирана новина.");
            }
        }

        public void deleteNews(string id)
        {
            string sqlDelete = @"delete from news where id = " + id;

            ExecuteScalar(sqlDelete);
            throw new Exception("Успешно изтрита новина.");
        }

        public NewsDAL()
        {
        }
    }
}