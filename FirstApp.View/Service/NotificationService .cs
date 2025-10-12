using FirstApp.View.Components.Message;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.View.Service
{
    public class NotificationService
    {
        private Alert _alert;
        private Toast _toast;

        // Method to register the alert component
        public void RegisterAlert(Alert alert)
        {
            _alert = alert;
        }

        // Method to register the toast component
        public void RegisterToast(Toast toast)
        {
            _toast = toast;
        }

        // Method to show the alert
        public void ShowAlert(string message, string title)
        {
            _alert?.Show(message, title);
        }

        // Method to show the toast
        public void ShowToast(string message)
        {
            _toast?.Show(message);
        }
    }

}
