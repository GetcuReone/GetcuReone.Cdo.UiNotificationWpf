using GetcuReone.MvvmFrame.Wpf.Interfaces;
using System.Windows.Controls;

namespace GetcuReone.Cdo.UiNotificationWpf
{
    /// <summary>
    /// Installation Notification Instance Assistant
    /// </summary>
    public static class UiNotificationSetupHelper
    {
        /// <summary>
        /// Install notification service.
        /// </summary>
        /// <param name="configUi"></param>
        /// <param name="frame">Frame for bind.</param>
        public static void SetupUiNitification<TConfigUiServices>(this TConfigUiServices configUi, Frame frame)
            where TConfigUiServices : IConfigUiServices
        {
            configUi.AddSingleton<IUiNotification, UiNotificationService>(frame);
        }
    }
}
