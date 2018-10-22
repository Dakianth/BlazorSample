using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorSpa.Shared
{
    /// <summary>
    /// Specifies the buttons that are displayed on a message box. Used as an argument of the Show method.
    /// </summary>
    public enum MessageBoxButton
    {
        /// <summary>
        /// The message box displays an OK button.
        /// </summary>
        OK,
        /// <summary>
        /// The message box displays OK and Cancel buttons.
        /// </summary>
        OKCancel,
        /// <summary>
        /// The message box displays Yes, No, and Cancel buttons.
        /// </summary>
        YesNoCancel = 3,
        /// <summary>
        /// The message box displays Yes and No buttons.
        /// </summary>
        YesNo
    }
}
