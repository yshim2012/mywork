using System;
using System.IO;
using System.Threading;
using System.Configuration;
namespace Utility
{
    /// <summary>
    /// 文本框控件值的配置文件观察类,如果文件有变化则重新加载缓存起来
    /// </summary>
    public class TextBoxVerifyConfigWatcher:ConfigWatcher
    {
        /// <summary>
        /// 开始观察
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
        /// 文件变化而触发的代理事件
        /// </summary>
        /// <param name="state"></param>
        protected override void OnWatchedFileChange(object state)
        {
            TextBoxVerifyConfig.Reload();
        }
    }
}
