using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projekt.Services;

namespace Projekt.Forms
{
    public partial class NoteEditor : Window
    {
        private readonly MarkdownParser mdParser = new MarkdownParser();
        public NoteEditor()
        {
            InitializeComponent();
            webPreview.NavigationCompleted += (s, e) => { };
            webPreview.EnsureCoreWebView2Async();
        }

        private async void txtEditor_TextChanged(object sender,
    System.Windows.Controls.TextChangedEventArgs e)
        {
            await webPreview.EnsureCoreWebView2Async();
            webPreview.NavigateToString(mdParser.Parse(txtEditor.Text));
        }
    }
}
