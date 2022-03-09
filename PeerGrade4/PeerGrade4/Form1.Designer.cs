
using System.Windows.Forms;

namespace PeerGrade4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Program = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.intTime = new System.Windows.Forms.ToolStripTextBox();
            this.ChangeTime = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nightTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTXT = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTXT = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.Format = new System.Windows.Forms.ToolStripMenuItem();
            this.Bold = new System.Windows.Forms.ToolStripMenuItem();
            this.Italic = new System.Windows.Forms.ToolStripMenuItem();
            this.Underline = new System.Windows.Forms.ToolStripMenuItem();
            this.Font = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PagePlus = new System.Windows.Forms.Button();
            this.PageMinus = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copy = new System.Windows.Forms.ToolStripMenuItem();
            this.paste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Program,
            this.File,
            this.Edit,
            this.Format});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Program
            // 
            this.Program.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Program.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.Exit});
            this.Program.Name = "Program";
            this.Program.Size = new System.Drawing.Size(65, 20);
            this.Program.Text = "Program";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoSave,
            this.themeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // AutoSave
            // 
            this.AutoSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intTime,
            this.ChangeTime});
            this.AutoSave.Name = "AutoSave";
            this.AutoSave.Size = new System.Drawing.Size(152, 22);
            this.AutoSave.Text = "Auto Save(sec)";
            // 
            // intTime
            // 
            this.intTime.Name = "intTime";
            this.intTime.Size = new System.Drawing.Size(100, 23);
            // 
            // ChangeTime
            // 
            this.ChangeTime.Name = "ChangeTime";
            this.ChangeTime.Size = new System.Drawing.Size(160, 22);
            this.ChangeTime.Text = "Change";
            this.ChangeTime.Click += new System.EventHandler(this.ChangeTime_Click);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dayToolStripMenuItem,
            this.nightTheme});
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.dayToolStripMenuItem.Text = "Day";
            this.dayToolStripMenuItem.Click += new System.EventHandler(this.DayTheme_Click);
            // 
            // nightTheme
            // 
            this.nightTheme.Name = "nightTheme";
            this.nightTheme.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.nightTheme.Size = new System.Drawing.Size(143, 22);
            this.nightTheme.Text = "Night";
            this.nightTheme.Click += new System.EventHandler(this.NightTheme_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.Exit.Size = new System.Drawing.Size(129, 22);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.Close_Click);
            // 
            // File
            // 
            this.File.BackColor = System.Drawing.Color.LightSkyBlue;
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.SaveAs,
            this.Save,
            this.Clear});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(37, 20);
            this.File.Text = "File";
            // 
            // Open
            // 
            this.Open.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenTXT,
            this.OpenRTF});
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(139, 22);
            this.Open.Text = "Open";
            // 
            // OpenTXT
            // 
            this.OpenTXT.Name = "OpenTXT";
            this.OpenTXT.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.OpenTXT.Size = new System.Drawing.Size(149, 22);
            this.OpenTXT.Text = "txt-file";
            this.OpenTXT.Click += new System.EventHandler(this.OpenTXT_Click);
            // 
            // OpenRTF
            // 
            this.OpenRTF.Name = "OpenRTF";
            this.OpenRTF.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.OpenRTF.Size = new System.Drawing.Size(149, 22);
            this.OpenRTF.Text = "rtf-file";
            this.OpenRTF.Click += new System.EventHandler(this.OpenRTF_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTXT,
            this.saveRTF});
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(139, 22);
            this.SaveAs.Text = "SaveAs";
            // 
            // saveTXT
            // 
            this.saveTXT.Name = "saveTXT";
            this.saveTXT.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.saveTXT.Size = new System.Drawing.Size(145, 22);
            this.saveTXT.Text = "txt-file";
            this.saveTXT.Click += new System.EventHandler(this.saveAsTXT_Click);
            // 
            // saveRTF
            // 
            this.saveRTF.Name = "saveRTF";
            this.saveRTF.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.saveRTF.Size = new System.Drawing.Size(145, 22);
            this.saveRTF.Text = "rtf-file";
            this.saveRTF.Click += new System.EventHandler(this.saveAsRTF_Click);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save.Size = new System.Drawing.Size(139, 22);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Clear
            // 
            this.Clear.Name = "Clear";
            this.Clear.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.Clear.Size = new System.Drawing.Size(139, 22);
            this.Clear.Text = "Clear";
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAll,
            this.copy,
            this.paste});
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(39, 20);
            this.Edit.Text = "Edit";
            // 
            // selectAll
            // 
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(180, 22);
            this.selectAll.Text = "SelectAll";
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // Format
            // 
            this.Format.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Format.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Bold,
            this.Italic,
            this.Underline,
            this.Font});
            this.Format.Name = "Format";
            this.Format.Size = new System.Drawing.Size(57, 20);
            this.Format.Text = "Format";
            // 
            // Bold
            // 
            this.Bold.BackColor = System.Drawing.SystemColors.Control;
            this.Bold.Name = "Bold";
            this.Bold.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.Bold.Size = new System.Drawing.Size(167, 22);
            this.Bold.Text = "Bold";
            this.Bold.Click += new System.EventHandler(this.Bold_Click);
            // 
            // Italic
            // 
            this.Italic.Name = "Italic";
            this.Italic.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.Italic.Size = new System.Drawing.Size(167, 22);
            this.Italic.Text = "Italic";
            this.Italic.Click += new System.EventHandler(this.Italic_Click);
            // 
            // Underline
            // 
            this.Underline.Name = "Underline";
            this.Underline.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.Underline.Size = new System.Drawing.Size(167, 22);
            this.Underline.Text = "Underline";
            this.Underline.Click += new System.EventHandler(this.Underline_Click);
            // 
            // Font
            // 
            this.Font.Name = "Font";
            this.Font.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.Font.Size = new System.Drawing.Size(167, 22);
            this.Font.Text = "Font";
            this.Font.Click += new System.EventHandler(this.Font_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "saveFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 382);
            this.tabControl1.TabIndex = 3;
            // 
            // PagePlus
            // 
            this.PagePlus.BackColor = System.Drawing.Color.Black;
            this.PagePlus.Location = new System.Drawing.Point(12, 415);
            this.PagePlus.Name = "PagePlus";
            this.PagePlus.Size = new System.Drawing.Size(75, 23);
            this.PagePlus.TabIndex = 4;
            this.PagePlus.Text = "Add";
            this.PagePlus.UseVisualStyleBackColor = false;
            this.PagePlus.Click += new System.EventHandler(this.PagePlus_Click);
            // 
            // PageMinus
            // 
            this.PageMinus.BackColor = System.Drawing.Color.Black;
            this.PageMinus.Location = new System.Drawing.Point(93, 415);
            this.PageMinus.Name = "PageMinus";
            this.PageMinus.Size = new System.Drawing.Size(75, 23);
            this.PageMinus.TabIndex = 5;
            this.PageMinus.Text = "Delete";
            this.PageMinus.UseVisualStyleBackColor = false;
            this.PageMinus.Click += new System.EventHandler(this.PageMinus_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // copy
            // 
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(180, 22);
            this.copy.Text = "Copy";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // paste
            // 
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(180, 22);
            this.paste.Text = "Paste";
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PageMinus);
            this.Controls.Add(this.PagePlus);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem Program;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem OpenTXT;
        private System.Windows.Forms.ToolStripMenuItem OpenRTF;
        private System.Windows.Forms.ToolStripMenuItem saveTXT;
        private System.Windows.Forms.ToolStripMenuItem saveRTF;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem Clear;
        private TabControl tabControl1;
        private Button PagePlus;
        private Button PageMinus;
        private ToolStripMenuItem Save;
        private ToolStripMenuItem Edit;
        private ToolStripMenuItem Format;
        private ToolStripMenuItem Bold;
        private ToolStripMenuItem Italic;
        private ToolStripMenuItem Underline;
        private new ToolStripMenuItem Font;
        private FontDialog fontDialog1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem AutoSave;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem dayToolStripMenuItem;
        private ToolStripMenuItem nightTheme;
        private Timer timer1;
        private ToolStripTextBox intTime;
        private ToolStripMenuItem ChangeTime;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem selectAll;
        private ToolStripMenuItem copy;
        private ToolStripMenuItem paste;
    }
}

