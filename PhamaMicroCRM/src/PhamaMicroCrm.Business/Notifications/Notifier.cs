﻿using PhamaMicroCrm.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PhamaMicroCrm.Business.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
