using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Protocol
{
  public   class PutOutExcel
    {

     public static bool isExcelInstalled()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            return type != null;
        }
        public void GenerateExcelCurrent(System.Windows.Forms.DataGridView dataGridView1)
        {
            #region 导出EXCEL表格类 刘新阳2014年12月27日13:51:50  
            int columnCount = 0;
            //导出到execl    
            try
            {
                //没有数据的话就不往下执行    
                if (dataGridView1.Rows.Count == 0)
                {
                    throw new Exception("当前页面没有数据可以导出！");


                }
                //实例化一个Excel.Application对象    
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写    
                excel.Visible = false;
                //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错    
                excel.Application.Workbooks.Add(true);

                //生成Excel中列头名称，下面的不一定是大家都用得到的，我只是判断有哪些列是显示了的，然后只搬家这些列的数据。如果你是全部搬家，那就直接一个for循环就可以了------------------------------  
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Visible)
                    {

                        columnCount = columnCount + 1;
                    }
                }
                string[] headers = new string[columnCount];
                int index = 0;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Visible)
                    {
                        headers[index] = dataGridView1.Columns[i].HeaderText;
                        index = index + 1;
                    }
                }
                for (int i = 0; i < columnCount; i++)
                {
                    excel.Cells[1, i + 1] = headers[i];
                    if (dataGridView1.Columns[i].ValueType == typeof(DateTime))
                    {
                        Microsoft.Office.Interop.Excel.Range headRange = excel.Cells[1, i - 1] as Microsoft.Office.Interop.Excel.Range;// as Range;//获取表头单元格  
                        headRange.ColumnWidth = 22;//设置列宽  
                    }
                }
                //---------------------------------------------------**********************************----------------------------------------  
                //把DataGridView当前页的数据保存在Excel中    
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    int columnIndex = 0;
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Columns[j].Visible)
                        {
                            columnIndex = columnIndex + 1;
                            if (dataGridView1[j, i].ValueType == typeof(string))
                            {
                                excel.Cells[i + 2, columnIndex] = "'" + dataGridView1[j, i].Value.ToString();
                            }
                            else
                            {
                                excel.Cells[i + 2, columnIndex] = dataGridView1[j, i].Value.ToString();
                            }
                        }
                    }
                }
                //设置禁止弹出保存和覆盖的询问提示框    
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;
                //保存工作簿    
                //excel.Application.Workbooks.Add(true).Save();  
                //保存excel文件    
                excel.Save();
                //确保Excel进程关闭    
                excel.Quit();
                excel = null;
                throw new Exception("当前页面数据已经成功导出到您指定的目录！");

            }
            catch (Exception ex)
            {
                throw new Exception("操作错误，请联系管理员", ex);
            }
            #endregion

        }
    }
}
