// Decompiled with JetBrains decompiler
// Type: Fuar.KatilimciFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class KatilimciFrm : XtraForm
  {
    public string _id = string.Empty;
    private int maxid_fuar;
    private int maxid_mus;
    private int maxid_tur;
    private List<string> id_lst = new List<string>();
    private IContainer components;
    private GroupBox groupBox1;
    private SimpleButton btn_iptal;
    private SimpleButton btn_kaydet;
    private MaskedTextBox txt_gsm;
    private TextBox txt_soyad;
    private TextBox txt_ad;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private DateEdit date_dt;
    private TextBox txt_tip;
    private Label label6;
    private MaskedTextBox txt_tckimlik;
    private GridControl dtg_kat;
    private GridView grd_kat;
    private GroupBox groupBox2;
    private RepositoryItemButtonEdit rp1;
    private BarManager bm1;
    private BarDockControl barDockControlTop;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_sil;
    private PopupMenu pp1;
    private ErrorProvider ep1;

    public KatilimciFrm() => this.InitializeComponent();

    private void KatilimciFrm_Load(object sender, EventArgs e) => this.xgrid_load();

    private void xgrid_load()
    {
      RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
      repositoryItemLookUpEdit1.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM FUARLAR");
      repositoryItemLookUpEdit1.DisplayMember = "FUARADI";
      repositoryItemLookUpEdit1.ValueMember = "ID";
      repositoryItemLookUpEdit1.AllowNullInput = DefaultBoolean.False;
      repositoryItemLookUpEdit1.NullValuePromptShowForEmptyValue = true;
      repositoryItemLookUpEdit1.NullText = "Fuar Seçiniz...";
      RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
      repositoryItemLookUpEdit2.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM ULASIM");
      repositoryItemLookUpEdit2.DisplayMember = "ULASIMSEKLI";
      repositoryItemLookUpEdit2.ValueMember = "ID";
      repositoryItemLookUpEdit2.NullValuePromptShowForEmptyValue = true;
      repositoryItemLookUpEdit2.NullText = "Ulaşım şeklini Seçiniz...";
      RepositoryItemLookUpEdit repositoryItemLookUpEdit3 = new RepositoryItemLookUpEdit();
      repositoryItemLookUpEdit3.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM TURBILGI");
      repositoryItemLookUpEdit3.DisplayMember = "TURADI";
      repositoryItemLookUpEdit3.ValueMember = "ID";
      repositoryItemLookUpEdit3.NullValuePromptShowForEmptyValue = true;
      repositoryItemLookUpEdit3.NullText = "Tur Şirketini Seçiniz...";
      RepositoryItemLookUpEdit repositoryItemLookUpEdit4 = new RepositoryItemLookUpEdit();
      repositoryItemLookUpEdit4.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM MUSTERILER");
      repositoryItemLookUpEdit4.DisplayMember = "FIRMAADI";
      repositoryItemLookUpEdit4.ValueMember = "ID";
      repositoryItemLookUpEdit4.AllowNullInput = DefaultBoolean.False;
      repositoryItemLookUpEdit4.NullValuePromptShowForEmptyValue = true;
      repositoryItemLookUpEdit4.NullText = "Firma Seçiniz...";
      if (this._id != "")
      {
        DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM KATILIMCILAR WHERE ID = " + this._id);
        if (dataTable.Rows.Count > 0)
        {
          this.txt_ad.Text = dataTable.Rows[0]["ADI"].ToString();
          this.txt_soyad.Text = dataTable.Rows[0]["SOYADI"].ToString();
          this.txt_tckimlik.Text = dataTable.Rows[0]["TCKIMLIKNO"].ToString();
          this.txt_gsm.Text = dataTable.Rows[0]["GSM"].ToString();
          this.txt_tip.Text = dataTable.Rows[0]["TIP"].ToString();
          this.date_dt.DateTime = Convert.ToDateTime(dataTable.Rows[0]["DTARIH"]);
          this.dtg_kat.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM KATILIMCIHAR WHERE KATID = " + this._id);
        }
      }
      else
        this.dtg_kat.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM KATILIMCIHAR").Clone();
      this.grd_kat.Columns["ID"].Visible = false;
      this.grd_kat.Columns["KATID"].Visible = false;
      this.grd_kat.Columns["FUARID"].Caption = "FUAR";
      this.grd_kat.Columns["FUARID"].ColumnEdit = (RepositoryItem) repositoryItemLookUpEdit1;
      this.grd_kat.Columns["ULASIMID"].Caption = "ULAŞIM ŞEKLİ";
      this.grd_kat.Columns["ULASIMID"].ColumnEdit = (RepositoryItem) repositoryItemLookUpEdit2;
      this.grd_kat.Columns["TURID"].Caption = "TUR ŞİRKETİ";
      this.grd_kat.Columns["TURID"].ColumnEdit = (RepositoryItem) repositoryItemLookUpEdit3;
      this.grd_kat.Columns["MUSTERIID"].Caption = "MÜŞTERİ";
      this.grd_kat.Columns["MUSTERIID"].ColumnEdit = (RepositoryItem) repositoryItemLookUpEdit4;
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (!this.alan_kontrol())
        return;
      if (this._id == "")
        this.insert_kat();
      else
        this.update_kat();
      this.Close();
    }

    private void dtg_kat_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Shift && e.KeyCode == Keys.Insert)
        this.setnewrow();
      if (e.Shift && e.KeyCode == Keys.Delete && !string.IsNullOrEmpty(this.grd_kat.GetFocusedRowCellDisplayText("ID")) && MessageBox.Show("Seçili Katılımcı işlemini silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
      {
        this.id_lst.Add(this.grd_kat.GetFocusedRowCellValue("ID").ToString());
        this.grd_kat.DeleteSelectedRows();
      }
      if (e.KeyData != Keys.Delete)
        return;
      this.grd_kat.SetFocusedValue((object) 0);
    }

    private void setnewrow()
    {
      if (!this.cmb_kontrol())
        return;
      this.grd_kat.AddNewRow();
      this.grd_kat.SetFocusedRowCellValue("FUARID", (object) this.maxid_fuar);
      this.grd_kat.SetFocusedRowCellValue("MUSTERIID", (object) this.maxid_mus);
      this.grd_kat.SetFocusedRowCellValue("AKTARMA", (object) false);
    }

    private string set_is_null(string deger)
    {
      string str;
      try
      {
        str = !string.IsNullOrEmpty(deger) ? (!string.IsNullOrWhiteSpace(deger) ? deger : "0") : "0";
      }
      catch
      {
        return "0";
      }
      return str;
    }

    private bool cmb_kontrol()
    {
      this.maxid_fuar = _main.komutcalistir_int("IF(EXISTS(SELECT ID FROM FUARLAR WHERE AKTIF = 1)) BEGIN SELECT ID FROM FUARLAR WHERE AKTIF = 1 END " + "ELSE BEGIN  SELECT MAX(ID) AS ID FROM FUARLAR END");
      this.maxid_mus = _main.komutcalistir_int("SELECT MAX(ID) FROM MUSTERILER");
      if (this.maxid_fuar == 0)
      {
        int num = (int) MessageBox.Show("Fuar bilgisi bulunamadı. \nİlgili kart tanımlarından oluşturunuz.");
        return false;
      }
      if (this.maxid_mus != 0)
        return true;
      int num1 = (int) MessageBox.Show("Müşteri bilgisi bulunamadı. \nİlgili kart tanımlarından oluşturunuz.");
      return false;
    }

    private void dtg_kat_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
    }

    private void bb_ekle_ItemClick(object sender, ItemClickEventArgs e) => this.setnewrow();

    private void bb_sil_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (string.IsNullOrEmpty(this.grd_kat.GetFocusedRowCellDisplayText("ID")) || MessageBox.Show("Seçili Katılımcı işlemini silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
        return;
      this.id_lst.Add(this.grd_kat.GetFocusedRowCellValue("ID").ToString());
      this.grd_kat.DeleteSelectedRows();
    }

    private bool alan_kontrol()
    {
      bool flag = true;
      if (this.txt_ad.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_ad, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.txt_soyad.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_soyad, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.txt_tckimlik.Text.Length < 12)
      {
        this.ep1.SetError((Control) this.txt_tckimlik, "Alanı eksiksiz doldurunuz");
        return false;
      }
      this.ep1.Clear();
      if (this.txt_gsm.Text.Length < 11)
      {
        this.ep1.SetError((Control) this.txt_gsm, "Alanı eksiksiz doldurunuz");
        return false;
      }
      this.ep1.Clear();
      if (this.date_dt.EditValue == null)
      {
        this.ep1.SetError((Control) this.date_dt, "Tarih Seçiniz");
        return false;
      }
      this.ep1.Clear();
      if (this.grd_kat.RowCount != 0)
        return flag;
      int num = (int) MessageBox.Show("Katılımcı işlemi eklemelisiniz.");
      return false;
    }

    private void insert_kat()
    {
      string str = _main.komutcalistir_str("INSERT INTO KATILIMCILAR (ADI,SOYADI,DTARIH,TCKIMLIKNO,GSM,TIP) " + "VALUES ('" + this.txt_ad.Text + "','" + this.txt_soyad.Text + "','" + this.date_dt.DateTime.ToString("s") + "','" + this.txt_tckimlik.Text + "','" + this.txt_gsm.Text + "','" + this.txt_tip.Text + "') " + "SELECT @@IDENTITY AS KATILIMCIID ");
      if (string.IsNullOrEmpty(str))
        return;
      string empty = string.Empty;
      for (int dataSourceIndex = 0; dataSourceIndex < this.grd_kat.RowCount; ++dataSourceIndex)
        _main.komutcalistir("INSERT INTO KATILIMCIHAR (KATID,FUARID,ULASIMID,TURID,MUSTERIID,BILETNO,AKTARMA,AKTARMAUCRETI) " + " VALUES (" + str + "," + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "FUARID").ToString() + "," + this.set_is_null(this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "ULASIMID").ToString()) + "," + this.set_is_null(this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "TURID").ToString()) + "," + this.set_is_null(this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "MUSTERIID").ToString()) + ",'" + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "BILETNO").ToString() + "','" + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "AKTARMA").ToString() + "','" + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "AKTARMAUCRETI").ToString() + "')");
    }

    private void update_kat()
    {
      _main.komutcalistir("UPDATE KATILIMCILAR SET ADI = '" + this.txt_ad.Text + "',SOYADI = '" + this.txt_soyad.Text + "',DTARIH = '" + this.date_dt.DateTime.ToString("s") + "',TCKIMLIKNO = '" + this.txt_tckimlik.Text + "',GSM = '" + this.txt_gsm.Text + "',TIP = '" + this.txt_tip.Text + "'" + " WHERE ID = " + this._id);
      string str1 = string.Empty;
      string empty = string.Empty;
      for (int dataSourceIndex = 0; dataSourceIndex < this.grd_kat.RowCount; ++dataSourceIndex)
      {
        string str2 = this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "ID").ToString();
        if (str2 != "")
          _main.komutcalistir("IF EXISTS( SELECT ID FROM KATILIMCIHAR WHERE ID = " + str2 + ") BEGIN UPDATE KATILIMCIHAR SET " + "FUARID = " + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "FUARID").ToString() + ",ULASIMID = " + this.set_is_null(this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "ULASIMID").ToString()) + ",TURID = " + this.set_is_null(this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "TURID").ToString()) + ", MUSTERIID = " + this.set_is_null(this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "MUSTERIID").ToString()) + ", BILETNO = '" + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "BILETNO").ToString() + "',AKTARMA = '" + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "AKTARMA").ToString() + "',AKTARMAUCRETI = '" + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "AKTARMAUCRETI").ToString() + "' WHERE ID = " + str2 + " END " + "ELSE BEGIN " + "INSERT INTO KATILIMCIHAR (KATID,FUARID,ULASIMID,TURID,MUSTERIID,BILETNO,AKTARMA,AKTARMAUCRETI) " + " VALUES (" + this._id + "," + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "FUARID").ToString() + "," + this.set_is_null(this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "ULASIMID").ToString()) + "," + this.set_is_null(this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "TURID").ToString()) + "," + this.set_is_null(this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "MUSTERIID").ToString()) + ",'" + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "BILETNO").ToString() + "','" + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "AKTARMA").ToString() + "','" + this.grd_kat.GetRowCellValue(this.grd_kat.GetRowHandle(dataSourceIndex), "AKTARMAUCRETI").ToString() + "') END");
      }
      if (this.id_lst.Count <= 0)
        return;
      for (int index = 0; index < this.id_lst.Count; ++index)
        str1 = str1 + "'" + this.id_lst[index] + "',";
      _main.komutcalistir("DELETE FROM KATILIMCIHAR WHERE KATID = " + this._id + " AND ID IN (" + str1.Remove(str1.Length - 1) + ")");
      this.id_lst.Clear();
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
      this.groupBox1 = new GroupBox();
      this.txt_tckimlik = new MaskedTextBox();
      this.txt_tip = new TextBox();
      this.date_dt = new DateEdit();
      this.txt_gsm = new MaskedTextBox();
      this.txt_soyad = new TextBox();
      this.txt_ad = new TextBox();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.btn_iptal = new SimpleButton();
      this.btn_kaydet = new SimpleButton();
      this.dtg_kat = new GridControl();
      this.grd_kat = new GridView();
      this.rp1 = new RepositoryItemButtonEdit();
      this.groupBox2 = new GroupBox();
      this.bm1 = new BarManager(this.components);
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControlRight = new BarDockControl();
      this.bb_ekle = new BarButtonItem();
      this.bb_sil = new BarButtonItem();
      this.pp1 = new PopupMenu(this.components);
      this.ep1 = new ErrorProvider(this.components);
      this.groupBox1.SuspendLayout();
      this.date_dt.Properties.VistaTimeProperties.BeginInit();
      this.date_dt.Properties.BeginInit();
      this.dtg_kat.BeginInit();
      this.grd_kat.BeginInit();
      this.rp1.BeginInit();
      this.groupBox2.SuspendLayout();
      this.bm1.BeginInit();
      this.pp1.BeginInit();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.txt_tckimlik);
      this.groupBox1.Controls.Add((Control) this.txt_tip);
      this.groupBox1.Controls.Add((Control) this.date_dt);
      this.groupBox1.Controls.Add((Control) this.txt_gsm);
      this.groupBox1.Controls.Add((Control) this.txt_soyad);
      this.groupBox1.Controls.Add((Control) this.txt_ad);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Location = new Point(22, 25);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(567, 117);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Katılımcı Tanımları";
      this.txt_tckimlik.Location = new Point(114, 79);
      this.txt_tckimlik.Mask = "000000000000";
      this.txt_tckimlik.Name = "txt_tckimlik";
      this.txt_tckimlik.Size = new Size(145, 21);
      this.txt_tckimlik.TabIndex = 3;
      this.txt_tckimlik.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.txt_tip.Location = new Point(405, 51);
      this.txt_tip.Name = "txt_tip";
      this.txt_tip.Size = new Size(145, 21);
      this.txt_tip.TabIndex = 5;
      this.date_dt.EditValue = (object) null;
      this.date_dt.Location = new Point(405, 79);
      this.date_dt.Name = "date_dt";
      this.date_dt.Properties.AllowNullInput = DefaultBoolean.False;
      this.date_dt.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.date_dt.Properties.MaxValue = new DateTime(2100, 12, 31, 0, 0, 0, 0);
      this.date_dt.Properties.MinValue = new DateTime(2000, 1, 1, 0, 0, 0, 0);
      this.date_dt.Properties.NullValuePrompt = "Tarih Seçiniz...";
      this.date_dt.Properties.NullValuePromptShowForEmptyValue = true;
      this.date_dt.Properties.VistaTimeProperties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.date_dt.Size = new Size(100, 20);
      this.date_dt.TabIndex = 6;
      this.txt_gsm.Location = new Point(405, 23);
      this.txt_gsm.Mask = "(0000) 000 00 00";
      this.txt_gsm.Name = "txt_gsm";
      this.txt_gsm.Size = new Size(145, 21);
      this.txt_gsm.TabIndex = 4;
      this.txt_gsm.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.txt_soyad.Location = new Point(114, 51);
      this.txt_soyad.Name = "txt_soyad";
      this.txt_soyad.Size = new Size(145, 21);
      this.txt_soyad.TabIndex = 2;
      this.txt_ad.Location = new Point(114, 23);
      this.txt_ad.Name = "txt_ad";
      this.txt_ad.Size = new Size(145, 21);
      this.txt_ad.TabIndex = 1;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(310, 54);
      this.label6.Name = "label6";
      this.label6.Size = new Size(85, 13);
      this.label6.TabIndex = 0;
      this.label6.Text = "Yakınlık Derecesi";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(310, 82);
      this.label5.Name = "label5";
      this.label5.Size = new Size(69, 13);
      this.label5.TabIndex = 0;
      this.label5.Text = "Doğum Tarihi";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(310, 26);
      this.label4.Name = "label4";
      this.label4.Size = new Size(43, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "Gsm No";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(25, 82);
      this.label3.Name = "label3";
      this.label3.Size = new Size(72, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "T.C. Kimlik No";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(25, 54);
      this.label2.Name = "label2";
      this.label2.Size = new Size(40, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "SoyAdı";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(25, 26);
      this.label1.Name = "label1";
      this.label1.Size = new Size(22, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Adı";
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(110, 366);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 9;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(22, 366);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 8;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.dtg_kat.Dock = DockStyle.Fill;
      this.dtg_kat.Location = new Point(3, 17);
      this.dtg_kat.MainView = (BaseView) this.grd_kat;
      this.dtg_kat.Name = "dtg_kat";
      this.dtg_kat.RepositoryItems.AddRange(new RepositoryItem[1]
      {
        (RepositoryItem) this.rp1
      });
      this.dtg_kat.Size = new Size(561, 187);
      this.dtg_kat.TabIndex = 7;
      this.dtg_kat.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_kat
      });
      this.dtg_kat.KeyDown += new KeyEventHandler(this.dtg_kat_KeyDown);
      this.dtg_kat.MouseUp += new MouseEventHandler(this.dtg_kat_MouseUp);
      this.grd_kat.GridControl = this.dtg_kat;
      this.grd_kat.Name = "grd_kat";
      this.grd_kat.OptionsView.ShowGroupPanel = false;
      this.rp1.AutoHeight = false;
      this.rp1.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Glyph)
      });
      this.rp1.Name = "rp1";
      this.rp1.TextEditStyle = TextEditStyles.HideTextEditor;
      this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.dtg_kat);
      this.groupBox2.Location = new Point(22, 148);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(567, 207);
      this.groupBox2.TabIndex = 5;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Katılımcı İşlemleri";
      this.bm1.DockControls.Add(this.barDockControlTop);
      this.bm1.DockControls.Add(this.barDockControlBottom);
      this.bm1.DockControls.Add(this.barDockControlLeft);
      this.bm1.DockControls.Add(this.barDockControlRight);
      this.bm1.Form = (Control) this;
      this.bm1.Items.AddRange(new BarItem[2]
      {
        (BarItem) this.bb_ekle,
        (BarItem) this.bb_sil
      });
      this.bm1.MaxItemId = 4;
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = DockStyle.Top;
      this.barDockControlTop.Location = new Point(0, 0);
      this.barDockControlTop.Size = new Size(626, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 417);
      this.barDockControlBottom.Size = new Size(626, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 417);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(626, 0);
      this.barDockControlRight.Size = new Size(0, 417);
      this.bb_ekle.Caption = "Ekle";
      this.bb_ekle.Id = 0;
      this.bb_ekle.Name = "bb_ekle";
      this.bb_ekle.ItemClick += new ItemClickEventHandler(this.bb_ekle_ItemClick);
      this.bb_sil.Caption = "Sil";
      this.bb_sil.Id = 2;
      this.bb_sil.Name = "bb_sil";
      this.bb_sil.ItemClick += new ItemClickEventHandler(this.bb_sil_ItemClick);
      this.pp1.LinksPersistInfo.AddRange(new LinkPersistInfo[2]
      {
        new LinkPersistInfo((BarItem) this.bb_ekle),
        new LinkPersistInfo((BarItem) this.bb_sil)
      });
      this.pp1.Manager = this.bm1;
      this.pp1.Name = "pp1";
      this.ep1.ContainerControl = (ContainerControl) this;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(626, 417);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.KeyPreview = true;
      this.Name = nameof (KatilimciFrm);
      this.Text = "Katılımcı";
      this.Load += new EventHandler(this.KatilimciFrm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.date_dt.Properties.VistaTimeProperties.EndInit();
      this.date_dt.Properties.EndInit();
      this.dtg_kat.EndInit();
      this.grd_kat.EndInit();
      this.rp1.EndInit();
      this.groupBox2.ResumeLayout(false);
      this.bm1.EndInit();
      this.pp1.EndInit();
      ((ISupportInitialize) this.ep1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
