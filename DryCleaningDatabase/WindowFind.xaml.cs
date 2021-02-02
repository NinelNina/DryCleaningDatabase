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

namespace DryCleaningDatabase
{
    public partial class WindowFind : Window
    {
        public string searchParameter { set; get; }
        public string selectedParameter { set; get; }

        bool searchParameterIsNotEmpty;
        bool selectedParameterIsNotEmpty;

        public WindowFind(List<string> columns)
        {
            InitializeComponent();

            search.IsEnabled = false;

            selectCombobox.ItemsSource = columns;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            searchParameter = searchParameters.Text;
            selectedParameter = selectCombobox.Text;

            this.DialogResult = true;
        }

        private void searchParameters_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchParameters.Text != "")
            {
                searchParameterIsNotEmpty = true;
            }
            else
            {
                searchParameterIsNotEmpty = false;
            }

            if (searchParameterIsNotEmpty && selectedParameterIsNotEmpty)
            {
                search.IsEnabled = true;
            }
            else
            {
                search.IsEnabled = false;
            }
        }

        private void selectCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectCombobox.SelectedItem != null)
            {
                labelSearch.Content = selectCombobox.SelectedValue + ":";
                selectedParameterIsNotEmpty = true;
            }
            else
            {
                selectedParameterIsNotEmpty = false;
            }

            if (searchParameterIsNotEmpty && selectedParameterIsNotEmpty)
            {
                search.IsEnabled = true;
            }
            else
            {
                search.IsEnabled = false;
            }
        }
    }
}
