using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Data;
using System.Configuration;
using Aspose.Cells;

namespace Utility
{
    /// <summary>
    /// ����EXCEL
    /// </summary>
    public class ExcelExportOprator
    {
        #region field
        private static string[] InventoryTitleName = { "SN��", "�ֿ�", "��Ʒ����", "��Ʒ����", "����", "Ч��", "���", "����", "�������", "�������", "����״̬"};
        private static string[] InventoryColumnName = { "SERIAL_NUMBER", "warehouse_name", "PRODUCT_CODE", "product_name", "LOT_NUMBER", "EXP_DATE", "UNIT", "QUANTITY", "RECEIVE_IN_DATE", "RECEIVING_PLAN_TYPE", "QUALITY_FLAG"};
        private static string[] InventoryProductTitleName = { "�ֿ�", "��Ʒ����" , "�ƻ�����","����", "����", };
        private static string[] InventoryProductColumnName = { "warehouse_name", "product_name", "RECEIVING_PLAN_TYPE", "LOT_NUMBER", "QUANTITY" };
        private static string[] SNTitleName = { "SN��", "�ֿ�", "��Ʒ����", "����", "Ч��", "���", "����", "����", "����", "����" };
        private static string[] SNColumnName = { "SERIAL_NUMBER", "WAREHOUSE_NAME", "PRODUCT_CODE", "LOT_NUMBER", "EXP_DATE", "UNIT", "QUANTITY", "SHEET_NO", "CREATE_DATE", "OPTION_TYPE" };
        private static string[] ReceiveHistoryTitleName = { "SN��", "�ֿ�", "��Ʒ����", "��Ʒ����", "����", "Ч��", "���", "����", "�������", "�������" };
        private static string[] ReceiveHistoryColumnName = { "SERIAL_NUMBER", "warehouse_name", "PRODUCT_CODE", "product_name", "LOT_NUMBER", "EXP_DATE", "PRODUCT_UNIT_NAME", "QUANTITY", "RECEIVE_IN_DATE", "PLAN_TYPE" };
        private static string[] ShippingHistoryTitleName = { "SN��", "�ֿ�", "��Ʒ����", "��Ʒ����", "����", "Ч��", "���", "����", "�������", "�������", "Ŀ�Ĳֿ�" };
        private static string[] ShippingHistoryColumnName = { "SERIAL_NUMBER", "warehouse_name", "PRODUCT_CODE", "product_name", "LOT_NUMBER", "EXP_DATE", "PRODUCT_UNIT_NAME", "QUANTITY", "SHIP_OUT_DATE", "PLAN_TYPE", "in_warehouse_name" };
        private static string[] ProgramPlanTitleName = {  "���ȵ���", "�Ƶ���", "�����ֿ�", "Ŀ�Ĳֿ�", "Ԥ������", "Ԥ������", "��������", "�ƻ�״̬", "�Ƶ�����" };
        private static string[] ProgramPlanColumnName = { "LOAD_NO","USER_NAME", "OUT_WAREHOUSE_NAME", "IN_WAREHOUSE_NAME", "EXPECT_LEAVING_TIME", "EXPECT_ARRIVING_TIME", "PLAN_TYPE_NAME", "STATE_FLAG_NAME", "CREATE_DATE" };
        private static string[] DimSalesLimitTitleName = { "���۴���", "�·�", "�������", "�ƻ����", "��ɽ��", "ʣ����"};
        private static string[] DimSalesLimitColumnName = { "SALESNAME", "MONTH_FOR", "LIMIT_TYPE", "PLAN_MONEY", "FACT_MONEY", "LEAVE_MONEY"};
        private static string[] DimLimitOperateTitleName = { "���۴���", "�·�", "��������", "�������", "������", "����ʱ��", "��ע", "����ԭ��", "SN��", "��Ʒ����", "��Ʒ����", "���", "���", "�ƻ�����", "�������", "�ƻ����", "��ɽ��" ,"�ֿ�"};
        private static string[] DimLimitOperateColumnName = { "SALESNAME", "MONTH_FOR", "DO_TYPE", "LIMIT_TYPE", "USER_NAME", "CREATE_DATE", "MEMO", "LIMIT_TYPE", "SERIAL_NUMBER", "PRODUCT_CODE", "PRODUCT_NAME", "PRODUCT_UNIT_NAME", "PRODUCT_MONEY", "PLAN_QUANTITY", "FACT_QUANTITY", "PLAN_MONEY", "FACT_MONEY", "WAREHOUSE_NAME" };
        private static string[] DimUserTitleName = { "�û�����", "�û��ʺ�", "�����ֿ���", "�����ֿ���" };
        private static string[] DimUserColumnName = { "USER_NAME", "ACCOUNT_ID", "WAREHOUSE_CODE", "WAREHOUSE_NAME" };
        private static string[] DimSplitTitleName = { "SN��", "��Ʒ����", "��Ʒ����", "����", "Ч��", "���", "����", "�������", "����״̬", "������־", "�������" };
        private static string[] DimSplitColumnName = { "SERIAL_NUMBER", "PRODUCT_CODE", "product_name", "LOT_NUMBER", "EXP_DATE", "UNIT", "QUANTITY", "RECEIVE_IN_DATE", "QUALITY_FLAG", "WMS_LOCK_FLAG", "SPLIT_DATE" };
        private static string[] ReceivingPlanTitleName = { "���ȵ���", "�����ֿ�", "Ԥ������", "Ԥ������", "��������", "�ƻ�״̬", "�Ƶ�����" };
        private static string[] ReceivingPlanColumnName = { "LOAD_NO", "OUT_WAREHOUSE_NAME", "EXPECT_LEAVING_TIME", "EXPECT_ARRIVING_TIME", "PLAN_TYPE_NAME", "STATE_FLAG_NAME", "CREATE_DATE" };
        private static string[] ShippingPlanTitleName = { "���ȵ���", "Ŀ�Ĳֿ�", "Ԥ������", "Ԥ������", "��������", "�ƻ�״̬", "�Ƶ�����" };
        private static string[] ShippingPlanColumnName = { "LOAD_NO", "IN_WAREHOUSE_NAME", "EXPECT_LEAVING_TIME", "EXPECT_ARRIVING_TIME", "PLAN_TYPE_NAME", "STATE_FLAG_NAME", "CREATE_DATE" };
        private static string[] ExchangeOldMachineTitleName = { "�ƻ�����", "�ɻ�SN��", "��ϵ��", "Ͷ�ߵ���", "��������", "�ɻ�����", "�»�SN��", "������", "�����»�", "�Ƶ�����" };
        private static string[] ExchangeOldMachineColumnName = { "LOAD_NO", "OLD_MACHINE_SN", "CONSUMER_NAME", "COMPLAINT_NO", "CHANGE_TYPE", "OLD_SN_RESULT", "NEW_MACHINE_SN", "HANDLED_NAME", "IS_CHANGED", "CREATE_DATE" };
        private static string[] CenterShippingTitleName = { "���ⵥ��", "���۴���", "������", "�Ƶ�����", "�ƻ�״̬", "��ע"};
        private static string[] CenterShippingColumnName = { "LOAD_NO", "SALESNAME", "HANDLED_NAME", "CREATE_DATE", "STATE_FLAG", "REMARK" };
        private static string[] ExchangeOfRetailerTitleName = { "��������", "���۴���", "�˻�ԭ��", "ʡ", "��", "�ͻ�����", "�Ƶ�����", "�ƻ�״̬" };
        private static string[] ExchangeOfRetailerColumnName = { "LOAD_NO", "SALESNAME", "CHANGE_REASON_NAME", "PROVINCE", "CITY", "CONSUMER_TYPE", "CREATE_DATE", "STATE_FLAG" };
        private static string[] RoleFunctionTitleName = { "��ɫ����", "��ɫ����", "������1", "������2", "������3", "������״̬" };
        private static string[] RoleFunctionColumnName = { "role_no", "role_name", "name_1", "name_2", "name_3", "flag" };
        private static string[] CardOfCustomerTitleName = { "�ƻ�����", "���۴���", "��������", "��������", "��֤����", "��д��֤����", "�Ƶ�����", "�ƻ�״̬" };
        private static string[] CardOfCustomerColumnName = { "LOAD_NO", "SALESNAME", "RECEIVING_CAUSE_NAME", "PROMOTION_TYPE", "CARD_COUNT", "NUM", "CREATE_DATE", "STATE_FLAG" };
        private static string[] UserCardRecordTitleName = { "�ƻ�����","�ͷ���������", "���۴���", "��������", "��������", "��֤����", "��д��֤����", "�Ƶ�����", "�ƻ�״̬", "��ע"};
        private static string[] UserCardRecordColumnName = { "LOAD_NO", "warehouse_name","SALESNAME", "RECEIVING_CAUSE_NAME", "PROMOTION_TYPE", "CARD_COUNT", "NUM", "CREATE_DATE", "STATE_FLAG", "MEMO"};
        private static string[] CardTypeReportTitleName = { "��Ƭ����", "���۴���", "����" };
        private static string[] CardTypeReportColumnName = { "CART_TYPE", "USER_NAME", "CARD_QTY" };
        //�̵�
        private static string[] InventoryAddTitleName ={ "�̵㵥��", "�̵�ֿ����", "�̵�ֿ�", "��Ʒ����", "��Ʒ����", "��ƷSN��", "����", "Ч��", "���", "����" };
        private static string[] InventoryAddColumnName ={ "CHECK_NO", "warehouse_code", "WAREHOUSE_NAME", "PRODUCT_CODE", "PRODUCT_NAME", "SERIAL_NUMBER", "Lot_Number", "Exp_Date", "Unit", "PRODUCT_QUANTITY" };

        private static string[] ReportTitle ={ "�̵㵥��", "�̵�ֿ����", "�̵�ֿ�", "��Ʒ����", "��Ʒ����", "���", "ʵ������", "�ƻ�����", "�̵�״��" };
        private static string[] ReportColumnName ={ "checkNo", "check_Wh", "WH_NAME", "Product_Code", "Pro_Name", "unit", "FactQuantity", "planQuantity", "state" };//Product_name

        private static string[] FactTitle ={ "�̵�ֿ����", "�̵�ֿ�", "��Ʒ����", "��Ʒ����", "��ƷSN��", "����", "Ч��", "���", "ʵ������" };
        private static string[] FactColumnName ={ "check_Wh", "WH_NAME", "Product_Code", "Product_name", "serial_number", "lot_number", "exp_date", "unit", "FactQuantity" };

        private static string[] PlanTitle ={ "�̵㵥��", "�̵�ֿ����", "�̵�ֿ�", "��Ʒ����", "��Ʒ����","��ƷSN��","����","Ч��", "���", "�ƻ�����" };
        private static string[] PlanColumnName ={ "checkNo", "check_Wh", "WH_NAME", "Product_Code", "Product_name", "serial_number", "lot_number", "exp_date", "unit", "planQuantity", };

        private static string[] RetailerExchangeMoneyDifferenceTitleName ={ "��������", "���۴���", "�Ƶ�����", "�ƻ�״̬", "�������", "������" };
        private static string[] RetailerExchangeMoneyDifferenceColumnName ={ "LOAD_NO", "SALESMAN", "CREATE_DATE", "STATE_FLAG", "NewMoney", "OldMoney" };

        private static string[] DispatchDetailReportTitleName ={ "���ȵ���", "�Ƶ���", "�����ֿ�", "Ŀ�Ĳֿ�", "Ԥ������", "Ԥ������", "�Ƶ�����", "��Ʒ����", "��Ʒ����", "����", "Ч��", "���", "��������", "�������" };
        private static string[] DispatchDetailReportColumnName ={ "LOAD_NO", "USER_NAME", "WAREHOUSE_NAME_OUT", "WAREHOUSE_NAME_IN", "EXPECT_LEAVING_TIME", "EXPECT_ARRIVING_TIME", "CREATE_DATE", "PRODUCT_CODE", "PRODUCT_NAME", "LOT_NUMBER", "EXP_DATE", "PRODUCT_UNIT_NAME", "PRODUCT_QUANTITY_S", "PRODUCT_QUANTITY_R" };


        private static string[] DispatchDetailReportTitleNameSN ={ "���ȵ���", "�Ƶ���", "�����ֿ�", "Ŀ�Ĳֿ�", "Ԥ������", "Ԥ������", "��������", "����״̬", "����״̬", "���״̬", "�Ƶ�����", "SN��", "��Ʒ����", "��Ʒ����", "����", "Ч��", "���", "��������", "�������" };
        private static string[] DispatchDetailReportColumnNameSN ={ "LOAD_NO", "USER_NAME", "WAREHOUSE_NAME_OUT", "WAREHOUSE_NAME_IN", "EXPECT_LEAVING_TIME", "EXPECT_ARRIVING_TIME", "PLAN_TYPE_NAME", "STATE_FLAG_PP", "STATE_FLAG_S", "STATE_FLAG_R", "CREATE_DATE", "SERIAL_NUMBER", "PRODUCT_CODE", "PRODUCT_NAME", "LOT_NUMBER", "EXP_DATE", "PRODUCT_UNIT_NAME", "PRODUCT_QUANTITY_S", "PRODUCT_QUANTITY_R" };


        private static string[] SnOperateRepeatTitleName ={ "SN��", "����ģ��", "��������", "������", "����ʱ��", "�ظ�����ģ��", "�ظ���������", "�ظ�������", "�ظ�����ʱ��"};
        private static string[] SnOperateRepeatColumnName ={ "SN_NO", "NEW_MODULE", "NEW_TYPE", "NEW_OPERATION", "NEW_TIME", "OLD_MODULE", "OLD_TYPE", "OLD_OPERATION", "OLD_TIME" };
        

        #endregion


        #region ����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="exportName"></param>
        public static void DownloadExcel(DataTable table, Stream stream,string type,string exportName)
        {
            switch (type)
            {
                case "Inventory":
                    {
                        Export(table, stream, exportName, InventoryTitleName, InventoryColumnName);
                        break;
                    }
                case "InventoryAdd":
                    {
                        Export(table, stream, exportName, InventoryAddTitleName, InventoryAddColumnName);
                        break;
                    }
                case "InventoryProduct":
                    {
                        Export(table, stream, exportName, InventoryProductTitleName, InventoryProductColumnName);
                        break;
                    }
                case "SNOprator":
                    {
                        Export(table,stream,exportName,SNTitleName,SNColumnName);
                        break;
                    }
                case "ReceiveHistory":
                    {
                        ExportDate(table, stream, exportName, ReceiveHistoryTitleName, ReceiveHistoryColumnName);
                        break;
                    }
                case "ShippingHistory":
                    {
                        ExportDate(table, stream, exportName, ShippingHistoryTitleName, ShippingHistoryColumnName);
                        break;
                    }
                case "ProgramPlan":
                    {
                        ExportDate(table, stream, exportName, ProgramPlanTitleName, ProgramPlanColumnName);
                        break;
                    }
                case "DimSalesLimit":
                    {
                        Export(table, stream, exportName, DimSalesLimitTitleName, DimSalesLimitColumnName);
                        break;
                    }
                case "DimLimitOperate":
                    {
                        Export(table, stream, exportName, DimLimitOperateTitleName, DimLimitOperateColumnName);
                        break;
                    }
                case "DimUser":
                    {
                        ExportDate(table, stream, exportName, DimUserTitleName, DimUserColumnName);
                        break;
                    }
                case "DimSplit":
                    {
                        ExportDate(table, stream, exportName, DimSplitTitleName, DimSplitColumnName);
                        break;
                    }
                case "ReceivingPlan":
                    {
                        ExportDate(table, stream, exportName, ReceivingPlanTitleName, ReceivingPlanColumnName);
                        break;
                    }
                case "ShippingPlan":
                    {
                        ExportDate(table, stream, exportName, ShippingPlanTitleName, ShippingPlanColumnName);
                        break;
                    }
                case "ExchangeOldMachine":
                    {
                        ExportDate(table, stream, exportName, ExchangeOldMachineTitleName, ExchangeOldMachineColumnName);
                        break;
                    }
                case "CenterShipping":
                    {
                        ExportDate(table, stream, exportName, CenterShippingTitleName, CenterShippingColumnName);
                        break;
                    }
                case "ExchangeOfRetailer":
                    {
                        ExportDate(table, stream, exportName, ExchangeOfRetailerTitleName, ExchangeOfRetailerColumnName);
                        break;
                    }
                case "RoleFunction":
                    {
                        ExportDate(table, stream, exportName, RoleFunctionTitleName, RoleFunctionColumnName);
                        break;
                    }
                case "InvertoryByExpDateReport":
                    {
                        new ExcelExport(table, stream, exportName).InvertoryByExpDateReport();
                        break;
                    }
                case "InvertoryReceiveInReport":
                    {
                        new ExcelExport(table, stream, exportName).InvertoryReceiveInReport();
                        break;
                    }
                case "CenterChangeResonReport":
                    {
                        new ExcelExport(table, stream, exportName).CenterChangeResonReport();
                        break;
                    }
                case "CenterCenterOperatorReport":
                    {
                        new ExcelExport(table, stream, exportName).CenterCenterOperatorReport();
                        break;
                    }
                case "CenterSalesManOperatorReport":
                    {
                        new ExcelExport(table, stream, exportName).CenterSalesManOperatorReport();
                        break;
                    }
                case "CenterProductOperatorReport":
                    {
                        new ExcelExport(table, stream, exportName).CenterProductOperatorReport();
                        break;
                    }
                case "YYShipHistoryReport":
                    {
                        new ExcelExport(table, stream, exportName).YYShipHistoryReport();
                        break;
                    }
                case "CardOfCustomer":
                    {
                        ExportDate(table, stream, exportName, CardOfCustomerTitleName, CardOfCustomerColumnName);
                        break;
                    }
                case "UserCardRecord":
                    {
                        ExportDate(table, stream, exportName, UserCardRecordTitleName, UserCardRecordColumnName);
                        break;
                    }
                case "CardTypeReport":
                    {
                        ExportDate(table, stream, exportName, CardTypeReportTitleName, CardTypeReportColumnName);
                        break;
                    }
                case "RetailerExchangeMoneyDifferenceReport":
                    {
                        ExportDate(table, stream, exportName, RetailerExchangeMoneyDifferenceTitleName, RetailerExchangeMoneyDifferenceColumnName);
                        break;
                    }
                case "SnOperateRepeatReport":
                    {
                        ExportDate(table, stream, exportName, SnOperateRepeatTitleName, SnOperateRepeatColumnName);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion


        #region ������ϸ����(2012-11-8)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <param name="exportName"></param>
        public static void DownloadExcel02(DataTable table, DataTable table02, Stream stream, string type, string exportName, string exportName02)
        {
            switch (type)
            {
                case "DispatchDetailReport":
                    {
                        Export02(table, table02, stream, exportName, exportName02, DispatchDetailReportTitleName, DispatchDetailReportColumnName, DispatchDetailReportTitleNameSN, DispatchDetailReportColumnNameSN);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        #region ������ϸ������
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="table"></param>
        /// <param name="titleName"></param>
        /// <param name="columnName"></param>
        /// <param name="stream"></param>
        public static void Export02(DataTable table, DataTable table02, Stream stream, string exportName, string exportName02, string[] titleName, string[] columnName, string[] titleNameSN, string[] columnNameSN)
        {
            Workbook excel = new Workbook();
            Worksheet worksheet = excel.Worksheets[0];
            worksheet.Name = exportName;
            Cells cells = worksheet.Cells;
            Cell cell = null;

            Worksheets sheets = excel.Worksheets;
            sheets.Add(exportName02);
            Worksheet worksheet1 = excel.Worksheets[1];
            Cells cells1 = worksheet1.Cells;
            Cell cell1 = null;

            Style styleTitle = excel.Styles[excel.Styles.Add()];
            styleTitle.Font.IsBold = true;
            styleTitle.Font.Size = 14;
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;

            Style styleHead = excel.Styles[excel.Styles.Add()];
            styleHead.Font.IsBold = true;
            styleHead.Font.Size = 12;
            styleHead.HorizontalAlignment = TextAlignmentType.Center;

            Style styleLeft = excel.Styles[excel.Styles.Add()];
            styleLeft.Font.IsBold = true;
            styleLeft.Font.Size = 12;
            styleLeft.HorizontalAlignment = TextAlignmentType.Left;

            Style styleDetail = excel.Styles[excel.Styles.Add()];
            styleDetail.HorizontalAlignment = TextAlignmentType.Center;
            styleHead.Font.Size = 10;

            for (int i = 0; i < titleName.Length; i++)
            {
                cell = cells[0, i];
                cell.Style = styleTitle;
                cell.PutValue(exportName);
            }

            cells.SetRowHeight(0, 25);
            worksheet.Cells.Merge(0, 0, 1, titleName.Length);


            cells.SetRowHeight(1, 20);
            cell = cells[1, 0];
            cell.Style = styleLeft;
            cell.PutValue("�������ڣ�" + System.DateTime.Now.ToString("yyyy-MM-dd"));
            worksheet.Cells.Merge(1, 0, 1, titleName.Length);

            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cell = cells[2, i];
                cell.Style = styleHead;
                cell.PutValue(titleName[i]);
            }

            worksheet.FreezePanes(3, 0, 3, titleName.Length);

            //Detail
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                for (int k = 0; k < columnName.Length; k++)
                {
                    cell = cells[(i + 3), k];
                    cell.Style = styleDetail;
                    string column = columnName[k];
                    if (column == "ID" || column == "START_YEAR" || column == "DEPRECIATION_YEAR" || column == "EXAM_MONTH" || column == "VH_CAPACITY")
                    {
                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                            cell.PutValue(int.Parse(row[column].ToString()));
                        }
                    }
                    else if (column == "CONFIG_FEE")
                    {
                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                            cell.PutValue(double.Parse(row[column].ToString()).ToString("f1"));
                        }
                    }
                    else if (table.Columns[column].DataType == typeof(Decimal))
                    {
                        cell.Style.Number = 2;
                        cell.PutValue(row[column]);
                    }
                    else if (table.Columns[column].DataType == typeof(DateTime))
                    {
                        //cell.Style.Number = 22;
                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                            //DateTime exp_date = Convert.ToDateTime(row[column]);
                            string exp_date = Convert.ToDateTime(row[column]).ToShortDateString();
                            cell.PutValue(exp_date);
                        }
                    }
                    else
                    {
                        cell.PutValue(row[column]);
                    }
                }

            }
            for (int i = 0; i < titleNameSN.Length; i++)
            {
                cell1 = cells1[0, i];
                cell1.Style = styleTitle;
                cell1.PutValue(exportName02);
            }

            cells1.SetRowHeight(0, 25);
            worksheet1.Cells.Merge(0, 0, 1, titleNameSN.Length);


            cells1.SetRowHeight(1, 20);
            cell1 = cells1[1, 0];
            cell1.Style = styleLeft;
            cell1.PutValue("�������ڣ�" + System.DateTime.Now.ToString("yyyy-MM-dd"));
            worksheet1.Cells.Merge(1, 0, 1, titleNameSN.Length);

            //Head
            cells1.SetRowHeight(2, 20);
            for (int i = 0; i < titleNameSN.Length; i++)
            {
                cell1 = cells1[2, i];
                cell1.Style = styleHead;
                cell1.PutValue(titleNameSN[i]);
            }

            worksheet1.FreezePanes(3, 0, 3, titleNameSN.Length);

            //Detail
            for (int i = 0; i < table02.Rows.Count; i++)
            {
                DataRow row = table02.Rows[i];

                for (int k = 0; k < columnNameSN.Length; k++)
                {
                    cell1 = cells1[(i + 3), k];
                    cell1.Style = styleDetail;
                    string column = columnNameSN[k];
                    if (column == "ID" || column == "START_YEAR" || column == "DEPRECIATION_YEAR" || column == "EXAM_MONTH" || column == "VH_CAPACITY")
                    {
                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                            cell1.PutValue(int.Parse(row[column].ToString()));
                        }
                    }
                    else if (column == "CONFIG_FEE")
                    {
                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                            cell1.PutValue(double.Parse(row[column].ToString()).ToString("f1"));
                        }
                    }
                    else if (table02.Columns[column].DataType == typeof(Decimal))
                    {
                        cell1.Style.Number = 2;
                        cell1.PutValue(row[column]);
                    }
                    else if (table02.Columns[column].DataType == typeof(DateTime))
                    {
                        //cell.Style.Number = 22;
                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                            //DateTime exp_date = Convert.ToDateTime(row[column]);
                            string exp_date = Convert.ToDateTime(row[column]).ToShortDateString();
                            cell1.PutValue(exp_date);
                        }
                    }
                    else
                    {
                        cell1.PutValue(row[column]);
                    }
                }

            }



            worksheet.AutoFitRows();
            worksheet1.AutoFitRows();
            excel.Save(stream, FileFormatType.Excel2007Xlsx);

        }
        #endregion 

        #region ����
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="table"></param>
        /// <param name="titleName"></param>
        /// <param name="columnName"></param>
        /// <param name="stream"></param>
        public static void Export(DataTable table,Stream stream,string exportName, string[] titleName, string[] columnName)
        {
           
            Workbook excel = new Workbook();
            Worksheet worksheet = excel.Worksheets[0];
            worksheet.Name = exportName;
            Cells cells = worksheet.Cells;
            Cell cell = null;


            Style styleTitle = excel.Styles[excel.Styles.Add()];
            styleTitle.Font.IsBold = true;
            styleTitle.Font.Size = 14;
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;

            Style styleHead = excel.Styles[excel.Styles.Add()];
            styleHead.Font.IsBold = true;
            styleHead.Font.Size = 12;
            styleHead.HorizontalAlignment = TextAlignmentType.Center;

            Style styleLeft = excel.Styles[excel.Styles.Add()];
            styleLeft.Font.IsBold = true;
            styleLeft.Font.Size = 12;
            styleLeft.HorizontalAlignment = TextAlignmentType.Left;

            Style styleDetail = excel.Styles[excel.Styles.Add()];
            styleDetail.HorizontalAlignment = TextAlignmentType.Center;
            styleHead.Font.Size = 10;

            for (int i = 0; i < titleName.Length; i++)
            {
                cell = cells[0, i];
                cell.Style = styleTitle;
                cell.PutValue(exportName);
            }

            cells.SetRowHeight(0, 25);
            worksheet.Cells.Merge(0, 0, 1, titleName.Length);


            cells.SetRowHeight(1, 20);
            cell = cells[1, 0];
            cell.Style = styleLeft;
            cell.PutValue("�������ڣ�" + System.DateTime.Now.ToString("yyyy-MM-dd"));
            worksheet.Cells.Merge(1, 0, 1, titleName.Length);

            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cell = cells[2, i];
                cell.Style = styleHead;
                cell.PutValue(titleName[i]);
            }

            worksheet.FreezePanes(3, 0, 3, titleName.Length);

            //Detail
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                for (int k = 0; k < columnName.Length; k++)
                {
                    cell = cells[(i + 3), k];
                    cell.Style = styleDetail;
                    string column = columnName[k];

					if(table.Columns[column].DataType == typeof(Decimal))
					{
						cell.Style.Number = 1;
						cell.PutValue(row[column]);
					}
                    else if (table.Columns[column].DataType == typeof(DateTime))
                    {
                        //cell.Style.Number = 22;
                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                           // DateTime exp_date = Convert.ToDateTime(row[column]);
                            string exp_date = Convert.ToDateTime(row[column]).ToShortDateString();
                            cell.PutValue(exp_date);
                        }
                    }
                    else
                    {
                        cell.PutValue(row[column]);
                    }
                }

            }

            excel.Save(stream, FileFormatType.Excel2007Xlsx);

        }

        #region ����ʱ�����ʱ����
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="table"></param>
        /// <param name="titleName"></param>
        /// <param name="columnName"></param>
        /// <param name="stream"></param>
        public static void Export(DataTable table, Stream stream, string exportName, string[] titleName, string[] columnName, bool operDate)
        {

            Workbook excel = new Workbook();
            Worksheet worksheet = excel.Worksheets[0];
            worksheet.Name = exportName;
            Cells cells = worksheet.Cells;
            Cell cell = null;
            Style styleTitle = excel.Styles[excel.Styles.Add()];
            styleTitle.Font.IsBold = true;
            styleTitle.Font.Size = 14;
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;
            Style styleHead = excel.Styles[excel.Styles.Add()];
            styleHead.Font.IsBold = true;
            styleHead.Font.Size = 12;
            styleHead.HorizontalAlignment = TextAlignmentType.Center;
            Style styleLeft = excel.Styles[excel.Styles.Add()];
            styleLeft.Font.IsBold = true;
            styleLeft.Font.Size = 12;
            styleLeft.HorizontalAlignment = TextAlignmentType.Left;
            Style styleDetail = excel.Styles[excel.Styles.Add()];
            styleDetail.HorizontalAlignment = TextAlignmentType.Center;
            styleHead.Font.Size = 10;
            for (int i = 0; i < titleName.Length; i++)
            {
                cell = cells[0, i];
                cell.Style = styleTitle;
                cell.PutValue(exportName);
            }
            cells.SetRowHeight(0, 25);
            worksheet.Cells.Merge(0, 0, 1, titleName.Length);
            cells.SetRowHeight(1, 20);
            cell = cells[1, 0];
            cell.Style = styleLeft;
            cell.PutValue("�������ڣ�" + System.DateTime.Now.ToString("yyyy-MM-dd"));
            worksheet.Cells.Merge(1, 0, 1, titleName.Length);
            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cell = cells[2, i];
                cell.Style = styleHead;
                cell.PutValue(titleName[i]);
            }
            worksheet.FreezePanes(3, 0, 3, titleName.Length);
            //Detail
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                for (int k = 0; k < columnName.Length; k++)
                {
                    cell = cells[(i + 3), k];
                    cell.Style = styleDetail;
                    string column = columnName[k];

                    if (table.Columns[column].DataType == typeof(Decimal))
                    {
                        cell.Style.Number = 1;
                        cell.PutValue(row[column]);
                    }
                    else if (table.Columns[column].DataType == typeof(DateTime))
                    {
                        //cell.Style.Number = 22;
                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                            // DateTime exp_date = Convert.ToDateTime(row[column]);
                            string exp_date = Convert.ToDateTime(row[column]).ToString();
                            cell.PutValue(exp_date);
                        }
                    }
                    else
                    {
                        cell.PutValue(row[column]);
                    }
                }
            }
            excel.Save(stream, FileFormatType.Excel2007Xlsx);
        }
        #endregion

        //�̵㵼��
        public static void ExportSheet(DataTable table1, DataTable table2,DataTable table3, Stream stream, string exportName1, string exportName2,string exportName3)
        {
            string[] titleName=null;
            string[] columnName = null;
            Workbook excel = new Workbook();
            DataTable table = new DataTable();
            for (int j = 0; j <3; j++)
            {
                Worksheet worksheet = null;
              
                if (j == 0)
                {
                    titleName = ReportTitle;
                    columnName = ReportColumnName;
                    table = table1;
                    worksheet = excel.Worksheets[0];
                    worksheet.Name = exportName1;
                }
                else if (j == 1)
                {
                    titleName = FactTitle;
                    columnName = FactColumnName;
                    table = table2;
                    worksheet = excel.Worksheets.Add(exportName2);
                }
                else
                {
                    titleName = PlanTitle;
                    columnName = PlanColumnName;
                    
                    table = table3;
                    worksheet = excel.Worksheets.Add(exportName3);
                }

                Cells cells = worksheet.Cells;
                Cell cell = null;

                Style styleTitle = excel.Styles[excel.Styles.Add()];
                styleTitle.Font.IsBold = true;
                styleTitle.Font.Size = 14;
                styleTitle.HorizontalAlignment = TextAlignmentType.Center;

                Style styleHead = excel.Styles[excel.Styles.Add()];
                styleHead.Font.IsBold = true;
                styleHead.Font.Size = 12;
                styleHead.HorizontalAlignment = TextAlignmentType.Center;

                Style styleLeft = excel.Styles[excel.Styles.Add()];
                styleLeft.Font.IsBold = true;
                styleLeft.Font.Size = 12;
                styleLeft.HorizontalAlignment = TextAlignmentType.Left;

                Style styleDetail = excel.Styles[excel.Styles.Add()];
                styleDetail.HorizontalAlignment = TextAlignmentType.Center;
                styleHead.Font.Size = 10;


                for (int i = 0; i < titleName.Length; i++)
                {
                    cell = cells[0, i];
                    cell.Style = styleHead;
                    cell.PutValue(titleName[i]);
                }
                if (table != null && table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow row = table.Rows[i];

                        for (int k = 0; k < columnName.Length; k++)
                        {
                            cell = cells[(i + 1), k];
                            cell.Style = styleDetail;
                            string column = columnName[k];


                            if (table.Columns[column].DataType == typeof(Decimal))
                            {
                                if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                                {
                                    cell.Style.Number = 1;
                                    cell.PutValue(row[column]);
                                }
                            }
                            else if (table.Columns[column].DataType == typeof(DateTime))
                            {
                                //cell.Style.Number = 22;
                                if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                                {
                                    //DateTime exp_date = Convert.ToDateTime(row[column]);
                                    string exp_date = Convert.ToDateTime(row[column]).ToShortDateString();
                                    cell.PutValue(exp_date);
                                }
                            }
                            else
                            {
                                cell.PutValue(row[column]);
                            }
                            
                        }

                    }
                }

            }

            excel.Save(stream, FileFormatType.Excel2007Xlsx);
        }


        /// <summary>
        /// �����ݵ�����EXCEL,���ĳһ���Ǳ�ʾʱ��ʱ������ʱ����ʾΪ��YYYY-MM-DD������ʽ��
        /// </summary>
        /// <param name="table"></param>
        /// <param name="stream"></param>
        /// <param name="exportName"></param>
        /// <param name="titleName"></param>
        /// <param name="columnName"></param>
        //�޸��ˣ�������
        //ʱ�䣺2009-05-04
        public static void ExportDate(DataTable table, Stream stream, string exportName, string[] titleName, string[] columnName)
        {

            Workbook excel = new Workbook();
            Worksheet worksheet = excel.Worksheets[0];
            worksheet.Name = exportName;
            Cells cells = worksheet.Cells;
            Cell cell = null;


            Style styleTitle = excel.Styles[excel.Styles.Add()];
            styleTitle.Font.IsBold = true;
            styleTitle.Font.Size = 14;
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;

            Style styleHead = excel.Styles[excel.Styles.Add()];
            styleHead.Font.IsBold = true;
            styleHead.Font.Size = 12;
            styleHead.HorizontalAlignment = TextAlignmentType.Center;

            Style styleLeft = excel.Styles[excel.Styles.Add()];
            styleLeft.Font.IsBold = true;
            styleLeft.Font.Size = 12;
            styleLeft.HorizontalAlignment = TextAlignmentType.Left;

            Style styleDetail = excel.Styles[excel.Styles.Add()];
            styleDetail.HorizontalAlignment = TextAlignmentType.Center;
            styleHead.Font.Size = 10;

            for (int i = 0; i < titleName.Length; i++)
            {
                cell = cells[0, i];
                cell.Style = styleTitle;
                cell.PutValue(exportName);
            }

            cells.SetRowHeight(0, 25);
            worksheet.Cells.Merge(0, 0, 1, titleName.Length);


            cells.SetRowHeight(1, 20);
            cell = cells[1, 0];
            cell.Style = styleLeft;
            cell.PutValue("�������ڣ�" + System.DateTime.Now.ToString("yyyy-MM-dd"));
            worksheet.Cells.Merge(1, 0, 1, titleName.Length);

            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cell = cells[2, i];
                cell.Style = styleHead;
                cell.PutValue(titleName[i]);
            }

            worksheet.FreezePanes(3, 0, 3, titleName.Length);

            //Detail
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                for (int k = 0; k < columnName.Length; k++)
                {
                    cell = cells[(i + 3), k];
                    cell.Style = styleDetail;
                    string column = columnName[k];
                    
                    if (table.Columns[column].DataType == typeof(Decimal))
                    {
                        cell.Style.Number = 1;
                        cell.PutValue(row[column]);
                    }
                    else if (table.Columns[column].DataType == typeof(DateTime))
                    {
                        //cell.Style.Number = 22;
                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                            //DateTime exp_date = Convert.ToDateTime(row[column]);
                            string exp_date = Convert.ToDateTime(row[column]).ToString("yyyy-MM-dd");
                            cell.PutValue(exp_date);
                        }
                    }
                    else
                    {
                        cell.PutValue(row[column]);
                    }
                }

            }

            excel.Save(stream, FileFormatType.Excel2007Xlsx);

        }
        #endregion


        /// <summary>
        /// ����VBAExcel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <param name="exportName"></param>

        public static void ExportVBA(DataTable table, Stream stream, string filename, string exportName,string type)
        {
            switch (type)
            {
                case "InventoryProduct":
                    {
                        ExportVBA(table, stream, filename,  exportName, InventoryProductTitleName, InventoryProductColumnName);
                        break;
                    }
                case "YYShipHistoryReport":
                {
                    ExportVBA(table, stream, filename, exportName, ShippingHistoryTitleName, ShippingHistoryColumnName);
                    break;
                }
                    default:
                    break;
            }
            
        }
        /// <summary>
        /// ����VBAExcel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <param name="exportName"></param>
        /// <param name="titleName"></param>
        /// <param name="columnName"></param>
        public static void ExportVBA(DataTable table, Stream stream,string filename, string exportName, string[] titleName, string[] columnName)
        {
           
            Workbook excel = new Workbook();
           excel.Open(filename, FileFormatType.Excel2007Xlsx);
            Worksheet worksheet = excel.Worksheets[0];
            worksheet.Name = exportName;
            Cells cells = worksheet.Cells;
            Cell cell = null;


            Style styleTitle = excel.Styles[excel.Styles.Add()];
            styleTitle.Font.IsBold = true;
            styleTitle.Font.Size = 14;
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;

            Style styleHead = excel.Styles[excel.Styles.Add()];
            styleHead.Font.IsBold = true;
            styleHead.Font.Size = 12;
            styleHead.HorizontalAlignment = TextAlignmentType.Center;

            Style styleLeft = excel.Styles[excel.Styles.Add()];
            styleLeft.Font.IsBold = true;
            styleLeft.Font.Size = 12;
            styleLeft.HorizontalAlignment = TextAlignmentType.Left;

            Style styleDetail = excel.Styles[excel.Styles.Add()];
            styleDetail.HorizontalAlignment = TextAlignmentType.Center;
            styleHead.Font.Size = 10;

            for (int i = 0; i < titleName.Length; i++)
            {
                cell = cells[0, i];
                cell.Style = styleTitle;
                cell.PutValue(exportName);
            }

            cells.SetRowHeight(0, 25);
            worksheet.Cells.Merge(0, 0, 1, titleName.Length);


            cells.SetRowHeight(1, 20);
            cell = cells[1, 0];
            cell.Style = styleLeft;
            cell.PutValue("�������ڣ�" + System.DateTime.Now.ToString("yyyy-MM-dd"));
            worksheet.Cells.Merge(1, 0, 1, titleName.Length);

            //Head
            cells.SetRowHeight(2, 20);
            for (int i = 0; i < titleName.Length; i++)
            {
                cell = cells[2, i];
                cell.Style = styleHead;
                cell.PutValue(titleName[i].ToString());
            }

            worksheet.FreezePanes(3, 0, 3, titleName.Length);

            //Detail
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                for (int k = 0; k < columnName.Length; k++)
                {
                    cell = cells[(i + 3), k];
                    cell.Style = styleDetail;
                    string column = columnName[k];

                    if (table.Columns[column].DataType == typeof(Decimal))
                    {
						
                        cell.Style.Number = 1;
                        cell.PutValue(row[column]);
                    }
                    else if (table.Columns[column].DataType == typeof(DateTime))
                    {
                        //cell.Style.Number = 22;
                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                            string exp_date = Convert.ToDateTime(row[column]).ToShortDateString();
                            cell.PutValue(exp_date);
                        }
                    }
                    else
                    {
                        cell.PutValue(row[column].ToString(),false);
                    }
                }

            }
			worksheet.ClearComments();
            excel.Save(stream, FileFormatType.Excel2007Xlsx);

        }
        /// <summary>
        /// ����VBAExcel���ͻ���Ƭ�Ǽ���ϸ���߱��������ã�
        /// </summary>
        /// <param name="table"></param>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <param name="exportName"></param>
        /// <param name="columnName"></param>
        public static void ExportVBAExcel(DataTable table, Stream stream, string filename, string exportName, string[] columnName, string SavePath, string fiename)
        {
            Workbook excel = new Workbook();
            excel.Open(filename, FileFormatType.Excel2007Xlsx);

            Worksheet worksheet = excel.Worksheets[0];
            worksheet.Name = exportName;
            Cells cells = worksheet.Cells;
            Cell cell = null;

            Style styleTitle = excel.Styles[excel.Styles.Add()];
            styleTitle.Font.IsBold = true;
            styleTitle.Font.Size = 14;
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;

            Style styleHead = excel.Styles[excel.Styles.Add()];
            styleHead.Font.IsBold = true;
            styleHead.Font.Size = 12;
            styleHead.HorizontalAlignment = TextAlignmentType.Center;

            Style styleLeft = excel.Styles[excel.Styles.Add()];
            styleLeft.Font.IsBold = true;
            styleLeft.Font.Size = 12;
            styleLeft.HorizontalAlignment = TextAlignmentType.Left;

            Style styleDetail = excel.Styles[excel.Styles.Add()];
            styleDetail.HorizontalAlignment = TextAlignmentType.Center;
            styleHead.Font.Size = 10;

            //Detail
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                for (int k = 0; k < columnName.Length; k++)
                {
                    cell = cells[(i + 2), k];
                    cell.Style = styleDetail;
                    string column = columnName[k];

                    if (table.Columns[column] != null)
                    {

                        if (table.Columns[column].DataType == typeof(Decimal))
                        {
                            cell.Style.Number = 1;
                            cell.PutValue(row[column]);
                        }
                        else if (table.Columns[column].DataType == typeof(DateTime))
                        {

                            if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                            {
                                string exp_date = Convert.ToDateTime(row[column]).ToString("yyyy-MM-dd");
                                cell.PutValue(exp_date);
                            }
                        }
                        else
                        {
                            cell.PutValue(row[column].ToString(), false);
                        }
                    }
                }

            }
            worksheet.ClearComments();

            string path = SavePath + fiename;
            excel.Save(@path, FileFormatType.Excel2007Xlsx);

        }


        /// <summary>
        /// ����VBAExcel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <param name="exportName"></param>
        /// <param name="columnName"></param>
        public static void ExportVBA(DataTable table, Stream stream, string filename, string exportName, string[] columnName)
        {

            Workbook excel = new Workbook();
            excel.Open(filename, FileFormatType.Excel2007Xlsx);

            Worksheet worksheet = excel.Worksheets[0];
            worksheet.Name = exportName;
            Cells cells = worksheet.Cells;
            Cell cell = null;

            Style styleTitle = excel.Styles[excel.Styles.Add()];
            styleTitle.Font.IsBold = true;
            styleTitle.Font.Size = 14;
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;

            Style styleHead = excel.Styles[excel.Styles.Add()];
            styleHead.Font.IsBold = true;
            styleHead.Font.Size = 12;
            styleHead.HorizontalAlignment = TextAlignmentType.Center;

            Style styleLeft = excel.Styles[excel.Styles.Add()];
            styleLeft.Font.IsBold = true;
            styleLeft.Font.Size = 12;
            styleLeft.HorizontalAlignment = TextAlignmentType.Left;

            Style styleDetail = excel.Styles[excel.Styles.Add()];
            styleDetail.HorizontalAlignment = TextAlignmentType.Center;
            styleHead.Font.Size = 10;

            //Detail
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                for (int k = 0; k < columnName.Length; k++)
                {
                    cell = cells[(i + 2), k];
                    cell.Style = styleDetail;
                    string column = columnName[k];

					if(table.Columns[column].DataType == typeof(Decimal))
					{
						cell.Style.Number = 1;
						cell.PutValue(row[column]);
					}
                    else if (table.Columns[column].DataType == typeof(DateTime))
                    {

                        if (row[column] != DBNull.Value && row[column].ToString() != string.Empty)
                        {
                            string exp_date = Convert.ToDateTime(row[column]).ToString("yyyy-MM-dd");
                            cell.PutValue(exp_date);
                        }
                    }
                    else
                    {
                        cell.PutValue(row[column].ToString(),false);
                    }
                }

            }
			worksheet.ClearComments();

            excel.Save(stream, FileFormatType.Excel2007Xlsx);

        }
    }
}
