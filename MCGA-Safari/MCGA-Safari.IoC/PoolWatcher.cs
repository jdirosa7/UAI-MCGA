using MCGA_Safari.Services.Contracts;
using Safari.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA_Safari.IoC
{
    public class PoolWatcher
    {
        //Properties
        private INotificationAction _action;
        public INotificationAction Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
            }
        }


        //Constructors

        public PoolWatcher() { }

        public PoolWatcher(INotificationAction action)
        {
            _action = action;
        }


        public void Notify(string message)
        {
            if (_action == null)
            {
                _action = new EventLogWriter();
            }

            _action.ActOnNotification(message);
        }

        public void Notify(INotificationAction action, string message)
        {
            this._action = @action;
            action.ActOnNotification(message);
        }
    }
}
