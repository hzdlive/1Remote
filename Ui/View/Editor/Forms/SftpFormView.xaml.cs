﻿using System;
using System.Windows;
using System.Windows.Controls;
using _1RM.Model.Protocol;
using Shawn.Utils.Wpf.FileSystem;

namespace _1RM.View.Editor.Forms
{
    public partial class SftpFormView : UserControl
    {
        public SftpFormView()
        {
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                if (DataContext is SFTP vm)
                {
                    CbUsePrivateKey.IsChecked = false;
                    if (vm.PrivateKey == vm.ServerEditorDifferentOptions)
                    {
                        CbUsePrivateKey.IsChecked = null;
                    }
                    if (!string.IsNullOrEmpty(vm.PrivateKey))
                    {
                        CbUsePrivateKey.IsChecked = true;
                    }
                }
            };
        }

        private void ButtonOpenPrivateKey_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is SFTP sftp)
            {
                var path = SelectFileHelper.OpenFile(filter: "ppk|*.*", currentDirectoryForShowingRelativePath: Environment.CurrentDirectory);
                if (path == null) return;
                sftp.PrivateKey = path;
            }
        }

        private void CbUsePrivateKey_OnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb && DataContext is SFTP sftp)
            {
                if (cb.IsChecked == false)
                {
                    sftp.PrivateKey = "";
                }
                else
                {
                    sftp.Password = "";
                }
            }
        }
    }
}
