using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    /// <summary>
    /// 需要校验的文本框控件属性类
    /// </summary>
    public class TextBoxProperty
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="textboxId">文本框控件ID</param>
        /// <param name="required">是否必须</param>
        /// <param name="requiredMessageId">必填出错的信息ID</param>
        /// <param name="maxLength">最大长度</param>
        /// <param name="lengthMessageId">超出最大长度的信息ID</param>
        internal TextBoxProperty(string textboxId, bool required, string requiredMessageId, int maxLength, string lengthMessageId)
        {
            this.textboxid = textboxId;
            this.required = required;
            this.requiredmessageid = requiredMessageId;
            this.maxlength = maxLength;
            this.lengthmessageid = lengthMessageId;
            this.typepattern = string.Empty;
            this.typemessageid = string.Empty;
        }

        private string textboxid;
        /// <summary>
        /// 文本框ID
        /// </summary>
        public string TextBoxId
        {
            set { textboxid = value; }
            get { return textboxid; }
        }

        private bool required;
        /// <summary>
        /// 是否必填
        /// </summary>
        public bool Required
        {
            set { required = value; }
            get { return required; }
        }

        private string requiredmessageid;
        /// <summary>
        /// 必填出错的信息ID
        /// </summary>
        public string RequiredMessageId
        {
            set { requiredmessageid = value; }
            get { return requiredmessageid; }
        }

        private int maxlength;
        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength
        {
            set { maxlength = value; }
            get { return maxlength; }
        }

        private string lengthmessageid;
        /// <summary>
        /// 超出最大长度的信息ID
        /// </summary>
        public string LengthMessageId
        {
            set { lengthmessageid = value; }
            get { return lengthmessageid; }
        }

        private string typepattern;
        /// <summary>
        /// 类型的正则表达式
        /// </summary>
        public string TypePattern
        {
            set { typepattern = value; }
            get { return typepattern; }
        }

        private string typemessageid;
        /// <summary>
        /// 类型校验出错的信息ID
        /// </summary>
        public string TypeMessageId
        {
            set { typemessageid = value; }
            get { return typemessageid; }
        }
    }
}
