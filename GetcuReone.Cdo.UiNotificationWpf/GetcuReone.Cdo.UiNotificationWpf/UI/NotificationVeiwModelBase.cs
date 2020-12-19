using GetcuReone.Cdi.MvvmFrameWpf;
using GetcuReone.Cdo.UiNotificationWpf.Entities;
using GetcuReone.Cdo.UiNotificationWpf.Entities.Enums;
using GetcuReone.MvvmFrame.Wpf.Commands;
using GetcuReone.MvvmFrame.Wpf.EventArgs;
using GetcuReone.MvvmFrame.Wpf.Models;
using System.Threading.Tasks;
using System.Windows;

namespace GetcuReone.Cdo.UiNotificationWpf.UI
{
    /// <summary>
    /// Base class for view-model ui notification.
    /// </summary>
    public abstract class NotificationVeiwModelBase : GrViewModelBase
    {
        /// <summary>
        /// Request.
        /// </summary>
        protected UiNotificationRequest Request { get; private set; }

        /// <summary>
        /// Button close notification.
        /// </summary>
        public ButtonModel<Command> CloseNotification_ButtonModel { get => _closeNotification_ButtonModel; set => SetPropertyValue(ref _closeNotification_ButtonModel, value); }
        private ButtonModel<Command> _closeNotification_ButtonModel;

        /// <summary>
        /// Visibility.
        /// </summary>
        public Visibility Visibility { get => _visibility; set => SetPropertyValue(ref _visibility, value); }
        private Visibility _visibility;

        /// <summary>
        /// Title.
        /// </summary>
        public string Title => Request?.Title;
        /// <summary>
        /// Message.
        /// </summary>
        public string Message => Request?.Message;
        /// <summary>
        /// Type.
        /// </summary>
        public NotificationTypes Type => Request?.Type ?? NotificationTypes.Info;

        /// <inheritdoc/>
        protected override void Initialize()
        {
            CloseNotification_ButtonModel = GetModel<ButtonModel<Command>>();
            CloseNotification_ButtonModel.Command = new Command(e => GoBack());
        }

        private protected UiNotificationService GetNotificationService()
        {
            return (UiNotificationService)UiServices.GetUiService<IUiNotification>();
        }

        /// <summary>
        /// Go back.
        /// </summary>
        protected void GoBack()
        {
            if (NavigationManager.CanGoBack)
                NavigationManager.GoBack();

            Visibility = Visibility.Collapsed;
            GetNotificationService().CollapseFrame();
        }

        /// <inheritdoc/>
        protected override ValueTask OnGoPageAsync(object navigateParam)
        {
            if (navigateParam != null && navigateParam is UiNotificationRequest request)
            {
                Request = request;
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(Type));
                Visibility = Visibility.Visible;
            }
            else
                GoBack();

            return default;
        }

        /// <inheritdoc/>
        protected override ValueTask OnLoadPageAsync()
        {
            return default;
        }

        /// <inheritdoc/>
        protected override ValueTask OnLeavePageAsync(NavigatingEventArgs args)
        {
            if (Visibility != Visibility.Collapsed)
                Visibility = Visibility.Collapsed;

            return default;
        }
    }
}
