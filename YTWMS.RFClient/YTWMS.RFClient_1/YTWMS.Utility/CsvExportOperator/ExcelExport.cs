using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Data;
using System.Configuration;
using Aspose.Cells;
using DataMapper;
using Utility;
using System.Collections;

namespace Utility
{
    public class ExcelExport
    {
        #region field
        private Workbook excel;
        private Worksheet worksheet;
        private Cells cells;
        private Style styleTitle;
        private Style styleHead;
        private Style styleLeft;
        private Style styleRigth;
        private Style styleDetail;
        private Style styleTop;
        private Style styleCenter;
        private Cell cell;
        private string exportName;
        private DataTable table;
        private Stream stream;
        private int row = 0;

        #endregion

        public ExcelExport(DataTable table,Stream stream,string exportName)
        {
            excel = new Workbook();
            worksheet = excel.Worksheets[0];
            worksheet.Name = exportName;
            cells = worksheet.Cells;
            this.table = table;
            this.stream = stream;
            this.exportName = exportName;
            

            styleTitle = excel.Styles[excel.Styles.Add()];
            styleTitle.Font.IsBold = true;
            styleTitle.Font.Size = 14;
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;

            styleHead = excel.Styles[excel.Styles.Add()];
            styleHead.Font.IsBold = true;
            styleHead.Font.Size = 12;
            styleHead.HorizontalAlignment = TextAlignmentType.Left;

            styleLeft = excel.Styles[excel.Styles.Add()];
            styleLeft.Font.Size = 10;
            styleLeft.HorizontalAlignment = TextAlignmentType.Left;

            styleRigth = excel.Styles[excel.Styles.Add()];
            styleRigth.Font.Size = 10;
            styleRigth.HorizontalAlignment = TextAlignmentType.Right;

            styleDetail = excel.Styles[excel.Styles.Add()];
            styleDetail.HorizontalAlignment = TextAlignmentType.Left;
            styleDetail.Font.Size = 10;

            styleTop = excel.Styles[excel.Styles.Add()];
            styleTop.VerticalAlignment = TextAlignmentType.Top;
            styleTop.HorizontalAlignment = TextAlignmentType.Left;
            styleTop.Font.Size = 10;

            styleCenter = excel.Styles[excel.Styles.Add()];
            styleCenter.Font.Size = 10;
            styleCenter.HorizontalAlignment = TextAlignmentType.Center;



        }

        #region 设置
        /// <summary>
        /// 
        /// </summary>
        /// <param name="widths"></param>
        private void SetTitle(int[] widths)
        {
            for (int i = 0; i < widths.Length; i++)
            {
                cell = cells[0, i];
                cell.Style = styleTitle;
                cell.PutValue(exportName);
                cells.SetColumnWidth(i, widths[i]);
            }

            cells.SetRowHeight(0, 25);
            worksheet.Cells.Merge(0, 0, 1, widths.Length);

            cells.SetRowHeight(1, 20);
            cell = cells[1, 0];
            cell.Style = styleHead;
            cell.PutValue("生成日期：" + System.DateTime.Now.ToString("yyyy-MM-dd"));
            worksheet.Cells.Merge(1, 0, 1, widths.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="style"></param>
        /// <param name="value"></param>
        private void cellPutValue(int row, int column, Style style,string value)
        {
            cell = cells[row, column];
            cell.Style = style;
            cell.PutValue(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="style"></param>
        /// <param name="value"></param>
        private void cellPutNumberValue(int row, int column, Style style, object value)
        {
            cell = cells[row, column];
            cell.Style = style;
            cell.Style.Number = 1;
            cell.PutValue(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="style"></param>
        /// <param name="value"></param>
        private void cellPutNumberValueZeor(int row, int column, Style style, object value)
        {
            if (value == null || value.ToString() == "0")
                return;
            cell = cells[row, column];
            cell.Style = style;
            cell.Style.Number = 1;
            cell.PutValue(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private int getProdcutColumn(string productName, DataTable table)
        {
            DataRow[] rows = table.Select("PRODUCT_NAME='" + productName+"'");
            return int.Parse(rows[0]["ROWNUM"].ToString()) - 1 ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataTable getProduct()
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            return JjmcBaseinfoProduct.QueryDataTable("SelectProductRowNum", paramHashtable);
        }

        #endregion

        #region 库存报表
        #region 全国库存汇总按效期分报表
        public void InvertoryByExpDateReport()
        {
            
            string[] titleName = new string[] { "仓库", "产品名称", "批号", "汇总"};
            int[] widths = new int[] { 18, 18, 15, 10 };
            SetTitle(widths);
            worksheet.FreezePanes(3, 0, 3, widths.Length);
            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cellPutValue(2, i, styleHead, titleName[i]);
            }

            string warehouseNameFlag = "";
            string productNameFlag = "";
            int warehouseStartRow = 0;
            int productStartRow = 0;

            string warehouseName = "";
            string productName = "";
            string lotNumber = "";
            int quantity = 0;

            int total = 0;
            int warehouseTotal = 0;
            int productTotal = 0;

            row = 3;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dataRow = table.Rows[i];
                warehouseName = dataRow["WAREHOUSE_NAME"].ToString();
                productName = dataRow["PRODUCT_NAME"].ToString();
                lotNumber = dataRow["LOT_NUMBER"].ToString();
                quantity = int.Parse(dataRow["QUANTITY"].ToString());
                
                if (warehouseNameFlag == "")
                {
                    cellPutValue(row, 0, styleTop, warehouseName);
                    cellPutValue(row, 1, styleTop, productName);
                    cellPutValue(row, 2, styleDetail, lotNumber);
                    cellPutNumberValue(row, 3, styleRigth, quantity);

                    total += quantity;
                    warehouseTotal += quantity;
                    productTotal += quantity;
                    warehouseStartRow = row;
                    productStartRow = row;

                    warehouseNameFlag = warehouseName;
                    productNameFlag = productName;

                }
                else
                {

                    if (warehouseNameFlag == warehouseName)
                    {
                        if (productNameFlag == productName)
                        {
                            cellPutValue(row, 0, styleTop, warehouseName);
                            cellPutValue(row, 1, styleTop, productName);
                            cellPutValue(row, 2, styleDetail, lotNumber);
                            cellPutNumberValue(row, 3, styleRigth, quantity);

                            total += quantity;
                            warehouseTotal += quantity;
                            productTotal += quantity;
                        }
                        else
                        {
                            cellPutValue(row, 0, styleTop, warehouseName);
                            cellPutValue(row, 1, styleDetail, productNameFlag + " 汇总");
                            cellPutValue(row, 2, styleDetail, productNameFlag + " 汇总");
                            cellPutNumberValue(row, 3, styleRigth, productTotal);
                            worksheet.Cells.Merge(row, 1, 1, 2);
                            worksheet.Cells.Merge(productStartRow, 1, (row-productStartRow), 1);
                            row++;

                            cellPutValue(row, 0, styleTop, warehouseName);
                            cellPutValue(row, 1, styleTop, productName);
                            cellPutValue(row, 2, styleDetail, lotNumber);
                            cellPutNumberValue(row, 3, styleRigth, quantity);
                            total += quantity;
                            warehouseTotal += quantity;
                            productTotal = quantity;

                            productStartRow = row;

                            productNameFlag = productName;

                        }

                    }
                    else
                    {
                        cellPutValue(row, 0, styleTop, warehouseNameFlag);
                        cellPutValue(row, 1, styleDetail, productNameFlag + " 汇总");
                        cellPutValue(row, 2, styleDetail, productNameFlag + " 汇总");
                        cellPutNumberValue(row, 3, styleRigth, productTotal);
                        worksheet.Cells.Merge(row, 1, 1, 2);                      
                        row++;

                        //客服中心汇总   
                        //cellPutValue(warehouseStartRow, 0, styleDetail, warehouseNameFlag);
                        worksheet.Cells.Merge(warehouseStartRow, 0, (row - warehouseStartRow), 1);
                        cellPutValue(row, 0, styleDetail, warehouseNameFlag + " 汇总");
                        cellPutValue(row, 1, styleDetail, warehouseNameFlag + " 汇总");
                        cellPutValue(row, 2, styleDetail, warehouseNameFlag + " 汇总");
                        cellPutNumberValue(row, 3, styleRigth, warehouseTotal);
                        worksheet.Cells.Merge(row, 0, 1, 3);
                        row++;


                        cellPutValue(row, 0, styleTop, warehouseName);
                        cellPutValue(row, 1, styleTop, productName);
                        cellPutValue(row, 2, styleDetail, lotNumber);
                        cellPutNumberValue(row, 3, styleRigth, quantity);

                        total += quantity;
                        warehouseTotal = quantity;
                        productTotal = quantity;
                        warehouseStartRow = row;
                        productStartRow = row;

                        warehouseNameFlag = warehouseName;
                        productNameFlag = productName;
                    }
                }

                row++;

            }

            cellPutValue(row, 0, styleTop, warehouseNameFlag);
            cellPutValue(row, 1, styleDetail, productNameFlag + " 汇总");
            cellPutValue(row, 2, styleDetail, productNameFlag + " 汇总");
            cellPutNumberValue(row, 3, styleRigth, productTotal);
            worksheet.Cells.Merge(row, 1, 1, 2);
            
            row++;

            //客服中心汇总
            //cellPutValue(warehouseStartRow, 0, styleDetail, warehouseNameFlag);
            worksheet.Cells.Merge(warehouseStartRow, 0, (row - warehouseStartRow), 1);
            cellPutValue(row, 0, styleDetail, warehouseNameFlag + " 汇总");
            cellPutValue(row, 1, styleDetail, warehouseNameFlag + " 汇总");
            cellPutValue(row, 2, styleDetail, warehouseNameFlag + " 汇总");
            cellPutNumberValue(row, 3, styleRigth, warehouseTotal);
            worksheet.Cells.Merge(row, 0, 1, 3);
            row++;

            //总计
            cellPutValue(row, 0, styleDetail, "总计");
            cellPutValue(row, 1, styleDetail, "总计");
            cellPutValue(row, 2, styleDetail, "总计");
            cellPutNumberValue(row, 3, styleRigth, total);
            worksheet.Cells.Merge(row, 0, 1, 3);

            excel.Save(stream, FileFormatType.Excel2003);

        }
        #endregion

        #region 全国库存汇总报表
        public void InvertoryReceiveInReport()
        {
            DataTable productTable = getProduct();
            int productCount = productTable.Rows.Count;
            string[] titleName = new string[productCount + 3];
            int[] widths = new int[productCount + 3];
            titleName[0] = "仓库";
            titleName[1] = "计划类型";
            titleName[titleName.Length-1] = "总计";

            widths[0] = 18;
            widths[1] = 20;
            widths[titleName.Length - 1] = 10;

            for (int i = 0; i < productCount; i++)
            {
                titleName[i+2] = productTable.Rows[i]["PRODUCT_NAME"].ToString();
                widths[i+2] = 15;
            }

            SetTitle(widths);
            worksheet.FreezePanes(3, 0, 3, widths.Length);
            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cellPutValue(2, i, styleDetail, titleName[i]);
            }

            string warehouseNameFlag = "";
            string typeFlag = "";
            int warehouseStartRow = 0;


            string warehouseName = "";
            string type = "";
            string productName = "";
            int quantity = 0;
            int length = titleName.Length;

            int[] warehouseTotal = new int[productCount];
            int[] total = new int[productCount];
            int typeTotal = 0;
            int typeWarehouseTotal = 0;
            int typeAllTotal = 0;
            int productColumn = 0;

            row = 3;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dataRow = table.Rows[i];
                warehouseName = dataRow["WAREHOUSE_NAME"].ToString();
                productName = dataRow["PRODUCT_NAME"].ToString();
                type = EnumParser.GetEnumFiledName(typeof(ReceiveInPlanType), dataRow["RECEIVING_PLAN_TYPE"].ToString());
                quantity = int.Parse(dataRow["QUANTITY"].ToString());
                productColumn = getProdcutColumn(productName, productTable);
                if (warehouseNameFlag == "")
                {
                    cellPutValue(row, 0, styleTop, warehouseName);
                    cellPutValue(row, 1, styleDetail, type);

                    cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                    warehouseTotal[productColumn] = quantity;
                    total[productColumn] = quantity;
                    typeTotal += quantity;
                       

                    warehouseStartRow = row;
                    warehouseNameFlag = warehouseName;
                    typeFlag = type;

                }
                else
                {

                    if (warehouseNameFlag == warehouseName)
                    {
                        if (typeFlag == type)
                        {
                            cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                            warehouseTotal[productColumn] += quantity;
                            total[productColumn] += quantity;
                            typeTotal += quantity;
                  
                        }
                        else
                        {
                            cellPutNumberValue(row, length - 1, styleRigth, typeTotal);
                            typeWarehouseTotal += typeTotal;
                            typeTotal = 0;
                            row++;

                            cellPutValue(row, 0, styleTop, warehouseName);
                            cellPutValue(row, 1, styleDetail, type);

                            cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                            warehouseTotal[productColumn] += quantity;
                            total[productColumn] += quantity;
                            typeTotal += quantity;
  
                            typeFlag = type;

                        }

                    }
                    else
                    {

                        //客服中心汇总
                        cellPutNumberValue(row, length - 1, styleRigth, typeTotal);  
                        row++;
                        worksheet.Cells.Merge(warehouseStartRow, 0, (row - warehouseStartRow), 1);
                        cellPutValue(row, 0, styleDetail, warehouseNameFlag + " 汇总");
                        cellPutValue(row, 1, styleDetail, warehouseNameFlag + " 汇总");
                        worksheet.Cells.Merge(row, 0, 1, 2);        
                        for (int k = 0; k < warehouseTotal.Length; k++)
                        {
                            int column = 2 + k;
                            cellPutNumberValueZeor(row, column, styleRigth, warehouseTotal[k]);
                            warehouseTotal[k] = 0;

                        }
                        typeWarehouseTotal += typeTotal;
                        cellPutNumberValue(row, length - 1, styleRigth, typeWarehouseTotal);
                        typeAllTotal += typeWarehouseTotal;
                        typeWarehouseTotal = 0;
                        typeTotal = 0;
                        row++;


                        cellPutValue(row, 0, styleTop, warehouseName);
                        cellPutValue(row, 1, styleDetail, type);
                        cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                        warehouseTotal[productColumn] = quantity;
                        total[productColumn] += quantity;
                        typeTotal += quantity;

                        warehouseStartRow = row;
                        warehouseNameFlag = warehouseName;
                        typeFlag = type;   
                       
                    }
                }

            }

            //客服中心汇总
            cellPutNumberValue(row, length - 1, styleRigth, typeTotal); 
            row++;
            worksheet.Cells.Merge(warehouseStartRow, 0, (row - warehouseStartRow), 1);
            cellPutValue(row, 0, styleDetail, warehouseNameFlag + " 汇总");
            cellPutValue(row, 1, styleDetail, warehouseNameFlag + " 汇总");
            worksheet.Cells.Merge(row, 0, 1, 2);
            for (int i = 0; i < warehouseTotal.Length; i++)
            {
                int column = 2 + i;
                cellPutNumberValueZeor(row, column, styleRigth, warehouseTotal[i]);

            }
            typeWarehouseTotal += typeTotal;
            typeAllTotal += typeWarehouseTotal;
            cellPutNumberValue(row, length - 1, styleRigth, typeWarehouseTotal);
            row++;


            //总计
            cellPutValue(row, 0, styleDetail, "总计");
            cellPutValue(row, 1, styleDetail, "总计");
            worksheet.Cells.Merge(row, 0, 1, 2);
            for (int i = 0; i < total.Length; i++)
            {
                int column = 2 + i;
                cellPutNumberValueZeor(row, column, styleRigth, total[i]);

            }
            cellPutNumberValue(row, length - 1, styleRigth, typeAllTotal);

           
            excel.Save(stream, FileFormatType.Excel2003);

        }
        #endregion
        #endregion

        #region 客服中心报表
        #region 更换原因分析报表
        public void CenterChangeResonReport()
        {

            DataTable productTable = getProduct();
            int productCount = productTable.Rows.Count;
            string[] titleName = new string[productCount + 3];
            int[] widths = new int[productCount + 3];
            titleName[0] = "更换类型";
            titleName[1] = "更换原因";
            titleName[titleName.Length - 1] = "总计";

            widths[0] = 15;
            widths[1] = 20;
            widths[titleName.Length - 1] = 10;

            for (int i = 0; i < productCount; i++)
            {
                titleName[i + 2] = productTable.Rows[i]["PRODUCT_NAME"].ToString();
                widths[i + 2] = 15;
            }

            SetTitle(widths);
            worksheet.FreezePanes(3, 0, 3, widths.Length);
            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cellPutValue(2, i, styleDetail, titleName[i]);
            }

            string changeTypeFlag = "";
            string causeNameFlag = "";
            int changeTypeStartRow = 0;


            string changeType = "";
            string causeName = "";
            string productName = "";
            int quantity = 0;
            int length = titleName.Length;

            int[] changeTypeTotal = new int[productCount];
            int[] total = new int[productCount];
            int causeNameTotal = 0;
            int causeNameTypeTotal = 0;
            int typeAllTotal = 0;
            int productColumn = 0;

            row = 3;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dataRow = table.Rows[i];
                causeName = dataRow["RECEIVING_CAUSE_NAME"].ToString();
                productName = dataRow["PRODUCT_NAME"].ToString();
                changeType = EnumParser.GetEnumFiledName(typeof(ChangeType), dataRow["CHANGE_TYPE"].ToString());
                quantity = int.Parse(dataRow["QUANTITY"].ToString());
                productColumn = getProdcutColumn(productName, productTable);
                if (changeTypeFlag == "")
                {
                    cellPutValue(row, 0, styleTop, changeType);
                    cellPutValue(row, 1, styleDetail, causeName);

                    cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                    changeTypeTotal[productColumn] = quantity;
                    total[productColumn] = quantity;
                    causeNameTotal += quantity;


                    changeTypeStartRow = row;
                    changeTypeFlag = changeType;
                    causeNameFlag = causeName;

                }
                else
                {

                    if (changeTypeFlag == changeType)
                    {
                        if (causeNameFlag == causeName)
                        {
                            cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                            changeTypeTotal[productColumn] += quantity;
                            total[productColumn] += quantity;
                            causeNameTotal += quantity;

                        }
                        else
                        {
                            cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                            causeNameTypeTotal += causeNameTotal;
                            causeNameTotal = 0;
                            row++;

                            cellPutValue(row, 0, styleTop, causeName);
                            cellPutValue(row, 1, styleDetail, causeName);

                            cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                            changeTypeTotal[productColumn] += quantity;
                            total[productColumn] += quantity;
                            causeNameTotal += quantity;

                            causeNameFlag = causeName;

                        }

                    }
                    else
                    {

                        //更换类型汇总
                        cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                        row++;
                        worksheet.Cells.Merge(changeTypeStartRow, 0, (row - changeTypeStartRow), 1);
                        cellPutValue(row, 0, styleDetail, changeTypeFlag + " 汇总");
                        cellPutValue(row, 1, styleDetail, changeTypeFlag + " 汇总");
                        worksheet.Cells.Merge(row, 0, 1, 2);
                        for (int k = 0; k < changeTypeTotal.Length; k++)
                        {
                            int column = 2 + k;
                            cellPutNumberValueZeor(row, column, styleRigth, changeTypeTotal[k]);
                            changeTypeTotal[k] = 0;

                        }
                        causeNameTypeTotal += causeNameTotal;
                        cellPutNumberValue(row, length - 1, styleRigth, causeNameTypeTotal);
                        typeAllTotal += causeNameTypeTotal;
                        causeNameTypeTotal = 0;
                        causeNameTotal = 0;
                        row++;


                        cellPutValue(row, 0, styleTop, changeType);
                        cellPutValue(row, 1, styleDetail, causeName);
                        cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                        changeTypeTotal[productColumn] = quantity;
                        total[productColumn] += quantity;
                        causeNameTotal += quantity;

                        changeTypeStartRow = row;
                        changeTypeFlag = changeType;
                        causeNameFlag = causeName;

                    }
                }

            }

            //更换类型汇总
            cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
            row++;
            worksheet.Cells.Merge(changeTypeStartRow, 0, (row - changeTypeStartRow), 1);
            cellPutValue(row, 0, styleDetail, changeTypeFlag + " 汇总");
            cellPutValue(row, 1, styleDetail, changeTypeFlag + " 汇总");
            worksheet.Cells.Merge(row, 0, 1, 2);
            for (int i = 0; i < changeTypeTotal.Length; i++)
            {
                int column = 2 + i;
                cellPutNumberValueZeor(row, column, styleRigth, changeTypeTotal[i]);

            }
            causeNameTypeTotal += causeNameTotal;
            typeAllTotal += causeNameTypeTotal;
            cellPutNumberValue(row, length - 1, styleRigth, causeNameTypeTotal);
            row++;


            //总计
            cellPutValue(row, 0, styleDetail, "总计");
            cellPutValue(row, 1, styleDetail, "总计");
            worksheet.Cells.Merge(row, 0, 1, 2);
            for (int i = 0; i < total.Length; i++)
            {
                int column = 2 + i;
                cellPutNumberValueZeor(row, column, styleRigth, total[i]);

            }
            cellPutNumberValue(row, length - 1, styleRigth, typeAllTotal);


            excel.Save(stream, FileFormatType.Excel2003);

        }
        #endregion

        #region 客服中心使用分析报表
        public void CenterCenterOperatorReport()
        {

            DataTable productTable = getProduct();
            int productCount = productTable.Rows.Count;
            string[] titleName = new string[productCount + 3];
            int[] widths = new int[productCount + 3];
            titleName[0] = "仓库名称";
            titleName[1] = "更换原因";
            titleName[titleName.Length - 1] = "总计";

            widths[0] = 15;
            widths[1] = 20;
            widths[titleName.Length - 1] = 10;

            for (int i = 0; i < productCount; i++)
            {
                titleName[i + 2] = productTable.Rows[i]["PRODUCT_NAME"].ToString();
                widths[i + 2] = 15;
            }

            SetTitle(widths);
            worksheet.FreezePanes(3, 0, 3, widths.Length);
            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cellPutValue(2, i, styleDetail, titleName[i]);
            }

            string warehouseNameFlag = "";
            string causeNameFlag = "";
            int warehouseNameStartRow = 0;


            string warehouseName = "";
            string causeName = "";
            string productName = "";
            int quantity = 0;
            int length = titleName.Length;

            int[] warehouseNameTotal = new int[productCount];
            int[] total = new int[productCount];
            int causeNameTotal = 0;
            int causeNameWarehouseTotal = 0;
            int typeAllTotal = 0;
            int productColumn = 0;

            row = 3;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dataRow = table.Rows[i];
                causeName = dataRow["RECEIVING_CAUSE_NAME"].ToString();
                productName = dataRow["PRODUCT_NAME"].ToString();
                warehouseName = dataRow["WAREHOUSE_NAME"].ToString();
                quantity = int.Parse(dataRow["QUANTITY"].ToString());
                productColumn = getProdcutColumn(productName, productTable);
                if (warehouseNameFlag == "")
                {
                    cellPutValue(row, 0, styleTop, warehouseName);
                    cellPutValue(row, 1, styleDetail, causeName);

                    cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                    warehouseNameTotal[productColumn] = quantity;
                    total[productColumn] = quantity;
                    causeNameTotal += quantity;

                    warehouseNameStartRow = row;
                    warehouseNameFlag = warehouseName;
                    causeNameFlag = causeName;
                }
                else
                {

                    if (warehouseNameFlag == warehouseName)
                    {
                        #region 更换原因
                        if (causeNameFlag == causeName)
                        {
                            cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                            warehouseNameTotal[productColumn] += quantity;
                            total[productColumn] += quantity;
                            causeNameTotal += quantity;

                        }
                        else
                        {
                            cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                            causeNameWarehouseTotal += causeNameTotal;
                            causeNameTotal = 0;
                            row++;

                            cellPutValue(row, 0, styleTop, warehouseName);
                            cellPutValue(row, 1, styleDetail, causeName);

                            cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                            warehouseNameTotal[productColumn] += quantity;
                            total[productColumn] += quantity;
                            causeNameTotal += quantity;

                            causeNameFlag = causeName;

                        }
                        #endregion
                    }
                    else
                    {
                        #region 仓库汇总
                        cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                        row++;
                        worksheet.Cells.Merge(warehouseNameStartRow, 0, (row - warehouseNameStartRow), 1);
                        cellPutValue(row, 0, styleDetail, warehouseNameFlag + " 汇总");
                        cellPutValue(row, 1, styleDetail, warehouseNameFlag + " 汇总");
                        worksheet.Cells.Merge(row, 0, 1, 2);
                        for (int k = 0; k < warehouseNameTotal.Length; k++)
                        {
                            int column = 2 + k;
                            cellPutNumberValueZeor(row, column, styleRigth, warehouseNameTotal[k]);
                            warehouseNameTotal[k] = 0;

                        }
                        causeNameWarehouseTotal += causeNameTotal;
                        cellPutNumberValue(row, length - 1, styleRigth, causeNameWarehouseTotal);
                        typeAllTotal += causeNameWarehouseTotal;
                        causeNameWarehouseTotal = 0;
                        causeNameTotal = 0;
                        row++;


                        cellPutValue(row, 0, styleTop, warehouseName);
                        cellPutValue(row, 1, styleDetail, causeName);
                        cellPutNumberValue(row, (productColumn + 2), styleRigth, quantity);
                        warehouseNameTotal[productColumn] = quantity;
                        total[productColumn] += quantity;
                        causeNameTotal += quantity;

                        warehouseNameStartRow = row;
                        warehouseNameFlag = warehouseName;
                        causeNameFlag = causeName;
                        #endregion
                    }
                }
            }
            #region 仓库汇总
            //仓库汇总
            cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
            row++;
            worksheet.Cells.Merge(warehouseNameStartRow, 0, (row - warehouseNameStartRow), 1);
            cellPutValue(row, 0, styleDetail, warehouseNameFlag + " 汇总");
            cellPutValue(row, 1, styleDetail, warehouseNameFlag + " 汇总");
            worksheet.Cells.Merge(row, 0, 1, 2);
            for (int i = 0; i < warehouseNameTotal.Length; i++)
            {
                int column = 2 + i;
                cellPutNumberValueZeor(row, column, styleRigth, warehouseNameTotal[i]);

            }
            causeNameWarehouseTotal += causeNameTotal;
            typeAllTotal += causeNameWarehouseTotal;
            cellPutNumberValue(row, length - 1, styleRigth, causeNameWarehouseTotal);
            row++;


            //总计
            cellPutValue(row, 0, styleDetail, "总计");
            cellPutValue(row, 1, styleDetail, "总计");
            worksheet.Cells.Merge(row, 0, 1, 2);
            for (int i = 0; i < total.Length; i++)
            {
                int column = 2 + i;
                cellPutNumberValueZeor(row, column, styleRigth, total[i]);

            }
            cellPutNumberValue(row, length - 1, styleRigth, typeAllTotal);


            excel.Save(stream, FileFormatType.Excel2003);
            #endregion
        }
        #endregion

        #region 销售代表领用分析报表
        public void CenterSalesManOperatorReport()
        {

            DataTable productTable = getProduct();
            int productCount = productTable.Rows.Count;
            string[] titleName = new string[productCount + 4];
            int[] widths = new int[productCount + 4];
            titleName[0] = "销售代表";
            titleName[1] = "领用人";
            titleName[2] = "更换原因";
            titleName[titleName.Length - 1] = "总计";

            widths[0] = 10;
            widths[1] = 10;
            widths[2] = 20;
            widths[titleName.Length - 1] = 10;

            for (int i = 0; i < productCount; i++)
            {
                titleName[i + 3] = productTable.Rows[i]["PRODUCT_NAME"].ToString();
                widths[i + 3] = 15;
            }

            SetTitle(widths);
            worksheet.FreezePanes(3, 0, 3, widths.Length);
            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cellPutValue(2, i, styleDetail, titleName[i]);
            }

            string salesNameFlag = "";
            string handledNameFlag = "";
            string causeNameFlag = "";
            int salesNameStartRow = 0;
            int handledNameStartRow = 0;


            string salesName = "";
            string handledName = "";
            string causeName = "";
            string productName = "";
            int quantity = 0;
            int length = titleName.Length;

            int[] handledNameTotal = new int[productCount];
            int[] salesNameTotal = new int[productCount];
            int[] total = new int[productCount];
            int causeNameTotal = 0;
            int handledNameProductTotal = 0;
            int salesNameProductTotal = 0;
            int typeAllTotal = 0;
            int productColumn = 0;

            row = 3;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dataRow = table.Rows[i];
                causeName = dataRow["RECEIVING_CAUSE_NAME"].ToString();
                productName = dataRow["PRODUCT_NAME"].ToString();
                salesName = dataRow["SALES_NAME"].ToString();
                handledName = dataRow["HANDLED_NAME"].ToString();

                quantity = int.Parse(dataRow["QUANTITY"].ToString());
                productColumn = getProdcutColumn(productName, productTable);
                if (salesNameFlag == "")
                {
                    cellPutValue(row, 0, styleTop, salesName);
                    cellPutValue(row, 1, styleTop, handledName);
                    cellPutValue(row, 2, styleDetail, causeName);

                    cellPutNumberValue(row, (productColumn + 3), styleRigth, quantity);
                    handledNameTotal[productColumn] = quantity;
                    salesNameTotal[productColumn] = quantity;
                    total[productColumn] = quantity;
                    causeNameTotal += quantity;


                    salesNameStartRow = row;
                    handledNameStartRow = row;
                    salesNameFlag = salesName;
                    handledNameFlag = handledName;
                    causeNameFlag = causeName;

                }
                else
                {

                    if (salesNameFlag == salesName)
                    {
                        #region 领用人
                        if (handledNameFlag == handledName)
                        {

                            #region 更换原因
                            if (causeNameFlag == causeName)
                            {
                                cellPutNumberValue(row, (productColumn + 3), styleRigth, quantity);
                                handledNameTotal[productColumn] += quantity;
                                salesNameTotal[productColumn] += quantity;
                                total[productColumn] += quantity;
                                causeNameTotal += quantity;

                            }
                            else
                            {
                                cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                                handledNameProductTotal += causeNameTotal;
                                causeNameTotal = 0;
                                row++;

                                cellPutValue(row, 0, styleTop, salesName);
                                cellPutValue(row, 1, styleTop, handledName);
                                cellPutValue(row, 2, styleDetail, causeName);

                                cellPutNumberValue(row, (productColumn + 3), styleRigth, quantity);
                                handledNameTotal[productColumn] += quantity;
                                salesNameTotal[productColumn] += quantity;
                                total[productColumn] += quantity;
                                causeNameTotal += quantity;
                                causeNameFlag = causeName;

                            }
                            #endregion

                        }
                        else
                        {
                            //领用人汇总
                            cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                            row++;
                        
                            cellPutValue(row, 0, styleDetail, salesName);
                            cellPutValue(row, 1, styleDetail, handledNameFlag + " 汇总");
                            cellPutValue(row, 2, styleDetail, handledNameFlag + " 汇总");
                            worksheet.Cells.Merge(row, 1, 1, 2);
                            worksheet.Cells.Merge(handledNameStartRow, 1, (row - handledNameStartRow), 1);
                            for (int k = 0; k < handledNameTotal.Length; k++)
                            {
                                int column = 3 + k;
                                cellPutNumberValueZeor(row, column, styleRigth, handledNameTotal[k]);
                                handledNameTotal[k] = 0;

                            }
                            handledNameProductTotal += causeNameTotal;
                            salesNameProductTotal += handledNameProductTotal;
                            cellPutNumberValue(row, length - 1, styleRigth, handledNameProductTotal);

                            handledNameProductTotal = 0;
                            causeNameTotal = 0;
                            row++;


                            cellPutValue(row, 0, styleTop, salesName);
                            cellPutValue(row, 1, styleTop, handledName);
                            cellPutValue(row, 2, styleDetail, causeName);
                            cellPutNumberValue(row, (productColumn + 3), styleRigth, quantity);
                            handledNameTotal[productColumn] = quantity;
                            salesNameTotal[productColumn] += quantity;
                            total[productColumn] += quantity;
                            causeNameTotal += quantity;

                            handledNameStartRow = row;
                            handledNameFlag = handledName;
                            causeNameFlag = causeName;
                        }

                        #endregion
                    }
                    else
                    {
                        #region 销售代表汇总
                        //领用人汇总
                        cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                        row++;
                        
                        cellPutValue(row, 0, styleDetail, salesName);
                        cellPutValue(row, 1, styleDetail, handledNameFlag + " 汇总");
                        cellPutValue(row, 2, styleDetail, handledNameFlag + " 汇总");
                        worksheet.Cells.Merge(row, 1, 1, 2);
                        worksheet.Cells.Merge(handledNameStartRow, 1, (row - handledNameStartRow), 1);
                        for (int k = 0; k < handledNameTotal.Length; k++)
                        {
                            int column = 3 + k;
                            cellPutNumberValueZeor(row, column, styleRigth, handledNameTotal[k]);
                            handledNameTotal[k] = 0;

                        }
                        handledNameProductTotal += causeNameTotal;
                        salesNameProductTotal += handledNameProductTotal;
                        cellPutNumberValue(row, length - 1, styleRigth, handledNameProductTotal);
                        handledNameProductTotal = 0;
                        causeNameTotal = 0;
                        row++;

                        //销售代表汇总
                        worksheet.Cells.Merge(salesNameStartRow, 0, (row - salesNameStartRow), 1);
                        cellPutValue(row, 0, styleDetail, salesNameFlag + " 汇总");
                        cellPutValue(row, 1, styleDetail, salesNameFlag + " 汇总");
                        cellPutValue(row, 2, styleDetail, salesNameFlag + " 汇总");                      
                        worksheet.Cells.Merge(row, 0, 1, 3);
                        for (int k = 0; k < salesNameTotal.Length; k++)
                        {
                            int column = 3 + k;
                            cellPutNumberValueZeor(row, column, styleRigth, salesNameTotal[k]);
                            salesNameTotal[k] = 0;

                        }

                        cellPutNumberValue(row, length - 1, styleRigth, salesNameProductTotal);
                        typeAllTotal += salesNameProductTotal;
                        salesNameProductTotal = 0;
                        row++;


                        cellPutValue(row, 0, styleTop, salesName);
                        cellPutValue(row, 1, styleTop, handledName);
                        cellPutValue(row, 2, styleDetail, causeName);
                        cellPutNumberValue(row, (productColumn + 3), styleRigth, quantity);
                        handledNameTotal[productColumn] = quantity;
                        salesNameTotal[productColumn] = quantity;
                        total[productColumn] += quantity;
                        causeNameTotal += quantity;


                        salesNameStartRow = row;
                        handledNameStartRow = row;
                        salesNameFlag = salesName;
                        handledNameFlag = handledName;
                        causeNameFlag = causeName;
                        #endregion
                    }
                }
            }

            #region 总计
            //领用人汇总
            cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
            row++;

            cellPutValue(row, 0, styleDetail, salesName);
            cellPutValue(row, 1, styleDetail, handledNameFlag + " 汇总");
            cellPutValue(row, 2, styleDetail, handledNameFlag + " 汇总");
            worksheet.Cells.Merge(row, 1, 1, 2);
            worksheet.Cells.Merge(handledNameStartRow, 1, (row - handledNameStartRow), 1);
            for (int k = 0; k < handledNameTotal.Length; k++)
            {
                int column = 3 + k;
                cellPutNumberValueZeor(row, column, styleRigth, handledNameTotal[k]);
                handledNameTotal[k] = 0;

            }
            handledNameProductTotal += causeNameTotal;
            salesNameProductTotal += handledNameProductTotal;
            cellPutNumberValue(row, length - 1, styleRigth, handledNameProductTotal);
            handledNameProductTotal = 0;
            causeNameTotal = 0;
            row++;

            //销售代表汇总
            worksheet.Cells.Merge(salesNameStartRow, 0, (row - salesNameStartRow), 1);
            cellPutValue(row, 0, styleDetail, salesNameFlag + " 汇总");
            cellPutValue(row, 1, styleDetail, salesNameFlag + " 汇总");
            cellPutValue(row, 2, styleDetail, salesNameFlag + " 汇总");
            worksheet.Cells.Merge(row, 0, 1, 3);
            for (int k = 0; k < salesNameTotal.Length; k++)
            {
                int column = 3 + k;
                cellPutNumberValueZeor(row, column, styleRigth, salesNameTotal[k]);
                salesNameTotal[k] = 0;

            }
            cellPutNumberValue(row, length - 1, styleRigth, salesNameProductTotal);
            typeAllTotal += salesNameProductTotal;
            row++;


            //总计
            cellPutValue(row, 0, styleDetail, "总计");
            cellPutValue(row, 1, styleDetail, "总计");
            cellPutValue(row, 2, styleDetail, "总计");
            worksheet.Cells.Merge(row, 0, 1, 3);
            for (int i = 0; i < total.Length; i++)
            {
                int column = 3 + i;
                cellPutNumberValueZeor(row, column, styleRigth, total[i]);

            }
            cellPutNumberValue(row, length - 1, styleRigth, typeAllTotal);


            excel.Save(stream, FileFormatType.Excel2003);

            #endregion
        }
        #endregion

        #region 客户样品投放使用分析报表
        public void CenterProductOperatorReport()
        {

            DataTable productTable = getProduct();
            int productCount = productTable.Rows.Count;
            string[] titleName = new string[productCount + 5];
            int[] widths = new int[productCount + 5];
            titleName[0] = "仓库名称";
            titleName[1] = "客户地址";
            titleName[2] = "科室电话";
            titleName[3] = "更换原因";
            titleName[titleName.Length - 1] = "总计";

            widths[0] = 15;
            widths[1] = 30;
            widths[2] = 10;
            widths[3] = 20;
            widths[titleName.Length - 1] = 10;

            for (int i = 0; i < productCount; i++)
            {
                titleName[i + 4] = productTable.Rows[i]["PRODUCT_NAME"].ToString();
                widths[i + 4] = 15;
            }

            SetTitle(widths);
            worksheet.FreezePanes(3, 0, 3, widths.Length);
            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cellPutValue(2, i, styleDetail, titleName[i]);
            }

            string warehouseNameFlag = "";
            string addressFlag = "";
            string sectionFlag = "";
            string causeNameFlag = "";
            int warehouseNameStartRow = 0;
            int addressStartRow = 0;
            int sectionStartRow = 0;

            string warehouseName = "";
            string address = "";
            string section = "";
            string causeName = "";
            string productName = "";
            int quantity = 0;
            int length = titleName.Length;

            int[] warehouseNameTotal = new int[productCount];
            int[] total = new int[productCount];
            int causeNameTotal = 0;
            int warehouseNameProductTotal = 0;
            int typeAllTotal = 0;
            int productColumn = 0;

            row = 3;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dataRow = table.Rows[i];
                causeName = dataRow["RECEIVING_CAUSE_NAME"].ToString();
                productName = dataRow["PRODUCT_NAME"].ToString();
                address = dataRow["CONSUMER_ADDRESS"].ToString();
                section = dataRow["SECTION_OFFICE"].ToString();
                warehouseName = dataRow["WAREHOUSE_NAME"].ToString();

                quantity = int.Parse(dataRow["QUANTITY"].ToString());
                productColumn = getProdcutColumn(productName, productTable);
                if (warehouseNameFlag == "")
                {
                    cellPutValue(row, 0, styleTop, warehouseName);
                    cellPutValue(row, 1, styleTop, address);
                    cellPutValue(row, 2, styleTop, section);
                    cellPutValue(row, 3, styleDetail, causeName);

                    cellPutNumberValue(row, (productColumn + 4), styleRigth, quantity);
                    warehouseNameTotal[productColumn] = quantity;
                    total[productColumn] = quantity;
                    causeNameTotal += quantity;


                    warehouseNameStartRow = row;
                    addressStartRow = row;
                    sectionStartRow = row;
                    warehouseNameFlag = warehouseName;
                    addressFlag = address;
                    sectionFlag = section;
                    causeNameFlag = causeName;

                }
                else
                {
                    if (warehouseNameFlag == warehouseName)
                    {
                        #region 客户地址
                        if (addressFlag == address)
                        {

                            #region 科室电话
                            if (sectionFlag == section)
                            {
                                #region 更换原因
                                if (causeNameFlag == causeName)
                                {
                                    cellPutNumberValue(row, (productColumn + 4), styleRigth, quantity);
                                    warehouseNameTotal[productColumn] += quantity;
                                    total[productColumn] += quantity;
                                    causeNameTotal += quantity;
                                }
                                else
                                {
                                    cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                                    warehouseNameProductTotal += causeNameTotal;
                                    causeNameTotal = 0;
                                    row++;

                                    cellPutValue(row, 0, styleTop, warehouseName);
                                    cellPutValue(row, 1, styleTop, address);
                                    cellPutValue(row, 2, styleTop, section);
                                    cellPutValue(row, 3, styleDetail, causeName);

                                    cellPutNumberValue(row, (productColumn + 4), styleRigth, quantity);
                                    warehouseNameTotal[productColumn] += quantity;
                                    total[productColumn] += quantity;
                                    causeNameTotal += quantity;
                                    causeNameFlag = causeName;
                                }
                                #endregion                          
                            }
                            else
                            {
                                cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                                warehouseNameProductTotal += causeNameTotal;
                                causeNameTotal = 0;
                                row++;

                                worksheet.Cells.Merge(sectionStartRow, 2, (row - sectionStartRow), 1);
                                cellPutValue(row, 0, styleTop, warehouseName);
                                cellPutValue(row, 1, styleTop, address);
                                cellPutValue(row, 2, styleTop, section);
                                cellPutValue(row, 3, styleDetail, causeName);

                                cellPutNumberValue(row, (productColumn + 4), styleRigth, quantity);
                                warehouseNameTotal[productColumn] += quantity;
                                total[productColumn] += quantity;
                                causeNameTotal += quantity;

                                sectionFlag = section;
                                causeNameFlag = causeName;
                                sectionStartRow = row;
                                row++;                        

                            }
                            #endregion

                        }
                        else
                        {
                            //客户地址
                            cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                            warehouseNameProductTotal += causeNameTotal;
                            causeNameTotal = 0;
                            row++;

                            cellPutValue(row, 0, styleTop, warehouseName);
                            cellPutValue(row, 1, styleTop, address);
                            cellPutValue(row, 2, styleTop, section);
                            cellPutValue(row, 3, styleDetail, causeName);
                            worksheet.Cells.Merge(addressStartRow, 1, (row - addressStartRow), 1);
                            worksheet.Cells.Merge(sectionStartRow, 1, (row - sectionStartRow), 1);
                            

                            cellPutNumberValue(row, (productColumn + 4), styleRigth, quantity);
                            warehouseNameTotal[productColumn] += quantity;
                            total[productColumn] += quantity;
                            causeNameTotal += quantity;

                            addressStartRow = row;
                            sectionStartRow = row;
                            addressFlag = address;
                            sectionFlag = section;
                            causeNameFlag = causeName;                       
                        }

                        #endregion
           
                    }
                    else
                    {
                        #region 仓库汇总
                        //客户地址
                        cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
                        row++;
                 
                        //仓库汇总
                        worksheet.Cells.Merge(warehouseNameStartRow, 0, (row - warehouseNameStartRow), 1);
                        worksheet.Cells.Merge(addressStartRow, 1, (row - addressStartRow), 1);
                        worksheet.Cells.Merge(sectionStartRow, 2, (row - sectionStartRow), 1);
                        cellPutValue(row, 0, styleDetail, warehouseNameFlag + " 汇总");
                        cellPutValue(row, 1, styleDetail, warehouseNameFlag + " 汇总");
                        cellPutValue(row, 2, styleDetail, warehouseNameFlag + " 汇总");
                        cellPutValue(row, 3, styleDetail, warehouseNameFlag + " 汇总");
                        worksheet.Cells.Merge(row, 0, 1, 4);
                        for (int k = 0; k < warehouseNameTotal.Length; k++)
                        {
                            int column = 4 + k;
                            cellPutNumberValueZeor(row, column, styleRigth, warehouseNameTotal[k]);
                            warehouseNameTotal[k] = 0;

                        }

                        warehouseNameProductTotal += causeNameTotal;
                        cellPutNumberValue(row, length - 1, styleRigth, warehouseNameProductTotal);
                        typeAllTotal += warehouseNameProductTotal;
                        warehouseNameProductTotal = 0;
                        causeNameTotal = 0;
                        row++;


                        cellPutValue(row, 0, styleTop, warehouseName);
                        cellPutValue(row, 1, styleTop, address);
                        cellPutValue(row, 2, styleTop, section);
                        cellPutValue(row, 3, styleDetail, causeName);
                        cellPutNumberValue(row, (productColumn + 4), styleRigth, quantity);
                        warehouseNameTotal[productColumn] = quantity;
                        total[productColumn] += quantity;
                        causeNameTotal += quantity;


                        warehouseNameStartRow = row;
                        addressStartRow = row;
                        sectionStartRow = row;
                        warehouseNameFlag = warehouseName;
                        addressFlag = address;
                        sectionFlag = section;    
                        causeNameFlag = causeName;
                        #endregion
                    }
                }
            }

            #region 总计
            //客户地址
            cellPutNumberValue(row, length - 1, styleRigth, causeNameTotal);
            warehouseNameProductTotal += causeNameTotal;
            row++;

            //仓库汇总
            worksheet.Cells.Merge(warehouseNameStartRow, 0, (row - warehouseNameStartRow), 1);
            worksheet.Cells.Merge(addressStartRow, 1, (row - addressStartRow), 1);
            worksheet.Cells.Merge(sectionStartRow, 2, (row - sectionStartRow), 1);
            cellPutValue(row, 0, styleDetail, warehouseNameFlag + " 汇总");
            cellPutValue(row, 1, styleDetail, warehouseNameFlag + " 汇总");
            cellPutValue(row, 2, styleDetail, warehouseNameFlag + " 汇总");
            cellPutValue(row, 3, styleDetail, warehouseNameFlag + " 汇总");
            worksheet.Cells.Merge(row, 0, 1, 4);
            for (int k = 0; k < warehouseNameTotal.Length; k++)
            {
                int column = 4 + k;
                cellPutNumberValueZeor(row, column, styleRigth, warehouseNameTotal[k]);
                warehouseNameTotal[k] = 0;

            }

            cellPutNumberValue(row, length - 1, styleRigth, warehouseNameProductTotal);
            typeAllTotal += warehouseNameProductTotal;
            warehouseNameProductTotal = 0;
            row++;


            //总计
            cellPutValue(row, 0, styleDetail, "总计");
            cellPutValue(row, 1, styleDetail, "总计");
            cellPutValue(row, 2, styleDetail, "总计");
            cellPutValue(row, 3, styleDetail, "总计");
            worksheet.Cells.Merge(row, 0, 1, 4);
            for (int i = 0; i < total.Length; i++)
            {
                int column = 4 + i;
                cellPutNumberValueZeor(row, column, styleRigth, total[i]);

            }
            cellPutNumberValue(row, length - 1, styleRigth, typeAllTotal);


            excel.Save(stream, FileFormatType.Excel2003);

            #endregion
        }
        #endregion
        #endregion

        #region 英源发货报表
        /// <summary>
        /// 英源发货汇总报表
        /// </summary>
        public void YYShipHistoryReport()
        {

            DataTable productTable = getProduct();
            int productCount = productTable.Rows.Count;
            string[] titleName = new string[productCount + 2];
            int[] widths = new int[productCount + 2];
            titleName[0] = "入库类型";
            titleName[titleName.Length - 1] = "总计";

            widths[0] = 15;
            widths[titleName.Length - 1] = 10;

            for (int i = 0; i < productCount; i++)
            {
                titleName[i + 1] = productTable.Rows[i]["PRODUCT_NAME"].ToString();
                widths[i + 1] = 15;
            }

            SetTitle(widths);
            worksheet.FreezePanes(3, 0, 3, widths.Length);
            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cellPutValue(2, i, styleDetail, titleName[i]);
            }

            string planTypeFlag = "";

            string planType = "";
            string productName = "";
            int quantity = 0;
            int length = titleName.Length;

            int[] total = new int[productCount];
            int planTypeTotal = 0;
            int typeAllTotal = 0;
            int productColumn = 0;

            row = 3;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dataRow = table.Rows[i];

                productName = dataRow["PRODUCT_NAME"].ToString();
                planType = EnumParser.GetEnumFiledName(typeof(ShipOutPlanType), dataRow["PLAN_TYPE"].ToString());
                quantity = int.Parse(dataRow["QUANTITY"].ToString());
                productColumn = getProdcutColumn(productName, productTable);
                if (planTypeFlag == "")
                {
                    cellPutValue(row, 0, styleTop, planType);

                    cellPutNumberValue(row, (productColumn + 1), styleRigth, quantity);
                    total[productColumn] = quantity;
                    planTypeTotal += quantity;

                    planTypeFlag = planType;

                }
                else
                {

                    if (planTypeFlag == planType)
                    {
                        cellPutNumberValue(row, (productColumn + 1), styleRigth, quantity);
                        total[productColumn] += quantity;
                        planTypeTotal += quantity;
                    }
                    else
                    {

                        //出库类型汇总
                        cellPutNumberValue(row, length - 1, styleRigth, planTypeTotal);
                        typeAllTotal += planTypeTotal;
                        planTypeTotal = 0;
                        row++;

                        cellPutValue(row, 0, styleTop, planType);
                        cellPutNumberValue(row, (productColumn + 1), styleRigth, quantity);
                        total[productColumn] += quantity;
                        planTypeTotal += quantity;

                        planTypeFlag = planType;

                    }
                }

            }
            //出库类型汇总
            cellPutNumberValue(row, length - 1, styleRigth, planTypeTotal);
            typeAllTotal += planTypeTotal; 
            planTypeTotal = 0;
            row++;

            //总计
            cellPutValue(row, 0, styleDetail, "总计");
            for (int i = 0; i < total.Length; i++)
            {
                int column = 1 + i;
                cellPutNumberValueZeor(row, column, styleRigth, total[i]);

            }
            cellPutNumberValue(row, length - 1, styleRigth, typeAllTotal);


            excel.Save(stream, FileFormatType.Excel2003);

        }
        #endregion
    }
}
