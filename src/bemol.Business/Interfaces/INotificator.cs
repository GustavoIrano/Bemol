using bemol.Business.Notifications;
using System.Collections.Generic;

namespace bemol.Business.Interfaces
{
    public interface INotificator
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
