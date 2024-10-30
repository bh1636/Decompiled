// Decompiled with JetBrains decompiler
// Type: Fuar.SiparisFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class SiparisFrm : XtraForm
  {
    public string _sipno = string.Empty;
    public static string mlz_ad = string.Empty;
    public static string mlz_kod = string.Empty;
    public static string mus_kod = string.Empty;
    public static string mus_name = string.Empty;
    public static string mus_id = string.Empty;
    public string stat = string.Empty;
    public static DataTable dt_musteri = new DataTable();
    private IContainer components;
    private BarDockControl barDockControlRight;
    private GroupBox groupBox1;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private GroupBox groupBox3;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private BarManager bm1;
    private BarDockControl barDockControlTop;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControl1;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_sil;
    private ErrorProvider ep1;
    private PopupMenu pp1;
    private ButtonEdit txt_firmaunvan;
    private ButtonEdit txt_firmakod;
    private DateEdit dt_date;
    private Label label6;
    private TimeEdit tm_time;
    private MemoEdit txt_aciklama;
    private TextEdit txt_no;
    private GridControl dtg_sip;
    private GridView grd_sip;
    private Label label8;
    private Label label7;
    private TextEdit txt_barkod;
    private RepositoryItemButtonEdit btn1;
    private TextEdit txt_miktar;
    private Label label9;
    private ComboBoxEdit cmb_odeme;
    private SimpleButton btn_kapat;
    private GroupBox groupBox2;
    private TextEdit txt_nettop;
    private TextEdit txt_kdv;
    private TextEdit txt_kdvsiztop;
    private TextEdit txt_ind;
    private TextEdit txt_toplam;
    private Label label14;
    private Label label13;
    private Label label12;
    private Label label11;
    private Label label10;
    private Label l_ted;
    private LookUpEdit cmb_ted;
    private ButtonEdit txt_firmaid;

    public SiparisFrm() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (!this.alankontrol())
        return;
      try
      {
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        string empty3 = string.Empty;
        DataTable dataSource = (DataTable) this.dtg_sip.DataSource;
        string str1 = !(this.stat == "edit") ? this.get_max_sipno() : this.txt_no.Text;
        string str2 = !(_main.dt_user.Rows[0]["KULLANICIADI"].ToString() == "ADMIN") ? _main.dt_user.Rows[0]["TEDARIKCIID"].ToString() : this.cmb_ted.EditValue.ToString();
        SiparisFrm.mus_id = this.txt_firmaid.Text;
        _main.komutcalistir("DELETE FROM SIPARISLER WHERE SIPARISNO = '" + str1 + "'");
        for (int index = 0; index < dataSource.Rows.Count; ++index)
        {
          if (dataSource.Rows[index]["MALZEMEKOD"].ToString() != "")
          {
            string str3 = dataSource.Rows[index]["KDVORANI"].ToString().Replace(",", ".");
            string str4 = dataSource.Rows[index]["KDVTUTARI"].ToString().Replace(",", ".");
            if (str3 == "")
              str3 = "0";
            if (str4 == "")
              str4 = "0";
            _main.komutcalistir("INSERT INTO SIPARISLER (SIPARISTARIHI, SIPARISSAATI, SIPARISNO, MUSTERIREF, KULLANICIREF, TEDARIKCIREF, ACIKLAMA, ODEMESEKLI, SATIRTURU, MALZEMEREF, MALZEMEKOD, " + "BIRIM, MIKTAR, BIRIMFIYAT, TUTAR, INDIRIMREF, INDIRIMORANI1, INDIRIMORANI2,TEDIND, INDIRIMTUTARI, NETTUTAR, SATIRACIKLAMA, TESLIMTARIHI, SATIRNO, KDVORANI, KDVTUTARI) " + "VALUES     ('" + this.dt_date.DateTime.ToString("yyyy-MM-dd") + "','" + this.tm_time.Time.ToString("HH:mm:ss") + "','" + str1 + "','" + SiparisFrm.mus_id + "','" + _main.dt_user.Rows[0]["ID"].ToString() + "', " + "'" + str2 + "','" + this.txt_aciklama.Text + "','" + this.cmb_odeme.SelectedItem.ToString() + "','" + dataSource.Rows[index]["SATIRTURU"].ToString() + "', " + "'" + dataSource.Rows[index]["MALZEMEREF"].ToString() + "','" + dataSource.Rows[index]["MALZEMEKOD"].ToString() + "','" + dataSource.Rows[index]["BIRIM"].ToString() + "','" + dataSource.Rows[index]["MIKTAR"].ToString().Replace(",", ".") + "','" + dataSource.Rows[index]["BIRIMFIYAT"].ToString().Replace(",", ".") + "', " + "'" + dataSource.Rows[index]["TUTAR"].ToString().Replace(",", ".") + "','" + dataSource.Rows[index]["INDIRIMREF"].ToString() + "','" + dataSource.Rows[index]["INDIRIMORANI1"].ToString().Replace(",", ".") + "','" + dataSource.Rows[index]["INDIRIMORANI2"].ToString().Replace(",", ".") + "', " + "'" + dataSource.Rows[index]["TEDIND"].ToString().Replace(",", ".") + "','" + dataSource.Rows[index]["INDIRIMTUTARI"].ToString().Replace(",", ".") + "','" + dataSource.Rows[index]["NETTUTAR"].ToString().Replace(",", ".") + "', " + "'" + dataSource.Rows[index]["SATIRACIKLAMA"].ToString().Replace("'", " ").Replace('"', ' ') + "','" + Convert.ToDateTime(dataSource.Rows[index]["TESLIMTARIHI"]).ToString("yyyy-MM-dd") + "'," + (index + 1).ToString() + "," + str3 + "," + str4 + ")");
          }
        }
        this.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void bb_ekle_ItemClick(object sender, ItemClickEventArgs e) => this.grd_sip.AddNewRow();

    private void bb_sil_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (this.grd_sip.FocusedRowHandle != -1)
        this.grd_sip.DeleteRow(this.grd_sip.FocusedRowHandle);
      this.set_toplamlar();
    }

    private void SiparisFrm_Load(object sender, EventArgs e)
    {
      this.get_tedarikci();
      this.xgrid_load();
      if (this.stat == "edit")
        this.txt_no.Properties.ReadOnly = true;
      else if (this.stat == "view")
      {
        this.txt_barkod.Enabled = false;
        this.txt_firmakod.Enabled = false;
        this.txt_firmaunvan.Enabled = false;
        this.txt_miktar.Enabled = false;
        this.txt_aciklama.Enabled = false;
        this.grd_sip.OptionsBehavior.Editable = false;
        this.dt_date.Enabled = false;
        this.tm_time.Enabled = false;
        this.cmb_odeme.Enabled = false;
        this.cmb_ted.Enabled = false;
        this.btn_iptal.Visible = false;
        this.btn_kaydet.Visible = false;
        this.btn_kapat.Visible = true;
      }
      this.txt_no.Visible = false;
    }

    private void xgrid_load()
    {
      RepositoryItemComboBox repositoryItemComboBox1 = new RepositoryItemComboBox();
      repositoryItemComboBox1.Items.Add((object) "Malzeme");
      repositoryItemComboBox1.Items.Add((object) "Promosyon");
      repositoryItemComboBox1.TextEditStyle = TextEditStyles.DisableTextEditor;
      RepositoryItemComboBox repositoryItemComboBox2 = new RepositoryItemComboBox();
      repositoryItemComboBox2.TextEditStyle = TextEditStyles.DisableTextEditor;
      this.cmb_odeme.Properties.Items.Add((object) "P");
      this.cmb_odeme.Properties.Items.Add((object) "A");
      this.cmb_odeme.Properties.Items.Add((object) "B");
      this.cmb_odeme.Properties.Items.Add((object) "C");
      this.cmb_odeme.Properties.Items.Add((object) "F");
      this.cmb_odeme.SelectedIndex = 1;
      if (_main.dt_user.Rows[0]["KULLANICIADI"].ToString() == "ADMIN")
      {
        this.cmb_ted.Enabled = true;
      }
      else
      {
        this.cmb_ted.EditValue = _main.dt_user.Rows[0]["TEDARIKCIID"];
        this.cmb_ted.Enabled = false;
      }
      if (this._sipno != "")
      {
        DataTable dataTable = _main.komutcalistir_dt("SELECT MU.FIRMAKODU, MU.FIRMAADI, MA.AD AS MALZEMEAD, S.ID, S.SIPARISTARIHI, S.SIPARISSAATI, S.SIPARISNO, S.MUSTERIREF, S.KULLANICIREF, S.TEDARIKCIREF, S.ACIKLAMA, " + "S.ODEMESEKLI, S.SATIRTURU, S.SATIRNO, S.MALZEMEKOD, S.BIRIM, S.MIKTAR, S.BIRIMFIYAT, S.TUTAR, S.INDIRIMREF, S.INDIRIMORANI1, S.INDIRIMORANI2,S.TEDIND, S.KDVORANI, S.KDVTUTARI, " + "S.INDIRIMTUTARI, S.NETTUTAR, S.SATIRACIKLAMA, S.KATSAYI, S.TESLIMTARIHI, S.DURUM, S.IPTAL, MU.ID AS MUSID FROM SIPARISLER AS S INNER JOIN MUSTERILER AS MU ON S.MUSTERIREF = MU.ID INNER JOIN " + "MALZEMELER AS MA ON S.MALZEMEKOD = MA.KOD WHERE S.SIPARISNO  = '" + this._sipno + "' ORDER BY S.SATIRNO");
        if (dataTable.Rows.Count > 0)
        {
          this.txt_no.Text = this._sipno;
          this.dt_date.DateTime = Convert.ToDateTime(dataTable.Rows[0]["SIPARISTARIHI"]);
          this.tm_time.Time = Convert.ToDateTime(dataTable.Rows[0]["SIPARISSAATI"].ToString());
          this.txt_firmaid.Text = dataTable.Rows[0]["MUSID"].ToString();
          this.txt_firmakod.Text = dataTable.Rows[0]["FIRMAKODU"].ToString();
          this.txt_firmaunvan.Text = dataTable.Rows[0]["FIRMAADI"].ToString();
          SiparisFrm.mus_id = dataTable.Rows[0]["MUSID"].ToString();
          this.txt_aciklama.Text = dataTable.Rows[0]["ACIKLAMA"].ToString();
          this.cmb_odeme.SelectedItem = (object) dataTable.Rows[0]["ODEMESEKLI"].ToString();
          this.cmb_ted.EditValue = dataTable.Rows[0]["TEDARIKCIREF"];
          dataTable.Columns.Add("MALZEMEREF", typeof (int));
          DataTable table = dataTable.DefaultView.ToTable(false, "ID", "SATIRTURU", "MALZEMEREF", "MALZEMEKOD", "BIRIM", "INDIRIMREF", "MIKTAR", "BIRIMFIYAT", "TUTAR", "INDIRIMORANI1", "INDIRIMORANI2", "TEDIND", "INDIRIMTUTARI", "KDVORANI", "KDVTUTARI", "NETTUTAR", "SATIRACIKLAMA", "TESLIMTARIHI");
          table.Columns.Add("MALZEMEAD");
          table.Columns["MALZEMEAD"].SetOrdinal(4);
          for (int index = 0; index < table.Rows.Count; ++index)
            table.Rows[index]["MALZEMEAD"] = (object) _main.komutcalistir_str("SELECT AD FROM MALZEMELER WHERE KOD = '" + table.Rows[index]["MALZEMEKOD"].ToString() + "'");
          this.dtg_sip.DataSource = (object) table;
        }
      }
      else
      {
        DataTable dataTable = _main.komutcalistir_dt("SELECT ID,SATIRTURU,MALZEMEREF,MALZEMEKOD,BIRIM,INDIRIMREF,MIKTAR,BIRIMFIYAT,TUTAR,INDIRIMORANI1,INDIRIMORANI2,TEDIND,INDIRIMTUTARI,KDVORANI,KDVTUTARI,NETTUTAR,SATIRACIKLAMA,TESLIMTARIHI FROM SIPARISLER WHERE 1=2").Clone();
        dataTable.Columns.Add("MALZEMEAD");
        dataTable.Columns["MALZEMEAD"].SetOrdinal(4);
        this.dtg_sip.DataSource = (object) dataTable;
        this.dt_date.DateTime = DateTime.Now;
        this.tm_time.Time = DateTime.Now;
      }
      this.grd_sip.Columns["MALZEMEKOD"].ColumnEdit = (RepositoryItem) this.btn1;
      this.grd_sip.Columns["MALZEMEKOD"].Caption = "ÜRÜN";
      this.grd_sip.Columns["MALZEMEKOD"].FilterMode = ColumnFilterMode.DisplayText;
      this.grd_sip.Columns["MALZEMEKOD"].UnboundType = UnboundColumnType.String;
      this.grd_sip.Columns["MALZEMEAD"].Caption = "ÜRÜN ADI";
      this.grd_sip.Columns["MALZEMEAD"].OptionsColumn.AllowEdit = false;
      this.grd_sip.Columns["TUTAR"].OptionsColumn.AllowEdit = false;
      this.grd_sip.Columns["TUTAR"].DisplayFormat.FormatType = FormatType.Numeric;
      this.grd_sip.Columns["TUTAR"].DisplayFormat.FormatString = "n2";
      this.grd_sip.Columns["INDIRIMORANI1"].OptionsColumn.AllowEdit = false;
      this.grd_sip.Columns["INDIRIMORANI2"].OptionsColumn.AllowEdit = false;
      this.grd_sip.Columns["INDIRIMTUTARI"].DisplayFormat.FormatType = FormatType.Numeric;
      this.grd_sip.Columns["INDIRIMTUTARI"].DisplayFormat.FormatString = "n2";
      this.grd_sip.Columns["NETTUTAR"].OptionsColumn.AllowEdit = false;
      this.grd_sip.Columns["NETTUTAR"].DisplayFormat.FormatType = FormatType.Numeric;
      this.grd_sip.Columns["NETTUTAR"].DisplayFormat.FormatString = "n2";
      this.grd_sip.Columns["SATIRTURU"].ColumnEdit = (RepositoryItem) repositoryItemComboBox1;
      this.grd_sip.Columns["BIRIM"].ColumnEdit = (RepositoryItem) repositoryItemComboBox2;
      this.grd_sip.Columns["BIRIM"].Caption = "BİRİM";
      this.grd_sip.Columns["ID"].Visible = false;
      this.grd_sip.Columns["MALZEMEREF"].Visible = false;
      this.grd_sip.Columns["INDIRIMREF"].Visible = false;
      this.grd_sip.Columns["INDIRIMORANI1"].Visible = false;
      this.grd_sip.Columns["INDIRIMORANI2"].Visible = false;
      this.grd_sip.Columns["KDVORANI"].OptionsColumn.AllowEdit = false;
      this.grd_sip.Columns["KDVTUTARI"].OptionsColumn.AllowEdit = false;
      this.grd_sip.Columns["KDVTUTARI"].DisplayFormat.FormatType = FormatType.Numeric;
      this.grd_sip.Columns["KDVTUTARI"].DisplayFormat.FormatString = "n2";
      this.grd_sip.Columns["BIRIMFIYAT"].DisplayFormat.FormatType = FormatType.Numeric;
      this.grd_sip.Columns["BIRIMFIYAT"].DisplayFormat.FormatString = "n2";
      this.grd_sip.Columns["TEDIND"].Visible = false;
      this.set_toplamlar();
      this.grd_sip.AddNewRow();
    }

    private void txt_barkod_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.txt_firmakod.Text.Length > 0 && this.txt_firmaunvan.Text.Length > 0)
      {
        this.set_newrow(this.txt_barkod.Text, this.txt_miktar.Text);
        this.txt_barkod.Text = "";
        this.txt_miktar.Text = "1";
        this.grd_sip.Focus();
        this.txt_barkod.Focus();
      }
      else
      {
        int num = (int) MessageBox.Show("Önce müşteri seçiniz.");
      }
    }

    private void btn1_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      if (this.txt_firmakod.Text.Length > 0 && this.txt_firmaunvan.Text.Length > 0)
      {
        int num = (int) new MalzemeSel().ShowDialog();
        if (!(SiparisFrm.mlz_ad != ""))
          return;
        this.grd_sip.SetFocusedRowCellValue("MALZEMEKOD", (object) SiparisFrm.mlz_kod);
        this.grd_sip.SetFocusedRowCellValue("MALZEMEAD", (object) SiparisFrm.mlz_ad);
        if (this.grd_sip.GetFocusedRowCellValue("SATIRTURU").ToString() == "")
          this.grd_sip.SetFocusedRowCellValue("SATIRTURU", (object) "Malzeme");
        this.grd_sip.SetFocusedRowCellValue("BIRIM", (object) this.get_main_unit(SiparisFrm.mlz_kod));
        DateTime dateTime = this.dt_date.DateTime;
        this.grd_sip.SetFocusedRowCellValue("TESLIMTARIHI", (object) this.dt_date.DateTime);
        if (this.grd_sip.GetFocusedRowCellValue("MIKTAR").ToString() == "")
          this.grd_sip.SetFocusedRowCellValue("MIKTAR", (object) "1");
        this.grd_sip.MoveLastVisible();
        if (!(this.grd_sip.GetFocusedRowCellValue("MALZEMEKOD").ToString() != ""))
          return;
        this.grd_sip.AddNewRow();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Önce müşteri seçiniz.");
      }
    }

    private void btn1_DoubleClick(object sender, EventArgs e)
    {
      if (this.txt_firmakod.Text.Length > 0 && this.txt_firmaunvan.Text.Length > 0)
      {
        int num = (int) new MalzemeSel().ShowDialog();
        if (!(SiparisFrm.mlz_ad != ""))
          return;
        this.grd_sip.SetFocusedRowCellValue("MALZEMEKOD", (object) SiparisFrm.mlz_kod);
        this.grd_sip.SetFocusedRowCellValue("MALZEMEAD", (object) SiparisFrm.mlz_ad);
        this.grd_sip.SetFocusedRowCellValue("SATIRTURU", (object) "Malzeme");
        this.grd_sip.SetFocusedRowCellValue("BIRIM", (object) this.get_main_unit(SiparisFrm.mlz_kod));
        DateTime dateTime = this.dt_date.DateTime;
        this.grd_sip.SetFocusedRowCellValue("TESLIMTARIHI", (object) this.dt_date.DateTime);
        if (this.grd_sip.GetFocusedRowCellValue("MIKTAR").ToString() == "")
          this.grd_sip.SetFocusedRowCellValue("MIKTAR", (object) "1");
        this.grd_sip.MoveLastVisible();
        if (!(this.grd_sip.GetFocusedRowCellValue("MALZEMEKOD").ToString() != ""))
          return;
        this.grd_sip.AddNewRow();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Önce müşteri seçiniz.");
      }
    }

    private void dtg_sip_MouseUp(object sender, MouseEventArgs e)
    {
      if (!(this.stat != "view") || e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
    }

    private void grd_sip_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
    {
      if (!(e.Column.FieldName == "BIRIM") || !(this.grd_sip.GetRowCellDisplayText(e.RowHandle, "MALZEMEKOD") != ""))
        return;
      e.RepositoryItem = this.get_birim_rep(this.grd_sip.GetRowCellDisplayText(e.RowHandle, "MALZEMEKOD"));
    }

    private RepositoryItem get_birim_rep(string s_mkod)
    {
      string sql_str = "SELECT B.BIRIM,MD.ANABIRIM FROM MALZEMEDETAY AS MD INNER JOIN MALZEMELER AS M ON MD.MALZEMEID = M.ID INNER JOIN BIRIMLER AS B ON MD.BIRIMID = B.ID " + "WHERE (M.KOD = '" + s_mkod + "')";
      RepositoryItemComboBox birimRep = new RepositoryItemComboBox();
      birimRep.TextEditStyle = TextEditStyles.DisableTextEditor;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = _main.komutcalistir_dt(sql_str);
      for (int index = 0; index < dataTable2.Rows.Count; ++index)
        birimRep.Items.Add((object) dataTable2.Rows[index][0].ToString());
      return (RepositoryItem) birimRep;
    }

    private string get_main_unit(string s_mkod)
    {
      string mainUnit = _main.komutcalistir_str("SELECT B.BIRIM FROM MALZEMEDETAY AS MD INNER JOIN MALZEMELER AS M ON MD.MALZEMEID = M.ID INNER JOIN BIRIMLER AS B ON MD.BIRIMID = B.ID " + "WHERE (MD.ANABIRIM = 1) AND (M.KOD = '" + s_mkod + "')");
      if (mainUnit == "")
        mainUnit = "ADET";
      return mainUnit;
    }

    private DataTable get_item(string barkod)
    {
      return _main.komutcalistir_dt("SELECT M.KOD, M.AD, B.BIRIM, MD.SATISFIYATI, MD.PARABIRIMI, MD.KDVORANI, MD.KDVDAHIL FROM MALZEMEDETAY AS MD INNER JOIN " + "MALZEMELER AS M ON MD.MALZEMEID = M.ID INNER JOIN BIRIMLER AS B ON MD.BIRIMID = B.ID " + "WHERE (MD.BARKOD1 = '" + barkod + "') OR (MD.BARKOD2 = '" + barkod + "') OR (MD.BARKOD3 = '" + barkod + "') OR (MD.BARKOD4 = '" + barkod + "') OR (MD.BARKOD5 = '" + barkod + "')");
    }

    private void set_newrow(string s_barkod, string s_miktar)
    {
      bool flag1 = true;
      int result = 0;
      this.grd_sip.InvalidateRows();
      DataTable dataTable = this.get_item(s_barkod);
      if (dataTable.Rows.Count <= 0)
        return;
      for (int dataSourceIndex1 = 0; dataSourceIndex1 < this.grd_sip.RowCount; ++dataSourceIndex1)
      {
        if (this.grd_sip.GetRowCellDisplayText(this.grd_sip.GetRowHandle(dataSourceIndex1), "MALZEMEKOD") == "")
        {
          this.grd_sip.FocusedRowHandle = this.grd_sip.GetRowHandle(dataSourceIndex1);
          this.grd_sip.SetFocusedRowCellValue("SATIRTURU", (object) "Malzeme");
          this.grd_sip.SetFocusedRowCellValue("MALZEMEKOD", (object) dataTable.Rows[0]["KOD"].ToString());
          this.grd_sip.SetFocusedRowCellValue("MALZEMEAD", (object) dataTable.Rows[0]["AD"].ToString());
          this.grd_sip.SetFocusedRowCellValue("BIRIM", (object) dataTable.Rows[0]["BIRIM"].ToString());
          DateTime dateTime = this.dt_date.DateTime;
          this.grd_sip.SetFocusedRowCellValue("TESLIMTARIHI", (object) this.dt_date.DateTime);
          if (int.TryParse(this.grd_sip.GetFocusedRowCellValue("MIKTAR").ToString(), out result))
          {
            if (result > 0)
              result += Convert.ToInt32(this.txt_miktar.Text);
          }
          else
            result = Convert.ToInt32(this.txt_miktar.Text);
          this.grd_sip.SetFocusedRowCellValue("MIKTAR", (object) result);
          break;
        }
        bool flag2;
        if (this.grd_sip.GetRowCellDisplayText(this.grd_sip.GetRowHandle(dataSourceIndex1), "MALZEMEKOD") == dataTable.Rows[0]["KOD"].ToString())
        {
          if (this.grd_sip.GetRowCellDisplayText(this.grd_sip.GetRowHandle(dataSourceIndex1), "BIRIM") == dataTable.Rows[0]["BIRIM"].ToString())
          {
            this.grd_sip.FocusedRowHandle = this.grd_sip.GetRowHandle(dataSourceIndex1);
            if (int.TryParse(this.grd_sip.GetFocusedRowCellValue("MIKTAR").ToString(), out result))
            {
              if (result > 0)
              {
                result += Convert.ToInt32(this.txt_miktar.Text);
                this.grd_sip.SetFocusedRowCellValue("MIKTAR", (object) result);
                flag2 = false;
                double indirim1;
                double indirim2;
                int indirimref;
                this.get_discount(dataTable.Rows[0]["KOD"].ToString(), this.txt_firmakod.Text, this.cmb_odeme.SelectedItem.ToString(), this.dt_date.DateTime, "Malzeme", out indirim1, out indirim2, out indirimref);
                this.grd_sip.SetFocusedRowCellValue("INDIRIMORANI1", (object) indirim1.ToString());
                this.grd_sip.SetFocusedRowCellValue("INDIRIMORANI2", (object) indirim2.ToString());
                this.grd_sip.SetFocusedRowCellValue("INDIRIMREF", (object) indirimref.ToString());
                BaseContainerValidateEditorEventArgs e = new BaseContainerValidateEditorEventArgs((object) result);
                this.grd_sip.FocusedColumn.FieldName = "MIKTAR";
                this.grd_sip_ValidatingEditor((object) null, e);
                break;
              }
            }
            else
            {
              result = Convert.ToInt32(this.txt_miktar.Text);
              this.grd_sip.SetFocusedRowCellValue("MIKTAR", (object) result);
              flag2 = false;
              break;
            }
          }
          else
          {
            int dataSourceIndex2 = -1;
            for (int dataSourceIndex3 = 0; dataSourceIndex3 < this.grd_sip.RowCount; ++dataSourceIndex3)
            {
              if (this.grd_sip.GetRowCellDisplayText(this.grd_sip.GetRowHandle(dataSourceIndex3), "MALZEMEKOD") == dataTable.Rows[0]["KOD"].ToString() && this.grd_sip.GetRowCellDisplayText(this.grd_sip.GetRowHandle(dataSourceIndex3), "BIRIM") == dataTable.Rows[0]["BIRIM"].ToString())
                dataSourceIndex2 = dataSourceIndex3;
            }
            if (dataSourceIndex2 >= 0)
            {
              this.grd_sip.FocusedRowHandle = this.grd_sip.GetRowHandle(dataSourceIndex2);
              if (int.TryParse(this.grd_sip.GetFocusedRowCellValue("MIKTAR").ToString(), out result))
              {
                if (result > 0)
                {
                  result += Convert.ToInt32(this.txt_miktar.Text);
                  this.grd_sip.SetFocusedRowCellValue("MIKTAR", (object) result);
                  flag2 = false;
                  break;
                }
              }
              else
              {
                result = Convert.ToInt32(this.txt_miktar.Text);
                this.grd_sip.SetFocusedRowCellValue("MIKTAR", (object) result);
                flag2 = false;
                break;
              }
            }
            else
            {
              this.grd_sip.MoveLastVisible();
              this.grd_sip.AddNewRow();
              this.grd_sip.SetFocusedRowCellValue("SATIRTURU", (object) "Malzeme");
              this.grd_sip.SetFocusedRowCellValue("MALZEMEKOD", (object) dataTable.Rows[0]["KOD"].ToString());
              this.grd_sip.SetFocusedRowCellValue("MALZEMEAD", (object) dataTable.Rows[0]["AD"].ToString());
              this.grd_sip.SetFocusedRowCellValue("BIRIM", (object) dataTable.Rows[0]["BIRIM"].ToString());
              DateTime dateTime = this.dt_date.DateTime;
              this.grd_sip.SetFocusedRowCellValue("TESLIMTARIHI", (object) this.dt_date.DateTime);
              if (int.TryParse(this.grd_sip.GetFocusedRowCellValue("MIKTAR").ToString(), out result))
              {
                if (result > 0)
                  result += Convert.ToInt32(this.txt_miktar.Text);
              }
              else
                result = Convert.ToInt32(this.txt_miktar.Text);
              this.grd_sip.SetFocusedRowCellValue("MIKTAR", (object) result);
              flag2 = true;
              break;
            }
          }
        }
        if (this.grd_sip.RowCount > 0)
        {
          this.grd_sip.MoveLastVisible();
          if (this.grd_sip.GetFocusedRowCellValue("MALZEMEKOD").ToString() != "" && flag1)
            this.grd_sip.AddNewRow();
        }
      }
    }

    private void txt_firmakod_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      MusteriSel musteriSel = new MusteriSel();
      if (this.txt_firmakod.Text != "")
      {
        musteriSel.s_kod_sel = this.txt_firmakod.Text;
        if (this.stat == "copy")
          musteriSel.s_kod_sel = "";
        musteriSel.s_name_sel = "";
      }
      else
      {
        musteriSel.s_kod_sel = "";
        musteriSel.s_name_sel = "";
      }
      if (musteriSel.ShowDialog() != DialogResult.OK || !(SiparisFrm.mus_kod != "") || !(SiparisFrm.mus_id != ""))
        return;
      this.txt_firmakod.Text = SiparisFrm.mus_kod;
      this.txt_firmaunvan.Text = SiparisFrm.mus_name;
      SiparisFrm.dt_musteri = this.get_musteri(this.txt_firmakod.Text);
      if (SiparisFrm.dt_musteri.Rows.Count > 0)
        this.cmb_odeme.SelectedItem = (object) SiparisFrm.dt_musteri.Rows[0]["ODEMESEKLI"].ToString();
      else
        this.cmb_odeme.SelectedItem = (object) "P";
    }

    private void txt_firmakod_DoubleClick(object sender, EventArgs e)
    {
      this.txt_firmakod_ButtonClick(sender, (ButtonPressedEventArgs) null);
    }

    private void txt_firmaunvan_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      MusteriSel musteriSel = new MusteriSel();
      if (this.txt_firmaunvan.Text != "")
      {
        musteriSel.s_kod_sel = "";
        musteriSel.s_name_sel = this.txt_firmaunvan.Text;
      }
      else
      {
        musteriSel.s_kod_sel = "";
        musteriSel.s_name_sel = "";
      }
      if (musteriSel.ShowDialog() != DialogResult.OK || !(SiparisFrm.mus_kod != "") || !(SiparisFrm.mus_id != ""))
        return;
      this.txt_firmaid.Text = SiparisFrm.mus_id;
      this.txt_firmakod.Text = SiparisFrm.mus_kod;
      this.txt_firmaunvan.Text = SiparisFrm.mus_name;
    }

    private void txt_firmaunvan_DoubleClick(object sender, EventArgs e)
    {
      this.txt_firmaunvan_ButtonClick(sender, (ButtonPressedEventArgs) null);
    }

    private string get_max_sipno()
    {
      int result = 0;
      string maxSipno = string.Empty;
      string s = _main.komutcalistir_str("SELECT MAX(CONVERT(INT, SIPARISNO,0)) FROM SIPARISLER");
      if (s == "")
        maxSipno = "000001";
      else if (int.TryParse(s, out result))
      {
        ++result;
        maxSipno = result.ToString("d6");
      }
      else
      {
        int num = (int) MessageBox.Show("Uygun FişNo Oluşturulamadı");
      }
      return maxSipno;
    }

    private bool alankontrol()
    {
      bool flag = true;
      if (this.txt_firmaid.Text == "")
      {
        this.ep1.SetError((Control) this.txt_firmaid, "Müşteri seçilmelidir.");
        flag = false;
      }
      else
        this.ep1.Clear();
      int num1 = 0;
      for (int dataSourceIndex = 0; dataSourceIndex < this.grd_sip.RowCount; ++dataSourceIndex)
      {
        if (this.grd_sip.GetRowCellValue(this.grd_sip.GetRowHandle(dataSourceIndex), "MALZEMEKOD").ToString() == "")
          this.grd_sip.DeleteRow(this.grd_sip.GetRowHandle(dataSourceIndex));
        else if (this.grd_sip.GetRowCellValue(this.grd_sip.GetRowHandle(dataSourceIndex), "MIKTAR").ToString() != "" && this.grd_sip.GetRowCellValue(this.grd_sip.GetRowHandle(dataSourceIndex), "MIKTAR").ToString() != "0")
          ++num1;
      }
      if (num1 == 0)
      {
        int num2 = (int) MessageBox.Show("Ürün olmadan fiş kaydedilemez.");
        flag = false;
      }
      if (this.cmb_ted.EditValue == null)
      {
        int num3 = (int) MessageBox.Show("Tedarikçi seçilmelidir.");
        flag = false;
      }
      return flag;
    }

    private bool check_sipno(string sipno)
    {
      return _main.komutcalistir_dt("SELECT SIPARISNO FROM SIPARISLER WHERE SIPARISNO = '" + sipno + "'").Rows.Count > 0;
    }

    private void txt_firmakod_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.txt_firmakod.Text != "")
      {
        SiparisFrm.dt_musteri = this.get_musteri(this.txt_firmakod.Text);
        if (SiparisFrm.dt_musteri.Rows.Count <= 0)
          return;
        this.txt_firmaunvan.Text = SiparisFrm.dt_musteri.Rows[0]["FIRMAADI"].ToString();
        this.cmb_odeme.SelectedItem = (object) SiparisFrm.dt_musteri.Rows[0]["ODEMESEKLI"].ToString();
      }
      else
      {
        this.txt_firmaunvan.Text = "";
        this.cmb_odeme.SelectedItem = (object) "P";
      }
    }

    private DataTable get_musteri(string musterikodu)
    {
      return _main.komutcalistir_dt("SELECT * FROM MUSTERILER WHERE FIRMAKODU = '" + musterikodu + "'");
    }

    private DataTable get_musteri_byid(string musteriid)
    {
      return _main.komutcalistir_dt("SELECT * FROM MUSTERILER WHERE ID = '" + musteriid + "'");
    }

    private void grd_sip_CellValueChanged(object sender, CellValueChangedEventArgs e)
    {
      int result1 = 0;
      string empty = string.Empty;
      if (this.txt_firmakod.Text != "")
      {
        string mlzkod = this.grd_sip.GetRowCellValue(e.RowHandle, "MALZEMEKOD").ToString();
        double indirim1;
        double indirim2;
        int indirimref;
        if (mlzkod != "" && e.Column.FieldName == "MIKTAR" && int.TryParse(e.Value.ToString(), out result1))
        {
          string satirturu = this.grd_sip.GetRowCellValue(e.RowHandle, "SATIRTURU").ToString();
          this.get_discount(mlzkod, this.txt_firmakod.Text, this.cmb_odeme.SelectedItem.ToString(), this.dt_date.DateTime, satirturu, out indirim1, out indirim2, out indirimref);
          this.grd_sip.SetRowCellValue(e.RowHandle, "INDIRIMORANI1", (object) indirim1.ToString());
          this.grd_sip.SetRowCellValue(e.RowHandle, "INDIRIMORANI2", (object) indirim2.ToString());
          this.grd_sip.SetRowCellValue(e.RowHandle, "INDIRIMREF", (object) indirimref.ToString());
        }
        if (this.grd_sip.GetRowCellValue(e.RowHandle, "MIKTAR").ToString() != "" && e.Column.FieldName == "MALZEMEKOD" && e.Value.ToString() != "")
        {
          string satirturu = this.grd_sip.GetRowCellValue(e.RowHandle, "SATIRTURU").ToString();
          this.get_discount(e.Value.ToString(), this.txt_firmakod.Text, this.cmb_odeme.SelectedItem.ToString(), this.dt_date.DateTime, satirturu, out indirim1, out indirim2, out indirimref);
          this.grd_sip.SetRowCellValue(e.RowHandle, "INDIRIMORANI1", (object) indirim1.ToString());
          this.grd_sip.SetRowCellValue(e.RowHandle, "INDIRIMORANI2", (object) indirim2.ToString());
          this.grd_sip.SetRowCellValue(e.RowHandle, "INDIRIMREF", (object) indirimref.ToString());
        }
        if (e.Column.FieldName == "BIRIM" && this.grd_sip.GetRowCellValue(e.RowHandle, "MALZEMEKOD").ToString() != "")
          this.get_fiyat(this.grd_sip.GetRowCellValue(e.RowHandle, "MALZEMEKOD").ToString(), this.grd_sip.GetRowCellValue(e.RowHandle, "BIRIM").ToString(), e.RowHandle);
        if (e.Column.FieldName == "MALZEMEKOD")
        {
          this.grd_sip.SetRowCellValue(e.RowHandle, "MALZEMEAD", (object) _main.komutcalistir_str("SELECT AD FROM MALZEMELER WHERE KOD = '" + e.Value.ToString() + "'"));
          this.get_fiyat(this.grd_sip.GetRowCellValue(e.RowHandle, "MALZEMEKOD").ToString(), this.grd_sip.GetRowCellValue(e.RowHandle, "BIRIM").ToString(), e.RowHandle);
          string satirturu = this.grd_sip.GetRowCellValue(e.RowHandle, "SATIRTURU").ToString();
          this.get_discount(e.Value.ToString(), this.txt_firmakod.Text, this.cmb_odeme.SelectedItem.ToString(), this.dt_date.DateTime, satirturu, out indirim1, out indirim2, out indirimref);
          this.grd_sip.SetRowCellValue(e.RowHandle, "INDIRIMORANI1", (object) indirim1.ToString());
          this.grd_sip.SetRowCellValue(e.RowHandle, "INDIRIMORANI2", (object) indirim2.ToString());
          this.grd_sip.SetRowCellValue(e.RowHandle, "INDIRIMREF", (object) indirimref.ToString());
        }
        if (e.Column.FieldName == "MIKTAR")
        {
          double result2 = 0.0;
          double result3 = 0.0;
          double result4 = 0.0;
          if (double.TryParse(this.grd_sip.GetRowCellValue(e.RowHandle, "BIRIMFIYAT").ToString(), out result3) && double.TryParse(e.Value.ToString(), out result2) && double.TryParse(this.grd_sip.GetRowCellValue(e.RowHandle, "KDVTUTARI").ToString(), out result4))
            this.grd_sip.SetRowCellValue(e.RowHandle, "TUTAR", (object) (result2 * result3));
        }
      }
      this.set_toplamlar();
    }

    private void get_discount(
      string mlzkod,
      string cari,
      string odeme,
      DateTime tarih,
      string satirturu,
      out double indirim1,
      out double indirim2,
      out int indirimref)
    {
      odeme = "A";
      cari = "1.1";
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      indirim1 = 0.0;
      indirim2 = 0.0;
      indirimref = 0;
      try
      {
        if (mlzkod != "1")
        {
          if (satirturu != "Promosyon")
          {
            DataTable dataTable1 = _main.komutcalistir_dt("SELECT URETICIKODU, MARKA, GRUPKODU, ANAKATEGORI, ALTKATEGORI1, TEDARIKCI FROM MALZEMELER " + "WHERE (KOD = '" + mlzkod + "')");
            if (dataTable1.Rows.Count <= 0)
              return;
            string str1 = dataTable1.Rows[0]["MARKA"].ToString();
            string str2 = dataTable1.Rows[0]["ANAKATEGORI"].ToString();
            string str3 = dataTable1.Rows[0]["ALTKATEGORI1"].ToString();
            string str4 = dataTable1.Rows[0]["TEDARIKCI"].ToString();
            string str5 = "DECLARE @IND1 AS FLOAT,@IND2 AS FLOAT, @CARIKOD AS VARCHAR(50),@ODEMEKOD AS VARCHAR(50),@MLZMARKAKOD AS VARCHAR(50), @ANAKATEGORI AS VARCHAR(50),@ALTKATEGORI AS VARCHAR(50),@TARIH AS VARCHAR(50),@TEDARIKCI AS VARCHAR(50),@INDID AS INT " + "SET @CARIKOD = '" + cari + "' " + "SET @ODEMEKOD = '" + odeme + "' " + "SET @MLZMARKAKOD = '" + str1 + "' " + "SET @ANAKATEGORI = '" + str2 + "' " + "SET @ALTKATEGORI = '" + str3 + "' " + "SET @TEDARIKCI = '" + str4 + "' " + "SET @TARIH = '" + tarih.ToString("yyyy-MM-dd") + "' " + "SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = @CARIKOD AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
            if (str1 != "")
              str5 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
            if (str2 != "")
              str5 += " AND ANAKATEGORI = @ANAKATEGORI ";
            if (str3 != "")
              str5 += " AND ALTKATEGORI = @ALTKATEGORI ";
            if (odeme != "")
              str5 += " AND ODEMEKOD = @ODEMEKOD ";
            if (str4 != "")
              str5 += " AND TEDARIKCI = @TEDARIKCI ";
            string str6 = str5 + " IF (ISNULL(@IND1,0) = 0) BEGIN " + "  SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = SUBSTRING(@CARIKOD,5,3) AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
            if (str1 != "")
              str6 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
            if (str2 != "")
              str6 += " AND ANAKATEGORI = @ANAKATEGORI ";
            if (str3 != "")
              str6 += " AND ALTKATEGORI = @ALTKATEGORI ";
            if (odeme != "")
              str6 += " AND ODEMEKOD = @ODEMEKOD ";
            if (str4 != "")
              str6 += " AND TEDARIKCI = @TEDARIKCI ";
            DataTable dataTable2 = _main.komutcalistir_dt(str6 + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END " + " ELSE BEGIN " + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END ");
            if (dataTable2.Rows.Count > 0)
            {
              indirimref = Convert.ToInt32(dataTable2.Rows[0][2]);
              if (indirimref == 0)
              {
                string str7 = "DECLARE @IND1 AS FLOAT,@IND2 AS FLOAT, @CARIKOD AS VARCHAR(50),@ODEMEKOD AS VARCHAR(50),@MLZMARKAKOD AS VARCHAR(50),@TARIH AS VARCHAR(50),@TEDARIKCI AS VARCHAR(50),@INDID AS INT " + "SET @CARIKOD = '" + cari + "' " + "SET @ODEMEKOD = '" + odeme + "' " + "SET @MLZMARKAKOD = '" + str1 + "' " + "SET @TEDARIKCI = '" + str4 + "' " + "SET @TARIH = '" + tarih.ToString("yyyy-MM-dd") + "' " + "SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = @CARIKOD AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                if (str1 != "")
                  str7 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
                if (odeme != "")
                  str7 += " AND ODEMEKOD = @ODEMEKOD ";
                if (str4 != "")
                  str7 += " AND TEDARIKCI = @TEDARIKCI ";
                string str8 = str7 + " IF (ISNULL(@IND1,0) = 0) BEGIN " + "  SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = SUBSTRING(@CARIKOD,5,3) AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                if (str1 != "")
                  str8 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
                if (odeme != "")
                  str8 += " AND ODEMEKOD = @ODEMEKOD ";
                if (str4 != "")
                  str8 += " AND TEDARIKCI = @TEDARIKCI ";
                DataTable dataTable3 = _main.komutcalistir_dt(str8 + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END " + " ELSE BEGIN " + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END ");
                if (dataTable3.Rows.Count > 0)
                {
                  indirimref = Convert.ToInt32(dataTable3.Rows[0][2]);
                  if (indirimref == 0)
                  {
                    string str9 = "DECLARE @IND1 AS FLOAT,@IND2 AS FLOAT, @CARIKOD AS VARCHAR(50),@ODEMEKOD AS VARCHAR(50),@MLZMARKAKOD AS VARCHAR(50),@TARIH AS VARCHAR(50),@TEDARIKCI AS VARCHAR(50),@INDID AS INT " + "SET @CARIKOD = '" + cari + "' " + "SET @ODEMEKOD = '" + odeme + "' " + "SET @MLZMARKAKOD = '" + str1 + "' " + "SET @TARIH = '" + tarih.ToString("yyyy-MM-dd") + "' " + "SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = @CARIKOD AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                    if (str1 != "")
                      str9 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
                    if (odeme != "")
                      str9 += " AND ODEMEKOD = @ODEMEKOD ";
                    string str10 = str9 + " IF (ISNULL(@IND1,0) = 0) BEGIN " + "  SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = SUBSTRING(@CARIKOD,5,3) AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                    if (str1 != "")
                      str10 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
                    if (odeme != "")
                      str10 += " AND ODEMEKOD = @ODEMEKOD ";
                    DataTable dataTable4 = _main.komutcalistir_dt(str10 + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END " + " ELSE BEGIN " + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END ");
                    if (dataTable4.Rows.Count > 0)
                    {
                      indirimref = Convert.ToInt32(dataTable4.Rows[0][2]);
                      if (indirimref == 0)
                      {
                        string str11 = "DECLARE @IND1 AS FLOAT,@IND2 AS FLOAT, @CARIKOD AS VARCHAR(50),@ODEMEKOD AS VARCHAR(50),@MLZMARKAKOD AS VARCHAR(50),@TARIH AS VARCHAR(50),@TEDARIKCI AS VARCHAR(50),@INDID AS INT " + "SET @CARIKOD = '" + cari + "' " + "SET @ODEMEKOD = '" + odeme + "' " + "SET @TEDARIKCI = '" + str4 + "' " + "SET @TARIH = '" + tarih.ToString("yyyy-MM-dd") + "' " + "SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = @CARIKOD AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                        if (odeme != "")
                          str11 += " AND ODEMEKOD = @ODEMEKOD ";
                        if (str4 != "")
                          str11 += " AND TEDARIKCI = @TEDARIKCI ";
                        string str12 = str11 + " IF (ISNULL(@IND1,0) = 0) BEGIN " + "  SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = SUBSTRING(@CARIKOD,5,3) AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                        if (odeme != "")
                          str12 += " AND ODEMEKOD = @ODEMEKOD ";
                        if (str4 != "")
                          str12 += " AND TEDARIKCI = @TEDARIKCI ";
                        DataTable dataTable5 = _main.komutcalistir_dt(str12 + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END " + " ELSE BEGIN " + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END ");
                        if (dataTable5.Rows.Count <= 0)
                          return;
                        indirimref = Convert.ToInt32(dataTable5.Rows[0][2]);
                        if (indirimref == 0)
                        {
                          indirim1 = 0.0;
                          indirim2 = 0.0;
                        }
                        else
                        {
                          indirim1 = Convert.ToDouble(dataTable5.Rows[0][0]);
                          if (dataTable5.Rows[0][1].ToString() != "")
                            indirim2 = Convert.ToDouble(dataTable5.Rows[0][1]);
                          else
                            indirim2 = 0.0;
                        }
                      }
                      else
                      {
                        indirim1 = Convert.ToDouble(dataTable4.Rows[0][0]);
                        if (dataTable4.Rows[0][1].ToString() != "")
                          indirim2 = Convert.ToDouble(dataTable4.Rows[0][1]);
                        else
                          indirim2 = 0.0;
                      }
                    }
                    else
                    {
                      indirim1 = Convert.ToDouble(dataTable4.Rows[0][0]);
                      if (dataTable4.Rows[0][1].ToString() != "")
                        indirim2 = Convert.ToDouble(dataTable4.Rows[0][1]);
                      else
                        indirim2 = 0.0;
                    }
                  }
                  else
                  {
                    indirim1 = Convert.ToDouble(dataTable3.Rows[0][0]);
                    if (dataTable3.Rows[0][1].ToString() != "")
                      indirim2 = Convert.ToDouble(dataTable3.Rows[0][1]);
                    else
                      indirim2 = 0.0;
                  }
                }
                else
                {
                  indirim1 = 0.0;
                  indirim2 = 0.0;
                  indirimref = 0;
                }
              }
              else
              {
                indirim1 = Convert.ToDouble(dataTable2.Rows[0][0]);
                if (dataTable2.Rows[0][1].ToString() != "")
                  indirim2 = Convert.ToDouble(dataTable2.Rows[0][1]);
                else
                  indirim2 = 0.0;
              }
            }
            else
            {
              indirim1 = 0.0;
              indirim2 = 0.0;
              indirimref = 0;
            }
          }
          else
          {
            indirim1 = 100.0;
            indirim2 = 0.0;
            indirimref = 0;
          }
        }
        else
        {
          indirim1 = 0.0;
          indirim2 = 0.0;
          indirimref = 0;
        }
      }
      catch
      {
        indirim1 = 0.0;
        indirim2 = 0.0;
        indirimref = 0;
      }
    }

    private void get_discount_eski(
      string mlzkod,
      string cari,
      string odeme,
      DateTime tarih,
      string satirturu,
      out double indirim1,
      out double indirim2,
      out int indirimref)
    {
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      indirim1 = 0.0;
      indirim2 = 0.0;
      indirimref = 0;
      try
      {
        if (mlzkod != "1")
        {
          if (satirturu != "Promosyon")
          {
            DataTable dataTable1 = _main.komutcalistir_dt("SELECT URETICIKODU, MARKA, GRUPKODU, ANAKATEGORI, ALTKATEGORI1, TEDARIKCI FROM MALZEMELER " + "WHERE (KOD = '" + mlzkod + "')");
            if (dataTable1.Rows.Count <= 0)
              return;
            string str1 = dataTable1.Rows[0]["MARKA"].ToString();
            string str2 = dataTable1.Rows[0]["ANAKATEGORI"].ToString();
            string str3 = dataTable1.Rows[0]["ALTKATEGORI1"].ToString();
            string str4 = dataTable1.Rows[0]["TEDARIKCI"].ToString();
            string str5 = "DECLARE @IND1 AS FLOAT,@IND2 AS FLOAT, @CARIKOD AS VARCHAR(50),@ODEMEKOD AS VARCHAR(50),@MLZMARKAKOD AS VARCHAR(50), @ANAKATEGORI AS VARCHAR(50),@ALTKATEGORI AS VARCHAR(50),@TARIH AS VARCHAR(50),@TEDARIKCI AS VARCHAR(50),@INDID AS INT " + "SET @CARIKOD = '" + cari + "' " + "SET @ODEMEKOD = '" + odeme + "' " + "SET @MLZMARKAKOD = '" + str1 + "' " + "SET @ANAKATEGORI = '" + str2 + "' " + "SET @ALTKATEGORI = '" + str3 + "' " + "SET @TEDARIKCI = '" + str4 + "' " + "SET @TARIH = '" + tarih.ToString("yyyy-MM-dd") + "' " + "SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = @CARIKOD AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
            if (str1 != "")
              str5 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
            if (str2 != "")
              str5 += " AND ANAKATEGORI = @ANAKATEGORI ";
            if (str3 != "")
              str5 += " AND ALTKATEGORI = @ALTKATEGORI ";
            if (odeme != "")
              str5 += " AND ODEMEKOD = @ODEMEKOD ";
            if (str4 != "")
              str5 += " AND TEDARIKCI = @TEDARIKCI ";
            string str6 = str5 + " IF (ISNULL(@IND1,0) = 0) BEGIN " + "  SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = SUBSTRING(@CARIKOD,5,3) AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
            if (str1 != "")
              str6 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
            if (str2 != "")
              str6 += " AND ANAKATEGORI = @ANAKATEGORI ";
            if (str3 != "")
              str6 += " AND ALTKATEGORI = @ALTKATEGORI ";
            if (odeme != "")
              str6 += " AND ODEMEKOD = @ODEMEKOD ";
            if (str4 != "")
              str6 += " AND TEDARIKCI = @TEDARIKCI ";
            DataTable dataTable2 = _main.komutcalistir_dt(str6 + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END " + " ELSE BEGIN " + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END ");
            if (dataTable2.Rows.Count > 0)
            {
              indirimref = Convert.ToInt32(dataTable2.Rows[0][2]);
              if (indirimref == 0)
              {
                string str7 = "DECLARE @IND1 AS FLOAT,@IND2 AS FLOAT, @CARIKOD AS VARCHAR(50),@ODEMEKOD AS VARCHAR(50),@MLZMARKAKOD AS VARCHAR(50),@TARIH AS VARCHAR(50),@TEDARIKCI AS VARCHAR(50),@INDID AS INT " + "SET @CARIKOD = '" + cari + "' " + "SET @ODEMEKOD = '" + odeme + "' " + "SET @MLZMARKAKOD = '" + str1 + "' " + "SET @TEDARIKCI = '" + str4 + "' " + "SET @TARIH = '" + tarih.ToString("yyyy-MM-dd") + "' " + "SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = @CARIKOD AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                if (str1 != "")
                  str7 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
                if (odeme != "")
                  str7 += " AND ODEMEKOD = @ODEMEKOD ";
                if (str4 != "")
                  str7 += " AND TEDARIKCI = @TEDARIKCI ";
                string str8 = str7 + " IF (ISNULL(@IND1,0) = 0) BEGIN " + "  SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = SUBSTRING(@CARIKOD,5,3) AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                if (str1 != "")
                  str8 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
                if (odeme != "")
                  str8 += " AND ODEMEKOD = @ODEMEKOD ";
                if (str4 != "")
                  str8 += " AND TEDARIKCI = @TEDARIKCI ";
                DataTable dataTable3 = _main.komutcalistir_dt(str8 + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END " + " ELSE BEGIN " + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END ");
                if (dataTable3.Rows.Count > 0)
                {
                  indirimref = Convert.ToInt32(dataTable3.Rows[0][2]);
                  if (indirimref == 0)
                  {
                    string str9 = "DECLARE @IND1 AS FLOAT,@IND2 AS FLOAT, @CARIKOD AS VARCHAR(50),@ODEMEKOD AS VARCHAR(50),@MLZMARKAKOD AS VARCHAR(50),@TARIH AS VARCHAR(50),@TEDARIKCI AS VARCHAR(50),@INDID AS INT " + "SET @CARIKOD = '" + cari + "' " + "SET @ODEMEKOD = '" + odeme + "' " + "SET @MLZMARKAKOD = '" + str1 + "' " + "SET @TARIH = '" + tarih.ToString("yyyy-MM-dd") + "' " + "SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = @CARIKOD AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                    if (str1 != "")
                      str9 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
                    if (odeme != "")
                      str9 += " AND ODEMEKOD = @ODEMEKOD ";
                    string str10 = str9 + " IF (ISNULL(@IND1,0) = 0) BEGIN " + "  SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = SUBSTRING(@CARIKOD,5,3) AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                    if (str1 != "")
                      str10 += " AND MLZMARKAKOD = @MLZMARKAKOD ";
                    if (odeme != "")
                      str10 += " AND ODEMEKOD = @ODEMEKOD ";
                    DataTable dataTable4 = _main.komutcalistir_dt(str10 + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END " + " ELSE BEGIN " + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END ");
                    if (dataTable4.Rows.Count > 0)
                    {
                      indirimref = Convert.ToInt32(dataTable4.Rows[0][2]);
                      if (indirimref == 0)
                      {
                        string str11 = "DECLARE @IND1 AS FLOAT,@IND2 AS FLOAT, @CARIKOD AS VARCHAR(50),@ODEMEKOD AS VARCHAR(50),@MLZMARKAKOD AS VARCHAR(50),@TARIH AS VARCHAR(50),@TEDARIKCI AS VARCHAR(50),@INDID AS INT " + "SET @CARIKOD = '" + cari + "' " + "SET @ODEMEKOD = '" + odeme + "' " + "SET @TEDARIKCI = '" + str4 + "' " + "SET @TARIH = '" + tarih.ToString("yyyy-MM-dd") + "' " + "SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = @CARIKOD AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                        if (odeme != "")
                          str11 += " AND ODEMEKOD = @ODEMEKOD ";
                        if (str4 != "")
                          str11 += " AND TEDARIKCI = @TEDARIKCI ";
                        string str12 = str11 + " IF (ISNULL(@IND1,0) = 0) BEGIN " + "  SELECT @IND1 = INDIRIM1, @IND2 = INDIRIM2, @INDID = LOGREF FROM INDIRIMLER WHERE CARIKOD = SUBSTRING(@CARIKOD,5,3) AND @TARIH BETWEEN BASLANGIC AND BITIS AND ACTIVE = 0 ";
                        if (odeme != "")
                          str12 += " AND ODEMEKOD = @ODEMEKOD ";
                        if (str4 != "")
                          str12 += " AND TEDARIKCI = @TEDARIKCI ";
                        DataTable dataTable5 = _main.komutcalistir_dt(str12 + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END " + " ELSE BEGIN " + "  SELECT ISNULL(@IND1,0) AS INDIRIM1, ISNULL(@IND2,0) AS INDIRIM2, ISNULL(@INDID,0) " + " END ");
                        if (dataTable5.Rows.Count <= 0)
                          return;
                        indirimref = Convert.ToInt32(dataTable5.Rows[0][2]);
                        if (indirimref == 0)
                        {
                          indirim1 = 0.0;
                          indirim2 = 0.0;
                        }
                        else
                        {
                          indirim1 = Convert.ToDouble(dataTable5.Rows[0][0]);
                          if (dataTable5.Rows[0][1].ToString() != "")
                            indirim2 = Convert.ToDouble(dataTable5.Rows[0][1]);
                          else
                            indirim2 = 0.0;
                        }
                      }
                      else
                      {
                        indirim1 = Convert.ToDouble(dataTable4.Rows[0][0]);
                        if (dataTable4.Rows[0][1].ToString() != "")
                          indirim2 = Convert.ToDouble(dataTable4.Rows[0][1]);
                        else
                          indirim2 = 0.0;
                      }
                    }
                    else
                    {
                      indirim1 = Convert.ToDouble(dataTable4.Rows[0][0]);
                      if (dataTable4.Rows[0][1].ToString() != "")
                        indirim2 = Convert.ToDouble(dataTable4.Rows[0][1]);
                      else
                        indirim2 = 0.0;
                    }
                  }
                  else
                  {
                    indirim1 = Convert.ToDouble(dataTable3.Rows[0][0]);
                    if (dataTable3.Rows[0][1].ToString() != "")
                      indirim2 = Convert.ToDouble(dataTable3.Rows[0][1]);
                    else
                      indirim2 = 0.0;
                  }
                }
                else
                {
                  indirim1 = 0.0;
                  indirim2 = 0.0;
                  indirimref = 0;
                }
              }
              else
              {
                indirim1 = Convert.ToDouble(dataTable2.Rows[0][0]);
                if (dataTable2.Rows[0][1].ToString() != "")
                  indirim2 = Convert.ToDouble(dataTable2.Rows[0][1]);
                else
                  indirim2 = 0.0;
              }
            }
            else
            {
              indirim1 = 0.0;
              indirim2 = 0.0;
              indirimref = 0;
            }
          }
          else
          {
            indirim1 = 100.0;
            indirim2 = 0.0;
            indirimref = 0;
          }
        }
        else
        {
          indirim1 = 0.0;
          indirim2 = 0.0;
          indirimref = 0;
        }
      }
      catch
      {
        indirim1 = 0.0;
        indirim2 = 0.0;
        indirimref = 0;
      }
    }

    private void get_fiyat(string mlzkod, string birim, int rhandle)
    {
      double result1 = 0.0;
      double result2 = 0.0;
      double result3 = 0.0;
      double result4 = 0.0;
      double num1 = 0.0;
      double result5 = 0.0;
      if (this.grd_sip.GetRowCellValue(rhandle, "BIRIMFIYAT").ToString() != "")
        double.TryParse(this.grd_sip.GetRowCellValue(rhandle, "BIRIMFIYAT").ToString(), out result2);
      DataTable dataTable = _main.komutcalistir_dt("SELECT MD.SATISFIYATI, MD.PARABIRIMI, MD.KDVORANI, MD.KDVDAHIL FROM MALZEMELER AS M INNER JOIN " + "MALZEMEDETAY AS MD ON M.ID = MD.MALZEMEID INNER JOIN BIRIMLER AS B ON MD.BIRIMID = B.ID " + "WHERE (M.KOD = '" + mlzkod + "') AND (B.BIRIM = '" + birim + "')");
      if (dataTable.Rows.Count <= 0)
        return;
      if (dataTable.Rows[0]["SATISFIYATI"].ToString() != "")
      {
        double dovTutar = this.get_dov_tutar(dataTable.Rows[0]["SATISFIYATI"].ToString(), dataTable.Rows[0]["PARABIRIMI"].ToString());
        if (dataTable.Rows[0]["KDVDAHIL"].ToString() == "True" && double.TryParse(dataTable.Rows[0]["KDVORANI"].ToString(), out result5))
          dovTutar /= result5 / 100.0 + 1.0;
        this.grd_sip.SetRowCellValue(rhandle, "BIRIMFIYAT", (object) dovTutar.ToString("n2"));
        double.TryParse(this.grd_sip.GetRowCellValue(rhandle, "MIKTAR").ToString(), out result1);
        if (result1 == 0.0)
          result1 = 1.0;
        if (dovTutar == 0.0)
          return;
        double num2 = dovTutar * result1;
        this.grd_sip.SetRowCellValue(rhandle, "TUTAR", (object) num2.ToString("n2"));
        if (double.TryParse(this.grd_sip.GetRowCellValue(rhandle, "INDIRIMORANI1").ToString(), out result3))
        {
          double num3;
          if (double.TryParse(this.grd_sip.GetRowCellValue(rhandle, "INDIRIMORANI2").ToString(), out result4))
          {
            double num4 = num2 / 100.0 * result3;
            double num5 = (num2 - num4) / 100.0 * result4;
            num1 = num2 - (num4 + num5);
            num3 = num4 + num5;
          }
          else
          {
            num3 = num2 / 100.0 * result3;
            num1 = num2 - num3;
          }
          this.grd_sip.SetRowCellValue(rhandle, "NETTUTAR", (object) num1);
          this.grd_sip.SetRowCellValue(rhandle, "INDIRIMTUTARI", (object) num3);
        }
        double num6 = !(dataTable.Rows[0]["KDVDAHIL"].ToString() == "True") ? (!double.TryParse(dataTable.Rows[0]["KDVORANI"].ToString(), out result5) ? 0.0 : num1 * result5 / 100.0) : (!double.TryParse(dataTable.Rows[0]["KDVORANI"].ToString(), out result5) ? 0.0 : (num1 * (result5 + 100.0) / 100.0 - num1) * result1);
        this.grd_sip.SetRowCellValue(rhandle, "KDVORANI", (object) result5);
        this.grd_sip.SetRowCellValue(rhandle, "KDVTUTARI", (object) num6.ToString("n2"));
        this.grd_sip.SetRowCellValue(rhandle, "BIRIMFIYAT", (object) dovTutar.ToString("n2"));
      }
      else
        this.grd_sip.SetRowCellValue(rhandle, "BIRIMFIYAT", (object) "0");
    }

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void set_toplamlar()
    {
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 0.0;
      double result1 = 0.0;
      double result2 = 0.0;
      double result3 = 0.0;
      double result4 = 0.0;
      for (int dataSourceIndex = 0; dataSourceIndex < this.grd_sip.RowCount; ++dataSourceIndex)
      {
        if (double.TryParse(this.grd_sip.GetRowCellValue(this.grd_sip.GetRowHandle(dataSourceIndex), "TUTAR").ToString(), out result1))
          num1 += result1;
        if (double.TryParse(this.grd_sip.GetRowCellValue(this.grd_sip.GetRowHandle(dataSourceIndex), "INDIRIMTUTARI").ToString(), out result3))
          num3 += result3;
        if (double.TryParse(this.grd_sip.GetRowCellValue(this.grd_sip.GetRowHandle(dataSourceIndex), "NETTUTAR").ToString(), out result2))
          num2 += result2;
        if (double.TryParse(this.grd_sip.GetRowCellValue(this.grd_sip.GetRowHandle(dataSourceIndex), "KDVTUTARI").ToString(), out result4))
          num4 += result4;
      }
      this.txt_toplam.Text = num1.ToString("n2");
      this.txt_nettop.Text = (num2 + num4).ToString("n2");
      this.txt_ind.Text = num3.ToString("n2");
      this.txt_kdv.Text = num4.ToString("n2");
      this.txt_kdvsiztop.Text = num2.ToString("n2");
    }

    private void hesapla(
      double miktar,
      double fiyat,
      double indirim1,
      double indirim2,
      double ind_tut_ted,
      bool manual,
      out double ind_tutari,
      out double net_tutar)
    {
      ind_tutari = 0.0;
      net_tutar = 0.0;
      if (miktar == 0.0 || fiyat == 0.0)
        return;
      double num1 = fiyat * miktar;
      if (manual)
      {
        ind_tutari = ind_tut_ted;
        net_tutar = num1 - ind_tutari;
      }
      else if (indirim2 != 0.0)
      {
        ind_tutari = num1 / 100.0 * indirim1;
        net_tutar = num1 - ind_tutari;
        double num2 = net_tutar / 100.0 * indirim2;
        net_tutar = num1 - (ind_tutari + num2);
        ind_tutari += num2;
        net_tutar = num1 - (ind_tutari + num2);
        ind_tutari += num2;
      }
      else
      {
        ind_tutari = num1 / 100.0 * indirim1;
        net_tutar = num1 - ind_tutari;
        net_tutar = num1 - ind_tutari;
      }
    }

    private void grd_sip_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
    {
      double result1 = 0.0;
      if (this.grd_sip.FocusedColumn.FieldName == "BIRIMFIYAT")
      {
        e.Valid = double.TryParse(e.Value.ToString(), out result1);
        if (e.Valid)
        {
          double result2 = 0.0;
          double result3 = 0.0;
          double result4 = 0.0;
          double result5 = 0.0;
          double net_tutar = 0.0;
          double ind_tutari = 0.0;
          double result6 = 0.0;
          double result7 = 0.0;
          double.TryParse(e.Value.ToString(), out result2);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("INDIRIMORANI1").ToString(), out result3);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("INDIRIMORANI2").ToString(), out result4);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("MIKTAR").ToString(), out result7);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("KDVORANI").ToString(), out result6);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("TEDIND").ToString(), out result5);
          string mlzkod = this.grd_sip.GetFocusedRowCellValue("MALZEMEKOD").ToString();
          string birim = this.grd_sip.GetFocusedRowCellValue("BIRIM").ToString();
          this.hesapla(result7, result2, result3, result4, result5, false, out ind_tutari, out net_tutar);
          this.grd_sip.SetFocusedRowCellValue("INDIRIMREF", (object) "0");
          this.grd_sip.SetFocusedRowCellValue("TUTAR", (object) (result7 * result2).ToString("n2"));
          this.grd_sip.SetFocusedRowCellValue("NETTUTAR", (object) net_tutar.ToString("n2"));
          this.grd_sip.SetFocusedRowCellValue("INDIRIMTUTARI", (object) ind_tutari.ToString("n2"));
          this.grd_sip.SetFocusedRowCellValue("KDVTUTARI", (object) (!this.get_kdvdurum(mlzkod, birim) ? net_tutar * result6 / 100.0 : net_tutar * (result6 + 100.0) / 100.0 - net_tutar).ToString("n2"));
        }
      }
      if (this.grd_sip.FocusedColumn.FieldName == "TEDIND")
      {
        e.Valid = double.TryParse(e.Value.ToString(), out result1);
        if (e.Valid)
        {
          double result8 = 0.0;
          double result9 = 0.0;
          double result10 = 0.0;
          double result11 = 0.0;
          double net_tutar = 0.0;
          double ind_tutari = 0.0;
          double result12 = 0.0;
          double result13 = 0.0;
          double.TryParse(e.Value.ToString(), out result11);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("BIRIMFIYAT").ToString(), out result8);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("INDIRIMORANI1").ToString(), out result9);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("INDIRIMORANI2").ToString(), out result10);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("MIKTAR").ToString(), out result13);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("KDVORANI").ToString(), out result12);
          string mlzkod = this.grd_sip.GetFocusedRowCellValue("MALZEMEKOD").ToString();
          string birim = this.grd_sip.GetFocusedRowCellValue("BIRIM").ToString();
          this.hesapla(result13, result8, result9, result10, result11, false, out ind_tutari, out net_tutar);
          this.grd_sip.SetFocusedRowCellValue("INDIRIMREF", (object) "0");
          this.grd_sip.SetFocusedRowCellValue("TUTAR", (object) (result13 * result8).ToString("n2"));
          this.grd_sip.SetFocusedRowCellValue("NETTUTAR", (object) net_tutar.ToString("n2"));
          this.grd_sip.SetFocusedRowCellValue("INDIRIMTUTARI", (object) ind_tutari.ToString("n2"));
          this.grd_sip.SetFocusedRowCellValue("KDVTUTARI", (object) (!this.get_kdvdurum(mlzkod, birim) ? net_tutar * result12 / 100.0 : net_tutar * (result12 + 100.0) / 100.0 - net_tutar).ToString("n2"));
        }
      }
      if (this.grd_sip.FocusedColumn.FieldName == "INDIRIMTUTARI")
      {
        e.Valid = double.TryParse(e.Value.ToString(), out result1);
        if (e.Valid)
        {
          double result14 = 0.0;
          double result15 = 0.0;
          double result16 = 0.0;
          double result17 = 0.0;
          double net_tutar = 0.0;
          double ind_tutari = 0.0;
          double result18 = 0.0;
          double result19 = 0.0;
          double.TryParse(e.Value.ToString(), out result17);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("BIRIMFIYAT").ToString(), out result14);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("INDIRIMORANI1").ToString(), out result15);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("INDIRIMORANI2").ToString(), out result16);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("MIKTAR").ToString(), out result19);
          double.TryParse(this.grd_sip.GetFocusedRowCellValue("KDVORANI").ToString(), out result18);
          string mlzkod = this.grd_sip.GetFocusedRowCellValue("MALZEMEKOD").ToString();
          string birim = this.grd_sip.GetFocusedRowCellValue("BIRIM").ToString();
          this.hesapla(result19, result14, result15, result16, result17, true, out ind_tutari, out net_tutar);
          this.grd_sip.SetFocusedRowCellValue("INDIRIMREF", (object) "0");
          this.grd_sip.SetFocusedRowCellValue("TUTAR", (object) (result19 * result14).ToString("n2"));
          this.grd_sip.SetFocusedRowCellValue("NETTUTAR", (object) net_tutar.ToString("n2"));
          this.grd_sip.SetFocusedRowCellValue("KDVTUTARI", (object) (!this.get_kdvdurum(mlzkod, birim) ? net_tutar * result18 / 100.0 : net_tutar * (result18 + 100.0) / 100.0 - net_tutar).ToString("n2"));
        }
      }
      if (!(this.grd_sip.FocusedColumn.FieldName == "MIKTAR"))
        return;
      e.Valid = double.TryParse(e.Value.ToString(), out result1) && result1 > 0.0;
      if (!e.Valid)
        return;
      double result20 = 0.0;
      double result21 = 0.0;
      double result22 = 0.0;
      double result23 = 0.0;
      double net_tutar1 = 0.0;
      double ind_tutari1 = 0.0;
      double result24 = 0.0;
      double result25 = 0.0;
      double.TryParse(e.Value.ToString(), out result25);
      double.TryParse(this.grd_sip.GetFocusedRowCellValue("INDIRIMORANI1").ToString(), out result21);
      double.TryParse(this.grd_sip.GetFocusedRowCellValue("INDIRIMORANI2").ToString(), out result22);
      double.TryParse(this.grd_sip.GetFocusedRowCellValue("BIRIMFIYAT").ToString(), out result20);
      double.TryParse(this.grd_sip.GetFocusedRowCellValue("KDVORANI").ToString(), out result24);
      double.TryParse(this.grd_sip.GetFocusedRowCellValue("TEDIND").ToString(), out result23);
      string mlzkod1 = this.grd_sip.GetFocusedRowCellValue("MALZEMEKOD").ToString();
      string birim1 = this.grd_sip.GetFocusedRowCellValue("BIRIM").ToString();
      this.hesapla(result25, result20, result21, result22, result23, false, out ind_tutari1, out net_tutar1);
      this.grd_sip.SetFocusedRowCellValue("INDIRIMREF", (object) "0");
      this.grd_sip.SetFocusedRowCellValue("TUTAR", (object) (result25 * result20).ToString("n2"));
      this.grd_sip.SetFocusedRowCellValue("NETTUTAR", (object) net_tutar1.ToString("n2"));
      this.grd_sip.SetFocusedRowCellValue("INDIRIMTUTARI", (object) ind_tutari1.ToString("n2"));
      this.grd_sip.SetFocusedRowCellValue("KDVTUTARI", (object) (!this.get_kdvdurum(mlzkod1, birim1) ? result25 * result20 * result24 / 100.0 : net_tutar1 * (result24 + 100.0) / 100.0 - net_tutar1).ToString("n2"));
    }

    private bool get_kdvdurum(string mlzkod, string birim)
    {
      DataTable dataTable = _main.komutcalistir_dt("SELECT MD.SATISFIYATI, MD.PARABIRIMI, MD.KDVORANI, MD.KDVDAHIL FROM MALZEMELER AS M INNER JOIN " + "MALZEMEDETAY AS MD ON M.ID = MD.MALZEMEID INNER JOIN BIRIMLER AS B ON MD.BIRIMID = B.ID " + "WHERE (M.KOD = '" + mlzkod + "') AND (B.BIRIM = '" + birim + "')");
      return dataTable.Rows.Count > 0 && dataTable.Rows[0]["KDVDAHIL"].ToString() == "True";
    }

    private double get_dov_tutar(string _fiyat, string _kurtype)
    {
      double dovTutar = 0.0;
      double result = 0.0;
      if (double.TryParse(_fiyat, out result))
      {
        switch (_kurtype)
        {
          case "USD":
            double num1 = _main.komutcalistir_double("SELECT USD FROM KURLAR");
            if (num1 != 0.0)
            {
              dovTutar = result * num1;
              break;
            }
            break;
          case "EUR":
            double num2 = _main.komutcalistir_double("SELECT EURO FROM KURLAR");
            if (num2 != 0.0)
            {
              dovTutar = result * num2;
              break;
            }
            break;
          default:
            dovTutar = result;
            break;
        }
      }
      return dovTutar;
    }

    private void get_tedarikci()
    {
      this.cmb_ted.Properties.DataSource = (object) _main.komutcalistir_dt("SELECT ID,TEDARIKCIKODU FROM TEDARIKCILER");
      this.cmb_ted.Properties.DisplayMember = "TEDARIKCIKODU";
      this.cmb_ted.Properties.ValueMember = "ID";
    }

    private void txt_firmaid_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      if (new MusteriSel().ShowDialog() != DialogResult.OK || !(SiparisFrm.mus_kod != "") || !(SiparisFrm.mus_id != ""))
        return;
      this.txt_firmaid.Text = SiparisFrm.mus_id;
      this.txt_firmakod.Text = SiparisFrm.mus_kod;
      this.txt_firmaunvan.Text = SiparisFrm.mus_name;
      SiparisFrm.dt_musteri = this.get_musteri(SiparisFrm.mus_kod);
      if (SiparisFrm.dt_musteri.Rows.Count > 0)
        this.cmb_odeme.SelectedItem = (object) SiparisFrm.dt_musteri.Rows[0]["ODEMESEKLI"].ToString();
      else
        this.cmb_odeme.SelectedItem = (object) "P";
    }

    private void txt_firmaid_DoubleClick(object sender, EventArgs e)
    {
      this.txt_firmaid_ButtonClick(sender, (ButtonPressedEventArgs) null);
    }

    private void txt_firmaid_Validating(object sender, CancelEventArgs e)
    {
      SiparisFrm.dt_musteri = this.get_musteri_byid(this.txt_firmaid.Text);
      if (SiparisFrm.dt_musteri.Rows.Count > 0)
      {
        SiparisFrm.mus_id = this.txt_firmaid.Text;
        this.txt_firmakod.Text = SiparisFrm.dt_musteri.Rows[0]["FIRMAKODU"].ToString();
        this.txt_firmaunvan.Text = SiparisFrm.dt_musteri.Rows[0]["FIRMAADI"].ToString();
        this.cmb_odeme.SelectedItem = (object) SiparisFrm.dt_musteri.Rows[0]["ODEMESEKLI"].ToString();
      }
      else
      {
        this.txt_firmaid.Text = "";
        this.txt_firmakod.Text = "";
        this.txt_firmaunvan.Text = "";
        this.cmb_odeme.SelectedItem = (object) "P";
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
      this.barDockControlRight = new BarDockControl();
      this.groupBox1 = new GroupBox();
      this.cmb_ted = new LookUpEdit();
      this.bm1 = new BarManager(this.components);
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControl1 = new BarDockControl();
      this.bb_ekle = new BarButtonItem();
      this.bb_sil = new BarButtonItem();
      this.l_ted = new Label();
      this.txt_miktar = new TextEdit();
      this.label9 = new Label();
      this.label8 = new Label();
      this.label7 = new Label();
      this.txt_barkod = new TextEdit();
      this.txt_no = new TextEdit();
      this.label1 = new Label();
      this.txt_aciklama = new MemoEdit();
      this.label6 = new Label();
      this.tm_time = new TimeEdit();
      this.txt_firmaunvan = new ButtonEdit();
      this.txt_firmakod = new ButtonEdit();
      this.dt_date = new DateEdit();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.cmb_odeme = new ComboBoxEdit();
      this.label5 = new Label();
      this.groupBox3 = new GroupBox();
      this.dtg_sip = new GridControl();
      this.grd_sip = new GridView();
      this.btn1 = new RepositoryItemButtonEdit();
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.ep1 = new ErrorProvider(this.components);
      this.pp1 = new PopupMenu(this.components);
      this.btn_kapat = new SimpleButton();
      this.groupBox2 = new GroupBox();
      this.txt_nettop = new TextEdit();
      this.txt_kdv = new TextEdit();
      this.txt_kdvsiztop = new TextEdit();
      this.txt_ind = new TextEdit();
      this.txt_toplam = new TextEdit();
      this.label14 = new Label();
      this.label13 = new Label();
      this.label12 = new Label();
      this.label11 = new Label();
      this.label10 = new Label();
      this.txt_firmaid = new ButtonEdit();
      this.groupBox1.SuspendLayout();
      this.cmb_ted.Properties.BeginInit();
      this.bm1.BeginInit();
      this.txt_miktar.Properties.BeginInit();
      this.txt_barkod.Properties.BeginInit();
      this.txt_no.Properties.BeginInit();
      this.txt_aciklama.Properties.BeginInit();
      this.tm_time.Properties.BeginInit();
      this.txt_firmaunvan.Properties.BeginInit();
      this.txt_firmakod.Properties.BeginInit();
      this.dt_date.Properties.VistaTimeProperties.BeginInit();
      this.dt_date.Properties.BeginInit();
      this.cmb_odeme.Properties.BeginInit();
      this.groupBox3.SuspendLayout();
      this.dtg_sip.BeginInit();
      this.grd_sip.BeginInit();
      this.btn1.BeginInit();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.pp1.BeginInit();
      this.groupBox2.SuspendLayout();
      this.txt_nettop.Properties.BeginInit();
      this.txt_kdv.Properties.BeginInit();
      this.txt_kdvsiztop.Properties.BeginInit();
      this.txt_ind.Properties.BeginInit();
      this.txt_toplam.Properties.BeginInit();
      this.txt_firmaid.Properties.BeginInit();
      this.SuspendLayout();
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(1156, 0);
      this.barDockControlRight.Size = new Size(0, 541);
      this.groupBox1.Controls.Add((Control) this.txt_firmaid);
      this.groupBox1.Controls.Add((Control) this.cmb_ted);
      this.groupBox1.Controls.Add((Control) this.l_ted);
      this.groupBox1.Controls.Add((Control) this.txt_miktar);
      this.groupBox1.Controls.Add((Control) this.label9);
      this.groupBox1.Controls.Add((Control) this.label8);
      this.groupBox1.Controls.Add((Control) this.label7);
      this.groupBox1.Controls.Add((Control) this.txt_barkod);
      this.groupBox1.Controls.Add((Control) this.txt_no);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.txt_aciklama);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.tm_time);
      this.groupBox1.Controls.Add((Control) this.txt_firmaunvan);
      this.groupBox1.Controls.Add((Control) this.dt_date);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(922, 110);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Sipariş Genel Tanımları";
      this.cmb_ted.Location = new Point(336, 75);
      this.cmb_ted.MenuManager = (IDXMenuManager) this.bm1;
      this.cmb_ted.Name = "cmb_ted";
      this.cmb_ted.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.cmb_ted.Properties.NullText = "Tedarikçi Seçiniz...";
      this.cmb_ted.Size = new Size(158, 20);
      this.cmb_ted.TabIndex = 27;
      this.bm1.DockControls.Add(this.barDockControlTop);
      this.bm1.DockControls.Add(this.barDockControlBottom);
      this.bm1.DockControls.Add(this.barDockControlLeft);
      this.bm1.DockControls.Add(this.barDockControl1);
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
      this.barDockControlTop.Size = new Size(1156, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 541);
      this.barDockControlBottom.Size = new Size(1156, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 541);
      this.barDockControl1.CausesValidation = false;
      this.barDockControl1.Dock = DockStyle.Right;
      this.barDockControl1.Location = new Point(1156, 0);
      this.barDockControl1.Size = new Size(0, 541);
      this.bb_ekle.Caption = "Ekle";
      this.bb_ekle.Id = 0;
      this.bb_ekle.Name = "bb_ekle";
      this.bb_ekle.ItemClick += new ItemClickEventHandler(this.bb_ekle_ItemClick);
      this.bb_sil.Caption = "Sil";
      this.bb_sil.Id = 2;
      this.bb_sil.Name = "bb_sil";
      this.bb_sil.ItemClick += new ItemClickEventHandler(this.bb_sil_ItemClick);
      this.l_ted.AutoSize = true;
      this.l_ted.Location = new Point(250, 78);
      this.l_ted.Name = "l_ted";
      this.l_ted.Size = new Size(49, 13);
      this.l_ted.TabIndex = 25;
      this.l_ted.Text = "Tedarikçi";
      this.txt_miktar.EditValue = (object) 1;
      this.txt_miktar.Location = new Point(835, 75);
      this.txt_miktar.MenuManager = (IDXMenuManager) this.bm1;
      this.txt_miktar.Name = "txt_miktar";
      this.txt_miktar.Properties.AllowNullInput = DefaultBoolean.False;
      this.txt_miktar.Properties.Mask.EditMask = "n0";
      this.txt_miktar.Properties.Mask.MaskType = MaskType.Numeric;
      this.txt_miktar.Properties.NullText = "1";
      this.txt_miktar.Properties.NullValuePrompt = "1";
      this.txt_miktar.Properties.NullValuePromptShowForEmptyValue = true;
      this.txt_miktar.Size = new Size(69, 20);
      this.txt_miktar.TabIndex = 24;
      this.label9.AutoSize = true;
      this.label9.Location = new Point(793, 79);
      this.label9.Name = "label9";
      this.label9.Size = new Size(36, 13);
      this.label9.TabIndex = 23;
      this.label9.Text = "Miktar";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(813, 26);
      this.label8.Name = "label8";
      this.label8.Size = new Size(65, 13);
      this.label8.TabIndex = 22;
      this.label8.Text = "Barkod Girişi";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(513, 26);
      this.label7.Name = "label7";
      this.label7.Size = new Size(48, 13);
      this.label7.TabIndex = 21;
      this.label7.Text = "Açıklama";
      this.txt_barkod.Location = new Point(796, 49);
      this.txt_barkod.MenuManager = (IDXMenuManager) this.bm1;
      this.txt_barkod.Name = "txt_barkod";
      this.txt_barkod.Size = new Size(108, 20);
      this.txt_barkod.TabIndex = 1;
      this.txt_barkod.KeyUp += new KeyEventHandler(this.txt_barkod_KeyUp);
      this.txt_no.Location = new Point(112, 77);
      this.txt_no.MenuManager = (IDXMenuManager) this.bm1;
      this.txt_no.Name = "txt_no";
      this.txt_no.Properties.Mask.EditMask = "d6";
      this.txt_no.Properties.Mask.MaskType = MaskType.Numeric;
      this.txt_no.Properties.NullValuePromptShowForEmptyValue = true;
      this.txt_no.Size = new Size(100, 20);
      this.txt_no.TabIndex = 20;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(20, 80);
      this.label1.Name = "label1";
      this.label1.Size = new Size(85, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Sipariş Numarası";
      this.label1.Visible = false;
      this.txt_aciklama.Location = new Point(564, 24);
      this.txt_aciklama.MenuManager = (IDXMenuManager) this.bm1;
      this.txt_aciklama.Name = "txt_aciklama";
      this.txt_aciklama.Size = new Size(210, 72);
      this.txt_aciklama.TabIndex = 19;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(20, 53);
      this.label6.Name = "label6";
      this.label6.Size = new Size(29, 13);
      this.label6.TabIndex = 18;
      this.label6.Text = "Saat";
      this.tm_time.EditValue = (object) new DateTime(2012, 3, 26, 0, 0, 0, 0);
      this.tm_time.Location = new Point(112, 51);
      this.tm_time.MenuManager = (IDXMenuManager) this.bm1;
      this.tm_time.Name = "tm_time";
      this.tm_time.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.tm_time.Size = new Size(100, 20);
      this.tm_time.TabIndex = 17;
      this.txt_firmaunvan.Location = new Point(336, 49);
      this.txt_firmaunvan.Name = "txt_firmaunvan";
      this.txt_firmaunvan.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.txt_firmaunvan.Size = new Size(158, 20);
      this.txt_firmaunvan.TabIndex = 16;
      this.txt_firmaunvan.ButtonClick += new ButtonPressedEventHandler(this.txt_firmaunvan_ButtonClick);
      this.txt_firmaunvan.DoubleClick += new EventHandler(this.txt_firmaunvan_DoubleClick);
      this.txt_firmakod.Location = new Point(1003, 89);
      this.txt_firmakod.Name = "txt_firmakod";
      this.txt_firmakod.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.txt_firmakod.Size = new Size(49, 20);
      this.txt_firmakod.TabIndex = 16;
      this.txt_firmakod.Visible = false;
      this.txt_firmakod.ButtonClick += new ButtonPressedEventHandler(this.txt_firmakod_ButtonClick);
      this.txt_firmakod.DoubleClick += new EventHandler(this.txt_firmakod_DoubleClick);
      this.txt_firmakod.KeyUp += new KeyEventHandler(this.txt_firmakod_KeyUp);
      this.dt_date.EditValue = (object) null;
      this.dt_date.Location = new Point(112, 24);
      this.dt_date.MenuManager = (IDXMenuManager) this.bm1;
      this.dt_date.Name = "dt_date";
      this.dt_date.Properties.AllowNullInput = DefaultBoolean.False;
      this.dt_date.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.dt_date.Properties.NullValuePromptShowForEmptyValue = true;
      this.dt_date.Properties.VistaTimeProperties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.dt_date.Size = new Size(100, 20);
      this.dt_date.TabIndex = 15;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(250, 52);
      this.label4.Name = "label4";
      this.label4.Size = new Size(69, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "Firma Ünvanı";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(250, 26);
      this.label3.Name = "label3";
      this.label3.Size = new Size(60, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Firma Kodu";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(20, 27);
      this.label2.Name = "label2";
      this.label2.Size = new Size(31, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Tarih";
      this.cmb_odeme.Location = new Point(952, 63);
      this.cmb_odeme.MenuManager = (IDXMenuManager) this.bm1;
      this.cmb_odeme.Name = "cmb_odeme";
      this.cmb_odeme.Properties.AllowNullInput = DefaultBoolean.False;
      this.cmb_odeme.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.cmb_odeme.Properties.ImmediatePopup = true;
      this.cmb_odeme.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
      this.cmb_odeme.Size = new Size(100, 20);
      this.cmb_odeme.TabIndex = 25;
      this.cmb_odeme.Visible = false;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(949, 38);
      this.label5.Name = "label5";
      this.label5.Size = new Size(65, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Ödeme Şekli";
      this.label5.Visible = false;
      this.groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox3.Controls.Add((Control) this.dtg_sip);
      this.groupBox3.Location = new Point(12, 128);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(1128, 273);
      this.groupBox3.TabIndex = 27;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Sipariş Detayları";
      this.dtg_sip.Dock = DockStyle.Fill;
      this.dtg_sip.Location = new Point(3, 17);
      this.dtg_sip.MainView = (BaseView) this.grd_sip;
      this.dtg_sip.MenuManager = (IDXMenuManager) this.bm1;
      this.dtg_sip.Name = "dtg_sip";
      this.dtg_sip.RepositoryItems.AddRange(new RepositoryItem[1]
      {
        (RepositoryItem) this.btn1
      });
      this.dtg_sip.Size = new Size(1122, 253);
      this.dtg_sip.TabIndex = 0;
      this.dtg_sip.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_sip
      });
      this.dtg_sip.MouseUp += new MouseEventHandler(this.dtg_sip_MouseUp);
      this.grd_sip.GridControl = this.dtg_sip;
      this.grd_sip.Name = "grd_sip";
      this.grd_sip.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
      this.grd_sip.OptionsBehavior.AllowDeleteRows = DefaultBoolean.True;
      this.grd_sip.OptionsCustomization.AllowFilter = false;
      this.grd_sip.OptionsCustomization.AllowSort = false;
      this.grd_sip.OptionsMenu.EnableColumnMenu = false;
      this.grd_sip.OptionsNavigation.AutoFocusNewRow = true;
      this.grd_sip.OptionsNavigation.EnterMoveNextColumn = true;
      this.grd_sip.OptionsView.ShowGroupPanel = false;
      this.grd_sip.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(this.grd_sip_CustomRowCellEditForEditing);
      this.grd_sip.CellValueChanged += new CellValueChangedEventHandler(this.grd_sip_CellValueChanged);
      this.grd_sip.ValidatingEditor += new BaseContainerValidateEditorEventHandler(this.grd_sip_ValidatingEditor);
      this.btn1.AllowNullInput = DefaultBoolean.False;
      this.btn1.AutoHeight = false;
      this.btn1.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.btn1.Name = "btn1";
      this.btn1.NullValuePrompt = "Ürün Seçiniz...";
      this.btn1.NullValuePromptShowForEmptyValue = true;
      this.btn1.ButtonClick += new ButtonPressedEventHandler(this.btn1_ButtonClick);
      this.btn1.DoubleClick += new EventHandler(this.btn1_DoubleClick);
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(12, 495);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 28;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(98, 495);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 29;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.ep1.ContainerControl = (ContainerControl) this;
      this.pp1.LinksPersistInfo.AddRange(new LinkPersistInfo[2]
      {
        new LinkPersistInfo((BarItem) this.bb_ekle),
        new LinkPersistInfo((BarItem) this.bb_sil)
      });
      this.pp1.Manager = this.bm1;
      this.pp1.Name = "pp1";
      this.btn_kapat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_kapat.Location = new Point(1065, 495);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(75, 33);
      this.btn_kapat.TabIndex = 35;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Visible = false;
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.txt_nettop);
      this.groupBox2.Controls.Add((Control) this.txt_kdv);
      this.groupBox2.Controls.Add((Control) this.txt_kdvsiztop);
      this.groupBox2.Controls.Add((Control) this.txt_ind);
      this.groupBox2.Controls.Add((Control) this.txt_toplam);
      this.groupBox2.Controls.Add((Control) this.label14);
      this.groupBox2.Controls.Add((Control) this.label13);
      this.groupBox2.Controls.Add((Control) this.label12);
      this.groupBox2.Controls.Add((Control) this.label11);
      this.groupBox2.Controls.Add((Control) this.label10);
      this.groupBox2.Location = new Point(711, 399);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(429, 88);
      this.groupBox2.TabIndex = 41;
      this.groupBox2.TabStop = false;
      this.txt_nettop.Enabled = false;
      this.txt_nettop.Location = new Point(314, 58);
      this.txt_nettop.MenuManager = (IDXMenuManager) this.bm1;
      this.txt_nettop.Name = "txt_nettop";
      this.txt_nettop.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txt_nettop.Properties.Appearance.Options.UseFont = true;
      this.txt_nettop.Properties.Appearance.Options.UseTextOptions = true;
      this.txt_nettop.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
      this.txt_nettop.Size = new Size(100, 22);
      this.txt_nettop.TabIndex = 9;
      this.txt_kdv.Enabled = false;
      this.txt_kdv.Location = new Point(314, 36);
      this.txt_kdv.MenuManager = (IDXMenuManager) this.bm1;
      this.txt_kdv.Name = "txt_kdv";
      this.txt_kdv.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txt_kdv.Properties.Appearance.Options.UseFont = true;
      this.txt_kdv.Properties.Appearance.Options.UseTextOptions = true;
      this.txt_kdv.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
      this.txt_kdv.Size = new Size(100, 22);
      this.txt_kdv.TabIndex = 8;
      this.txt_kdvsiztop.Enabled = false;
      this.txt_kdvsiztop.Location = new Point(314, 14);
      this.txt_kdvsiztop.MenuManager = (IDXMenuManager) this.bm1;
      this.txt_kdvsiztop.Name = "txt_kdvsiztop";
      this.txt_kdvsiztop.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txt_kdvsiztop.Properties.Appearance.Options.UseFont = true;
      this.txt_kdvsiztop.Properties.Appearance.Options.UseTextOptions = true;
      this.txt_kdvsiztop.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
      this.txt_kdvsiztop.Size = new Size(100, 22);
      this.txt_kdvsiztop.TabIndex = 7;
      this.txt_ind.Enabled = false;
      this.txt_ind.Location = new Point(79, 36);
      this.txt_ind.MenuManager = (IDXMenuManager) this.bm1;
      this.txt_ind.Name = "txt_ind";
      this.txt_ind.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txt_ind.Properties.Appearance.Options.UseFont = true;
      this.txt_ind.Properties.Appearance.Options.UseTextOptions = true;
      this.txt_ind.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
      this.txt_ind.Size = new Size(100, 22);
      this.txt_ind.TabIndex = 6;
      this.txt_toplam.Enabled = false;
      this.txt_toplam.Location = new Point(79, 14);
      this.txt_toplam.MenuManager = (IDXMenuManager) this.bm1;
      this.txt_toplam.Name = "txt_toplam";
      this.txt_toplam.Properties.Appearance.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txt_toplam.Properties.Appearance.Options.UseFont = true;
      this.txt_toplam.Properties.Appearance.Options.UseTextOptions = true;
      this.txt_toplam.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
      this.txt_toplam.Size = new Size(100, 22);
      this.txt_toplam.TabIndex = 5;
      this.label14.AutoSize = true;
      this.label14.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label14.Location = new Point(224, 63);
      this.label14.Name = "label14";
      this.label14.Size = new Size(88, 16);
      this.label14.TabIndex = 4;
      this.label14.Text = "Net Toplam :";
      this.label13.AutoSize = true;
      this.label13.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label13.Location = new Point(223, 41);
      this.label13.Name = "label13";
      this.label13.Size = new Size(89, 16);
      this.label13.TabIndex = 3;
      this.label13.Text = "KdvToplamı :";
      this.label12.AutoSize = true;
      this.label12.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label12.Location = new Point(201, 19);
      this.label12.Name = "label12";
      this.label12.Size = new Size(111, 16);
      this.label12.TabIndex = 2;
      this.label12.Text = "Kdv'siz Toplam :";
      this.label11.AutoSize = true;
      this.label11.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label11.Location = new Point(19, 41);
      this.label11.Name = "label11";
      this.label11.Size = new Size(61, 16);
      this.label11.TabIndex = 1;
      this.label11.Text = "İndirim :";
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label10.Location = new Point(18, 19);
      this.label10.Name = "label10";
      this.label10.Size = new Size(62, 16);
      this.label10.TabIndex = 0;
      this.label10.Text = "Toplam :";
      this.txt_firmaid.Location = new Point(336, 23);
      this.txt_firmaid.Name = "txt_firmaid";
      this.txt_firmaid.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.txt_firmaid.Properties.ValidateOnEnterKey = true;
      this.txt_firmaid.Size = new Size(158, 20);
      this.txt_firmaid.TabIndex = 28;
      this.txt_firmaid.ButtonClick += new ButtonPressedEventHandler(this.txt_firmaid_ButtonClick);
      this.txt_firmaid.DoubleClick += new EventHandler(this.txt_firmaid_DoubleClick);
      this.txt_firmaid.Validating += new CancelEventHandler(this.txt_firmaid_Validating);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1156, 541);
      this.Controls.Add((Control) this.cmb_odeme);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.btn_kapat);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.txt_firmakod);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControl1);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.KeyPreview = true;
      this.Name = nameof (SiparisFrm);
      this.ShowIcon = false;
      this.Text = "Sipariş";
      this.Load += new EventHandler(this.SiparisFrm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.cmb_ted.Properties.EndInit();
      this.bm1.EndInit();
      this.txt_miktar.Properties.EndInit();
      this.txt_barkod.Properties.EndInit();
      this.txt_no.Properties.EndInit();
      this.txt_aciklama.Properties.EndInit();
      this.tm_time.Properties.EndInit();
      this.txt_firmaunvan.Properties.EndInit();
      this.txt_firmakod.Properties.EndInit();
      this.dt_date.Properties.VistaTimeProperties.EndInit();
      this.dt_date.Properties.EndInit();
      this.cmb_odeme.Properties.EndInit();
      this.groupBox3.ResumeLayout(false);
      this.dtg_sip.EndInit();
      this.grd_sip.EndInit();
      this.btn1.EndInit();
      ((ISupportInitialize) this.ep1).EndInit();
      this.pp1.EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.txt_nettop.Properties.EndInit();
      this.txt_kdv.Properties.EndInit();
      this.txt_kdvsiztop.Properties.EndInit();
      this.txt_ind.Properties.EndInit();
      this.txt_toplam.Properties.EndInit();
      this.txt_firmaid.Properties.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
