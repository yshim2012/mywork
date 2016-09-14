using System;
using System.IO;
using System.Threading;
using System.Configuration;

namespace Utility
    {
    /// <summary>
    /// Message配置文件观察类,如果文件有变化则重新加载缓存起来
    /// </summary>
    public sealed class MessageConfigWatcher : ConfigWatcher
        {
        /// <summary>
        /// 开始观察
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
        /// 文件变化而触发的代理事件
        /// </summary>
        /// <param name="state"></param>
        protected override void OnWatchedFileChange(object state)
            {
            MessagePool.Reload();
            }
        }
    }
