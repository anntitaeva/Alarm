using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Arduino_Alarm.SetAlarm
{
    class GetSchedule
    {
        public string Path { get; set; }
        public GetSchedule()
        {
            Path = "Schedule.xls";
        }

        public GetSchedule(string path)
        {
            Path = path;
        }

        DataTable GetData(string path)
        {
            DataTable dt;
            string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path
                  + ";Extended Properties=\"Excel 8.0;HDR=Yes\"";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                List<string> sheets = GetSheetNames(connection);
                string sheet_name = sheets[0];
                int numberOfRows = NumberOfRows(connection, sheet_name);

                OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from [" + sheet_name + "$B1:L" + numberOfRows + "]", connection);

                dt = new DataTable();

                adapter.Fill(dt);

            }
            return dt;
        }

        List<string> GetSheetNames(OleDbConnection connection)
        {
            List<string> sheets = new List<string>();
            DataTable t = connection.GetSchema("Tables");
            foreach (DataRow row in t.Rows)
            {
                string sheetName = (string)row["TABLE_NAME"];
                if (sheetName.EndsWith("$"))
                {
                    sheetName = sheetName.Substring(0, sheetName.Length - 1);
                }
                sheets.Add(sheetName);
            }

            return sheets;
        }
        int NumberOfRows(OleDbConnection connection, string sheet_name)
        {
            int number = 0;
            DataTable t = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT count(*) FROM [" + sheet_name + "$]", connection);
            adapter.Fill(t);
            object[] array = t.Rows[0].ItemArray;
            number = (int)array[0] + 1;
            return number;
        }
    }
}
