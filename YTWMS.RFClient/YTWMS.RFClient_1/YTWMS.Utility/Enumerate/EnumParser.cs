using System;
using System.Collections;
using System.Reflection;
using System.Web.UI.WebControls;

namespace Utility
{
    /// <summary>
    /// ö�ٵĽ�����
    /// </summary>
    public static class EnumParser
    {
        private static Hashtable cachedEnum = new Hashtable();

        /// <summary>
        /// ����ö�����͵õ���ö�ٶ��������ֵ
        /// </summary>
        /// <param name="enumType">ö������</param>
        /// <returns>ö�ٶ��������ֵ</returns>
        public static string GetEnumDescription(Type enumType)
        {
            EnumDesc[] enumDescs = (EnumDesc[])enumType.GetCustomAttributes(typeof(EnumDesc), false);
            if (enumDescs.Length != 1)
                return string.Empty;
            return enumDescs[0].Description;
        }

        /// <summary>
        /// ����ö���ֶεõ����ֶε�ֵ
        /// </summary>
        /// <param name="enumField">ö���ֶ�</param>
        /// <returns>�ֶε�ֵ</returns>
        public static object GetEnumFiledValue(object enumField)
        {
            EnumField[] enumFields = GetEnumFields(enumField.GetType());
            foreach (EnumField field in enumFields)
            {
                if (field.FieldInfo.Name == enumField.ToString())
                    return field.FieldValue;
            }
            return null;
        }

        /// <summary>
        /// ����ö�����ͺ�ĳ��ö���ֶε�ֵ�õ����ֶ�����
        /// </summary>
        /// <param name="enumType">ö������</param>
        /// <param name="enumFieldName">ö���ֶ�����</param>
        /// <returns>�ֶε�ֵ</returns>
        public static string GetEnumFiledValue(Type enumType, object enumFieldName)
        {
            EnumField[] enumFields = GetEnumFields(enumType);
            foreach (EnumField field in enumFields)
            {
                if (field.FieldInfo.Name.Equals(enumFieldName))
                    return field.FieldValue.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// ����ö�����ͺ�ĳ��ö���ֶε�ֵ�õ����ֶ�����
        /// </summary>
        /// <param name="enumType">ö������</param>
        /// <param name="enumFieldValue">ö���ֶε�ֵ</param>
        /// <returns>�ֶ�����</returns>
        public static string GetEnumFiledName(Type enumType, object enumFieldValue)
        {
            EnumField[] enumFields = GetEnumFields(enumType);
            foreach (EnumField field in enumFields)
            {
                if (field.FieldValue.Equals(enumFieldValue))
                    return field.FieldInfo.Name;
            }
            return string.Empty;
        }

        /// <summary>
        /// ����ö�����͵õ�ö����ֵ������
        /// </summary>
        /// <param name="enumType">ö������</param>
        /// <param name="enumGroup">ö������������</param>
        /// <returns>ö����ֵ��object����</returns>
        public static object[] GetEnumFiledValues(Type enumType, string enumGroup)
        {
            ArrayList fieldValues = new ArrayList();
            EnumField[] enumFields = GetEnumFields(enumType);
            foreach (EnumField field in enumFields)
            {
                if (field.EnumGroups.Contains(enumGroup))
                    fieldValues.Add(field.FieldValue);
            }
            return fieldValues.ToArray();
        }

        /// <summary>
        /// ����ö�����͵õ�ö����ֵ������
        /// </summary>
        /// <param name="enumType">ö������</param>
        /// <returns>ö����ֵ��object����</returns>
        public static object[] GetEnumFiledValues(Type enumType)
        {
            ArrayList fieldValues = new ArrayList();
            EnumField[] enumFields = GetEnumFields(enumType);
            foreach (EnumField field in enumFields)
            {
                fieldValues.Add(field.FieldValue);
            }
            return fieldValues.ToArray();
        }

        /// <summary>
        /// ����ö�ٶ��󣬰�ö�ٶ���󶨵������б�ؼ�������������Ӷ������
        /// </summary>
        /// <param name="dropdownlist">�����б�ؼ�</param>
        /// <param name="enumType">ö�ٶ�������</param>
        /// <param name="addedItemText">��������ı�</param>
        /// <param name="addedItemValue">�������ֵ</param>
        /// <param name="enumGroup">ö������������</param>
        public static void FillDropDownList(DropDownList dropdownlist, Type enumType,
            string addedItemText, string addedItemValue, string enumGroup)
        {
            EnumField[] fields = GetEnumFields(enumType);
            dropdownlist.Items.Clear();
            if (addedItemText != string.Empty)
                dropdownlist.Items.Add(new ListItem(addedItemText, addedItemValue));
            foreach (EnumField field in fields)
            {
                if (!field.Bind)
                {
                    continue;
                }
                if (enumGroup == string.Empty)
                {
                    dropdownlist.Items.Add(new ListItem(field.FieldInfo.Name, field.FieldValue.ToString()));
                }
                else
                {
                    if (field.EnumGroups.Count != 0 && field.EnumGroups.Contains(enumGroup))
                    {
                        dropdownlist.Items.Add(new ListItem(field.FieldInfo.Name, field.FieldValue.ToString()));
                    }
                }
            }
        }

        /// <summary>
        /// ����ö�ٶ��󣬰�ö�ٶ���󶨵������б�ؼ�
        /// </summary>
        /// <param name="dropdownlist">�����б�ؼ�</param>
        /// <param name="enumType">ö�ٶ�������</param>
        /// <param name="addedItemText">��������ı�</param>
        /// <param name="addedItemValue">�������ֵ</param>
        public static void FillDropDownList(DropDownList dropdownlist, Type enumType, 
            string addedItemText, string addedItemValue)
        {
            FillDropDownList(dropdownlist, enumType, addedItemText, addedItemValue, string.Empty);
        }

        /// <summary>
        /// ����ö�ٶ��󣬰�ö�ٶ���󶨵������б�ؼ�������������Ӷ������
        /// </summary>
        /// <param name="dropdownlist">�����б�ؼ�</param>
        /// <param name="enumType">ö�ٶ�������</param>
        /// <param name="bindType">�󶨵�����</param>
        public static void FillDropDownList(DropDownList dropdownlist, Type enumType, string bindType)
        {
            FillDropDownList(dropdownlist, enumType, string.Empty, string.Empty, bindType);
        }

        /// <summary>
        /// ����ö�ٶ��󣬰�ö�ٶ���󶨵������б�ؼ�
        /// </summary>
        /// <param name="dropdownlist">�����б�ؼ�</param>
        /// <param name="enumType">ö�ٶ�������</param>
        public static void FillDropDownList(DropDownList dropdownlist, Type enumType)
        {
            FillDropDownList(dropdownlist, enumType, string.Empty, string.Empty, string.Empty);
        }

        private static EnumField[] GetEnumFields(Type enumType)
        {
            EnumField[] enumFields = null;
            //������û���ҵ���ͨ���������ֶε�������Ϣ
            if (cachedEnum.Contains(enumType.FullName) == false)
            {
                FieldInfo[] fields = enumType.GetFields();
                ArrayList edAL = new ArrayList();
                foreach (FieldInfo fi in fields)
                {
                    object[] eds = fi.GetCustomAttributes(typeof(EnumField), false);
                    if (eds.Length != 1)
                        continue;
                    ((EnumField)eds[0]).FieldInfo = fi;
                    edAL.Add(eds[0]);
                }

                cachedEnum.Add(enumType.FullName, (EnumField[])edAL.ToArray(typeof(EnumField)));
            }
            enumFields = (EnumField[])cachedEnum[enumType.FullName];

            return enumFields;
        }
    }
}
