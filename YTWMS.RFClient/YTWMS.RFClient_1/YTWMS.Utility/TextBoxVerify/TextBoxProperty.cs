using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    /// <summary>
    /// ��ҪУ����ı���ؼ�������
    /// </summary>
    public class TextBoxProperty
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="textboxId">�ı���ؼ�ID</param>
        /// <param name="required">�Ƿ����</param>
        /// <param name="requiredMessageId">����������ϢID</param>
        /// <param name="maxLength">��󳤶�</param>
        /// <param name="lengthMessageId">������󳤶ȵ���ϢID</param>
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
        /// �ı���ID
        /// </summary>
        public string TextBoxId
        {
            set { textboxid = value; }
            get { return textboxid; }
        }

        private bool required;
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool Required
        {
            set { required = value; }
            get { return required; }
        }

        private string requiredmessageid;
        /// <summary>
        /// ����������ϢID
        /// </summary>
        public string RequiredMessageId
        {
            set { requiredmessageid = value; }
            get { return requiredmessageid; }
        }

        private int maxlength;
        /// <summary>
        /// ��󳤶�
        /// </summary>
        public int MaxLength
        {
            set { maxlength = value; }
            get { return maxlength; }
        }

        private string lengthmessageid;
        /// <summary>
        /// ������󳤶ȵ���ϢID
        /// </summary>
        public string LengthMessageId
        {
            set { lengthmessageid = value; }
            get { return lengthmessageid; }
        }

        private string typepattern;
        /// <summary>
        /// ���͵�������ʽ
        /// </summary>
        public string TypePattern
        {
            set { typepattern = value; }
            get { return typepattern; }
        }

        private string typemessageid;
        /// <summary>
        /// ����У��������ϢID
        /// </summary>
        public string TypeMessageId
        {
            set { typemessageid = value; }
            get { return typemessageid; }
        }
    }
}
