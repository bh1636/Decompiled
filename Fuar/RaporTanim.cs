// Decompiled with JetBrains decompiler
// Type: Fuar.RaporTanim
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Fuar.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class RaporTanim : XtraForm
  {
    public string rapor_id = string.Empty;
    private IContainer components;
    private GridControl dtg_test;
    private GridView grd_test;
    private GroupControl groupControl1;
    private RadioGroup rd_type;
    private GroupControl groupControl2;
    private MemoEdit mem_raporbilgi;
    private GroupControl groupControl3;
    private MemoEdit mem_sorgu;
    private SimpleButton btn_iptal;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_test;
    private GroupControl groupControl4;
    private GroupControl groupControl5;
    private SimpleButton btn_psil;
    private SimpleButton btn_pduzenle;
    private SimpleButton btn_pekle;
    private GridControl dtg_param;
    private GridView grd_param;
    private GridColumn g_id;
    private GridColumn g_ad;
    private GridColumn g_sqlad;
    private SimpleButton btn_kaydetkapat;
    private ErrorProvider ep1;
    private GroupControl groupControl6;
    private TextEdit t_rad;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlTop;
    private BarManager bm1;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_sil;
    private BarButtonItem bb_duzenle;
    private PopupMenu pp1;

    public RaporTanim() => this.InitializeComponent();

    private void RaporTanim_Load(object sender, EventArgs e)
    {
      if (!(this.rapor_id != string.Empty))
        return;
      this.load_rap();
    }

    private void load_rap()
    {
      DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM RAPORLAR WHERE ID = " + this.rapor_id);
      if (dataTable.Rows.Count <= 0)
        return;
      this.t_rad.Text = dataTable.Rows[0]["REPORTNAME"].ToString();
      this.rd_type.EditValue = (object) dataTable.Rows[0]["REPORTTYPE"].ToString();
      this.mem_raporbilgi.Text = dataTable.Rows[0]["REPORTINFO"].ToString();
      this.mem_sorgu.Text = dataTable.Rows[0]["REPORTDATA"].ToString();
    }

    private void get_params()
    {
      if (!(this.rapor_id != string.Empty))
        return;
      this.dtg_param.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM RAPORPARAMS WHERE REPORTID = " + this.rapor_id);
    }

    private void btn_pekle_Click(object sender, EventArgs e)
    {
      if (this.rapor_id == string.Empty)
      {
        int num1 = (int) MessageBox.Show("Parametre eklemek için önce raporu kaydetmelisiniz.");
      }
      else
      {
        int num2 = (int) new ParametreFrm()
        {
          rapor_id = this.rapor_id
        }.ShowDialog();
        this.get_params();
      }
    }

    private void btn_pduzenle_Click(object sender, EventArgs e)
    {
      try
      {
        string rowCellDisplayText = this.grd_param.GetFocusedRowCellDisplayText("ID");
        if (string.IsNullOrEmpty(rowCellDisplayText))
          return;
        int num = (int) new ParametreFrm()
        {
          rapor_id = this.rapor_id,
          parameter_id = rowCellDisplayText
        }.ShowDialog();
        this.get_params();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void btn_psil_Click(object sender, EventArgs e)
    {
      try
      {
        string rowCellDisplayText = this.grd_param.GetFocusedRowCellDisplayText("ID");
        if (string.IsNullOrEmpty(rowCellDisplayText) || MessageBox.Show(this.grd_param.GetFocusedRowCellDisplayText("PARAMCAPTION") + " isimli parametreyi silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
          return;
        _main.komutcalistir("DELETE FROM RAPORPARAMS WHERE ID = " + rowCellDisplayText);
        this.get_params();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydetkapat_Click(object sender, EventArgs e)
    {
      if (this.alankontrol())
        this.save_rap();
      this.Close();
    }

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (!this.alankontrol())
        return;
      this.save_rap();
    }

    private void RaporTanim_Activated(object sender, EventArgs e) => this.get_params();

    private void save_rap()
    {
      string text1 = this.t_rad.Text;
      string str1 = this.rd_type.EditValue.ToString();
      string text2 = this.mem_raporbilgi.Text;
      string text3 = this.mem_sorgu.Text;
      string str2 = _main.dt_user.Rows[0]["ADI"].ToString();
      if (this.rapor_id == string.Empty)
        this.rapor_id = _main.komutcalistir_str("INSERT INTO RAPORLAR (REPORTNAME, REPORTTYPE, ADDUSER, ADDDATE, REPORTINFO, REPORTDATA) " + "VALUES ('" + text1 + "','" + str1 + "','" + str2 + "',GETDATE(),'" + text2 + "','" + text3 + "') " + "SELECT @@IDENTITY");
      else
        _main.komutcalistir("UPDATE RAPORLAR SET REPORTNAME ='" + text1 + "', REPORTTYPE ='" + str1 + "', CHANGEDUSER ='" + str2 + "', " + "CHANGEDATE =GETDATE(), REPORTINFO ='" + text2 + "', REPORTDATA ='" + text3 + "' WHERE ID = " + this.rapor_id);
    }

    private bool alankontrol()
    {
      bool flag = true;
      if (this.t_rad.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.t_rad, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.mem_sorgu.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.mem_sorgu, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      return flag;
    }

    private void dtg_param_DoubleClick(object sender, EventArgs e)
    {
      this.btn_pduzenle_Click(sender, e);
    }

    private void bb_ekle_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_pekle_Click(sender, (EventArgs) e);
    }

    private void bb_duzenle_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_pduzenle_Click(sender, (EventArgs) e);
    }

    private void bb_sil_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_psil_Click(sender, (EventArgs) e);
    }

    private void dtg_param_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.grd_param.CalcHitInfo(e.Location);
      this.pp1.ShowPopup(Control.MousePosition);
    }

    private void btn_test_Click(object sender, EventArgs e)
    {
      try
      {
        DataTable dataTable = new DataTable();
        SqlConnection connection = new SqlConnection(_main.str_connection);
        SqlCommand sqlCommand = new SqlCommand(this.mem_sorgu.Text, connection);
        connection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        dataTable.Load((IDataReader) reader);
        connection.Close();
        this.dtg_test.DataSource = (object) dataTable;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
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
      this.dtg_test = new GridControl();
      this.grd_test = new GridView();
      this.groupControl1 = new GroupControl();
      this.rd_type = new RadioGroup();
      this.groupControl2 = new GroupControl();
      this.mem_raporbilgi = new MemoEdit();
      this.groupControl3 = new GroupControl();
      this.mem_sorgu = new MemoEdit();
      this.btn_iptal = new SimpleButton();
      this.btn_kaydet = new SimpleButton();
      this.btn_test = new SimpleButton();
      this.groupControl4 = new GroupControl();
      this.groupControl5 = new GroupControl();
      this.btn_psil = new SimpleButton();
      this.btn_pduzenle = new SimpleButton();
      this.btn_pekle = new SimpleButton();
      this.dtg_param = new GridControl();
      this.grd_param = new GridView();
      this.g_id = new GridColumn();
      this.g_ad = new GridColumn();
      this.g_sqlad = new GridColumn();
      this.btn_kaydetkapat = new SimpleButton();
      this.ep1 = new ErrorProvider(this.components);
      this.groupControl6 = new GroupControl();
      this.t_rad = new TextEdit();
      this.bm1 = new BarManager(this.components);
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControlRight = new BarDockControl();
      this.bb_ekle = new BarButtonItem();
      this.bb_sil = new BarButtonItem();
      this.bb_duzenle = new BarButtonItem();
      this.pp1 = new PopupMenu(this.components);
      this.dtg_test.BeginInit();
      this.grd_test.BeginInit();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.rd_type.Properties.BeginInit();
      this.groupControl2.BeginInit();
      this.groupControl2.SuspendLayout();
      this.mem_raporbilgi.Properties.BeginInit();
      this.groupControl3.BeginInit();
      this.groupControl3.SuspendLayout();
      this.mem_sorgu.Properties.BeginInit();
      this.groupControl4.BeginInit();
      this.groupControl4.SuspendLayout();
      this.groupControl5.BeginInit();
      this.groupControl5.SuspendLayout();
      this.dtg_param.BeginInit();
      this.grd_param.BeginInit();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.groupControl6.BeginInit();
      this.groupControl6.SuspendLayout();
      this.t_rad.Properties.BeginInit();
      this.bm1.BeginInit();
      this.pp1.BeginInit();
      this.SuspendLayout();
      this.dtg_test.Dock = DockStyle.Fill;
      this.dtg_test.Location = new Point(2, 21);
      this.dtg_test.MainView = (BaseView) this.grd_test;
      this.dtg_test.Name = "dtg_test";
      this.dtg_test.Size = new Size(1010, 136);
      this.dtg_test.TabIndex = 1;
      this.dtg_test.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_test
      });
      this.grd_test.GridControl = this.dtg_test;
      this.grd_test.Name = "grd_test";
      this.grd_test.OptionsBehavior.Editable = false;
      this.grd_test.OptionsBehavior.ReadOnly = true;
      this.grd_test.OptionsCustomization.AllowColumnMoving = false;
      this.grd_test.OptionsCustomization.AllowFilter = false;
      this.grd_test.OptionsCustomization.AllowGroup = false;
      this.grd_test.OptionsMenu.EnableColumnMenu = false;
      this.grd_test.OptionsMenu.EnableFooterMenu = false;
      this.grd_test.OptionsMenu.EnableGroupPanelMenu = false;
      this.grd_test.OptionsView.ShowGroupPanel = false;
      this.groupControl1.Controls.Add((Control) this.rd_type);
      this.groupControl1.Location = new Point(21, 61);
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(141, 95);
      this.groupControl1.TabIndex = 2;
      this.groupControl1.Text = "Rapor Ripi";
      this.rd_type.Dock = DockStyle.Fill;
      this.rd_type.EditValue = (object) "Tablo Rapor";
      this.rd_type.Location = new Point(2, 21);
      this.rd_type.Name = "rd_type";
      this.rd_type.Properties.Items.AddRange(new RadioGroupItem[3]
      {
        new RadioGroupItem((object) "Tablo Rapor", "Tablo Rapor"),
        new RadioGroupItem((object) "Pivot Rapor", "Pivot Rapor"),
        new RadioGroupItem((object) "Grafik Rapor", "Grafik Rapor")
      });
      this.rd_type.Size = new Size(137, 72);
      this.rd_type.TabIndex = 0;
      this.groupControl2.Controls.Add((Control) this.mem_raporbilgi);
      this.groupControl2.Location = new Point(168, 61);
      this.groupControl2.Name = "groupControl2";
      this.groupControl2.Size = new Size(580, 95);
      this.groupControl2.TabIndex = 3;
      this.groupControl2.Text = "Rapor Bilgisi (Açıklama)";
      this.mem_raporbilgi.Dock = DockStyle.Fill;
      this.mem_raporbilgi.Location = new Point(2, 21);
      this.mem_raporbilgi.Name = "mem_raporbilgi";
      this.mem_raporbilgi.Size = new Size(576, 72);
      this.mem_raporbilgi.TabIndex = 0;
      this.groupControl3.Controls.Add((Control) this.mem_sorgu);
      this.groupControl3.Location = new Point(21, 163);
      this.groupControl3.Name = "groupControl3";
      this.groupControl3.Size = new Size(727, 291);
      this.groupControl3.TabIndex = 4;
      this.groupControl3.Text = "Rapor Sorgusu";
      this.mem_sorgu.Dock = DockStyle.Fill;
      this.mem_sorgu.Location = new Point(2, 21);
      this.mem_sorgu.Name = "mem_sorgu";
      this.mem_sorgu.Size = new Size(723, 268);
      this.mem_sorgu.TabIndex = 0;
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(239, 678);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(101, 33);
      this.btn_iptal.TabIndex = 6;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(130, 678);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(101, 33);
      this.btn_kaydet.TabIndex = 5;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_test.Image = (Image) Resources.clean;
      this.btn_test.Location = new Point(21, 462);
      this.btn_test.Name = "btn_test";
      this.btn_test.Size = new Size(169, 33);
      this.btn_test.TabIndex = 7;
      this.btn_test.Text = "Sorguyu test et";
      this.btn_test.Click += new EventHandler(this.btn_test_Click);
      this.groupControl4.Controls.Add((Control) this.dtg_test);
      this.groupControl4.Location = new Point(21, 511);
      this.groupControl4.Name = "groupControl4";
      this.groupControl4.Size = new Size(1014, 159);
      this.groupControl4.TabIndex = 8;
      this.groupControl4.Text = "Sorgu Test Sonuçları";
      this.groupControl5.Controls.Add((Control) this.btn_psil);
      this.groupControl5.Controls.Add((Control) this.btn_pduzenle);
      this.groupControl5.Controls.Add((Control) this.btn_pekle);
      this.groupControl5.Controls.Add((Control) this.dtg_param);
      this.groupControl5.Location = new Point(765, 12);
      this.groupControl5.Name = "groupControl5";
      this.groupControl5.Size = new Size(270, 442);
      this.groupControl5.TabIndex = 9;
      this.groupControl5.Text = "Rapor Parametreleri";
      this.btn_psil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_psil.Location = new Point(176, 395);
      this.btn_psil.Name = "btn_psil";
      this.btn_psil.Size = new Size(75, 33);
      this.btn_psil.TabIndex = 8;
      this.btn_psil.Text = "Sil";
      this.btn_psil.Click += new EventHandler(this.btn_psil_Click);
      this.btn_pduzenle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_pduzenle.Location = new Point(95, 395);
      this.btn_pduzenle.Name = "btn_pduzenle";
      this.btn_pduzenle.Size = new Size(75, 33);
      this.btn_pduzenle.TabIndex = 7;
      this.btn_pduzenle.Text = "Düzenle";
      this.btn_pduzenle.Click += new EventHandler(this.btn_pduzenle_Click);
      this.btn_pekle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_pekle.Location = new Point(14, 395);
      this.btn_pekle.Name = "btn_pekle";
      this.btn_pekle.Size = new Size(75, 33);
      this.btn_pekle.TabIndex = 6;
      this.btn_pekle.Text = "Ekle";
      this.btn_pekle.Click += new EventHandler(this.btn_pekle_Click);
      this.dtg_param.Dock = DockStyle.Top;
      this.dtg_param.Location = new Point(2, 21);
      this.dtg_param.MainView = (BaseView) this.grd_param;
      this.dtg_param.Name = "dtg_param";
      this.dtg_param.Size = new Size(266, 361);
      this.dtg_param.TabIndex = 2;
      this.dtg_param.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_param
      });
      this.dtg_param.DoubleClick += new EventHandler(this.dtg_param_DoubleClick);
      this.dtg_param.MouseUp += new MouseEventHandler(this.dtg_param_MouseUp);
      this.grd_param.Columns.AddRange(new GridColumn[3]
      {
        this.g_id,
        this.g_ad,
        this.g_sqlad
      });
      this.grd_param.GridControl = this.dtg_param;
      this.grd_param.Name = "grd_param";
      this.grd_param.OptionsBehavior.Editable = false;
      this.grd_param.OptionsBehavior.ReadOnly = true;
      this.grd_param.OptionsCustomization.AllowColumnMoving = false;
      this.grd_param.OptionsCustomization.AllowColumnResizing = false;
      this.grd_param.OptionsCustomization.AllowFilter = false;
      this.grd_param.OptionsCustomization.AllowGroup = false;
      this.grd_param.OptionsCustomization.AllowQuickHideColumns = false;
      this.grd_param.OptionsCustomization.AllowSort = false;
      this.grd_param.OptionsMenu.EnableColumnMenu = false;
      this.grd_param.OptionsMenu.EnableFooterMenu = false;
      this.grd_param.OptionsMenu.EnableGroupPanelMenu = false;
      this.grd_param.OptionsView.ShowGroupPanel = false;
      this.g_id.Caption = "ID";
      this.g_id.FieldName = "ID";
      this.g_id.Name = "g_id";
      this.g_id.OptionsColumn.ShowInCustomizationForm = false;
      this.g_ad.Caption = "Parametre Adı";
      this.g_ad.FieldName = "PARAMCAPTION";
      this.g_ad.Name = "g_ad";
      this.g_ad.Visible = true;
      this.g_ad.VisibleIndex = 0;
      this.g_sqlad.Caption = "Parametre Sql Adı";
      this.g_sqlad.FieldName = "PARAMNAME";
      this.g_sqlad.Name = "g_sqlad";
      this.g_sqlad.Visible = true;
      this.g_sqlad.VisibleIndex = 1;
      this.btn_kaydetkapat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydetkapat.Location = new Point(21, 678);
      this.btn_kaydetkapat.Name = "btn_kaydetkapat";
      this.btn_kaydetkapat.Size = new Size(101, 33);
      this.btn_kaydetkapat.TabIndex = 10;
      this.btn_kaydetkapat.Text = "Kaydet ve Kapat";
      this.btn_kaydetkapat.Click += new EventHandler(this.btn_kaydetkapat_Click);
      this.ep1.ContainerControl = (ContainerControl) this;
      this.groupControl6.Controls.Add((Control) this.t_rad);
      this.groupControl6.Location = new Point(21, 12);
      this.groupControl6.Name = "groupControl6";
      this.groupControl6.Size = new Size(727, 43);
      this.groupControl6.TabIndex = 11;
      this.groupControl6.Text = "Rapor Adı";
      this.t_rad.Dock = DockStyle.Fill;
      this.t_rad.Location = new Point(2, 21);
      this.t_rad.Name = "t_rad";
      this.t_rad.Properties.MaxLength = 50;
      this.t_rad.Properties.NullText = "Rapor adı yazınız...";
      this.t_rad.Size = new Size(723, 20);
      this.t_rad.TabIndex = 0;
      this.bm1.DockControls.Add(this.barDockControlTop);
      this.bm1.DockControls.Add(this.barDockControlBottom);
      this.bm1.DockControls.Add(this.barDockControlLeft);
      this.bm1.DockControls.Add(this.barDockControlRight);
      this.bm1.Form = (Control) this;
      this.bm1.Items.AddRange(new BarItem[3]
      {
        (BarItem) this.bb_ekle,
        (BarItem) this.bb_sil,
        (BarItem) this.bb_duzenle
      });
      this.bm1.MaxItemId = 8;
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = DockStyle.Top;
      this.barDockControlTop.Location = new Point(0, 0);
      this.barDockControlTop.Size = new Size(1065, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 721);
      this.barDockControlBottom.Size = new Size(1065, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 721);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(1065, 0);
      this.barDockControlRight.Size = new Size(0, 721);
      this.bb_ekle.Caption = "Ekle";
      this.bb_ekle.Id = 0;
      this.bb_ekle.Name = "bb_ekle";
      this.bb_ekle.ItemClick += new ItemClickEventHandler(this.bb_ekle_ItemClick);
      this.bb_sil.Caption = "Sil";
      this.bb_sil.Id = 2;
      this.bb_sil.Name = "bb_sil";
      this.bb_sil.ItemClick += new ItemClickEventHandler(this.bb_sil_ItemClick);
      this.bb_duzenle.Caption = "Düzenle";
      this.bb_duzenle.Id = 5;
      this.bb_duzenle.Name = "bb_duzenle";
      this.bb_duzenle.ItemClick += new ItemClickEventHandler(this.bb_duzenle_ItemClick);
      this.pp1.LinksPersistInfo.AddRange(new LinkPersistInfo[3]
      {
        new LinkPersistInfo((BarItem) this.bb_ekle),
        new LinkPersistInfo((BarItem) this.bb_duzenle),
        new LinkPersistInfo((BarItem) this.bb_sil)
      });
      this.pp1.Manager = this.bm1;
      this.pp1.Name = "pp1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1065, 721);
      this.Controls.Add((Control) this.groupControl6);
      this.Controls.Add((Control) this.btn_kaydetkapat);
      this.Controls.Add((Control) this.groupControl5);
      this.Controls.Add((Control) this.groupControl4);
      this.Controls.Add((Control) this.btn_test);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.groupControl3);
      this.Controls.Add((Control) this.groupControl2);
      this.Controls.Add((Control) this.groupControl1);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.Name = nameof (RaporTanim);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Rapor Tanımı";
      this.Activated += new EventHandler(this.RaporTanim_Activated);
      this.Load += new EventHandler(this.RaporTanim_Load);
      this.dtg_test.EndInit();
      this.grd_test.EndInit();
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.rd_type.Properties.EndInit();
      this.groupControl2.EndInit();
      this.groupControl2.ResumeLayout(false);
      this.mem_raporbilgi.Properties.EndInit();
      this.groupControl3.EndInit();
      this.groupControl3.ResumeLayout(false);
      this.mem_sorgu.Properties.EndInit();
      this.groupControl4.EndInit();
      this.groupControl4.ResumeLayout(false);
      this.groupControl5.EndInit();
      this.groupControl5.ResumeLayout(false);
      this.dtg_param.EndInit();
      this.grd_param.EndInit();
      ((ISupportInitialize) this.ep1).EndInit();
      this.groupControl6.EndInit();
      this.groupControl6.ResumeLayout(false);
      this.t_rad.Properties.EndInit();
      this.bm1.EndInit();
      this.pp1.EndInit();
      this.ResumeLayout(false);
    }
  }
}
