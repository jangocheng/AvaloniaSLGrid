// Copyright © Microsoft Corporation. 
// This source is subject to the Microsoft Source License for Silverlight Controls (March 2008 Release).
// Please see http://go.microsoft.com/fwlink/?LinkID=111693 for details.
// All other rights reserved. 

using System.Collections.Generic;
using System.Diagnostics;
using Avalonia;

namespace System.Windows.Controlsb1
{ 
    internal static class Extensions
    {
        private static Dictionary<AvaloniaObject, Dictionary<AvaloniaProperty, bool>> _suspendedHandlers = new Dictionary<AvaloniaObject, Dictionary<AvaloniaProperty, bool>>(); 

        public static bool IsHandlerSuspended(this AvaloniaObject obj, AvaloniaProperty AvaloniaProperty)
        { 
            if (_suspendedHandlers.ContainsKey(obj)) 
            {
                return _suspendedHandlers[obj].ContainsKey(AvaloniaProperty); 
            }
            else
            { 
                return false;
            }
        } 
 
        public static void SetValueNoCallback(this AvaloniaObject obj, AvaloniaProperty property, object value)
        { 
            obj.SuspendHandler(property, true);
            try
            { 
                obj.SetValue(property, value);
            }
            finally 
            { 
                obj.SuspendHandler(property, false);
            } 

        }
 
        private static void SuspendHandler(this AvaloniaObject obj, AvaloniaProperty AvaloniaProperty, bool suspend)
        {
            if (_suspendedHandlers.ContainsKey(obj)) 
            { 
                Dictionary<AvaloniaProperty, bool> suspensions = _suspendedHandlers[obj];
 
                if (suspend)
                {
                    Debug.Assert(!suspensions.ContainsKey(AvaloniaProperty)); 
                    suspensions[AvaloniaProperty] = true; // true = dummy value
                }
                else 
                { 
                    Debug.Assert(suspensions.ContainsKey(AvaloniaProperty));
                    suspensions.Remove(AvaloniaProperty); 
                }
            }
            else 
            {
                Debug.Assert(suspend);
                _suspendedHandlers[obj] = new Dictionary<AvaloniaProperty, bool>(); 
                _suspendedHandlers[obj][AvaloniaProperty] = true; 
            }
        } 
    }
}
