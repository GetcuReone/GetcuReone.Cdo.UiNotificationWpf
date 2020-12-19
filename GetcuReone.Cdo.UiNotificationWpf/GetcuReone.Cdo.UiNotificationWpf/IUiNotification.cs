using GetcuReone.Cdo.UiNotificationWpf.Entities;

namespace GetcuReone.Cdo.UiNotificationWpf
{
    /// <summary>
    /// Informing interface from UI.
    /// </summary>
    public interface IUiNotification
    {
        /// <summary>
        /// Send notification at the top of the window.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns></returns>
        void SendNotificationWindow(UiNotificationRequest request);
    }
}
