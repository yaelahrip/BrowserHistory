using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.BrowserHistory
{
    public partial class BrowserHistory
    {
        public static List<URL> GetFirefoxHistory()
        {
            List<URL> URLs = new List<URL>();

            string firefoxDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            firefoxDir += @"\Mozilla\Firefox\Profiles";

            if (Directory.Exists(firefoxDir))
            {
                foreach (var dir in Directory.GetDirectories(firefoxDir))
                {
                    string dbPath = dir + @"\places.sqlite";

                    if (File.Exists(dbPath))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;New=False;Compress=True;"))
                            {
                                conn.Open();
                                string sql = "select * from moz_places";

                                using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn))
                                {
                                    da.Fill(dt);

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        long? visit_Count = null;
                                        if (!string.IsNullOrEmpty(row["visit_count"].ToString()))
                                        {
                                            visit_Count = long.Parse(row["visit_count"].ToString());
                                        }

                                        long? favicon_Id = null;
                                        if (!string.IsNullOrEmpty(row["favicon_id"].ToString()))
                                        {
                                            favicon_Id = long.Parse(row["favicon_id"].ToString());
                                        }

                                        long? last_Visit_Date = null;
                                        if (!string.IsNullOrEmpty(row["last_visit_date"].ToString()))
                                        {
                                            last_Visit_Date = long.Parse(row["last_visit_date"].ToString());
                                        }

                                        URLs.Add(new URL
                                        {
                                            browser = "FireFox",
                                            id = long.Parse(row["id"].ToString()),
                                            url = row["url"].ToString().Replace('\'', ' '),
                                            title = row["title"].ToString().Replace('\'', ' '),
                                            rev_host = row["rev_host"].ToString(),
                                            visit_count = visit_Count,
                                            hidden = long.Parse(row["hidden"].ToString()),
                                            typed = long.Parse(row["typed"].ToString()),
                                            favicon_id = favicon_Id,
                                            frecency = long.Parse(row["frecency"].ToString()),
                                            last_visit_date = last_Visit_Date,
                                            guid = row["guid"].ToString(),
                                            foreign_count = long.Parse(row["foreign_count"].ToString()),
                                        });
                                    }
                                }
                                conn.Close();
                            }
                        }
                    }
                }
            }

            return URLs;
        }
    }
}
