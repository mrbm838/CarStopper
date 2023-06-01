using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OP010
{
    public class ExcelHelper
    {
        /// <summary>
        /// 参数配置表1
        /// </summary>

        /// <summary>
        /// 把DataTable的数据写入到指定的excel文件中
        /// </summary>
        /// <param name="TargetFileNamePath">目标文件excel的路径</param>
        /// <param name="sourceData">要写入的数据</param>
        /// <param name="sheetName">excel表中的sheet的名称，可以根据情况自己起</param>
        /// <param name="IsWriteColumnName">是否写入DataTable的列名称</param>
        /// <returns>返回写入的行数</returns>
        public static int DataTableToExcel(string TargetFileNamePath, DataTable sourceData, string sheetName, bool IsWriteColumnName)
        {
            //数据验证
            if (!File.Exists(TargetFileNamePath))
            {
                //excel文件的路径不存在
                throw new ArgumentException("excel文件的路径不存在或者excel文件没有创建好");
            }
            if (sourceData == null)
            {
                throw new ArgumentException("要写入的DataTable不能为空");
            }

            if (sheetName == null && sheetName.Length == 0)
            {
                throw new ArgumentException("excel中的sheet名称不能为空或者不能为空字符串");
            }
            //根据Excel文件的后缀名创建对应的workbook
            IWorkbook workbook = null;
            if (TargetFileNamePath.IndexOf(".xlsx") > 0)
            {  //2007版本的excel
                workbook = new XSSFWorkbook();
            }
            else if (TargetFileNamePath.IndexOf(".xls") > 0) //2003版本的excel
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                return -1;    //都不匹配或者传入的文件根本就不是excel文件，直接返回
            }

            //excel表的sheet名
            ISheet sheet = workbook.CreateSheet(sheetName);
            if (sheet == null) return -1;   //无法创建sheet，则直接返回
                                            //写入Excel的行数
            int WriteRowCount = 0;
            //指明需要写入列名，则写入DataTable的列名,第一行写入列名
            if (IsWriteColumnName)
            {
                //sheet表创建新的一行,即第一行
                IRow ColumnNameRow = sheet.CreateRow(0); //0下标代表第一行
                                                         //进行写入DataTable的列名
                for (int colunmNameIndex = 0; colunmNameIndex < sourceData.Columns.Count; colunmNameIndex++)
                {
                    ColumnNameRow.CreateCell(colunmNameIndex).SetCellValue(sourceData.Columns[colunmNameIndex].ColumnName);
                }
                WriteRowCount++;
            }


            //写入数据
            for (int row = 0; row < sourceData.Rows.Count; row++)
            {
                //sheet表创建新的一行
                IRow newRow = sheet.CreateRow(WriteRowCount);
                for (int column = 0; column < sourceData.Columns.Count; column++)
                {
                    newRow.CreateCell(column).SetCellValue(sourceData.Rows[row][column].ToString());
                }
                WriteRowCount++;  //写入下一行
            }
            //写入到excel中
            FileStream fs = new FileStream(TargetFileNamePath, FileMode.Open, FileAccess.Write);
            workbook.Write(fs);

            fs.Flush();
            fs.Close();

            workbook.Close();
            return WriteRowCount;
        }

        /// <summary>
        /// 从Excel中读入数据到DataTable中
        /// </summary>
        /// <param name="FilePath">Excel文件的路径</param>
        /// <param name="sheetName">excel文件中工作表名称</param>
        /// <param name="IsHasColumnName">文件是否有列名</param>
        /// <returns>从Excel读取到数据的DataTable结果集</returns>
        public static DataTable ExcelToDataTable(string FilePath, string sheetName, bool IsHasColumnName)
        {
            IWorkbook workbook = null;
            ISheet sheet = null;
            DataTable newDataTable = new DataTable();
            int startRow = 0;
            try
            {
                if (!File.Exists(FilePath))
                {
                    MessageBox.Show("Excel文件不存在,地址为:" + FilePath);
                    return null;
                }
                //打开文件，读取workbook；             
                using (FileStream fs = File.OpenRead(FilePath))   //打开xlsx文件
                {
                    //根据Excel文件的后缀名创建对应的workbook
                    if (FilePath.IndexOf(".xlsx") > 0)//2007版本的excel
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else if (FilePath.IndexOf(".xls") > 0) //2003版本的excel
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                    else
                    {
                        MessageBox.Show("传入的文件不是Excel文件,地址为:" + FilePath);
                        return null; //都不匹配或者传入的文件根本就不是excel文件，直接返回
                    }
                }
                if (sheetName == "")
                {
                    //没有指定sheet名称，直接取第一个
                    sheet = workbook.GetSheetAt(0);
                    //获取不到，直接返回
                    if (sheet == null) return null;
                }
                else
                {
                    //获取工作表sheet
                    sheet = workbook.GetSheet(sheetName);
                    //获取不到，直接返回
                    if (sheet == null) return null;
                }
                IRow FirstRow = sheet.GetRow(0);//取第一行数据
                int cellCount = FirstRow.LastCellNum; //第一行最后一个cell的编号 即总的列数
                for (int i = FirstRow.FirstCellNum; i < cellCount; ++i)//给newDataTable添加列
                {
                    if (IsHasColumnName)//第一行是否为表头
                    {
                        ICell cell = FirstRow.GetCell(i);
                        if (cell != null)//没有数据的单元格都默认是null
                        {
                            string cellValue = cell.StringCellValue;
                            if (cellValue != null)
                            {
                                DataColumn column = new DataColumn(cellValue);//创建带列名的列
                                newDataTable.Columns.Add(column);//添加一列
                            }
                            else
                            {
                                DataColumn column = new DataColumn();//创建空列
                                newDataTable.Columns.Add(column);
                            }
                        }
                    }
                    else
                    {
                        DataColumn column = new DataColumn();//创建空列
                        newDataTable.Columns.Add(column);
                    }
                }
                startRow = IsHasColumnName ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;//确定起始行                   
                int rowCount = sheet.LastRowNum; //最后一行的标号即行数
                for (int i = startRow; i <= rowCount; ++i)
                {
                    IRow row = sheet.GetRow(i);//得到一行数据

                    if (row == null) continue; //没有数据的行默认是null
                    DataRow dataRow = newDataTable.NewRow(); //创建空行
                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                    {
                        if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null                              
                            dataRow[j] = row.GetCell(j).ToString();//单元格赋值
                    }
                    newDataTable.Rows.Add(dataRow);
                }
                workbook.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return newDataTable;
        }
    }
}
