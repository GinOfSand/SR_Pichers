using Microsoft.Win32;
using SR_Pichers.Model;
using SR_Pichers.Service;
using SR_Pichers.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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
//using System.Windows.Shapes;

namespace SR_Pichers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageLinkService linkService = new ImageLinkService();
        private string storageDirPath;
        private ImageService imageService = new ImageService();

        public MainWindow()
        {
            InitializeComponent();
            storageDirPath = Path.Combine(Directory.GetCurrentDirectory(), "storage");
            if (!Directory.Exists(storageDirPath))
            {
                Directory.CreateDirectory(storageDirPath);
            }
            UpdateImageLinkList();
        }

        private void UpdateImageLinkList()
        {
            ImageLinkListBox.Items.Clear();
            List<ImageLink> imageLinks = linkService.liastAll();
            foreach (var imageLink in imageLinks)
            {
                ImageLinkListBox.Items.Add(imageLink);
            }
        }

        private void ShowImage(ImageLink imageLink)
        {
            ImageLinkImage.Source = new BitmapImage(new Uri(Path.Combine(storageDirPath, imageLink.FileName)));
        }

        private void ImageLinkkBTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                // полный путь исходного файла
                string srcFilePath = op.FileName;
                // полученный путь файла на диске
                string dstFilePath = Path.Combine(
                    storageDirPath,
                    op.SafeFileName
                    );
                // скопировать в папку
                File.Copy(srcFilePath, dstFilePath, true);
                // добавить файл в БД
                ImageLink imageLink = new ImageLink()
                {
                    FileName = op.SafeFileName
                };
                linkService.Add(imageLink);
                UpdateImageLinkList();
                ShowImage(imageLink);
            }
            else
            {
                MessageBox.Show("Image not selected");
            }
        }

        private void ImageLinkListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ImageLink link = (ImageLink)ImageLinkListBox.SelectedItem;
            if(link != null)
            {
                ShowImage(link);
            }
        }

        private void ImageBTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                // полный путь исходного файла
                string srcFilePath = op.FileName;
                // полученный путь файла на диске
                BitmapImage bitmapImage = new BitmapImage(new Uri(srcFilePath));

                var data = ImageConverter.ConvertBitmapImageToByteArray(bitmapImage);
                Model.Image image = new Model.Image()
                {
                    Name = op.SafeFileName,
                    Data = data
                };
                imageService.Add(image);

            }
            else
            {
                MessageBox.Show("Image not selected");
            }
        }
    }
}
