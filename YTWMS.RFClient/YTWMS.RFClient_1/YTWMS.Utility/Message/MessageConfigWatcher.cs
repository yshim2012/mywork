using System;
using System.IO;
using System.Threading;
using System.Configuration;

namespace Utility
    {
    /// <summary>
    /// Message�����ļ��۲���,����ļ��б仯�����¼��ػ�������
    /// </summary>
    public sealed class MessageConfigWatcher : ConfigWatcher
        {
        /// <summary>
        /// ��ʼ�۲�
        /// </summary>
        public static void StartWatching()
            {
            new MessageConfigWatcher(new FileInfo(ConfigurationManager.AppSettings["ConfigFilesPath"] + "Message.config"));
            }

        private MessageConfigWatcher(FileInfo fileInfo)
            : base(fileInfo)
            {
            }

        /// <summary>
        /// �ļ��仯�������Ĵ����¼�
        /// </summary>
        /// <param name="state"></param>
        protected override void OnWatchedFileChange(object state)
            {
            MessagePool.Reload();
            }
        }
    }
