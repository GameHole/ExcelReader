using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UnityEngine;
public class ConvertMutiplyLines : IDealExcel
{
    public static string projectFloader = "";
    public string floader { get; set; } =$"{projectFloader}Config";

    public string fileName { get; set; }
    public string divededStr = "/";
    int startCol;
    int colCount;
    int startRow;
    public ConvertMutiplyLines(string fileName, int startCol, int colCount, bool ignoreHead = true)
    {
        startRow = ignoreHead ? 1 : 0;
        this.startCol = startCol;
        this.colCount = colCount;
        this.fileName = $"{fileName}.txt";
    }

    public string Run(DataTable reader)
    {
        StringBuilder builder = new StringBuilder();
        int count = startCol + colCount;
        for (int i = startRow; i < reader.Rows.Count; i++)
        {
            var item = reader.Rows[i].ItemArray;
            for (int j = startCol; j < count; j++)
            {
                //Debug.Log($"{j},{colCount}");
                builder.Append(item[j].ToString());
                if (j < count - 1)
                    builder.Append(divededStr);
            }
            if (i < reader.Rows.Count - 1)
                builder.Append("\n");
        }
        return builder.ToString();
    }
}

