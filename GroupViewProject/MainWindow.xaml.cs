using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupViewProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdListView();
        }
        String Idgroup;
        void UpdListView()
        {
            Main main = new Main();

            dbViewGroup.ItemsSource = main.ReadGroup();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tbNameGroup.Text) && !String.IsNullOrEmpty(tbNumberGroup.Text) && !String.IsNullOrEmpty(tbCurator.Text))
                {
                    Group group = new Group()
                    {
                        NameGroup = tbNameGroup.Text,
                        NumberGroup = tbNumberGroup.Text,
                        CuratorGroup = tbCurator.Text
                    };

                    Main main = new Main();

                    main.AddGroup(group);
                    UpdListView();
                }
                else MessageBox.Show("Одно из полей пустое");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tbNameGroup.Text))
                {
                    Group group = new Group()
                    {
                        idGroup = Convert.ToInt32(Idgroup)
                    };
                    Main main = new Main();

                    main.DelGroup(group);
                    UpdListView();
                }
                else MessageBox.Show("Одно из полей пустое");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbNameGroup.Text) && !String.IsNullOrWhiteSpace(tbNumberGroup.Text) && !String.IsNullOrWhiteSpace(tbCurator.Text) && !String.IsNullOrWhiteSpace(Idgroup))
                {
                    Group group = new Group()
                    {
                        idGroup = Convert.ToInt32(Idgroup),
                        NameGroup = tbNameGroup.Text,
                        NumberGroup = tbNumberGroup.Text,
                        CuratorGroup = tbCurator.Text
                    };
                    Main main = new Main();
                    main.UpdGroup(group);
                    UpdListView();
                }
                else
                {
                    MessageBox.Show("Одно из полей пустое");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void lvViewGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Group group = new Group();
            group = dbViewGroup.SelectedItem as Group;
            if (group != null)
            {

                Idgroup = group.idGroup.ToString();
                tbNameGroup.Text = group.NameGroup;
                tbNumberGroup.Text = group.NumberGroup;
                tbCurator.Text = group.CuratorGroup;
            }
        }
    }
}
