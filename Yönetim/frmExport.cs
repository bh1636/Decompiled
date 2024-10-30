// Decompiled with JetBrains decompiler
// Type: Yönetim.frmExport
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Yönetim.Properties;

#nullable disable
namespace Yönetim
{
  public class frmExport : Form
  {
    private IContainer components = (IContainer) null;
    private GridControl gridControl1;
    private GridView gridView1;
    private ToolStrip toolStrip1;
    private ToolStripButton toolStripButton1;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolStripButton2;

    public frmExport() => this.InitializeComponent();

    private void frmExport_Load(object sender, EventArgs e)
    {
      this.gridControl1.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT * FROM Wv_SiparisAktarimListesi"));
      if (!File.Exists(Application.StartupPath + "\\Desing.xml"))
        return;
      this.gridView1.RestoreLayoutFromXml(Application.StartupPath + "\\Desing.xml");
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Exporto Excell |*.xls";
      int num = (int) saveFileDialog.ShowDialog();
      if (!(saveFileDialog.FileName != ""))
        return;
      this.gridControl1.ExportToExcelOld(saveFileDialog.FileName);
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
      if (File.Exists(Application.StartupPath + "\\Desing.xml"))
        File.Delete(Application.StartupPath + "\\Desing.xml");
      this.gridView1.SaveLayoutToXml(Application.StartupPath + "\\Desing.xml");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmExport));
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.toolStrip1 = new ToolStrip();
      this.toolStripButton1 = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButton2 = new ToolStripButton();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      this.gridControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gridControl1.Location = new Point(3, 28);
      this.gridControl1.LookAndFeel.SkinName = "Liquid Sky";
      this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new Size(953, 398);
      this.gridControl1.TabIndex = 2;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.Editable = false;
      this.gridView1.OptionsSelection.MultiSelect = true;
      this.gridView1.OptionsView.ColumnAutoWidth = false;
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.OptionsView.ShowFooter = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.toolStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.toolStripButton1,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripButton2
      });
      this.toolStrip1.Location = new Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(959, 25);
      this.toolStrip1.TabIndex = 3;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripButton1.Image = (Image) Resources.Excel;
      this.toolStripButton1.ImageTransparentColor = Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new Size(106, 22);
      this.toolStripButton1.Text = "EXPORT EXCEL";
      this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.toolStripButton2.Image = (Image) Resources._3floppy_mount;
      this.toolStripButton2.ImageTransparentColor = Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new Size(102, 22);
      this.toolStripButton2.Text = "Tasarımı Sakla";
      this.toolStripButton2.Click += new EventHandler(this.toolStripButton2_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(959, 431);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.gridControl1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmExport);
      this.Text = "Export";
      this.Load += new EventHandler(this.frmExport_Load);
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
