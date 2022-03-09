using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeerGrade4
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Буфер обмена.
        /// </summary>
        string buffer="";
        /// <summary>
        /// Поле хранит цвет интерфейса.
        /// </summary>
        private Color color = Color.White;
        /// <summary>
        /// Поле хранит цвет шрифта.
        /// </summary>
        private Color colorFont = Color.Black;
        /// <summary>
        /// Поле хранит период автосохранения.
        /// </summary>
        private int interval = 30000;
        /// <summary>
        /// Поле хранит список открытых файлов.
        /// </summary>
        public List<string> files = new List<string>(10);
        /// <summary>
        /// Поле хранит количество открытых файлов.
        /// </summary>
        private int countOfNewFiles = 0;

        /// <summary>
        /// Конструктор формы. 
        /// Запускает форму, восстановление файлов, запускает таймер.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Recovery();
            InitializeTimer();
            PagePlus_Click(null, null);
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).Multiline = true;
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).Dock = DockStyle.Fill;
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Копировать");
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Вставить");
            ToolStripMenuItem colorMenuItem = new ToolStripMenuItem("Выделить всё");
            contextMenuStrip1.Items.AddRange(new[] { copyMenuItem, pasteMenuItem, colorMenuItem});
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).ContextMenuStrip = contextMenuStrip1;
            copyMenuItem.Click += copyMenuItem_Click;
            pasteMenuItem.Click += pasteMenuItem_Click;
            colorMenuItem.Click += ColorMenuItem_Click;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
            openFileDialog2.Filter = "RTF files(*.rtf)|*.rtf";
            saveFileDialog2.Filter = "RTF files(*.rtf)|*.rtf";
        }
        /// <summary>
        /// Выделение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            int length = (tabControl1.SelectedTab.Controls[0] as RichTextBox).TextLength;
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionStart = 0;
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionLength = length;
            }
            catch
            {

            }

        }

        /// <summary>
        /// Метод восстанавливает файлы из предыдущей сессии.
        /// </summary>
        private void Recovery()
        {
            try
            {
                interval = Properties.Settings.Default.settingsInterval;
                var jsonString = Properties.Settings.Default.settingsList;
                files = JsonSerializer.Deserialize<List<string>>(jsonString);
                System.IO.File.WriteAllText(@"D:\Semen\text.txt", jsonString);
                if (files.Count != 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Хотите восстановить предыдущую сессию?",
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        );
                    if (result == DialogResult.Yes)
                    {
                        Opening();
                    }
                    else
                    {
                        files = new List<string>(10);
                    }
                }
            }
            catch
            {
                files = new List<string>(10);
                var jsonString = JsonSerializer.Serialize(files);
                Properties.Settings.Default.settingsList = jsonString;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Метод открывает файлы из списка.
        /// </summary>
        private void Opening()
        {
            Regex regex1 = new Regex(@"\.txt");
            Regex regex2 = new Regex(@"\.rtf");
            List<string> newFiles = new List<string>(10);
            foreach (string file in files)
            {
                try
                {
                    this.NewPage();
                    if (regex1.IsMatch(file))
                    {
                        string text = System.IO.File.ReadAllText(file);
                        tabControl1.SelectedTab.Controls[0].Text = text;
                        string shortName = Path.GetFileName(file);
                        tabControl1.SelectedTab.Text = shortName;
                        tabControl1.SelectedTab.Tag = file;
                    }
                    else if (regex2.IsMatch(file))
                    {
                        (tabControl1.SelectedTab.Controls[0] as RichTextBox).Rtf = System.IO.File.ReadAllText(file);
                        string shortName = Path.GetFileName(file);
                        tabControl1.SelectedTab.Text = shortName;
                        tabControl1.SelectedTab.Tag = file;
                    }
                    else
                    {
                        PageMinus_Click(null, null);
                    }
                    tabControl1.SelectedTab.Controls[0].BackColor = color;
                    newFiles.Add(file);
                }
                catch
                {
                    PageMinus_Click(null, null);
                    MessageBox.Show($"Не удалось открыть файл {Path.GetFileName(file)}");
                }
            }
            files = newFiles;
        }

        /// <summary>
        /// Метод запускает таймер.
        /// </summary>
        private void InitializeTimer()
        {
            try
            {
                // Run this procedure in an appropriate event.  
                timer1.Interval = interval;
                timer1.Enabled = true;
                // Hook up timer's tick event handler.  
                this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }

        }

        /// <summary>
        /// Обработчик событий для таймера.
        /// Проводит автосохранение и запись в хранилище.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            try
            {
                int numberOfPages = tabControl1.TabPages.Count;
                for (int i = 0; i < numberOfPages; i++)
                {
                    if (tabControl1.TabPages[i].Tag.ToString() != "0")
                    {
                        string filename;
                        Regex regex1 = new Regex(@"$\.rtf");
                        if (System.IO.File.Exists(filename = tabControl1.SelectedTab.Tag.ToString()))
                        {

                            if (!identity())
                            {
                                if (regex1.IsMatch(filename))
                                {
                                    RichTextBox rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                                    System.IO.File.WriteAllText(filename, rtb.Rtf);
                                }
                                else
                                {
                                    RichTextBox rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                                    System.IO.File.WriteAllText(filename, rtb.Text);
                                }
                            }
                        }
                    }
                }
                var jsonString = JsonSerializer.Serialize(files);
                Properties.Settings.Default.settingsList = jsonString;
                Properties.Settings.Default.Save();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        /// <summary>
        /// Метод обрабатывает событие закрытия формы.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void Close_Click(object sender, EventArgs e)
        {
            try
            {
                int numberOfPages = tabControl1.TabPages.Count;
                DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите закрыть все вкладки?",
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );
                if (result == DialogResult.No)
                {
                    return;
                }
                timer1.Enabled = false;
                for (int i = 0; i < numberOfPages; i++)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    PageMinus_Click(null, null);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
            Close();
        }

        /// <summary>
        /// Метод отвечает за открытие текстовых файлов формата txt.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void OpenTXT_Click(object sender, EventArgs e)
        {
            try
            {
                NewPageOpenQuestion();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog1.FileName;
                    string text = System.IO.File.ReadAllText(filename);

                    tabControl1.SelectedTab.Controls[0].Text = text;
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionColor = colorFont;
                    int length = (tabControl1.SelectedTab.Controls[0] as RichTextBox).TextLength;  // at end of text
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionStart = 0;
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionLength = length;
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionColor = colorFont;
                    string shortName = Path.GetFileName(filename);
                    tabControl1.SelectedTab.Text = shortName;
                    MessageBox.Show("Файл открыт!");
                    tabControl1.SelectedTab.Tag = filename;
                    files.Add(filename);
                }
                tabControl1.SelectedTab.Controls[0].BackColor = color;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }

        }

        /// <summary>
        /// Метод позволяет открыть файл в новом окне.
        /// </summary>
        private void NewPageOpenQuestion()
        {
            try
            {
                if (tabControl1.TabPages.Count == 10)
                {
                    MessageBox.Show("Достигнуто максимальное число вкладок(10)!");
                    return;
                }
                if (tabControl1.TabPages.Count != 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Хотите открыть файл в новой вкладке?",
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        );
                    if (result == DialogResult.Yes)
                    {
                        this.NewPage();
                    }
                    else
                    {
                        files.Remove(tabControl1.SelectedTab.Tag.ToString());
                    }
                }
                else
                {
                    this.NewPage();
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        /// <summary>
        /// Метод позволяет открывать текстовые файлы в формате rft.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void OpenRTF_Click(object sender, EventArgs e)
        {
            NewPageOpenQuestion();
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //RichTextBox rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                    //rtb.LoadFile(openFileDialog2.FileName, RichTextBoxStreamType.RichText);
                    string filename = openFileDialog2.FileName;
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).Rtf = System.IO.File.ReadAllText(filename);
                    string shortName = Path.GetFileName(filename);
                    tabControl1.SelectedTab.Text = shortName;
                    MessageBox.Show("Файл открыт!");
                    tabControl1.SelectedTab.Tag = filename;
                    files.Add(filename);
                    tabControl1.SelectedTab.Controls[0].BackColor = color;
                    int length = (tabControl1.SelectedTab.Controls[0] as RichTextBox).TextLength;  // at end of text
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionStart = 0;
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionLength = length;
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionColor = colorFont;               
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionColor = colorFont;
                }
                catch
                {
                    PageMinus_Click(null, null);
                    MessageBox.Show("Неверный формат содержимого файла!");
                }
            }            
        }

        /// <summary>
        /// Метод позволяет сохранить файл в формате TXT.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void saveAsTXT_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (tabControl1.SelectedTab.Tag.ToString() != "0")
                    {
                        files.Remove(tabControl1.SelectedTab.Tag.ToString());
                    }
                    string filename = saveFileDialog1.FileName;
                    files.Add(filename);
                    RichTextBox rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                    System.IO.File.WriteAllText(filename, rtb.Text);
                    tabControl1.SelectedTab.Tag = filename;
                    string shortName = Path.GetFileName(filename);
                    tabControl1.SelectedTab.Text = shortName;
                    MessageBox.Show("Файл сохранен!");
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }

        }
        /// <summary>
        /// Метод позволяет сохранить текстовый файл в формате rtf.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsRTF_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog2.FileName;
                    if (tabControl1.SelectedTab.Tag.ToString() != "0")
                    {
                        files.Remove(tabControl1.SelectedTab.Tag.ToString());
                    }
                    files.Add(filename);
                    RichTextBox rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                    System.IO.File.WriteAllText(filename, rtb.Rtf);
                    tabControl1.SelectedTab.Tag = filename;
                    string shortName = Path.GetFileName(filename);
                    tabControl1.SelectedTab.Text = shortName;
                    MessageBox.Show("Файл сохранен!");
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
 
        }

        /// <summary>
        /// Метод создает новую вкладку и цепляет на нее текстовое поле.
        /// </summary>
        private void NewPage()
        {
            try
            {
                TabPage newp = new TabPage();
                RichTextBox rtf = new RichTextBox();
                newp.Text = $"NewFile{countOfNewFiles}";
                newp.Name = $"NewFile{countOfNewFiles}";
                countOfNewFiles++;
                rtf.Size = new Size(768, 368);
                if(colorFont == Color.White)
                {
                    rtf.SelectionColor = System.Drawing.Color.White;
                }
                else
                {
                    rtf.SelectionColor = System.Drawing.Color.Black;
                }
                newp.Controls.Add(rtf);
                tabControl1.TabPages.Add(newp);
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                tabControl1.SelectedTab.Tag = "0";
                tabControl1.SelectedTab.Controls[0].BackColor = color;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }

        }
        /// <summary>
        /// Метод удаляет весь текст из выбранной вкладки.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void Clear_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBox rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                rtb.Clear();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }

        }

        /// <summary>
        /// Обработчик нажатия на кнопку добавления новой пустой вкладки.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void PagePlus_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count == 10)
                {
                    MessageBox.Show("Достигнуто максимальное число вкладок(10)!");
                    return;
                }
                this.NewPage();
                tabControl1.SelectedTab.Controls[0].BackColor = color;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }

        }

        /// <summary>
        /// Обработчик нажатия на кнопку удаления текущей страницы
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void PageMinus_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count != 0)
                {
                    if (tabControl1.SelectedTab.Tag.ToString() == "0")
                    {
                        if (!Empty())
                        {
                            SaveChangesQuestion($"Хотите сохранить файл {tabControl1.SelectedTab.Text}?");
                        }
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    }
                    else
                    {
                        if (!identity())
                        {
                            Regex regex = new Regex(@"\.rtf");
                            if (regex.IsMatch(tabControl1.SelectedTab.Tag.ToString()))
                            {
                                SaveChangesQuestion($"Хотите сохранить изменения в файле {tabControl1.SelectedTab.Text}?");
                            }
                        }
                        files.Remove(tabControl1.SelectedTab.Tag.ToString());
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    }
                }
                else
                {
                    MessageBox.Show("Нет ни одной вкладки!");
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }

        }

        /// <summary>
        /// Метод вызывает вопрос о сохранении несохраненных ранее изменений.
        /// </summary>
        /// <param name="question"></param>
        private void SaveChangesQuestion(string question)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    question,
                    "Предупреждение",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                    );
                if (result == DialogResult.Yes)
                {
                    this.Save_Click(null, null);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        /// <summary>
        /// Метод проверяет идентичность текстового файла его сохраненной версии.
        /// </summary>
        /// <returns>Правда, если строки равны, ложь, если не равны</returns>
        private bool identity()
        {
            try
            {
                string filename;
                filename = tabControl1.SelectedTab.Tag.ToString();  
                Regex regex1 = new Regex(@"\.rtf");
                Regex regex2 = new Regex(@"\.txt");
                if (regex1.IsMatch(filename))
                {
                    return (tabControl1.SelectedTab.Controls[0] as RichTextBox).Rtf == System.IO.File.ReadAllText(filename);
                }
                if (regex2.IsMatch(filename))
                {
                    return (tabControl1.SelectedTab.Controls[0] as RichTextBox).Text == System.IO.File.ReadAllText(filename);
                }
                return false;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
            return false;

        }

        /// <summary>
        /// Метод проверяет, является ли файл пустой строкой.
        /// </summary>
        /// <returns>ответ на вопрос</returns>
        private bool Empty()
        {

            return (tabControl1.SelectedTab.Controls[0] as RichTextBox).Text == "";

        }

        /// <summary>
        /// Метод отвечает за сохранение уже существующих файлов.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                string filename;
                Regex regex1 = new Regex(@"$\.rtf");
                if (System.IO.File.Exists(filename = tabControl1.SelectedTab.Tag.ToString()))
                {
                    if (!identity())
                    {
                        if (regex1.IsMatch(filename))
                        {
                            RichTextBox rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                            System.IO.File.WriteAllText(filename, rtb.Rtf);
                        }
                        else
                        {
                            RichTextBox rtb = tabControl1.SelectedTab.Controls[0] as RichTextBox;
                            System.IO.File.WriteAllText(filename, rtb.Text);
                        }
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                        "Хотите сохранить форматирование файла?",
                        "Предупреждение",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                        );
                    if (result == DialogResult.Yes)
                    {
                        this.saveAsRTF_Click(null, null);
                    }
                    else
                    {
                        this.saveAsTXT_Click(null, null);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        /// <summary>
        /// Метод выделяет выбранный фрагмент текста жирным шрифтом.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void Bold_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count != 0)
                {
                    if ((tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont != null)
                    {
                        System.Drawing.Font currentFont = (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont;
                        System.Drawing.FontStyle newFontStyle;

                        if ((tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont.Bold == true)
                        {
                            newFontStyle = currentFont.Style ^ FontStyle.Bold;
                        }
                        else
                        {
                            newFontStyle = FontStyle.Bold | currentFont.Style;
                        }
                        (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont = new Font(
                            currentFont.FontFamily,
                            currentFont.Size,
                            newFontStyle
                        );
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        /// <summary>
        /// Метод выделяет выбранный фрагмент текста курсивом.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void Italic_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count != 0)
                {
                    if ((tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont != null)
                    {
                        System.Drawing.Font currentFont = (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont;
                        System.Drawing.FontStyle newFontStyle;
                        if ((tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont.Italic == true)
                        {
                            newFontStyle = currentFont.Style ^ FontStyle.Italic;
                        }
                        else
                        {
                            newFontStyle = currentFont.Style | FontStyle.Italic;
                        }
                        (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont = new Font(
                            currentFont.FontFamily,
                            currentFont.Size,
                            newFontStyle
                        );
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }


        }

        /// <summary>
        /// Метод вызывает встроенную форму для выбора шрифта для выделенного фрагмента текста.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void Font_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count != 0)
                {
                    fontDialog1.ShowDialog();
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        /// <summary>
        /// Метод выделяет выбранный фрагмент текста подчеркиванием.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void Underline_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count != 0)
                {
                    if ((tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont != null)
                    {
                        System.Drawing.Font currentFont = (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont;
                        System.Drawing.FontStyle newFontStyle;

                        if ((tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont.Underline == true)
                        {
                            newFontStyle = currentFont.Style ^ FontStyle.Underline;
                        }
                        else
                        {
                            newFontStyle = currentFont.Style | FontStyle.Underline;
                        }
                        (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionFont = new Font(
                            currentFont.FontFamily,
                            currentFont.Size,
                            newFontStyle
                        );
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }

        }

        /// <summary>
        /// Метод обрабатывает изменение частоты автосохранения.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void ChangeTime_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(intTime.ToString(), out interval) & interval >= 10 & interval <= 1000)
                {
                    timer1.Interval = interval * 1000;
                }
                else
                {
                    MessageBox.Show(
                        "Число должно быть в интервале от 10 до 1000!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }

        }

        /// <summary>
        /// Метод изменяет тему приложения на ночную.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void NightTheme_Click(object sender, EventArgs e)
        {
            try
            {
                menuStrip1.BackColor = Color.Black;
                this.BackColor = Color.Blue;
                Program.BackColor = Color.White;
                Edit.BackColor = Color.White;
                File.BackColor = Color.White;
                Format.BackColor = Color.White;
                tabControl1.BackColor = Color.Black;      
                color = Color.Black;
                colorFont = Color.White;
                foreach(TabPage page in tabControl1.TabPages)
                {
                    page.Controls[0].BackColor = Color.Black;
                    int length = (page.Controls[0] as RichTextBox).TextLength;  // at end of text
                    (page.Controls[0] as RichTextBox).SelectionStart = 0;
                    (page.Controls[0] as RichTextBox).SelectionLength = length;
                    (page.Controls[0] as RichTextBox).SelectionColor = colorFont;
                    if (colorFont == Color.White)
                    {
                        (page.Controls[0] as RichTextBox).SelectionColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        (page.Controls[0] as RichTextBox).SelectionColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        /// <summary>
        /// Метод изменяет тему приложения на дневную.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void DayTheme_Click(object sender, EventArgs e)
        {
            try
            {
                menuStrip1.BackColor = Color.SkyBlue;
                this.BackColor = Color.DarkGray;
                Program.BackColor = Color.LightSkyBlue;
                Edit.BackColor = Color.LightSkyBlue;
                File.BackColor = Color.LightSkyBlue;
                Format.BackColor = Color.LightSkyBlue;
                color = Color.White;
                colorFont = Color.Black;
                foreach (TabPage page in tabControl1.TabPages)
                {
                    page.Controls[0].BackColor = color;
                    int length = (page.Controls[0] as RichTextBox).TextLength;  // at end of text
                    (page.Controls[0] as RichTextBox).SelectionStart = 0;
                    (page.Controls[0] as RichTextBox).SelectionLength = length;
                    (page.Controls[0] as RichTextBox).SelectionColor = colorFont;
                    if (colorFont == Color.White)
                    {
                        (page.Controls[0] as RichTextBox).SelectionColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        (page.Controls[0] as RichTextBox).SelectionColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }
        /// <summary>
        /// Метод обрабатывает нажатие горячих клавиш.
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            //открыть новую вкладку
            if (e.Control && e.KeyCode == Keys.P)
            {
                PagePlus_Click(sender, e);
            }
            //сохранение всех файлов
            if (e.Control && e.KeyCode == Keys.K)  
            {
                foreach(TabPage page in tabControl1.TabPages)
                {
                    tabControl1.SelectedTab = page;
                    Save_Click(sender, e);
                }
            }
        }
        // вставка текста
        void pasteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                (tabControl1.SelectedTab.Controls[0] as RichTextBox).AppendText(buffer);
            }
            catch
            {

            }
            // Open an bitmap from file and copy it to the clipboard.

            //(tabControl1.SelectedTab.Controls[0] as RichTextBox).Paste(buffer);
        }
        // копирование текста
        void copyMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // если выделен текст в текстовом поле, то копируем его в буфер
                buffer = (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectedText;
            }
            catch
            {
            }
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            ColorMenuItem_Click(null, null);
        }

        private void copy_Click(object sender, EventArgs e)
        {
            copyMenuItem_Click(null, null);
        }

        private void paste_Click(object sender, EventArgs e)
        {
            pasteMenuItem_Click(null, null);
        }
    }
}
