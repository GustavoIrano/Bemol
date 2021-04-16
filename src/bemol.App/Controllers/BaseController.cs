using bemol.Business.Interfaces;
using bemol.Business.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace bemol.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificator _notificador;

        protected BaseController(INotificator notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.HaveNotification();
        }
    }
}
