// Decompiled with JetBrains decompiler
// Type: Yönetim.frmAnaMain
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Localization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Logo_Evrak_Cevirici;
using Oto_Tahakkut;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Yönetim.Properties;

#nullable disable
namespace Yönetim
{
  public class frmAnaMain : Form
  {
    private bool yazdirmaDurum = false;
    private IContainer components = (IContainer) null;
    private ToolStrip toolStrip1;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripButton toolStripButton7;
    private ToolStripSeparator toolStripSeparator8;
    private ToolStripSeparator toolStripSeparator9;
    private ToolStripDropDownButton toolStripButton2;
    private ToolStripMenuItem mikrodanGüncelBilgileriAlToolStripMenuItem;
    private ToolStripMenuItem mikroyaSiparişleriAktarToolStripMenuItem;
    private ToolStripDropDownButton toolStripButton1;
    private ToolStripMenuItem logodanGüncelBilgileriAlToolStripMenuItem;
    private ToolStripMenuItem logoyaSiparişleriAktarToolStripMenuItem;
    private GroupControl groupControl1;
    private ToolStripButton toolStripButton6;
    private GridControl gridControl1;
    private GridView gridView1;
    private Timer timer1;
    private ToolStrip toolStrip2;
    private ToolStripButton toolStripButton4;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton toolStripButton8;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripSeparator toolStripSeparator11;
    private ToolStripSeparator toolStripSeparator10;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private ToolStripDropDownButton toolStripDropDownButton2;
    private ToolStripMenuItem otomatikYazdirmayıBaşlatToolStripMenuItem;
    private ToolStripMenuItem otomatikYazdirmayıKapatToolStripMenuItem;
    private ToolStripDropDownButton toolStripButton9;
    private ToolStripMenuItem stokKartlarıToolStripMenuItem;
    private ToolStripMenuItem stokFiyatListesiToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem elTerminalineProgramıKurToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem3;
    private ToolStripSeparator toolStripMenuItem2;
    private ToolStripMenuItem topluDeğişiklikToolStripMenuItem;
    private ToolStripButton toolStripButton11;
    private ToolStripDropDownButton toolStripButton12;
    private ToolStripMenuItem stokSiparişDağılımıToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem anaCariRaporuToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem4;
    private ToolStripSeparator toolStripSeparator13;
    private ToolStripMenuItem yedekleVeSilToolStripMenuItem;
    private ToolStripMenuItem yedekdenGeriYükleToolStripMenuItem;
    private ToolStripMenuItem exportToolStripMenuItem;
    private ToolStripButton toolStripButton14;
    private ToolStripMenuItem topluBarkodBasımToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem5;
    private ToolStripSeparator toolStripMenuItem6;
    private ToolStripMenuItem bağToolStripMenuItem;
    private Timer tmrYedekleme;
    private ToolStripButton toolStripButton5;
    private ToolStripMenuItem logoAktarımLObjectToolStripMenuItem;
    private RepositoryItemDateEdit repositoryItemDateEdit1;

    public frmAnaMain()
    {
      this.InitializeComponent();
      GridLocalizer.Active = (XtraLocalizer<GridStringId>) new TurkishLocalizer();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      this.tmrYedekleme.Interval = 1800000;
      this.timer1.Enabled = false;
      this.timer1.Enabled = true;
      this.timer1_Tick(sender, e);
    }

    private void frmMain_LocationChanged(object sender, EventArgs e)
    {
    }

    private void toolStripButton9_Click(object sender, EventArgs e)
    {
    }

    private void toolStripButton6_Click(object sender, EventArgs e)
    {
      frmYazdirmaKuyruk frmYazdirmaKuyruk = new frmYazdirmaKuyruk();
      frmYazdirmaKuyruk.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) frmYazdirmaKuyruk.ShowDialog();
    }

    private void toolStripButton5_Click(object sender, EventArgs e)
    {
      frmCariHesapRaporu frmCariHesapRaporu = new frmCariHesapRaporu();
      frmCariHesapRaporu.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) frmCariHesapRaporu.ShowDialog();
    }

    private void toolStripButton4_Click(object sender, EventArgs e)
    {
    }

    private void toolStripButton7_Click(object sender, EventArgs e) => this.Close();

    private void logodanGüncelBilgileriAlToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.timer1.Enabled = false;
      frmLogoVerial frmLogoVerial = new frmLogoVerial();
      frmLogoVerial.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) frmLogoVerial.ShowDialog();
    }

    private void toolStripButton8_Click(object sender, EventArgs e)
    {
    }

    private void mikrodanGüncelBilgileriAlToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmMikroVeriAl frmMikroVeriAl = new frmMikroVeriAl();
      frmMikroVeriAl.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) frmMikroVeriAl.ShowDialog();
    }

    private void alinanSiparişlerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmSiparisListesi frmSiparisListesi = new frmSiparisListesi();
      frmSiparisListesi.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) frmSiparisListesi.ShowDialog();
    }

    private void günlükSİparişRaporuToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmSiparisListesi frmSiparisListesi = new frmSiparisListesi();
      frmSiparisListesi.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) frmSiparisListesi.ShowDialog();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      try
      {
        this.gridControl1.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("SELECT * FROM ANALISTE"));
        for (int index = 0; index < ((DataTable) this.gridControl1.DataSource).Columns.Count; ++index)
        {
          if (((DataTable) this.gridControl1.DataSource).Columns[index].DataType.Name == "Double" || ((DataTable) this.gridControl1.DataSource).Columns[index].DataType.Name == "Decimal")
          {
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].DisplayFormat.FormatString = "D";
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].DisplayFormat.FormatType = FormatType.Numeric;
            this.gridView1.Columns[((DataTable) this.gridControl1.DataSource).Columns[index].Caption].SummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,##0.00} TL");
          }
        }
        for (int index = 0; index < this.gridView1.Columns.Count; ++index)
        {
          if (this.gridView1.Columns[index].ColumnType.FullName != "System.String" && this.gridView1.Columns[index].ColumnType.FullName != "System.Int32")
          {
            this.gridView1.Columns[index].DisplayFormat.FormatType = FormatType.Numeric;
            this.gridView1.Columns[index].DisplayFormat.FormatString = "C";
          }
        }
        this.gridView1.BestFitColumns();
      }
      catch (Exception ex)
      {
      }
    }

    private void toolStripButton3_Click(object sender, EventArgs e)
    {
      AboutBox1 aboutBox1 = new AboutBox1();
      aboutBox1.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) aboutBox1.ShowDialog();
    }

    private void gridView1_DoubleClick(object sender, EventArgs e)
    {
      if (this.gridView1.SelectedRowsCount <= 0)
        return;
      int num = (int) new frmSiparis()
      {
        Seri = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "SERİ").ToString(),
        Sira = Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "SIRA").ToString()),
        CariKod = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "MÜŞTERİ KOD").ToString(),
        CariUnvan = this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "CARİ UNVANI").ToString()
      }.ShowDialog();
      this.timer1_Tick(sender, e);
    }

    private void toolStripButton4_Click_1(object sender, EventArgs e)
    {
      if (this.gridView1.SelectedRowsCount <= 0 || MessageBox.Show("Siparişinizi Silmek İstediğinizden Eminmisiniz ? ", "Uyari", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
        return;
      DBManager.sqlRunCommand(new SqlCommand("DELETE FROM SIPARISLER WHERE sip_evrakno_seri='" + this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "SERİ").ToString() + "' and sip_evrakno_sira=" + this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "SIRA").ToString()));
      int num = (int) MessageBox.Show("Siparişiniz Silindi.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
      this.timer1_Tick(sender, e);
    }

    private void toolStripButton10_Click(object sender, EventArgs e)
    {
      frmSiparis frmSiparis = new frmSiparis();
      frmSiparis.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) frmSiparis.ShowDialog();
      this.timer1_Tick(sender, e);
    }

    private void toolStripButton8_Click_1(object sender, EventArgs e)
    {
      if (this.gridView1.SelectedRowsCount <= 0 || MessageBox.Show("Siparişinizi Yazdirmak İstediğinizden Eminmisiniz ? ", "Uyari", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
        return;
      foreach (int selectedRow in this.gridView1.GetSelectedRows())
      {
        string str1 = this.gridView1.GetRowCellValue(selectedRow, "SERİ").ToString();
        string str2 = this.gridView1.GetRowCellValue(selectedRow, "SIRA").ToString();
        SqlCommand mCommand = new SqlCommand("INSERT INTO RMZ_EVRAKLISTESI(EVRAKSERI,EVRAKSIRA,PRINTER,YAZDIRILDIMI) VALUES (@EVRAKSERI,@EVRAKSIRA,@PRINTER,@YAZDIRILDIMI)");
        mCommand.Parameters.AddWithValue("@EVRAKSERI", (object) str1);
        mCommand.Parameters.AddWithValue("@EVRAKSIRA", (object) str2);
        mCommand.Parameters.AddWithValue("@PRINTER", (object) "");
        mCommand.Parameters.AddWithValue("@YAZDIRILDIMI", (object) "");
        DBManager.sqlRunCommand(mCommand);
      }
    }

    private void otomatikYazdirmayıBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.yazdirmaDurum = false;
      foreach (Process process in Process.GetProcesses())
      {
        if (process.ProcessName == "Yazirma")
        {
          process.Kill();
          this.yazdirmaDurum = true;
        }
      }
      try
      {
        Process.Start(Application.StartupPath + "\\Yazdirma.exe");
      }
      catch
      {
        int num = (int) MessageBox.Show("Otomatik Yazdirma Başlatılamadı.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void otomatikYazdirmayıKapatToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.yazdirmaDurum = false;
      foreach (Process process in Process.GetProcesses())
      {
        if (process.ProcessName == "Yazdirma")
          process.Kill();
      }
    }

    private void mikroyaSiparişleriAktarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.timer1.Enabled = false;
      frmMikroSiparisKayit mikroSiparisKayit = new frmMikroSiparisKayit();
      mikroSiparisKayit.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) mikroSiparisKayit.ShowDialog();
      this.timer1.Enabled = true;
    }

    private void logoyaSiparişleriAktarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.timer1.Enabled = false;
      frmLogoSiparisKayit logoSiparisKayit = new frmLogoSiparisKayit();
      logoSiparisKayit.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) logoSiparisKayit.ShowDialog();
      this.timer1.Enabled = true;
    }

    private void stokKartlarıToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmStokKart frmStokKart = new frmStokKart();
      frmStokKart.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) frmStokKart.ShowDialog();
    }

    private void stokFiyatListesiToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmStokFiyatGuncelle stokFiyatGuncelle = new frmStokFiyatGuncelle();
      stokFiyatGuncelle.StartPosition = FormStartPosition.CenterScreen;
      stokFiyatGuncelle.WindowState = FormWindowState.Maximized;
      int num = (int) stokFiyatGuncelle.ShowDialog();
    }

    private void elTerminalineProgramıKurToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmTerminalKurulum frmTerminalKurulum = new frmTerminalKurulum();
      frmTerminalKurulum.StartPosition = FormStartPosition.CenterScreen;
      int num = (int) frmTerminalKurulum.ShowDialog();
    }

    private void topluDeğişiklikToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new frmTopluDegistiklik().ShowDialog();
    }

    private void toolStripButton11_Click(object sender, EventArgs e)
    {
      try
      {
        this.gridControl1.ShowPreview();
      }
      catch
      {
      }
    }

    private void stokSiparişDağılımıToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new frmStokSiparisDagilimi()
      {
        Rapor = "1"
      }.ShowDialog();
    }

    private void anaCariRaporuToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new frmStokSiparisDagilimi()
      {
        Rapor = "2"
      }.ShowDialog();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
    }

    private void yedeklemeVeSilmeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void yedekdenGeriAlmaToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void yedekleVeSilToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new frmYedeklemeVeSilme().ShowDialog();
    }

    private void yedekdenGeriYükleToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      int num1 = (int) openFileDialog.ShowDialog();
      if (!(openFileDialog.FileName != ""))
        return;
      DataTable dataTable = DBManager.sqlGetDataTable(new SqlCommand("SELECT * FROM SIPARISLER"));
      int num2 = (int) dataTable.ReadXml(openFileDialog.FileName);
      DBManager.Update(dataTable, DBManager.adp);
    }

    private void toolStripButton13_Click(object sender, EventArgs e)
    {
    }

    private void exportToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new frmExport().ShowDialog();
    }

    private void toolStripButton14_Click(object sender, EventArgs e) => this.timer1_Tick(sender, e);

    private void yeniPromosyonTanımıToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new frmPromosyon().ShowDialog();
    }

    private void toolStripButton5_Click_1(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Excell 2008+ |*.xlsx";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.gridControl1.ExportToXlsx(saveFileDialog.FileName);
      int num = (int) MessageBox.Show("AKTARILDI");
    }

    private void logoAktarımLObjectToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.timer1.Enabled = false;
      new frmlObjectAktarim().Show();
      this.timer1.Enabled = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmAnaMain));
      this.toolStrip1 = new ToolStrip();
      this.toolStripButton1 = new ToolStripDropDownButton();
      this.logodanGüncelBilgileriAlToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator11 = new ToolStripSeparator();
      this.logoyaSiparişleriAktarToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem4 = new ToolStripSeparator();
      this.logoAktarımLObjectToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.toolStripButton2 = new ToolStripDropDownButton();
      this.mikrodanGüncelBilgileriAlToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator10 = new ToolStripSeparator();
      this.mikroyaSiparişleriAktarToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator8 = new ToolStripSeparator();
      this.toolStripButton9 = new ToolStripDropDownButton();
      this.stokKartlarıToolStripMenuItem = new ToolStripMenuItem();
      this.stokFiyatListesiToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem2 = new ToolStripSeparator();
      this.topluDeğişiklikToolStripMenuItem = new ToolStripMenuItem();
      this.topluBarkodBasımToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButton6 = new ToolStripButton();
      this.toolStripSeparator9 = new ToolStripSeparator();
      this.toolStripDropDownButton2 = new ToolStripDropDownButton();
      this.otomatikYazdirmayıBaşlatToolStripMenuItem = new ToolStripMenuItem();
      this.otomatikYazdirmayıKapatToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem1 = new ToolStripSeparator();
      this.elTerminalineProgramıKurToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem3 = new ToolStripSeparator();
      this.yedekleVeSilToolStripMenuItem = new ToolStripMenuItem();
      this.yedekdenGeriYükleToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem5 = new ToolStripSeparator();
      this.exportToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem6 = new ToolStripSeparator();
      this.bağToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripButton12 = new ToolStripDropDownButton();
      this.stokSiparişDağılımıToolStripMenuItem = new ToolStripMenuItem();
      this.anaCariRaporuToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.toolStripButton7 = new ToolStripButton();
      this.groupControl1 = new GroupControl();
      this.toolStrip2 = new ToolStrip();
      this.toolStripButton4 = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripButton8 = new ToolStripButton();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this.toolStripButton11 = new ToolStripButton();
      this.toolStripSeparator13 = new ToolStripSeparator();
      this.toolStripButton14 = new ToolStripButton();
      this.toolStripButton5 = new ToolStripButton();
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.repositoryItemDateEdit1 = new RepositoryItemDateEdit();
      this.timer1 = new Timer(this.components);
      this.statusStrip1 = new StatusStrip();
      this.toolStripStatusLabel1 = new ToolStripStatusLabel();
      this.tmrYedekleme = new Timer(this.components);
      this.toolStrip1.SuspendLayout();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.toolStrip2.SuspendLayout();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.repositoryItemDateEdit1.BeginInit();
      this.repositoryItemDateEdit1.VistaTimeProperties.BeginInit();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      this.toolStrip1.BackColor = SystemColors.Window;
      this.toolStrip1.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
      this.toolStrip1.ImageScalingSize = new Size(22, 22);
      this.toolStrip1.Items.AddRange(new ToolStripItem[12]
      {
        (ToolStripItem) this.toolStripButton1,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.toolStripButton2,
        (ToolStripItem) this.toolStripSeparator8,
        (ToolStripItem) this.toolStripButton9,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripButton6,
        (ToolStripItem) this.toolStripSeparator9,
        (ToolStripItem) this.toolStripDropDownButton2,
        (ToolStripItem) this.toolStripButton12,
        (ToolStripItem) this.toolStripSeparator6,
        (ToolStripItem) this.toolStripButton7
      });
      this.toolStrip1.Location = new Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(1245, 29);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripButton1.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.logodanGüncelBilgileriAlToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator11,
        (ToolStripItem) this.logoyaSiparişleriAktarToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem4,
        (ToolStripItem) this.logoAktarımLObjectToolStripMenuItem
      });
      this.toolStripButton1.Image = (Image) componentResourceManager.GetObject("toolStripButton1.Image");
      this.toolStripButton1.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton1.ImageTransparentColor = Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new Size(114, 26);
      this.toolStripButton1.Text = "Logo Aktarim";
      this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
      this.logodanGüncelBilgileriAlToolStripMenuItem.Image = (Image) Resources.import1;
      this.logodanGüncelBilgileriAlToolStripMenuItem.Name = "logodanGüncelBilgileriAlToolStripMenuItem";
      this.logodanGüncelBilgileriAlToolStripMenuItem.Size = new Size(223, 28);
      this.logodanGüncelBilgileriAlToolStripMenuItem.Text = "Logodan Güncel Bilgileri Al";
      this.logodanGüncelBilgileriAlToolStripMenuItem.Click += new EventHandler(this.logodanGüncelBilgileriAlToolStripMenuItem_Click);
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      this.toolStripSeparator11.Size = new Size(220, 6);
      this.logoyaSiparişleriAktarToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("logoyaSiparişleriAktarToolStripMenuItem.Image");
      this.logoyaSiparişleriAktarToolStripMenuItem.Name = "logoyaSiparişleriAktarToolStripMenuItem";
      this.logoyaSiparişleriAktarToolStripMenuItem.Size = new Size(223, 28);
      this.logoyaSiparişleriAktarToolStripMenuItem.Text = "Logoya Siparişleri Aktar";
      this.logoyaSiparişleriAktarToolStripMenuItem.Click += new EventHandler(this.logoyaSiparişleriAktarToolStripMenuItem_Click);
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new Size(220, 6);
      this.logoAktarımLObjectToolStripMenuItem.Image = (Image) Resources.Actions_list_add;
      this.logoAktarımLObjectToolStripMenuItem.Name = "logoAktarımLObjectToolStripMenuItem";
      this.logoAktarımLObjectToolStripMenuItem.Size = new Size(223, 28);
      this.logoAktarımLObjectToolStripMenuItem.Text = "Logo Aktarım l-Object";
      this.logoAktarımLObjectToolStripMenuItem.Click += new EventHandler(this.logoAktarımLObjectToolStripMenuItem_Click);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(6, 29);
      this.toolStripButton2.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.mikrodanGüncelBilgileriAlToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator10,
        (ToolStripItem) this.mikroyaSiparişleriAktarToolStripMenuItem
      });
      this.toolStripButton2.Image = (Image) componentResourceManager.GetObject("toolStripButton2.Image");
      this.toolStripButton2.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton2.ImageTransparentColor = Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new Size(118, 26);
      this.toolStripButton2.Text = "Mikro Aktarim";
      this.mikrodanGüncelBilgileriAlToolStripMenuItem.Image = (Image) Resources.import1;
      this.mikrodanGüncelBilgileriAlToolStripMenuItem.Name = "mikrodanGüncelBilgileriAlToolStripMenuItem";
      this.mikrodanGüncelBilgileriAlToolStripMenuItem.Size = new Size(227, 28);
      this.mikrodanGüncelBilgileriAlToolStripMenuItem.Text = "Mikrodan Güncel Bilgileri Al";
      this.mikrodanGüncelBilgileriAlToolStripMenuItem.Click += new EventHandler(this.mikrodanGüncelBilgileriAlToolStripMenuItem_Click);
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new Size(224, 6);
      this.mikroyaSiparişleriAktarToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("mikroyaSiparişleriAktarToolStripMenuItem.Image");
      this.mikroyaSiparişleriAktarToolStripMenuItem.Name = "mikroyaSiparişleriAktarToolStripMenuItem";
      this.mikroyaSiparişleriAktarToolStripMenuItem.Size = new Size(227, 28);
      this.mikroyaSiparişleriAktarToolStripMenuItem.Text = "Mikroya Siparişleri Aktar";
      this.mikroyaSiparişleriAktarToolStripMenuItem.Click += new EventHandler(this.mikroyaSiparişleriAktarToolStripMenuItem_Click);
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new Size(6, 29);
      this.toolStripButton9.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.stokKartlarıToolStripMenuItem,
        (ToolStripItem) this.stokFiyatListesiToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem2,
        (ToolStripItem) this.topluDeğişiklikToolStripMenuItem,
        (ToolStripItem) this.topluBarkodBasımToolStripMenuItem
      });
      this.toolStripButton9.Image = (Image) componentResourceManager.GetObject("toolStripButton9.Image");
      this.toolStripButton9.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton9.ImageTransparentColor = Color.Magenta;
      this.toolStripButton9.Name = "toolStripButton9";
      this.toolStripButton9.Size = new Size(132, 26);
      this.toolStripButton9.Text = "Stok Kart Bilgileri";
      this.toolStripButton9.Click += new EventHandler(this.toolStripButton9_Click);
      this.stokKartlarıToolStripMenuItem.Image = (Image) Resources.kcmpartitions;
      this.stokKartlarıToolStripMenuItem.Name = "stokKartlarıToolStripMenuItem";
      this.stokKartlarıToolStripMenuItem.Size = new Size(196, 28);
      this.stokKartlarıToolStripMenuItem.Text = "Stok Kartları";
      this.stokKartlarıToolStripMenuItem.Click += new EventHandler(this.stokKartlarıToolStripMenuItem_Click);
      this.stokFiyatListesiToolStripMenuItem.Image = (Image) Resources.money2;
      this.stokFiyatListesiToolStripMenuItem.Name = "stokFiyatListesiToolStripMenuItem";
      this.stokFiyatListesiToolStripMenuItem.Size = new Size(196, 28);
      this.stokFiyatListesiToolStripMenuItem.Text = "Stok Fiyat Düzenleme";
      this.stokFiyatListesiToolStripMenuItem.Click += new EventHandler(this.stokFiyatListesiToolStripMenuItem_Click);
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new Size(193, 6);
      this.topluDeğişiklikToolStripMenuItem.Image = (Image) Resources.folder_document;
      this.topluDeğişiklikToolStripMenuItem.Name = "topluDeğişiklikToolStripMenuItem";
      this.topluDeğişiklikToolStripMenuItem.Size = new Size(196, 28);
      this.topluDeğişiklikToolStripMenuItem.Text = "Toplu İskonto Atama";
      this.topluDeğişiklikToolStripMenuItem.Click += new EventHandler(this.topluDeğişiklikToolStripMenuItem_Click);
      this.topluBarkodBasımToolStripMenuItem.Image = (Image) Resources.print;
      this.topluBarkodBasımToolStripMenuItem.Name = "topluBarkodBasımToolStripMenuItem";
      this.topluBarkodBasımToolStripMenuItem.Size = new Size(196, 28);
      this.topluBarkodBasımToolStripMenuItem.Text = "Toplu Barkod Basım";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 29);
      this.toolStripButton6.Image = (Image) Resources.print;
      this.toolStripButton6.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton6.ImageTransparentColor = Color.Magenta;
      this.toolStripButton6.Name = "toolStripButton6";
      this.toolStripButton6.Size = new Size(117, 26);
      this.toolStripButton6.Text = "Yazdırma Listesi";
      this.toolStripButton6.Click += new EventHandler(this.toolStripButton6_Click);
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new Size(6, 29);
      this.toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[11]
      {
        (ToolStripItem) this.otomatikYazdirmayıBaşlatToolStripMenuItem,
        (ToolStripItem) this.otomatikYazdirmayıKapatToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.elTerminalineProgramıKurToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem3,
        (ToolStripItem) this.yedekleVeSilToolStripMenuItem,
        (ToolStripItem) this.yedekdenGeriYükleToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem5,
        (ToolStripItem) this.exportToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem6,
        (ToolStripItem) this.bağToolStripMenuItem
      });
      this.toolStripDropDownButton2.Image = (Image) Resources.Setup;
      this.toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
      this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
      this.toolStripDropDownButton2.Size = new Size(169, 26);
      this.toolStripDropDownButton2.Text = "İşlemler && Yedeklemeler";
      this.otomatikYazdirmayıBaşlatToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("otomatikYazdirmayıBaşlatToolStripMenuItem.Image");
      this.otomatikYazdirmayıBaşlatToolStripMenuItem.Name = "otomatikYazdirmayıBaşlatToolStripMenuItem";
      this.otomatikYazdirmayıBaşlatToolStripMenuItem.Size = new Size(227, 28);
      this.otomatikYazdirmayıBaşlatToolStripMenuItem.Text = "Otomatik Yazdirmayı Başlat";
      this.otomatikYazdirmayıBaşlatToolStripMenuItem.Click += new EventHandler(this.otomatikYazdirmayıBaşlatToolStripMenuItem_Click);
      this.otomatikYazdirmayıKapatToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("otomatikYazdirmayıKapatToolStripMenuItem.Image");
      this.otomatikYazdirmayıKapatToolStripMenuItem.Name = "otomatikYazdirmayıKapatToolStripMenuItem";
      this.otomatikYazdirmayıKapatToolStripMenuItem.Size = new Size(227, 28);
      this.otomatikYazdirmayıKapatToolStripMenuItem.Text = "Otomatik Yazdirmayı Kapat";
      this.otomatikYazdirmayıKapatToolStripMenuItem.Click += new EventHandler(this.otomatikYazdirmayıKapatToolStripMenuItem_Click);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(224, 6);
      this.elTerminalineProgramıKurToolStripMenuItem.Image = (Image) Resources.import1;
      this.elTerminalineProgramıKurToolStripMenuItem.Name = "elTerminalineProgramıKurToolStripMenuItem";
      this.elTerminalineProgramıKurToolStripMenuItem.Size = new Size(227, 28);
      this.elTerminalineProgramıKurToolStripMenuItem.Text = "El Terminaline Programı Kur";
      this.elTerminalineProgramıKurToolStripMenuItem.Click += new EventHandler(this.elTerminalineProgramıKurToolStripMenuItem_Click);
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new Size(224, 6);
      this.yedekleVeSilToolStripMenuItem.Image = (Image) Resources.database_import;
      this.yedekleVeSilToolStripMenuItem.Name = "yedekleVeSilToolStripMenuItem";
      this.yedekleVeSilToolStripMenuItem.Size = new Size(227, 28);
      this.yedekleVeSilToolStripMenuItem.Text = "Yedekleme ve Silme";
      this.yedekleVeSilToolStripMenuItem.Click += new EventHandler(this.yedekleVeSilToolStripMenuItem_Click);
      this.yedekdenGeriYükleToolStripMenuItem.Image = (Image) Resources.Backup;
      this.yedekdenGeriYükleToolStripMenuItem.Name = "yedekdenGeriYükleToolStripMenuItem";
      this.yedekdenGeriYükleToolStripMenuItem.Size = new Size(227, 28);
      this.yedekdenGeriYükleToolStripMenuItem.Text = "Yedekden Geri Yükle";
      this.yedekdenGeriYükleToolStripMenuItem.Click += new EventHandler(this.yedekdenGeriYükleToolStripMenuItem_Click);
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new Size(224, 6);
      this.exportToolStripMenuItem.Image = (Image) Resources.export1;
      this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
      this.exportToolStripMenuItem.Size = new Size(227, 28);
      this.exportToolStripMenuItem.Text = "Dışarı Veri Aktarımı";
      this.exportToolStripMenuItem.Click += new EventHandler(this.exportToolStripMenuItem_Click);
      this.toolStripMenuItem6.Name = "toolStripMenuItem6";
      this.toolStripMenuItem6.Size = new Size(224, 6);
      this.bağToolStripMenuItem.Image = (Image) Resources.database_import;
      this.bağToolStripMenuItem.Name = "bağToolStripMenuItem";
      this.bağToolStripMenuItem.Size = new Size(227, 28);
      this.bağToolStripMenuItem.Text = "Bağlantı Tanımları";
      this.toolStripButton12.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.stokSiparişDağılımıToolStripMenuItem,
        (ToolStripItem) this.anaCariRaporuToolStripMenuItem
      });
      this.toolStripButton12.Image = (Image) Resources.folder_document;
      this.toolStripButton12.ImageTransparentColor = Color.Magenta;
      this.toolStripButton12.Name = "toolStripButton12";
      this.toolStripButton12.Size = new Size(86, 26);
      this.toolStripButton12.Text = "Raporlar";
      this.stokSiparişDağılımıToolStripMenuItem.Image = (Image) Resources.kcmpartitions;
      this.stokSiparişDağılımıToolStripMenuItem.Name = "stokSiparişDağılımıToolStripMenuItem";
      this.stokSiparişDağılımıToolStripMenuItem.Size = new Size(190, 28);
      this.stokSiparişDağılımıToolStripMenuItem.Text = "Stok Sipariş Dağılımı";
      this.stokSiparişDağılımıToolStripMenuItem.Click += new EventHandler(this.stokSiparişDağılımıToolStripMenuItem_Click);
      this.anaCariRaporuToolStripMenuItem.Image = (Image) Resources.kcmpartitions;
      this.anaCariRaporuToolStripMenuItem.Name = "anaCariRaporuToolStripMenuItem";
      this.anaCariRaporuToolStripMenuItem.Size = new Size(190, 28);
      this.anaCariRaporuToolStripMenuItem.Text = "Ana Cari Raporu";
      this.anaCariRaporuToolStripMenuItem.Click += new EventHandler(this.anaCariRaporuToolStripMenuItem_Click);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(6, 29);
      this.toolStripButton7.Image = (Image) componentResourceManager.GetObject("toolStripButton7.Image");
      this.toolStripButton7.ImageAlign = ContentAlignment.MiddleLeft;
      this.toolStripButton7.ImageTransparentColor = Color.Magenta;
      this.toolStripButton7.Name = "toolStripButton7";
      this.toolStripButton7.Size = new Size(63, 26);
      this.toolStripButton7.Text = "Kapat";
      this.toolStripButton7.Click += new EventHandler(this.toolStripButton7_Click);
      this.groupControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupControl1.Controls.Add((Control) this.toolStrip2);
      this.groupControl1.Controls.Add((Control) this.gridControl1);
      this.groupControl1.Location = new Point(1, 32);
      this.groupControl1.LookAndFeel.Style = LookAndFeelStyle.Office2003;
      this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(1243, 417);
      this.groupControl1.TabIndex = 1;
      this.groupControl1.Text = "Sipariş Listesi";
      this.toolStrip2.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
      this.toolStrip2.ImageScalingSize = new Size(23, 23);
      this.toolStrip2.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.toolStripButton4,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripButton8,
        (ToolStripItem) this.toolStripSeparator7,
        (ToolStripItem) this.toolStripButton11,
        (ToolStripItem) this.toolStripSeparator13,
        (ToolStripItem) this.toolStripButton14,
        (ToolStripItem) this.toolStripButton5
      });
      this.toolStrip2.Location = new Point(2, 18);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.Size = new Size(1239, 30);
      this.toolStrip2.TabIndex = 2;
      this.toolStrip2.Text = "toolStrip2";
      this.toolStripButton4.Image = (Image) componentResourceManager.GetObject("toolStripButton4.Image");
      this.toolStripButton4.ImageTransparentColor = Color.Magenta;
      this.toolStripButton4.Name = "toolStripButton4";
      this.toolStripButton4.Size = new Size(119, 27);
      this.toolStripButton4.Text = "Secili Siparişi Sil";
      this.toolStripButton4.Click += new EventHandler(this.toolStripButton4_Click_1);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 30);
      this.toolStripButton8.Image = (Image) Resources.print;
      this.toolStripButton8.ImageTransparentColor = Color.Magenta;
      this.toolStripButton8.Name = "toolStripButton8";
      this.toolStripButton8.Size = new Size(189, 27);
      this.toolStripButton8.Text = "Secili Siparişileri Tekrar Yazdir";
      this.toolStripButton8.Click += new EventHandler(this.toolStripButton8_Click_1);
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(6, 30);
      this.toolStripButton11.Image = (Image) Resources.print;
      this.toolStripButton11.ImageTransparentColor = Color.Magenta;
      this.toolStripButton11.Name = "toolStripButton11";
      this.toolStripButton11.Size = new Size(102, 27);
      this.toolStripButton11.Text = "Listeyi Yazdır";
      this.toolStripButton11.Click += new EventHandler(this.toolStripButton11_Click);
      this.toolStripSeparator13.Name = "toolStripSeparator13";
      this.toolStripSeparator13.Size = new Size(6, 30);
      this.toolStripButton14.Image = (Image) Resources.Sign_Refresh__1_;
      this.toolStripButton14.ImageTransparentColor = Color.Magenta;
      this.toolStripButton14.Name = "toolStripButton14";
      this.toolStripButton14.Size = new Size(65, 27);
      this.toolStripButton14.Text = "Yenile";
      this.toolStripButton14.Click += new EventHandler(this.toolStripButton14_Click);
      this.toolStripButton5.Image = (Image) Resources.Excel;
      this.toolStripButton5.ImageTransparentColor = Color.Magenta;
      this.toolStripButton5.Name = "toolStripButton5";
      this.toolStripButton5.Size = new Size(101, 27);
      this.toolStripButton5.Text = "Excelle Aktar";
      this.toolStripButton5.Click += new EventHandler(this.toolStripButton5_Click_1);
      this.gridControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gridControl1.EmbeddedNavigator.ButtonStyle = BorderStyles.Simple;
      this.gridControl1.Location = new Point(2, 52);
      this.gridControl1.LookAndFeel.SkinName = "Liquid Sky";
      this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[1]
      {
        (RepositoryItem) this.repositoryItemDateEdit1
      });
      this.gridControl1.Size = new Size(1239, 361);
      this.gridControl1.TabIndex = 1;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.Editable = false;
      this.gridView1.OptionsSelection.MultiSelect = true;
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.OptionsView.ShowFooter = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.DoubleClick += new EventHandler(this.gridView1_DoubleClick);
      this.repositoryItemDateEdit1.AutoHeight = false;
      this.repositoryItemDateEdit1.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
      this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.timer1.Enabled = true;
      this.timer1.Interval = 100000;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.statusStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripStatusLabel1
      });
      this.statusStrip1.Location = new Point(0, 449);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(1245, 22);
      this.statusStrip1.TabIndex = 4;
      this.statusStrip1.Text = "statusStrip1";
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new Size(144, 17);
      this.toolStripStatusLabel1.Text = "www.nrsdanismanlik.com";
      this.tmrYedekleme.Enabled = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1245, 471);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.groupControl1);
      this.Controls.Add((Control) this.toolStrip1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmAnaMain);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Extra Sipariş  Sistemi   { Nrs Bilişim Danışmanlık Hizmetleri }  Version : 10.0.23.5";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.frmMain_Load);
      this.LocationChanged += new EventHandler(this.frmMain_LocationChanged);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.repositoryItemDateEdit1.VistaTimeProperties.EndInit();
      this.repositoryItemDateEdit1.EndInit();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
