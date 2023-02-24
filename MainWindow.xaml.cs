using System.Collections.Generic;
using System.Windows;

namespace Notebook
{
    public partial class MainWindow : Window
    {
        private List<string> notes;

        public MainWindow()
        {
            InitializeComponent();
            notes = new List<string>();
            lstNotes.ItemsSource = notes;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string note = "New note";
            notes.Add(note);
            lstNotes.SelectedItem = note;
            lstNotes.ScrollIntoView(note);
            txtNote.Text = note;
            txtNote.Visibility = Visibility.Visible;
            txtNote.Focus();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lstNotes.SelectedIndex >= 0)
            {
                txtNote.Text = lstNotes.SelectedItem.ToString();
                txtNote.Visibility = Visibility.Visible;
                txtNote.Focus();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstNotes.SelectedIndex >= 0)
            {
                notes.Remove(lstNotes.SelectedItem.ToString());
            }
        }

        private void lstNotes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstNotes.SelectedIndex >= 0)
            {
                txtNote.Text = lstNotes.SelectedItem.ToString();
                txtNote.Visibility = Visibility.Visible;
            }
            else
            {
                txtNote.Visibility = Visibility.Collapsed;
            }
        }

        private void txtNote_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lstNotes.SelectedIndex >= 0)
            {
                notes[lstNotes.SelectedIndex] = txtNote.Text;
                lstNotes.SelectedItem = txtNote.Text;
            }
            txtNote.Visibility = Visibility.Collapsed;
        }
    }
}
