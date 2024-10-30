// Decompiled with JetBrains decompiler
// Type: Fuar.SiparisBrws
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class SiparisBrws : Form
  {
    public int active_fiche;
    private IContainer components;
    private GridControl dtg_sip;
    private GridView grd_sip;
    private RepositoryItemPictureEdit imgk;
    private RepositoryItemPictureEdit img1;
    private RepositoryItemPictureEdit img2;
    private RepositoryItemPictureEdit img3;
    private SimpleButton btn_sil;
    private SimpleButton btn_duzenle;
    private SimpleButton btn_ekle;
    private SimpleButton btn_iptal;
    private BarManager bm1;
    private BarDockControl barDockControlTop;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_sil;
    private BarButtonItem bb_duzenle;
    private PopupMenu pp1;
    private SimpleButton btn_kopyala;
    private SimpleButton btn_incele;
    private BarButtonItem bb_kopyala;
    private BarButtonItem bb_incele;
    private SimpleButton btn_yazdir;
    private PrintingSystem ps1;
    private BarButtonItem bb_yazdir;
    private SimpleButton btn_yazdir_toplu;
    private BarButtonItem bb_yazdir_tumu;
    private SimpleButton btn_ekle_basit;
    private BarButtonItem bb_ekle_basit;
    private GridColumn SIPARISNO;
    private GridColumn SIPARISTARIHI;
    private GridColumn FIRMAKODU;
    private GridColumn FIRMAADI;
    private GridColumn ADI;
    private GridColumn TEDARIKCIKODU;
    private GridColumn NETTUTAR;
    private GridColumn TOPLAMTUTAR;
    private GridColumn ISFAST;

    public SiparisBrws() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_duzenle_Click(object sender, EventArgs e)
    {
      if (this.grd_sip.GetFocusedRowCellValue("SIPARISNO") == null)
        return;
      if ((bool) this.grd_sip.GetFocusedRowCellValue("ISFAST"))
      {
        SiparisFrmSimple siparisFrmSimple = new SiparisFrmSimple();
        siparisFrmSimple.MdiParent = this.MdiParent;
        siparisFrmSimple._sipno = this.grd_sip.GetFocusedRowCellDisplayText("SIPARISNO");
        siparisFrmSimple.stat = "edit";
        if (this.grd_sip.FocusedRowHandle != 0)
          this.active_fiche = this.grd_sip.FocusedRowHandle;
        siparisFrmSimple.Show();
      }
      else
      {
        SiparisFrm siparisFrm = new SiparisFrm();
        siparisFrm.MdiParent = this.MdiParent;
        siparisFrm._sipno = this.grd_sip.GetFocusedRowCellDisplayText("SIPARISNO");
        siparisFrm.stat = "edit";
        if (this.grd_sip.FocusedRowHandle != 0)
          this.active_fiche = this.grd_sip.FocusedRowHandle;
        siparisFrm.Show();
      }
    }

    private void btn_kopyala_Click(object sender, EventArgs e)
    {
      if (!(bool) this.grd_sip.GetFocusedRowCellValue("ISFAST"))
      {
        if (this.grd_sip.GetFocusedRowCellValue("SIPARISNO") == null)
          return;
        SiparisFrm siparisFrm = new SiparisFrm();
        siparisFrm.MdiParent = this.MdiParent;
        siparisFrm._sipno = this.grd_sip.GetFocusedRowCellDisplayText("SIPARISNO");
        siparisFrm.stat = "copy";
        siparisFrm.Show();
        this.active_fiche = 0;
      }
      else
      {
        int num = (int) MessageBox.Show("Basit siparişleri kopyalayamazsınız.");
      }
    }

    private void btn_incele_Click(object sender, EventArgs e)
    {
      if (this.grd_sip.GetFocusedRowCellValue("SIPARISNO") == null)
        return;
      if ((bool) this.grd_sip.GetFocusedRowCellValue("ISFAST"))
      {
        SiparisFrmSimple siparisFrmSimple = new SiparisFrmSimple();
        siparisFrmSimple.MdiParent = this.MdiParent;
        siparisFrmSimple._sipno = this.grd_sip.GetFocusedRowCellDisplayText("SIPARISNO");
        siparisFrmSimple.stat = "view";
        if (this.grd_sip.FocusedRowHandle != 0)
          this.active_fiche = this.grd_sip.FocusedRowHandle;
        siparisFrmSimple.Show();
      }
      else
      {
        SiparisFrm siparisFrm = new SiparisFrm();
        siparisFrm.MdiParent = this.MdiParent;
        siparisFrm._sipno = this.grd_sip.GetFocusedRowCellDisplayText("SIPARISNO");
        siparisFrm.stat = "view";
        if (this.grd_sip.FocusedRowHandle != 0)
          this.active_fiche = this.grd_sip.FocusedRowHandle;
        siparisFrm.Show();
      }
    }

    private void btn_ekle_Click(object sender, EventArgs e)
    {
      SiparisFrm siparisFrm = new SiparisFrm();
      siparisFrm.MdiParent = this.MdiParent;
      siparisFrm._sipno = "";
      siparisFrm.Show();
      this.active_fiche = 0;
    }

    private void btn_ekle_basit_Click(object sender, EventArgs e)
    {
      SiparisFrmSimple siparisFrmSimple = new SiparisFrmSimple();
      siparisFrmSimple.MdiParent = this.MdiParent;
      siparisFrmSimple._sipno = "";
      siparisFrmSimple.Show();
      this.active_fiche = 0;
    }

    private void btn_sil_Click(object sender, EventArgs e)
    {
      if (this.grd_sip.GetFocusedRowCellValue("SIPARISNO") == null || MessageBox.Show(this.grd_sip.GetFocusedRowCellDisplayText("SIPARISNO") + " Numaralı siparişi silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
        return;
      _main.komutcalistir("DELETE FROM SIPARISLER WHERE SIPARISNO = " + this.grd_sip.GetFocusedRowCellDisplayText("SIPARISNO"));
      this.active_fiche = 0;
      this.setgrid();
    }

    private void bb_ekle_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_ekle_Click(sender, (EventArgs) e);
    }

    private void bb_ekle_basit_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_ekle_basit_Click(sender, (EventArgs) e);
    }

    private void bb_duzenle_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_duzenle_Click(sender, (EventArgs) e);
    }

    private void bb_sil_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_sil_Click(sender, (EventArgs) e);
    }

    private void bb_kopyala_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_kopyala_Click(sender, (EventArgs) e);
    }

    private void bb_incele_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_incele_Click(sender, (EventArgs) e);
    }

    private void bb_yazdir_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_yazdir_Click(sender, (EventArgs) e);
    }

    private void bb_yazdir_tumu_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.btn_yazdir_toplu_Click(sender, (EventArgs) e);
    }

    private void dtg_sip_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
    }

    private void SiparisHarBrws_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.grd_sip.SaveLayoutToRegistry("DmsFuar\\SipBrws");
    }

    private void setgrid()
    {
      string str = "SELECT S.SIPARISNO, S.SIPARISTARIHI, M.FIRMAKODU, M.FIRMAADI, K.ADI, T.TEDARIKCIKODU, SUM(S.NETTUTAR) AS NETTUTAR,(SUM(S.NETTUTAR) + SUM(S.KDVTUTARI)) AS TOPLAMTUTAR, ISNULL(S.ISFAST,'False') AS ISFAST " + "FROM SIPARISLER AS S LEFT OUTER JOIN MUSTERILER AS M ON S.MUSTERIREF = M.ID LEFT OUTER JOIN KULLANICILAR AS K ON S.KULLANICIREF = K.ID LEFT OUTER JOIN TEDARIKCILER AS T ON S.TEDARIKCIREF = T.ID ";
      if (_main.dt_user.Rows[0]["KULLANICIADI"].ToString() != "ADMIN")
        str = str + "WHERE TEDARIKCIREF = '" + _main.dt_user.Rows[0]["TEDARIKCIID"].ToString() + "' ";
      this.dtg_sip.DataSource = (object) _main.komutcalistir_dt(str + "GROUP BY S.SIPARISNO, S.SIPARISTARIHI, M.FIRMAKODU, M.FIRMAADI, K.ADI, T.TEDARIKCIKODU, S.ISFAST");
      if (this.active_fiche != 0)
      {
        this.grd_sip.ClearSelection();
        this.grd_sip.SelectRow(this.active_fiche);
        this.grd_sip.FocusedRowHandle = this.active_fiche;
      }
      else
        this.grd_sip.MoveLastVisible();
      this.grd_sip.OptionsView.ShowFooter = true;
      this.grd_sip.Columns["NETTUTAR"].DisplayFormat.FormatType = FormatType.Numeric;
      this.grd_sip.Columns["NETTUTAR"].DisplayFormat.FormatString = "n2";
      this.grd_sip.Columns["NETTUTAR"].SummaryItem.SummaryType = SummaryItemType.Sum;
      this.grd_sip.Columns["NETTUTAR"].SummaryItem.FieldName = "NETTUTAR";
      this.grd_sip.Columns["NETTUTAR"].SummaryItem.DisplayFormat = "Toplam : {0:#,##0.00}";
      this.grd_sip.Columns["TOPLAMTUTAR"].DisplayFormat.FormatType = FormatType.Numeric;
      this.grd_sip.Columns["TOPLAMTUTAR"].DisplayFormat.FormatString = "n2";
      this.grd_sip.Columns["TOPLAMTUTAR"].SummaryItem.SummaryType = SummaryItemType.Sum;
      this.grd_sip.Columns["TOPLAMTUTAR"].SummaryItem.FieldName = "TOPLAMTUTAR";
      this.grd_sip.Columns["TOPLAMTUTAR"].SummaryItem.DisplayFormat = "Toplam : {0:#,##0.00}";
      this.grd_sip.Columns["SIPARISNO"].SummaryItem.SummaryType = SummaryItemType.Count;
      this.grd_sip.Columns["SIPARISNO"].SummaryItem.FieldName = "SIPARISNO";
      this.grd_sip.Columns["SIPARISNO"].SummaryItem.DisplayFormat = "Sipariş Adet : {0}";
      this.grd_sip.BestFitColumns();
    }

    private void SiparisHarBrws_Activated(object sender, EventArgs e) => this.setgrid();

    private void grd_sip_DoubleClick(object sender, EventArgs e)
    {
      this.btn_duzenle_Click(sender, e);
    }

    private void btn_yazdir_Click(object sender, EventArgs e)
    {
      if (this.grd_sip.GetFocusedRowCellValue("SIPARISNO") == null)
        return;
      string sql_str = "SELECT S.SIPARISTARIHI, S.SIPARISSAATI, S.SIPARISNO, MU.FIRMAKODU, MU.FIRMAADI, MU.YETKILI, MU.TELEFON1, MU.TELEFON2, MU.ILCE, MU.IL, " + "T.TEDARIKCIKODU, T.TEDARIKCIADI, T.TEDARIKCILOGOSU, K.ADI, K.SOYADI, K.EPOSTA, K.RESIM, MA.KOD AS [MALZEME KODU], MA.AD AS [MALZEME ADI], " + "MA.URETICIKODU, MA.MARKA, MA.GRUPKODU, MA.TEDARIKCI, MA.ANAKATEGORI, MA.ALTKATEGORI1 AS ALTKATEGORI, MA.KRESIM, MA.RESIM1, MA.RESIM2, " + "MA.RESIM3, S.ACIKLAMA, S.ODEMESEKLI, S.SATIRTURU, S.SATIRNO, S.BIRIM, S.MIKTAR, S.BIRIMFIYAT, S.TUTAR, S.INDIRIMORANI1, S.INDIRIMORANI2, " + "S.INDIRIMTUTARI, S.NETTUTAR, S.SATIRACIKLAMA, S.TESLIMTARIHI,S.KDVTUTARI,(S.KDVTUTARI + S.NETTUTAR) AS NETTOPLAM " + "FROM MUSTERILER AS MU INNER JOIN SIPARISLER AS S ON MU.ID = S.MUSTERIREF INNER JOIN KULLANICILAR AS K ON S.KULLANICIREF = K.ID LEFT JOIN " + "TEDARIKCILER AS T ON S.TEDARIKCIREF = T.ID INNER JOIN MALZEMELER AS MA ON S.MALZEMEKOD = MA.KOD " + "WHERE S.SIPARISNO = '" + this.grd_sip.GetFocusedRowCellValue("SIPARISNO").ToString() + "'";
      SiparisRapor siparisRapor = new SiparisRapor();
      siparisRapor.DataSource = (object) _main.komutcalistir_dt(sql_str);
      siparisRapor.ShowPreview();
    }

    private void set_right(List<string> lst)
    {
      if (lst[1] == "True")
      {
        this.btn_ekle.Enabled = true;
        this.bb_ekle.Enabled = true;
        this.btn_kopyala.Enabled = true;
        this.bb_kopyala.Enabled = true;
      }
      else
      {
        this.btn_ekle.Enabled = false;
        this.bb_ekle.Enabled = false;
        this.btn_kopyala.Enabled = false;
        this.bb_kopyala.Enabled = false;
      }
      if (lst[2] == "True")
      {
        this.btn_duzenle.Enabled = true;
        this.bb_duzenle.Enabled = true;
      }
      else
      {
        this.btn_duzenle.Enabled = false;
        this.bb_duzenle.Enabled = false;
      }
      if (lst[3] == "True")
      {
        this.btn_sil.Enabled = true;
        this.bb_sil.Enabled = true;
      }
      else
      {
        this.btn_sil.Enabled = false;
        this.bb_sil.Enabled = false;
      }
    }

    private void SiparisBrws_Load(object sender, EventArgs e)
    {
      this.set_right(_main.y_siparisler);
      foreach (GridColumn column in (CollectionBase) this.grd_sip.Columns)
        column.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
      this.grd_sip.RestoreLayoutFromRegistry("DmsFuar\\SipBrws");
    }

    private void grd_sip_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }

    private void btn_yazdir_toplu_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Listelenen bütün siparişleri yazdırmak istediğinize eminmisiz?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      SplashScreenManager.ShowForm(typeof (WaitForm1), false, true);
      try
      {
        for (int rowVisibleIndex = 0; rowVisibleIndex < this.grd_sip.RowCount; ++rowVisibleIndex)
        {
          string rowCellDisplayText = this.grd_sip.GetRowCellDisplayText(this.grd_sip.GetVisibleRowHandle(rowVisibleIndex), "SIPARISNO");
          if (rowCellDisplayText != "")
          {
            string sql_str = "SELECT S.SIPARISTARIHI, S.SIPARISSAATI, S.SIPARISNO, MU.FIRMAKODU, MU.FIRMAADI, MU.YETKILI, MU.TELEFON1, MU.TELEFON2, MU.ILCE, MU.IL, " + "T.TEDARIKCIKODU, T.TEDARIKCIADI, T.TEDARIKCILOGOSU, K.ADI, K.SOYADI, K.EPOSTA, K.RESIM, MA.KOD AS [MALZEME KODU], MA.AD AS [MALZEME ADI], " + "MA.URETICIKODU, MA.MARKA, MA.GRUPKODU, MA.TEDARIKCI, MA.ANAKATEGORI, MA.ALTKATEGORI1 AS ALTKATEGORI, MA.KRESIM, MA.RESIM1, MA.RESIM2, " + "MA.RESIM3, S.ACIKLAMA, S.ODEMESEKLI, S.SATIRTURU, S.SATIRNO, S.BIRIM, S.MIKTAR, S.BIRIMFIYAT, S.TUTAR, S.INDIRIMORANI1, S.INDIRIMORANI2, " + "S.INDIRIMTUTARI, S.NETTUTAR, S.SATIRACIKLAMA, S.TESLIMTARIHI,S.KDVTUTARI,(S.KDVTUTARI + S.NETTUTAR) AS NETTOPLAM " + "FROM MUSTERILER AS MU INNER JOIN SIPARISLER AS S ON MU.ID = S.MUSTERIREF INNER JOIN KULLANICILAR AS K ON S.KULLANICIREF = K.ID LEFT JOIN " + "TEDARIKCILER AS T ON S.TEDARIKCIREF = T.ID INNER JOIN MALZEMELER AS MA ON S.MALZEMEKOD = MA.KOD " + "WHERE S.SIPARISNO = '" + rowCellDisplayText.ToString() + "'";
            SiparisRapor siparisRapor = new SiparisRapor();
            siparisRapor.DataSource = (object) _main.komutcalistir_dt(sql_str);
            siparisRapor.Print();
          }
        }
        if (SplashScreenManager.Default == null)
          return;
        SplashScreenManager.CloseForm();
      }
      catch (Exception ex)
      {
        if (SplashScreenManager.Default != null)
          SplashScreenManager.CloseForm();
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
      this.dtg_sip = new GridControl();
      this.grd_sip = new GridView();
      this.SIPARISNO = new GridColumn();
      this.SIPARISTARIHI = new GridColumn();
      this.FIRMAKODU = new GridColumn();
      this.FIRMAADI = new GridColumn();
      this.ADI = new GridColumn();
      this.TEDARIKCIKODU = new GridColumn();
      this.NETTUTAR = new GridColumn();
      this.TOPLAMTUTAR = new GridColumn();
      this.ISFAST = new GridColumn();
      this.imgk = new RepositoryItemPictureEdit();
      this.img1 = new RepositoryItemPictureEdit();
      this.img2 = new RepositoryItemPictureEdit();
      this.img3 = new RepositoryItemPictureEdit();
      this.btn_sil = new SimpleButton();
      this.btn_duzenle = new SimpleButton();
      this.btn_ekle = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.bm1 = new BarManager(this.components);
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControlRight = new BarDockControl();
      this.bb_ekle = new BarButtonItem();
      this.bb_sil = new BarButtonItem();
      this.bb_duzenle = new BarButtonItem();
      this.bb_kopyala = new BarButtonItem();
      this.bb_incele = new BarButtonItem();
      this.bb_yazdir = new BarButtonItem();
      this.bb_yazdir_tumu = new BarButtonItem();
      this.bb_ekle_basit = new BarButtonItem();
      this.pp1 = new PopupMenu(this.components);
      this.btn_kopyala = new SimpleButton();
      this.btn_incele = new SimpleButton();
      this.btn_yazdir = new SimpleButton();
      this.ps1 = new PrintingSystem(this.components);
      this.btn_yazdir_toplu = new SimpleButton();
      this.btn_ekle_basit = new SimpleButton();
      this.dtg_sip.BeginInit();
      this.grd_sip.BeginInit();
      this.imgk.BeginInit();
      this.img1.BeginInit();
      this.img2.BeginInit();
      this.img3.BeginInit();
      this.bm1.BeginInit();
      this.pp1.BeginInit();
      ((ISupportInitialize) this.ps1).BeginInit();
      this.SuspendLayout();
      this.dtg_sip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dtg_sip.Location = new Point(1, 1);
      this.dtg_sip.MainView = (BaseView) this.grd_sip;
      this.dtg_sip.Name = "dtg_sip";
      this.dtg_sip.RepositoryItems.AddRange(new RepositoryItem[4]
      {
        (RepositoryItem) this.imgk,
        (RepositoryItem) this.img1,
        (RepositoryItem) this.img2,
        (RepositoryItem) this.img3
      });
      this.dtg_sip.Size = new Size(879, 363);
      this.dtg_sip.TabIndex = 14;
      this.dtg_sip.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_sip
      });
      this.dtg_sip.MouseUp += new MouseEventHandler(this.dtg_sip_MouseUp);
      this.grd_sip.Columns.AddRange(new GridColumn[9]
      {
        this.SIPARISNO,
        this.SIPARISTARIHI,
        this.FIRMAKODU,
        this.FIRMAADI,
        this.ADI,
        this.TEDARIKCIKODU,
        this.NETTUTAR,
        this.TOPLAMTUTAR,
        this.ISFAST
      });
      this.grd_sip.GridControl = this.dtg_sip;
      this.grd_sip.Name = "grd_sip";
      this.grd_sip.OptionsBehavior.Editable = false;
      this.grd_sip.OptionsSelection.MultiSelect = true;
      this.grd_sip.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;
      this.grd_sip.OptionsView.RowAutoHeight = true;
      this.grd_sip.OptionsView.ShowAutoFilterRow = true;
      this.grd_sip.OptionsView.ShowFooter = true;
      this.grd_sip.OptionsView.ShowGroupPanel = false;
      this.grd_sip.SelectionChanged += new SelectionChangedEventHandler(this.grd_sip_SelectionChanged);
      this.grd_sip.DoubleClick += new EventHandler(this.grd_sip_DoubleClick);
      this.SIPARISNO.Caption = "Sipariş Numarası";
      this.SIPARISNO.FieldName = "SIPARISNO";
      this.SIPARISNO.Name = "SIPARISNO";
      this.SIPARISNO.Visible = true;
      this.SIPARISNO.VisibleIndex = 0;
      this.SIPARISTARIHI.Caption = "Sipariş Tarihi";
      this.SIPARISTARIHI.FieldName = "SIPARISTARIHI";
      this.SIPARISTARIHI.Name = "SIPARISTARIHI";
      this.SIPARISTARIHI.Visible = true;
      this.SIPARISTARIHI.VisibleIndex = 1;
      this.FIRMAKODU.Caption = "Firma Kodu";
      this.FIRMAKODU.FieldName = "FIRMAKODU";
      this.FIRMAKODU.Name = "FIRMAKODU";
      this.FIRMAKODU.Visible = true;
      this.FIRMAKODU.VisibleIndex = 2;
      this.FIRMAADI.Caption = "Firma Adı";
      this.FIRMAADI.FieldName = "FIRMAADI";
      this.FIRMAADI.Name = "FIRMAADI";
      this.FIRMAADI.Visible = true;
      this.FIRMAADI.VisibleIndex = 3;
      this.ADI.Caption = "Kullanıcı Adı";
      this.ADI.FieldName = "ADI";
      this.ADI.Name = "ADI";
      this.ADI.Visible = true;
      this.ADI.VisibleIndex = 4;
      this.TEDARIKCIKODU.Caption = "Tedarikçi Kodu";
      this.TEDARIKCIKODU.FieldName = "TEDARIKCIKODU";
      this.TEDARIKCIKODU.Name = "TEDARIKCIKODU";
      this.TEDARIKCIKODU.Visible = true;
      this.TEDARIKCIKODU.VisibleIndex = 5;
      this.NETTUTAR.Caption = "Kdv'siz Toplam";
      this.NETTUTAR.FieldName = "NETTUTAR";
      this.NETTUTAR.Name = "NETTUTAR";
      this.NETTUTAR.Visible = true;
      this.NETTUTAR.VisibleIndex = 6;
      this.TOPLAMTUTAR.Caption = "Net Toplam";
      this.TOPLAMTUTAR.FieldName = "TOPLAMTUTAR";
      this.TOPLAMTUTAR.Name = "TOPLAMTUTAR";
      this.TOPLAMTUTAR.Visible = true;
      this.TOPLAMTUTAR.VisibleIndex = 7;
      this.ISFAST.Caption = "Basit Sipariş";
      this.ISFAST.FieldName = "ISFAST";
      this.ISFAST.Name = "ISFAST";
      this.imgk.Name = "imgk";
      this.imgk.SizeMode = PictureSizeMode.Zoom;
      this.img1.Name = "img1";
      this.img1.SizeMode = PictureSizeMode.Zoom;
      this.img2.Name = "img2";
      this.img2.SizeMode = PictureSizeMode.Zoom;
      this.img3.Name = "img3";
      this.img3.SizeMode = PictureSizeMode.Zoom;
      this.btn_sil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_sil.Location = new Point(373, 383);
      this.btn_sil.Name = "btn_sil";
      this.btn_sil.Size = new Size(75, 33);
      this.btn_sil.TabIndex = 20;
      this.btn_sil.Text = "Sil";
      this.btn_sil.Click += new EventHandler(this.btn_sil_Click);
      this.btn_duzenle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_duzenle.Location = new Point(193, 383);
      this.btn_duzenle.Name = "btn_duzenle";
      this.btn_duzenle.Size = new Size(75, 33);
      this.btn_duzenle.TabIndex = 19;
      this.btn_duzenle.Text = "Düzenle";
      this.btn_duzenle.Click += new EventHandler(this.btn_duzenle_Click);
      this.btn_ekle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_ekle.Location = new Point(13, 383);
      this.btn_ekle.Name = "btn_ekle";
      this.btn_ekle.Size = new Size(75, 33);
      this.btn_ekle.TabIndex = 18;
      this.btn_ekle.Text = "Ekle";
      this.btn_ekle.Click += new EventHandler(this.btn_ekle_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_iptal.Location = new Point(794, 383);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 17;
      this.btn_iptal.Text = "Kapat";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.bm1.DockControls.Add(this.barDockControlTop);
      this.bm1.DockControls.Add(this.barDockControlBottom);
      this.bm1.DockControls.Add(this.barDockControlLeft);
      this.bm1.DockControls.Add(this.barDockControlRight);
      this.bm1.Form = (Control) this;
      this.bm1.Items.AddRange(new BarItem[8]
      {
        (BarItem) this.bb_ekle,
        (BarItem) this.bb_sil,
        (BarItem) this.bb_duzenle,
        (BarItem) this.bb_kopyala,
        (BarItem) this.bb_incele,
        (BarItem) this.bb_yazdir,
        (BarItem) this.bb_yazdir_tumu,
        (BarItem) this.bb_ekle_basit
      });
      this.bm1.MaxItemId = 13;
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = DockStyle.Top;
      this.barDockControlTop.Location = new Point(0, 0);
      this.barDockControlTop.Size = new Size(881, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 428);
      this.barDockControlBottom.Size = new Size(881, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 428);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(881, 0);
      this.barDockControlRight.Size = new Size(0, 428);
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
      this.bb_kopyala.Caption = "Kopyala";
      this.bb_kopyala.Id = 8;
      this.bb_kopyala.Name = "bb_kopyala";
      this.bb_kopyala.ItemClick += new ItemClickEventHandler(this.bb_kopyala_ItemClick);
      this.bb_incele.Caption = "İncele";
      this.bb_incele.Id = 9;
      this.bb_incele.Name = "bb_incele";
      this.bb_incele.ItemClick += new ItemClickEventHandler(this.bb_incele_ItemClick);
      this.bb_yazdir.Caption = "Yazdır";
      this.bb_yazdir.Id = 10;
      this.bb_yazdir.Name = "bb_yazdir";
      this.bb_yazdir.ItemClick += new ItemClickEventHandler(this.bb_yazdir_ItemClick);
      this.bb_yazdir_tumu.Caption = "Tümünü Yazdır";
      this.bb_yazdir_tumu.Id = 11;
      this.bb_yazdir_tumu.Name = "bb_yazdir_tumu";
      this.bb_yazdir_tumu.ItemClick += new ItemClickEventHandler(this.bb_yazdir_tumu_ItemClick);
      this.bb_ekle_basit.Caption = "Ekle (Basit)";
      this.bb_ekle_basit.Id = 12;
      this.bb_ekle_basit.Name = "bb_ekle_basit";
      this.bb_ekle_basit.ItemClick += new ItemClickEventHandler(this.bb_ekle_basit_ItemClick);
      this.pp1.LinksPersistInfo.AddRange(new LinkPersistInfo[8]
      {
        new LinkPersistInfo((BarItem) this.bb_ekle),
        new LinkPersistInfo((BarItem) this.bb_ekle_basit),
        new LinkPersistInfo((BarItem) this.bb_duzenle),
        new LinkPersistInfo((BarItem) this.bb_kopyala),
        new LinkPersistInfo((BarItem) this.bb_incele),
        new LinkPersistInfo((BarItem) this.bb_sil),
        new LinkPersistInfo((BarItem) this.bb_yazdir),
        new LinkPersistInfo((BarItem) this.bb_yazdir_tumu)
      });
      this.pp1.Manager = this.bm1;
      this.pp1.Name = "pp1";
      this.btn_kopyala.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kopyala.Location = new Point(283, 383);
      this.btn_kopyala.Name = "btn_kopyala";
      this.btn_kopyala.Size = new Size(75, 33);
      this.btn_kopyala.TabIndex = 25;
      this.btn_kopyala.Text = "Kopyala";
      this.btn_kopyala.Click += new EventHandler(this.btn_kopyala_Click);
      this.btn_incele.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_incele.Location = new Point(463, 383);
      this.btn_incele.Name = "btn_incele";
      this.btn_incele.Size = new Size(75, 33);
      this.btn_incele.TabIndex = 30;
      this.btn_incele.Text = "İncele";
      this.btn_incele.Click += new EventHandler(this.btn_incele_Click);
      this.btn_yazdir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_yazdir.Location = new Point(553, 383);
      this.btn_yazdir.Name = "btn_yazdir";
      this.btn_yazdir.Size = new Size(75, 33);
      this.btn_yazdir.TabIndex = 35;
      this.btn_yazdir.Text = "Yazdır";
      this.btn_yazdir.Click += new EventHandler(this.btn_yazdir_Click);
      this.btn_yazdir_toplu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_yazdir_toplu.Location = new Point(643, 383);
      this.btn_yazdir_toplu.Name = "btn_yazdir_toplu";
      this.btn_yazdir_toplu.Size = new Size(75, 33);
      this.btn_yazdir_toplu.TabIndex = 40;
      this.btn_yazdir_toplu.Text = "Tümünü\r\nYazdır";
      this.btn_yazdir_toplu.Click += new EventHandler(this.btn_yazdir_toplu_Click);
      this.btn_ekle_basit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_ekle_basit.Location = new Point(103, 383);
      this.btn_ekle_basit.Name = "btn_ekle_basit";
      this.btn_ekle_basit.Size = new Size(75, 33);
      this.btn_ekle_basit.TabIndex = 45;
      this.btn_ekle_basit.Text = "Ekle (Basit)";
      this.btn_ekle_basit.Click += new EventHandler(this.btn_ekle_basit_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(881, 428);
      this.Controls.Add((Control) this.btn_ekle_basit);
      this.Controls.Add((Control) this.btn_yazdir_toplu);
      this.Controls.Add((Control) this.btn_yazdir);
      this.Controls.Add((Control) this.btn_incele);
      this.Controls.Add((Control) this.btn_kopyala);
      this.Controls.Add((Control) this.btn_sil);
      this.Controls.Add((Control) this.btn_duzenle);
      this.Controls.Add((Control) this.btn_ekle);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.dtg_sip);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.MinimizeBox = false;
      this.Name = nameof (SiparisBrws);
      this.Text = "Siparişler";
      this.WindowState = FormWindowState.Maximized;
      this.Activated += new EventHandler(this.SiparisHarBrws_Activated);
      this.FormClosing += new FormClosingEventHandler(this.SiparisHarBrws_FormClosing);
      this.Load += new EventHandler(this.SiparisBrws_Load);
      this.dtg_sip.EndInit();
      this.grd_sip.EndInit();
      this.imgk.EndInit();
      this.img1.EndInit();
      this.img2.EndInit();
      this.img3.EndInit();
      this.bm1.EndInit();
      this.pp1.EndInit();
      ((ISupportInitialize) this.ps1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
