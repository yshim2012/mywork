using System;

namespace Utility
{
    /// <summary>
    /// 枚举描述属性
    /// </summary>
    internal sealed class EnumDesc : Attribute
    {
        private string description;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="description">枚举的描述值</param>
        internal EnumDesc(string description)
        {
            this.description = description;
        }

        /// <summary>
        /// 枚举的描述值
        /// </summary>
        internal string Description
        {
            get { return this.description; }
        }
    }
}
