using System;
using System.Collections;
using System.Reflection;

namespace Utility
{
    /// <summary>
    /// ö���������
    /// </summary>
    internal sealed class EnumField : Attribute
    {
        private object fieldValue;
        private bool bind;
        private FieldInfo fieldInfo;
        private IList enumGroups;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="fieldValue">ö����ֵ</param>
        /// <param name="bind">�Ƿ�Ҫ�󶨵������б�ؼ�</param>
        /// <param name="enumGroups">ö������������</param>
        internal EnumField(object fieldValue, bool bind, string[] enumGroups)
        {
            this.fieldValue = fieldValue;
            this.bind = bind;
            this.enumGroups = ArrayList.Adapter(enumGroups);
        }
         
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="fieldValue">ö����ֵ</param>
        /// <param name="bind">�Ƿ�Ҫ�󶨵������б�ؼ�</param>
        internal EnumField(object fieldValue, bool bind)
            : this(fieldValue, bind, new string[] { })
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="fieldValue">ö����ֵ</param>
        /// <param name="enumGroups">��Ҫ�󶨵�����</param>
        internal EnumField(object fieldValue, string[] enumGroups)
            : this(fieldValue, true, enumGroups)
        {
        }

        /// <summary>
        /// ���캯����Ĭ����Ҫ��
        /// </summary>
        /// <param name="fieldValue">ö����ֵ</param>
        internal EnumField(object fieldValue)
            : this(fieldValue, true, new string[] { })
        {
        }

        /// <summary>
        /// ö����ֵ
        /// </summary>
        internal object FieldValue
        {
            get { return this.fieldValue; }
        }

        internal bool Bind
        {
            get { return this.bind; }
        }

        internal FieldInfo FieldInfo
        {
            get { return this.fieldInfo; }
            set { this.fieldInfo = value; }
        }

        internal IList EnumGroups
        {
            get { return this.enumGroups; }
        }
    }
}
