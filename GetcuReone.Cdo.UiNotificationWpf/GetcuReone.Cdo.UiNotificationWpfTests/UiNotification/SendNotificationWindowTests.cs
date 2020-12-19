using GetcuReone.Cdo.UiNotificationWpf;
using GetcuReone.Cdo.UiNotificationWpf.Entities;
using GetcuReone.Cdo.UiNotificationWpf.Entities.Enums;
using GetcuReone.Cdo.UiNotificationWpf.UI.NotificationWindow;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf.TestAdapter;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using System.Windows.Controls;

namespace GetcuReone.Cdo.UiNotificationWpfTests.UiNotification
{
    [TestClass]
    public sealed class SendNotificationWindowTests : UiTestBase
    {
        protected override void SetupViewModel<TViewModel>(TViewModel viewModel)
        {
            var subFrame = GetSubFrame();
            viewModel.UiServices.SetupUiNitification(subFrame);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Show notification.")]
        [Timeout(Timeouts.Second.Ten)]
        [Ignore]
        public void ShowNotificationTestCase()
        {
            string title = "Is notification";
            string message = "Love me";
            var notificationType = NotificationTypes.Info;

            GivenShowEmptyPage()
                .When("Show notification", viewModel =>
                {
                    viewModel.UiServices.GetUiService<IUiNotification>()
                        .SendNotificationWindow(new UiNotificationRequest
                        {
                            Message = message,
                            Title = title,
                            Type = notificationType,
                        });
                })
                .ThenWait(Timeouts.Millisecond.Hundred)
                .And("Check page", _ => 
                    CheckTypeAndGetPageSubFrame<NotificationWindowPage>())
                .And("Check dataContext.", page =>
                    page.CheckTypeAndDataContext<NotificationWindowViewModel>())
                .AndAreEqual(viewModel => viewModel.Title, title)
                .AndAreEqual(viewModel => viewModel.Message, message)
                .AndAreEqual(viewModel => viewModel.Type, notificationType)
                .RunTestWindow(Timeouts.Second.Ten);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Show warning notification.")]
        [Timeout(Timeouts.Second.Ten)]
        public void ShowWarningNotificationTestCase()
        {
            string title = "Is notification";
            string message = "Love me";
            var notificationType = NotificationTypes.Warning;

            GivenShowEmptyPage()
                .When("Show notification", viewModel =>
                {
                    viewModel.UiServices.GetUiService<IUiNotification>()
                        .SendNotificationWindow(new UiNotificationRequest
                        {
                            Message = message,
                            Title = title,
                            Type = notificationType,
                        });
                })
                .ThenWait(Timeouts.Millisecond.Hundred)
                .And("Check page.", _ =>
                    CheckTypeAndGetPageSubFrame<NotificationWindowPage>())
                .And("Check dataContext.", page =>
                    page.CheckTypeAndDataContext<NotificationWindowViewModel>())
                .AndAreEqual(viewModel => viewModel.Title, title)
                .AndAreEqual(viewModel => viewModel.Message, message)
                .AndAreEqual(viewModel => viewModel.Type, notificationType)
                .RunTestWindow(Timeouts.Second.Ten);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Show error notification.")]
        [Timeout(Timeouts.Second.Ten)]
        public void ShowErrorNotificationTestCase()
        {
            string title = "Is notification";
            string message = "Love me";
            var notificationType = NotificationTypes.Error;

            GivenShowEmptyPage()
                .When("Show notification", viewModel =>
                {
                    viewModel.UiServices.GetUiService<IUiNotification>()
                        .SendNotificationWindow(new UiNotificationRequest
                        {
                            Message = message,
                            Title = title,
                            Type = notificationType,
                        });
                })
                .ThenWait(Timeouts.Millisecond.Hundred)
                .And("Check page.", _ =>
                    CheckTypeAndGetPageSubFrame<NotificationWindowPage>())
                .And("Check dataContext.", page =>
                    page.CheckTypeAndDataContext<NotificationWindowViewModel>())
                .AndAreEqual(viewModel => viewModel.Title, title)
                .AndAreEqual(viewModel => viewModel.Message, message)
                .AndAreEqual(viewModel => viewModel.Type, notificationType)
                .RunTestWindow(Timeouts.Second.Ten);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Close notification.")]
        [Timeout(Timeouts.Second.Ten)]
        public void CloseNotificationTestCase()
        {
            string title = "Is notification";
            string message = "Love me";
            var notificationType = NotificationTypes.Info;

            GivenShowEmptyPage()
                .And("Show notification", viewModel =>
                {
                    viewModel.UiServices.GetUiService<IUiNotification>()
                        .SendNotificationWindow(new UiNotificationRequest
                        {
                            Message = message,
                            Title = title,
                            Type = notificationType,
                        });
                })
                .AndWait(Timeouts.Millisecond.Hundred)
                .When("Close notification", () =>
                {
                    var page = CheckTypeAndGetPageSubFrame<NotificationWindowPage>();
                    page.FindChildByName<Button>("btnOk").OnClick();
                    return page;
                })
                .ThenWait(Timeouts.Millisecond.Hundred)
                .And("Check viewModel", page =>
                    page.CheckTypeAndDataContext<NotificationWindowViewModel>())
                .AndAreEqual(viewModel => viewModel.Visibility, Visibility.Collapsed)
                .RunTestWindow(Timeouts.Second.Ten);
        }
    }
}
