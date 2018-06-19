using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Hospital
{
    /// <summary>
    /// 导出数据类
    /// </summary>
  public  class NPOI
    {
        /// <summary>
        /// 导出病人详细信息
        /// </summary>
        /// <param name="dataTable">数据源</param>
        public static void PatientBodyInfoToExcel(DataTable dataTable,string a,string path)
        {
            HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建工作簿  
            workbook2003.CreateSheet(a+"号病人详细信息表");  //新建1个Sheet工作表              
            HSSFSheet SheetOne = (HSSFSheet)workbook2003.GetSheet(a+"号病人详细信息表"); //获取名称为Sheet1的工作表  
            //对工作表先添加行，下标从0开始  
            for (int i = 0; i <500; i++)
            {
                SheetOne.CreateRow(i);   //创建10行  
            }
            SheetOne.SetColumnWidth(1, 20 * 256);
            SheetOne.SetColumnWidth(4, 13 * 256);
            SheetOne.SetColumnWidth(7, 20 * 256);
            SheetOne.SetColumnWidth(8, 13 * 256);
            //对每一行创建10个单元格  
            HSSFRow SheetRow = (HSSFRow)SheetOne.GetRow(0);  //获取Sheet1工作表的首行  
            HSSFCell[] SheetCell = new HSSFCell[10];
            for (int i = 0; i < 10; i++)
            {
                SheetCell[i] = (HSSFCell)SheetRow.CreateCell(i);  //为第一行创建10个单元格  
            }
            //创建之后就可以赋值了  
            SheetCell[0].SetCellValue("姓名");
      
            SheetCell[1].SetCellValue("时间");  
            SheetCell[2].SetCellValue("血氧(%)");  
            SheetCell[3].SetCellValue("脉率(bpm)"); 
            SheetCell[4].SetCellValue("吸氧时间(h)");
            SheetCell[5].SetCellValue("流量(L)"); 
            SheetCell[6].SetCellValue("模式"); 
            SheetCell[7].SetCellValue("警告");
            SheetCell[8].SetCellValue("吸氧总时间(h)");

            for (int i = 0; i <500; i++)
            {
                HSSFRow SheetRow1 = (HSSFRow)SheetOne.GetRow(i+1);
                HSSFCell[] SheetCell1 = new HSSFCell[10];
                for (int j = 0; j < 10; j++)
                {
                    SheetCell1[j] = (HSSFCell)SheetRow1.CreateCell(j);  //为第一行创建10个单元格  
                }
                SheetCell1[0].SetCellValue(dataTable.Rows[i][0].ToString());
                SheetCell1[1].SetCellValue(dataTable.Rows[i][1].ToString());
                SheetCell1[2].SetCellValue(dataTable.Rows[i][2].ToString());
                SheetCell1[3].SetCellValue(dataTable.Rows[i][3].ToString());
                SheetCell1[4].SetCellValue(dataTable.Rows[i][4].ToString());
                SheetCell1[5].SetCellValue(dataTable.Rows[i][5].ToString());
                SheetCell1[6].SetCellValue(dataTable.Rows[i][6].ToString());
                SheetCell1[7].SetCellValue(dataTable.Rows[i][7].ToString());
                SheetCell1[8].SetCellValue(dataTable.Rows[i][8].ToString());
            }

            for (int i = 0; i < 10; i++)
            {
              //  SheetCell[i].SetCellValue(i);    //循环赋值为整形  
            }
            FileStream file2003 = new FileStream(path, FileMode.Create);
            workbook2003.Write(file2003);
            file2003.Close();
            workbook2003.Close();
            MessageBox.Show("导出完成！", "系统提示！");
        }
        /// <summary>
        /// 当前病人
        /// </summary>
        /// <param name="dataTable"></param>
        public static void PatientBasicInfoToExcel(DataTable dataTable,string a,string path)
        {
            HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建工作簿  
            workbook2003.CreateSheet(a+"号病人基本信息表");  //新建1个Sheet工作表              
            HSSFSheet SheetOne = (HSSFSheet)workbook2003.GetSheet(a +"号病人基本信息表"); //获取名称为Sheet1的工作表  
            //对工作表先添加行，下标从0开始  
            for (int i = 0; i < 500; i++)
            {
                SheetOne.CreateRow(i);   //创建10行  
            }
        //    SheetOne.SetColumnWidth(1, 20 * 256);
            SheetOne.SetColumnWidth(6, 20 * 256);
         //   SheetOne.SetColumnWidth(7, 20 * 256);
            SheetOne.SetColumnWidth(7, 20 * 256);
            //对每一行创建10个单元格  
            HSSFRow SheetRow = (HSSFRow)SheetOne.GetRow(0);  //获取Sheet1工作表的首行  
            HSSFCell[] SheetCell = new HSSFCell[10];
            for (int i = 0; i < 10; i++)
            {
                SheetCell[i] = (HSSFCell)SheetRow.CreateCell(i);  //为第一行创建10个单元格  
            }
            //创建之后就可以赋值了  
            SheetCell[0].SetCellValue("姓名");

            SheetCell[1].SetCellValue("床号");
            SheetCell[2].SetCellValue("性别");
            SheetCell[3].SetCellValue("年龄");
            SheetCell[4].SetCellValue("住院号");
            SheetCell[5].SetCellValue("科室");
            SheetCell[6].SetCellValue("住院时间");
            SheetCell[7].SetCellValue("出院时间");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                HSSFRow SheetRow1 = (HSSFRow)SheetOne.GetRow(i + 1);
                HSSFCell[] SheetCell1 = new HSSFCell[10];
                for (int j = 0; j < 10; j++)
                {
                    SheetCell1[j] = (HSSFCell)SheetRow1.CreateCell(j);  //为第一行创建10个单元格  
                }
                SheetCell1[0].SetCellValue(dataTable.Rows[i][0].ToString());
                SheetCell1[1].SetCellValue(a);
                SheetCell1[2].SetCellValue(dataTable.Rows[i][2].ToString());
                SheetCell1[3].SetCellValue(dataTable.Rows[i][3].ToString());
                SheetCell1[4].SetCellValue(dataTable.Rows[i][4].ToString());
                SheetCell1[5].SetCellValue(dataTable.Rows[i][5].ToString());
                SheetCell1[6].SetCellValue(dataTable.Rows[i][6].ToString());
                SheetCell1[7].SetCellValue(dataTable.Rows[i][7].ToString());
            }

            for (int i = 0; i < 10; i++)
            {
                //  SheetCell[i].SetCellValue(i);    //循环赋值为整形  
            }
            FileStream file2003 = new FileStream(path, FileMode.Create);
            workbook2003.Write(file2003);
            file2003.Close();
            workbook2003.Close();
            MessageBox.Show("导出完成！", "系统提示！");
        }

        /// <summary>
        /// 所有病人
        /// </summary>
        /// <param name="dataTable"></param>
        public static void AllPatientBasicInfoToExcel(DataTable dataTable,string path)
        {
            HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建工作簿  
            workbook2003.CreateSheet("所有病人基本信息表");  //新建1个Sheet工作表              
            HSSFSheet SheetOne = (HSSFSheet)workbook2003.GetSheet("所有病人基本信息表"); //获取名称为Sheet1的工作表  
            //对工作表先添加行，下标从0开始  
            for (int i = 0; i < 500; i++)
            {
                SheetOne.CreateRow(i);   //创建10行  
            }
            //    SheetOne.SetColumnWidth(1, 20 * 256);
            SheetOne.SetColumnWidth(7, 20 * 256);
            //   SheetOne.SetColumnWidth(7, 20 * 256);
            SheetOne.SetColumnWidth(6, 20 * 256);
            //对每一行创建10个单元格  
            HSSFRow SheetRow = (HSSFRow)SheetOne.GetRow(0);  //获取Sheet1工作表的首行  
            HSSFCell[] SheetCell = new HSSFCell[10];
            for (int i = 0; i < 10; i++)
            {
                SheetCell[i] = (HSSFCell)SheetRow.CreateCell(i);  //为第一行创建10个单元格  
            }
            //创建之后就可以赋值了  
            SheetCell[0].SetCellValue("姓名");

            SheetCell[1].SetCellValue("床号");
            SheetCell[2].SetCellValue("性别");
            SheetCell[3].SetCellValue("年龄");
            SheetCell[4].SetCellValue("住院号");
            SheetCell[5].SetCellValue("科室");
            SheetCell[6].SetCellValue("住院时间");
            SheetCell[7].SetCellValue("出院时间");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                HSSFRow SheetRow1 = (HSSFRow)SheetOne.GetRow(i + 1);
                HSSFCell[] SheetCell1 = new HSSFCell[10];
                for (int j = 0; j < 10; j++)
                {
                    SheetCell1[j] = (HSSFCell)SheetRow1.CreateCell(j);  //为第一行创建10个单元格  
                }
                SheetCell1[0].SetCellValue(dataTable.Rows[i][0].ToString());
                SheetCell1[1].SetCellValue(dataTable.Rows[i][1].ToString());
                SheetCell1[2].SetCellValue(dataTable.Rows[i][2].ToString());
                SheetCell1[3].SetCellValue(dataTable.Rows[i][3].ToString());
                SheetCell1[4].SetCellValue(dataTable.Rows[i][4].ToString());
                SheetCell1[5].SetCellValue(dataTable.Rows[i][5].ToString());
                SheetCell1[6].SetCellValue(dataTable.Rows[i][6].ToString());
                SheetCell1[7].SetCellValue(dataTable.Rows[i][7].ToString());
            }

            for (int i = 0; i < 10; i++)
            {
                //  SheetCell[i].SetCellValue(i);    //循环赋值为整形  
            }
            FileStream file2003 = new FileStream(path, FileMode.Create);
            workbook2003.Write(file2003);
            file2003.Close();
            workbook2003.Close();
            MessageBox.Show("导出完成！", "系统提示！");
        }

        public static void HisPatientBasicInfoToExcel(DataTable dataTable,string path)
        {
            HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建工作簿  
            workbook2003.CreateSheet("所有历史病人基本信息表");  //新建1个Sheet工作表              
            HSSFSheet SheetOne = (HSSFSheet)workbook2003.GetSheet("所有历史病人基本信息表"); //获取名称为Sheet1的工作表  
            //对工作表先添加行，下标从0开始  
            for (int i = 0; i < 500; i++)
            {
                SheetOne.CreateRow(i);   //创建10行  
            }
            //    SheetOne.SetColumnWidth(1, 20 * 256);
            SheetOne.SetColumnWidth(4, 15 * 256);
            //   SheetOne.SetColumnWidth(7, 20 * 256);
            SheetOne.SetColumnWidth(5, 15 * 256);
            //对每一行创建10个单元格  
            HSSFRow SheetRow = (HSSFRow)SheetOne.GetRow(0);  //获取Sheet1工作表的首行  
            HSSFCell[] SheetCell = new HSSFCell[10];
            for (int i = 0; i < 10; i++)
            {
                SheetCell[i] = (HSSFCell)SheetRow.CreateCell(i);  //为第一行创建10个单元格  
            }
            //创建之后就可以赋值了  
            SheetCell[0].SetCellValue("姓名");

            SheetCell[1].SetCellValue("床号");
            SheetCell[2].SetCellValue("性别");
            SheetCell[3].SetCellValue("年龄");
            SheetCell[4].SetCellValue("住院号");
            SheetCell[5].SetCellValue("科室");
            SheetCell[6].SetCellValue("住院时间");
            SheetCell[7].SetCellValue("出院时间");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                HSSFRow SheetRow1 = (HSSFRow)SheetOne.GetRow(i + 1);
                HSSFCell[] SheetCell1 = new HSSFCell[10];
                for (int j = 0; j < 10; j++)
                {
                    SheetCell1[j] = (HSSFCell)SheetRow1.CreateCell(j);  //为第一行创建10个单元格  
                }
                SheetCell1[0].SetCellValue(dataTable.Rows[i][0].ToString());
                SheetCell1[1].SetCellValue(dataTable.Rows[i][1].ToString());
                SheetCell1[2].SetCellValue(dataTable.Rows[i][2].ToString());
                SheetCell1[3].SetCellValue(dataTable.Rows[i][3].ToString());
                SheetCell1[4].SetCellValue(dataTable.Rows[i][4].ToString());
                SheetCell1[5].SetCellValue(dataTable.Rows[i][5].ToString());
                SheetCell1[6].SetCellValue(dataTable.Rows[i][6].ToString());
                SheetCell1[7].SetCellValue(dataTable.Rows[i][7].ToString());
            }

            for (int i = 0; i < 10; i++)
            {
                //  SheetCell[i].SetCellValue(i);    //循环赋值为整形  
            }
            FileStream file2003 = new FileStream(path, FileMode.Create);
            workbook2003.Write(file2003);
            file2003.Close();
            workbook2003.Close();
            MessageBox.Show("导出完成！", "系统提示！");
        }

        public static void NowPatientInfoToExcel(DataTable sourceTable, string path,int count)
        {
            sourceTable.Columns[0].ColumnName = "时间";
            sourceTable.Columns[1].ColumnName = "血氧";
            sourceTable.Columns[2].ColumnName = "脉率";
            sourceTable.Columns[3].ColumnName = "流量";
            sourceTable.Columns[4].ColumnName = "模式";
            sourceTable.Columns[5].ColumnName = "报警";
            sourceTable.Columns[6].ColumnName = "吸氧时间";
            sourceTable.Columns[7].ColumnName = "吸氧总时间";
            //sourceTable.Columns[8].ColumnName = "吸氧时间";
            //sourceTable.Columns[9].ColumnName = "吸氧总时间";
            //   sourceTable.Rows[0][0] = "更改完成";
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            int dtRowsCount = sourceTable.Rows.Count;
            int SheetCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dtRowsCount) / 65536));
            int SheetNum = 1;
            int rowIndex = 1;
            int tempIndex = 1; //标示 
            ISheet sheet = workbook.CreateSheet("sheet1" + SheetNum);
            for (int i = 0; i < dtRowsCount; i+=count)
            {
                if (i == 0 || tempIndex == 1)
                {
                    IRow headerRow = sheet.CreateRow(0);
                    foreach (DataColumn column in sourceTable.Columns)
                        headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                }
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(tempIndex);
                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(sourceTable.Rows[i][column].ToString());
                }
                if (tempIndex == 65535)
                {
                    SheetNum++;
                    sheet = workbook.CreateSheet("sheet" + SheetNum);//
                    tempIndex = 0;
                }
                rowIndex++;
                tempIndex++;
                //AutoSizeColumns(sheet);
            }

            FileStream file2003 = new FileStream(path, FileMode.Create);
            workbook.Write(file2003);
            file2003.Close();
            workbook.Close();
            MessageBox.Show("导出完成！", "系统提示！");

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            sheet = null;
            // headerRow = null;
            workbook = null;
        }

        public static void MachinePatientInfoToExcel(DataTable dataTable,string path)
        {
            HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建工作簿  
            workbook2003.CreateSheet("监护仪信息表");  //新建1个Sheet工作表              
            HSSFSheet SheetOne = (HSSFSheet)workbook2003.GetSheet("监护仪信息表"); //获取名称为Sheet1的工作表  
            //对工作表先添加行，下标从0开始  
            for (int i = 0; i < 500; i++)
            {
                SheetOne.CreateRow(i);   //创建10行  
            }
            SheetOne.SetColumnWidth(4, 15 * 256);
            SheetOne.SetColumnWidth(1, 20 * 256);
            SheetOne.SetColumnWidth(7, 25 * 256);
            SheetOne.SetColumnWidth(8, 15 * 256);
            //对每一行创建10个单元格  
            HSSFRow SheetRow = (HSSFRow)SheetOne.GetRow(0);  //获取Sheet1工作表的首行  
            HSSFCell[] SheetCell = new HSSFCell[10];
            for (int i = 0; i < 10; i++)
            {
                SheetCell[i] = (HSSFCell)SheetRow.CreateCell(i);  //为第一行创建10个单元格  
            }
            //创建之后就可以赋值了  
            SheetCell[0].SetCellValue("时间");
            SheetCell[1].SetCellValue("模式");
            SheetCell[2].SetCellValue("血氧(%)");
            SheetCell[3].SetCellValue("脉率(bpm)");
            SheetCell[4].SetCellValue("流量(L)");
            SheetCell[5].SetCellValue("报警");
            SheetCell[6].SetCellValue("吸氧时间(h)");
            SheetCell[7].SetCellValue("吸氧总时间(h)");


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                HSSFRow SheetRow1 = (HSSFRow)SheetOne.GetRow(i + 1);
                HSSFCell[] SheetCell1 = new HSSFCell[10];
                for (int j = 0; j < 10; j++)
                {
                    SheetCell1[j] = (HSSFCell)SheetRow1.CreateCell(j);  //为第一行创建10个单元格  
                }
                SheetCell1[0].SetCellValue(dataTable.Rows[i][0].ToString());
                SheetCell1[1].SetCellValue(dataTable.Rows[i][1].ToString());
                SheetCell1[2].SetCellValue(dataTable.Rows[i][2].ToString());
                SheetCell1[3].SetCellValue(dataTable.Rows[i][3].ToString());
                SheetCell1[4].SetCellValue(dataTable.Rows[i][4].ToString());
                SheetCell1[5].SetCellValue(dataTable.Rows[i][5].ToString());
                SheetCell1[6].SetCellValue(dataTable.Rows[i][6].ToString());
                SheetCell1[7].SetCellValue(dataTable.Rows[i][7].ToString());
            }

            for (int i = 0; i < 10; i++)
            {
                //  SheetCell[i].SetCellValue(i);    //循环赋值为整形  
            }
            FileStream file2003 = new FileStream(path, FileMode.Create);
            workbook2003.Write(file2003);
            file2003.Close();
            workbook2003.Close();
            MessageBox.Show("导出完成！", "系统提示！");
        }


        public static MemoryStream ExportDataTableToExcel(DataTable sourceTable,string path,int count)
        {
            sourceTable.Columns[0].ColumnName = "姓名";
            sourceTable.Columns[1].ColumnName = "采集时间";
            sourceTable.Columns[2].ColumnName = "血氧";
            sourceTable.Columns[3].ColumnName = "脉率";
            sourceTable.Columns[4].ColumnName = "吸氧时间"; 
            sourceTable.Columns[5].ColumnName = "流量";
            sourceTable.Columns[6].ColumnName = "模式";
            sourceTable.Columns[7].ColumnName = "报警";
            sourceTable.Columns[8].ColumnName = "吸氧总时间";
            //   sourceTable.Rows[0][0] = "更改完成";
            HSSFWorkbook workbook = new HSSFWorkbook();



            MemoryStream ms = new MemoryStream();
            int dtRowsCount = sourceTable.Rows.Count;
            int SheetCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dtRowsCount) / 65536));
            int SheetNum = 1;
            int rowIndex = 1;
            int tempIndex = 1; //标示 
            ISheet sheet = workbook.CreateSheet("sheet1" + SheetNum);

            IRow rowTitle0 = sheet.CreateRow(0);
            ICell cell0 = rowTitle0.CreateCell(3);   //创建单元格  propertyinfos[i].Name
            cell0.SetCellValue("血氧饱和度动态监测报告");// 设置行标题
            SetCellStyle(workbook, cell0, 4);
            SetColumnWidth(sheet, 3, 12);




            for (int i = 0; i < dtRowsCount; i+= count)
            {
                if (i == 0 || tempIndex == 1)
                {
                    IRow headerRow = sheet.CreateRow(0);
                    foreach (DataColumn column in sourceTable.Columns)
                        headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                }
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(tempIndex);
                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(sourceTable.Rows[i][column].ToString());
                }
                if (tempIndex == 65535)
                {
                    SheetNum++;
                    sheet = workbook.CreateSheet("sheet" + SheetNum);//
                    tempIndex = 0;
                }
                rowIndex++;
                tempIndex++;
                //AutoSizeColumns(sheet);
            }

            FileStream file2003 = new FileStream(path, FileMode.Create);
            workbook.Write(file2003);
            file2003.Close();
            workbook.Close();
            MessageBox.Show("导出完成！", "系统提示！");

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            sheet = null;
            // headerRow = null;
            workbook = null;


            return ms;
        }

        /// <summary>
        /// 设置cell单元格边框的公共方法
        /// </summary>
        /// <param name="workBook">接口类型的工作簿，能适应不同版本</param>
        /// <param name="cell">cell单元格对象</param>
        private static void SetCellStyle(IWorkbook workBook, ICell cell, int a)
        {
            ICellStyle style = workBook.CreateCellStyle();
            //style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            //style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            //style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            //style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            //style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//水平对齐
            style.VerticalAlignment = VerticalAlignment.Center;//垂直对齐
            //设置字体
            IFont font = workBook.CreateFont();
            font.FontName = "微软雅黑";
            font.FontHeight = a * a;
            font.Color = IndexedColors.Black.Index;   //字体颜色         
            //font.Color =(short )FontColor .Red  ;
            style.SetFont(font);
            cell.CellStyle = style;
        }
        /// <summary>
        /// 设置cell单元格列宽的公共方法
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index">第几列</param>
        /// <param name="width">具体宽度值</param>
        private static void SetColumnWidth(ISheet sheet, int index, int width)
        {
            sheet.SetColumnWidth(index, width * 256);
        }

        public static void ExcelPrint(string path,DataTable dt, Dictionary<string, string> dic ,string savepath,int count)
        {
            int rows = 4;
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);//读入excel模板
                                                                                    //HSSF适用2007以前的版本,XSSF适用2007版本及其以上的。
            HSSFWorkbook UnionBook = new HSSFWorkbook(file);
            HSSFSheet unionSheet = null;
            unionSheet = (HSSFSheet)UnionBook.GetSheet("sheet1");

             IRow unionRow = unionSheet.GetRow(1);
             ICell unionCell = unionRow.GetCell(0);
          //   unionCell.SetCellValue("时间：2018.02.20 08:00 至 2018.02.21 08:00");//设值
            unionCell.SetCellValue("时间："+" "+dic["stime"]+" "+"至"+" "+dic["etime"]);//设值
            IRow row1 = unionSheet.GetRow(2);
            ICell cell1 = row1.GetCell(0);
            //  cell1.SetCellValue("西安高新医院   内科   姓名:   XXX      性别:  男    床号: 4  年龄:12岁  住院号: 123404");
            int last = 0;
            if (count== 4)
                last = 3;
            if (count == 2)
                last = 2;
            cell1.SetCellValue(dic["hospital"]+" "+ dic["depart"]+" "+"姓名："+dic["name"]+" "+"性别："+dic["gender"]+" "+"床号："+dic["bednum"]+" "+"年龄："+dic["age"]+" "+"住院号："+dic["patientnum"]);
            for (int i = 4; i < dt.Rows.Count; i+= count)
            {

                IRow row3 = unionSheet.CreateRow(i/count+last);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell3 = row3.CreateCell(j);
                    if ((dt.Rows[i - 4][j] == null))
                        return;
                    else
                    cell3.SetCellValue(dt.Rows[i-4][j].ToString());

                }
                rows++;
            }
            IRow row4 = unionSheet.CreateRow(rows);
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                ICell cell3 = row4.CreateCell(j);
                if ((dt.Rows[dt.Rows.Count - 1][j] == null))
                    return;
                else
                    cell3.SetCellValue(dt.Rows[dt.Rows.Count-1][j].ToString());

            }

            FileStream file2003 = new FileStream(savepath, FileMode.Create);
            UnionBook.Write(file2003);
            file2003.Close();
            UnionBook.Close();
            MessageBox.Show("导出成功！");

        }
    }
}
