using PhamaMicroCrm.Business.Notifications;
using System.Collections.Generic;

namespace PhamaMicroCrm.Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
