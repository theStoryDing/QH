
using OfficeOpenXml;
using System;
using System.IO;
using System.Windows.Forms;

namespace CaterCommon
{
    public partial class ExportExcel
    {             
        #region 使用EPPlus导出
        /// <summary>
        /// 导出数据到Excel
        /// </summary>
        /// <param name="dgv">数据源</param>
        /// <param name="title">标题</param>
        /// <param name="_path">路径</param>
        /// <returns>true/false</returns>
        public static bool ExportDataToExcel(DataGridView dgv, string title , string _path)
        {    
            //文件路径
            //string _filePath = saveDialog.FileName;
            string fileName = title + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
            string _newPath = _path + "\\"+fileName;

            FileInfo newFile = new FileInfo(_newPath);
            //存在同一文件则删除
            if(newFile.Exists)
            {
                try
                {
                    newFile.Delete();
                }
                catch(Exception ex)
                {
                    throw new Exception("删除同名文件失败！"+ex.Message);
                }
                
            }
                       
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                //创建工作簿
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(title);
                
                //插入列名
                for(int i = 1; i < dgv.ColumnCount + 1;i++)
                {
                    worksheet.Cells[1, i].Value = dgv.Columns[i - 1].HeaderText;
                    //worksheet.Cells[1, i].Style.Fill.PatternType = ExcelFillStyle.LightDown;
                    //worksheet.Cells[1, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));//设置单元格背景色
                    //worksheet.Cells[1, i].Style.Font.Bold = true;//字体为粗体
                    //worksheet.Cells[1, i].Style.Font.Color.SetColor(Color.Black);//字体颜色
                    //worksheet.Cells[1, i].Style.Font.Name = "微软雅黑";//字体
                    //worksheet.Cells[1, i].Style.Font.Size = 16;//字体大小
                }
                
                //插入数据
                for(int i = 0; i < dgv.Rows.Count; i++)
                {
                    for(int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value.ToString();

                    }
                }

                worksheet.Cells.AutoFitColumns();
               
                //设置格式
                //worksheet.Cells.Style.ShrinkToFit = true; //单元格自动适应大小             
                worksheet.Row(3).CustomHeight = true;//自动调整行高
                // 水平居中
                worksheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                //worksheet.OutLineApplyStyle = true;
                package.Save();
                return true;
            }
        }

        #endregion
    }





}