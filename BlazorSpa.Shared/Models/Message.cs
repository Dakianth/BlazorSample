using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorSpa.Shared.Models
{
    public class Message
    {
        public string Sender { get; set; }

        public string Text { get; set; }

        public string DisplayText => $"{Sender}: {Text}";
    }
}
