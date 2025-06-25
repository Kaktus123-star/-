using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;


namespace КУРСАЧ
{
    public partial class Form1 : Form
    {
        private int sortColumn = 1; // Индекс колонки "Дата съемки"
        private System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.Ascending;
        private string currentGroupBy = "Год"; 

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            // Инициализация comboBoxGroupBy
            comboBoxGroupBy.Items.AddRange(new string[] { "Год", "Месяц", "День" });
            comboBoxGroupBy.SelectedIndex = 0;
            comboBoxGroupBy.SelectedIndexChanged += comboBoxGroupBy_SelectedIndexChanged;

            // Инициализация comboBoxGroupBy2 
            comboBoxGroupBy2.Items.AddRange(new string[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.heic" });
            comboBoxGroupBy2.SelectedIndex = 0;
            comboBoxGroupBy2.SelectedIndexChanged += comboBoxGroupBy2_SelectedIndexChanged;

            if (listViewPhotos.Columns.Count == 0)
            {
                listViewPhotos.View = View.Details;
                listViewPhotos.Columns.Add("Имя файла", 200);
                listViewPhotos.Columns.Add("Дата съемки", 150);
                listViewPhotos.Columns.Add("Формат", 80);
            }

            // Обработчики событий
            listViewPhotos.MouseClick += listViewPhotos_MouseClick;
            listViewPhotos.ColumnClick += ListViewPhotos_ColumnClick;
            listViewPhotos.DoubleClick += listViewPhotos_DoubleClick;

            // Кнопка "Старт"
            buttonBrowse.Click += buttonBrowse_Click;
        }

        public struct PhotoInfo
        {
            public string FilePath;
            public DateTime DateTaken;
            public string Format;
        }

        private bool _isClicked = false;

        private void listViewPhotos_DoubleClick(object sender, EventArgs e)
        {
            if (listViewPhotos.SelectedItems.Count > 0 && _isClicked == false)
            {
                var info = (PhotoInfo)listViewPhotos.SelectedItems[0].Tag;
                ViewPhoto(info.FilePath);
                _isClicked = true;
            }
            else
            {
                _isClicked = false;
            }
        }

        private void listViewPhotos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = listViewPhotos.HitTest(e.Location);
                if (hit.Item != null)
                {
                    listViewPhotos.SelectedItems.Clear();
                    hit.Item.Selected = true;
                    var contextMenu = new ContextMenuStrip();
                    contextMenu.Items.Add("Удалить", null, DeletePhoto_Click);
                    contextMenu.Show(listViewPhotos, e.Location);
                }
            }
        }

        private void ListViewPhotos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortColumn)
            {
                // Переключение порядка сортировки
                sortOrder = (sortOrder == System.Windows.Forms.SortOrder.Ascending) ?
                            System.Windows.Forms.SortOrder.Descending :
                            System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                sortColumn = e.Column;
                sortOrder = System.Windows.Forms.SortOrder.Ascending;
            }

            if (sortColumn == 2) // колонка "Формат"
                listViewPhotos.ListViewItemSorter = new ListViewFormatSorter(sortColumn, sortOrder);
            else
                listViewPhotos.ListViewItemSorter = new ListViewDateSorter(sortColumn, sortOrder, currentGroupBy);

            listViewPhotos.Sort();
        }

        private void SortListView()
        {
            listViewPhotos.ListViewItemSorter = new ListViewDateSorter(sortColumn, sortOrder, currentGroupBy);
            listViewPhotos.Sort();
        }

        private class ListViewDateSorter : IComparer
        {
            private readonly int _column;
            private readonly System.Windows.Forms.SortOrder _order;
            private readonly string _groupBy;

            public ListViewDateSorter(int column, System.Windows.Forms.SortOrder order, string groupBy)
            {
                _column = column;
                _order = order;
                _groupBy = groupBy;
            }

            public int Compare(object x, object y)
            {
                var itemX = x as ListViewItem;
                var itemY = y as ListViewItem;
                if (itemX == null || itemY == null)
                    return 0;

                var photoX = (PhotoInfo?)itemX.Tag;
                var photoY = (PhotoInfo?)itemY.Tag;
                if (photoX == null || photoY == null)
                    return 0;

                int comparisonResult = 0;

                if (_column == 1) // "Дата съемки"
                {
                    switch (_groupBy)
                    {
                        case "Год":
                            comparisonResult = photoX.Value.DateTaken.Year.CompareTo(photoY.Value.DateTaken.Year);
                            if (comparisonResult == 0)
                                comparisonResult = photoX.Value.DateTaken.Month.CompareTo(photoY.Value.DateTaken.Month);
                            if (comparisonResult == 0)
                                comparisonResult = photoX.Value.DateTaken.Day.CompareTo(photoY.Value.DateTaken.Day);
                            break;
                        case "Месяц":
                            comparisonResult = photoX.Value.DateTaken.ToString("yyyy-MM").CompareTo(photoY.Value.DateTaken.ToString("yyyy-MM"));
                            break;
                        case "День":
                            comparisonResult = photoX.Value.DateTaken.ToString("yyyy-MM-dd").CompareTo(photoY.Value.DateTaken.ToString("yyyy-MM-dd"));
                            break;
                        default:
                            comparisonResult = DateTime.Compare(photoX.Value.DateTaken, photoY.Value.DateTaken);
                            break;
                    }
                    return (_order == System.Windows.Forms.SortOrder.Ascending) ? comparisonResult : -comparisonResult;
                }
                else
                {
                    return String.Compare(
                        itemX.SubItems[_column].Text,
                        itemY.SubItems[_column].Text,
                        StringComparison.CurrentCulture);
                }
            }
        }

        private class ListViewFormatSorter : IComparer
        {
            private readonly int _column;
            private readonly System.Windows.Forms.SortOrder _order;

            public ListViewFormatSorter(int column, System.Windows.Forms.SortOrder order)
            {
                _column = column;
                _order = order;
            }

            public int Compare(object x, object y)
            {
                var itemX = x as ListViewItem;
                var itemY = y as ListViewItem;
                if (itemX == null || itemY == null)
                    return 0;

                string txtX = itemX.SubItems[_column].Text;
                string txtY = itemY.SubItems[_column].Text;

                int result = String.Compare(txtX, txtY, StringComparison.CurrentCultureIgnoreCase);
                return (_order == System.Windows.Forms.SortOrder.Ascending) ? result : -result;
            }
        }

        private void ViewPhoto(string filePath)
        {
            try
            {
                using (var formViewer = new Form())
                {
                    formViewer.Text = Path.GetFileName(filePath);
                    formViewer.StartPosition = FormStartPosition.CenterParent;
                    formViewer.Size = new Size(800, 600);
                    var pictureBox = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        var image = Image.FromStream(stream);
                        pictureBox.Image = new Bitmap(image);
                    }
                    formViewer.Controls.Add(pictureBox);
                    formViewer.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия фото: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletePhoto_Click(object sender, EventArgs e)
        {
            if (listViewPhotos.SelectedItems.Count > 0)
            {
                var selectedItem = listViewPhotos.SelectedItems[0];
                var info = (PhotoInfo)selectedItem.Tag;
                var filePath = info.FilePath;
                var dialogResult = MessageBox.Show(
                    $"Удалить файл '{Path.GetFileName(filePath)}'?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(filePath);
                        listViewPhotos.Items.Remove(selectedItem);
                        UpdateStatus($"Файл удалён: {Path.GetFileName(filePath)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBoxSourceFolder.Text = fbd.SelectedPath;
                    LoadPhotosInfo(fbd.SelectedPath);

                    // Запускаем классификацию сразу после выбора папки
                    var groupBy = comboBoxGroupBy.SelectedItem?.ToString() ?? "Год";
                    ClassifyPhotos(fbd.SelectedPath, groupBy);
                }
            }
        }

        private void LoadPhotosInfo(string folderPath)
        {
            listViewPhotos.Items.Clear();

            string selectedFormat = comboBoxGroupBy2.SelectedItem?.ToString() ?? "*.jpg";
            string formatDisplayName = selectedFormat.Replace("*.", "").ToLower();

            var imageFiles = Directory.GetFiles(folderPath, selectedFormat);
            progressBar.Maximum = imageFiles.Length;
            progressBar.Value = 0;

            foreach (var file in imageFiles)
            {
                try
                {
                    var info = GetPhotoInfo(file, formatDisplayName);
                    string dateText;

                    switch (comboBoxGroupBy.SelectedItem?.ToString())
                    {
                        case "Год": dateText = info.DateTaken.ToString("yyyy"); break;
                        case "Месяц": dateText = info.DateTaken.ToString("yyyy-MM"); break;
                        case "День": dateText = info.DateTaken.ToString("yyyy-MM-dd"); break;
                        default: dateText = info.DateTaken.ToString(); break;
                    }

                    var item = new ListViewItem(Path.GetFileName(file))
                    {
                        SubItems = { dateText, info.Format },
                        Tag = info
                    };
                    listViewPhotos.Items.Add(item);
                }
                catch
                {
                    
                }
                progressBar.Value++;
                Application.DoEvents();
            }

            UpdateStatus($"Найдено {listViewPhotos.Items.Count} фотографий");
            SortListView();
        }

        private PhotoInfo GetPhotoInfo(string filePath, string formatDisplayName)
        {
            string extension = Path.GetExtension(filePath).TrimStart('.').ToLower();

            var info = new PhotoInfo
            {
                FilePath = filePath,
                DateTaken = DateTime.MinValue,
                Format = extension
            };

            try
            {
                using (var image = Image.FromFile(filePath))
                {
                    
                }
            }
            catch { }

            if (info.DateTaken == DateTime.MinValue)
            {
                info.DateTaken = File.GetLastWriteTime(filePath);
            }

            return info;
        }


        private void ClassifyPhotos(string sourceFolder, string groupBy)
        {
            var imageFiles = Directory.GetFiles(sourceFolder, "*.jpg");
            progressBar.Maximum = imageFiles.Length;
            progressBar.Value = 0;

            foreach (var file in imageFiles)
            {
                try
                {
                    var info = GetPhotoInfo(file, "jpg");
                    if (info.DateTaken == DateTime.MinValue)
                        continue;

                    var destinationFolder = GetDestinationFolder(sourceFolder, info.DateTaken, groupBy);
                    if (!Directory.Exists(destinationFolder))
                        Directory.CreateDirectory(destinationFolder);

                    var destinationFile = Path.Combine(destinationFolder, Path.GetFileName(file));
                    if (!File.Exists(destinationFile))
                        File.Copy(file, destinationFile);
                }
                catch { }

                progressBar.Value++;
                UpdateStatus($"Обработано {progressBar.Value} из {progressBar.Maximum}");
                Application.DoEvents();
            }

            MessageBox.Show("Классификация завершена!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetDestinationFolder(string baseFolder, DateTime dateTaken, string groupBy)
        {
            string subfolder;
            switch (groupBy)
            {
                case "Год": subfolder = dateTaken.ToString("yyyy"); break;
                case "Месяц": subfolder = dateTaken.ToString("yyyy-MM"); break;
                case "День": subfolder = dateTaken.ToString("yyyy-MM-dd"); break;
                default: subfolder = "Другие"; break;
            }
            return Path.Combine(baseFolder, subfolder);
        }

        private void UpdateStatus(string message)
        {
            if (statusStrip.Items.Count == 0)
                statusStrip.Items.Add(new ToolStripStatusLabel());
            statusStrip.Items[0].Text = message;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBoxGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentGroupBy = comboBoxGroupBy.SelectedItem?.ToString() ?? "Год";
            if (!string.IsNullOrEmpty(textBoxSourceFolder.Text))
            {
                LoadPhotosInfo(textBoxSourceFolder.Text);
            }
        }

        private void comboBoxGroupBy2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSourceFolder.Text))
            {
                LoadPhotosInfo(textBoxSourceFolder.Text);
            }
        }
    }
}
