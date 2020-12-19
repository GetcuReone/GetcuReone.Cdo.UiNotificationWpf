using GetcuReone.MvvmFrame.Interfaces;
using System.Windows.Controls;

namespace GetcuReone.Cdo.UiNotificationWpf.UI.NotificationWindow
{
    /// <summary>
    /// Interaction logic for NotificationWindowPage.xaml
    /// </summary>
    public partial class NotificationWindowPage : Page, IPage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        public void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
