using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasmart.Data
{
    internal static class SqlHelper
    {

        public static SqlConnection GetSqlConnection()
        {

                /*SqlConnection sqlConnection = new SqlConnection
                { ConnectionString = "" };
                return sqlConnection;*/
          
                return null;
        }


        public static DateTime GetDateFromReader(SqlDataReader sqlReader, int colNum)
        {
            DateTime date;
            try
            {
                date = sqlReader.IsDBNull(colNum)
                           ? new DateTime(1, 1, 1)//DateTime.Now
                           : DateTime.Parse(sqlReader.GetSqlDateTime(colNum).ToString());
            }
            catch (Exception)
            {
                //date = DateTime.Now;
                date = new DateTime(1, 1, 1);
            }
            return date;
        }

        public static DateTime? GetNullableDateFromReader(SqlDataReader sqlReader, int colNum)
        {
            DateTime? date;

            try
            {
                date = sqlReader.IsDBNull(colNum)
                           ? null
                           : (DateTime?)DateTime.Parse(sqlReader.GetSqlDateTime(colNum).ToString());
            }
            catch (Exception)
            {
                date = null;
            }
            return date;
        }


        public static int GetIntFromReader(SqlDataReader sqlReader, int colNum)
        {
            return sqlReader.IsDBNull(colNum) ? 0 : sqlReader.GetInt32(colNum);
        }

        public static int GetSmallintFromReader(SqlDataReader sqlReader, int colNum)
        {
            return sqlReader.IsDBNull(colNum) ? 0 : sqlReader.GetInt16(colNum);
        }

        public static int GetNullableIntFromReader(SqlDataReader sqlReader, int colNum)
        {
            return sqlReader.IsDBNull(colNum) ? -1 : sqlReader.GetInt32(colNum);
        }

        public static float GetFloatFromReader(SqlDataReader sqlReader, int colNum)
        {
            return sqlReader.IsDBNull(colNum) ? -1 : sqlReader.GetFloat(colNum);
        }

        public static float? GetNullableFloatFromReader(SqlDataReader sqlReader, int colNum)
        {
            return sqlReader.IsDBNull(colNum) ? null : (float?)sqlReader.GetFloat(colNum);
        }

        public static string GetStringFromReader(SqlDataReader sqlReader, int colNum)
        {
            return sqlReader.IsDBNull(colNum) ? string.Empty : sqlReader.GetString(colNum);
        }

        public static DateTime GetStringDateFromReader(SqlDataReader sqlReader, int colNum)
        {
            // Не используется
            DateTime returnDate = new DateTime(1, 1, 1);
            if (sqlReader.IsDBNull(colNum))
            {
                return new DateTime(1, 1, 1);
            }
            else
            {
                string tmp_cell = sqlReader.GetString(colNum);
                if (tmp_cell != "" && tmp_cell != " ")
                {
                    IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
                    if (!DateTime.TryParseExact(tmp_cell, "dd.MM.yy HH:mm:ss", culture, System.Globalization.DateTimeStyles.AssumeLocal, out returnDate))
                    {
                        //tmp_cell = tmp_cell.Substring(0, 8);
                        //returnDate = new DateTime(Convert.ToInt32(tmp_cell.Substring(6, 2)) + 2000, Convert.ToInt32(tmp_cell.Substring(3, 2)), Convert.ToInt32(tmp_cell.Substring(0, 2))) + TimeSpan.FromDays(1);
                    }
                }
                return returnDate;
            }
        }

        public static double GetDoubleFromReader(SqlDataReader sqlReader, int colNum)
        {
            return sqlReader.IsDBNull(colNum) ? 0 : sqlReader.GetDouble(colNum);
        }

        public static decimal GetDecimalFromReader(SqlDataReader sqlReader, int colNum)
        {
            return sqlReader.IsDBNull(colNum) ? 0 : sqlReader.GetDecimal(colNum);
        }

        public static bool GetBoolFromReader(SqlDataReader sqlReader, int colNum)
        {
            return sqlReader.IsDBNull(colNum) ? false : sqlReader.GetBoolean(colNum);
        }

        public static void AddReturnValue(SqlCommand sqlCommand, string paramName,
                                                      SqlDbType paramType)
        {
            sqlCommand.Parameters.Add(new SqlParameter(paramName, paramType)).Direction =
                ParameterDirection.ReturnValue;
        }
    }
}
