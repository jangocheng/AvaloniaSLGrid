// Copyright © Microsoft Corporation. 
// This source is subject to the Microsoft Source License for Silverlight Controls (March 2008 Release).
// Please see http://go.microsoft.com/fwlink/?LinkID=111693 for details.
// All other rights reserved. 

using Avalonia.Controls;

namespace System.Windows.Controlsb1
{ 
    public class DataGridRowDetailsEventArgs : EventArgs 
    {
        public DataGridRowDetailsEventArgs(Control detailsElement) 
        {
            this.DetailsElement = detailsElement;
        } 

        public Control DetailsElement
        { 
            get; 
            private set;
        } 
    }
}
