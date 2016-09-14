using System;

namespace Utility
{
    /// <summary>
    /// ö����������
    /// </summary>
    internal sealed class EnumDesc : Attribute
    {
        private string description;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="description">ö�ٵ�����ֵ</param>
        internal EnumDesc(string description)
        {
            this.description = description;
        }

        /// <summary>
        /// ö�ٵ�����ֵ
        /// </summary>
        internal string Description
        {
            get { return this.description; }
        }
    }
}
