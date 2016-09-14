using System;
using System.IO;
using System.Threading;
using System.Configuration;
namespace Utility
{
    /// <summary>
    /// �ı���ؼ�ֵ�������ļ��۲���,����ļ��б仯�����¼��ػ�������
    /// </summary>
    public class TextBoxVerifyConfigWatcher:ConfigWatcher
    {
        /// <summary>
        /// ��ʼ�۲�
        /// </summary>
        public static void StartWatching()
        {
            new TextBoxVerifyConfigWatcher(new FileInfo(ConfigurationManager.AppSettings["ConfigFilesPath"] + "TextBoxVerify.config"));
        }

        private TextBoxVerifyConfigWatcher(FileInfo fileInfo)
            : base(fileInfo)
        {
        }

        /// <summary>
        /// �ļ��仯�������Ĵ����¼�
        /// </summary>
        /// <param name="state"></param>
        protected override void OnWatchedFileChange(object state)
        {
            TextBoxVerifyConfig.Reload();
        }
    }
}
