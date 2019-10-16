using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HuaDan
{
	public class DBHelper
	{
		static string strConn = ConfigurationManager.AppSettings["dbconn"];
		/// <summary>
		/// 执行SQL语句,并返回查询结果(DataTable)
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="conn">数据库连接(SqlConnection对象)</param>
		/// <returns>查询结果以DataTable形式返回</returns>
		public static DataTable ExeSqlForDataTable(string sql)
		{
			SqlConnection conn = new SqlConnection(strConn);
			DataSet ds = new DataSet();
			try
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand(sql, conn);
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(ds);
			}
			catch (Exception ex)
			{
				Log.WriteLog("ExeSqlForDataTable sql=" + sql + "/r/n错误信息:" + ex.ToString());
			}
			finally
			{
				conn.Close();
			}

			return ds.Tables[0];
		}

		public static bool ExecuteNonQuery(string sql)
		{
			if (string.IsNullOrEmpty(sql))
				return false;

			bool flag = true;
			using (SqlConnection conn = new SqlConnection(strConn))
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = sql;
				try
				{
					conn.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Log.WriteLog("ExecuteNonQuery sql=" + sql + "/r/n错误信息:" + ex.ToString());
					flag = false;
				}
				finally
				{
					conn.Close();
				}
				return flag;
			}
		}


		public static string DateTableToJson(DataTable tb)
		{
			if (tb == null || tb.Rows.Count == 0)
			{
				return "[]";
			}

			StringBuilder sbJson = new StringBuilder();
			sbJson.Append("[");
			Dictionary<int, string> htColumns = new Dictionary<int, string>();
			Dictionary<int, Type> htColumnTypes = new Dictionary<int, Type>();
			for (int i = 0; i < tb.Columns.Count; i++)
			{
				htColumns.Add(i, tb.Columns[i].ColumnName.Trim());
				htColumnTypes.Add(i, tb.Columns[i].DataType);
			}

			for (int j = 0; j < tb.Rows.Count; j++)
			{
				if (j != 0)
				{
					sbJson.Append(",");
				}
				sbJson.Append("{");
				for (int c = 0; c < tb.Columns.Count; c++)
				{
					Type dataType = htColumnTypes[c];
					if (tb.Rows[j][c] == null || tb.Rows[j][c] == DBNull.Value)
					{
						sbJson.Append("\"" + htColumns[c] + "\":null,");
					}
					else if (object.Equals(dataType, typeof(bool)))
					{
						sbJson.Append("\"" + htColumns[c] + "\":" + (((bool)tb.Rows[j][c]) ? 1 : 0) + ",");
					}
					else if (object.Equals(dataType, typeof(DateTime)))
					{
						sbJson.Append("\"" + htColumns[c] + "\":\"" + ((DateTime)tb.Rows[j][c]).ToString("yyyy-MM-ddTHH:mm:ss") + "\",");
					}
					else if (dataType.IsPrimitive || object.Equals(dataType, typeof(decimal)))
					{
						sbJson.Append("\"" + htColumns[c] + "\":" + tb.Rows[j][c].ToString() + ",");
					}
					else
					{
						sbJson.Append("\"" + htColumns[c] + "\":\"" + tb.Rows[j][c].ToString() + "\","); //.Replace(",", "，").Replace(":", "：").Replace("\r\n", "<br />") + "\",");
					}
				}
				//sbJson.Append("\"index\":" + j.ToString()); //序号
				sbJson.Remove(sbJson.Length - 1, 1);
				sbJson.Append("}");
			}
			sbJson.Append("]");
			return sbJson.ToString();
		}
	}
}
