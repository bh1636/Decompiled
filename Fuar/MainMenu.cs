// Decompiled with JetBrains decompiler
// Type: Fuar.MainMenu
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using DevExpress.XtraTabbedMdi;
using Fuar.Properties;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

#nullable disable
namespace Fuar
{
  public class MainMenu : XtraForm
  {
    private IContainer components;
    private NavBarControl nbc;
    private NavBarGroup nb_kart;
    private NavBarGroup nb_hareket;
    private NavBarGroup nb_rapor;
    private NavBarGroup nb_cikis;
    private NavBarItem nbi_tur;
    private NavBarItem nbi_otel;
    private NavBarGroup nb_kull;
    private NavBarItem nbi_kullanici;
    private NavBarItem nbi_tedarikciler;
    private NavBarItem nbi_siparis;
    private NavBarGroup nb_aktarimlar;
    private NavBarItem nbi_musteri;
    private NavBarItem nbi_katilimci;
    private NavBarItem nbi_stokcek;
    private NavBarItem nbi_caricek;
    private NavBarItem nbi_sipgonder;
    private NavBarItem nbi_fuargc;
    private NavBarItem nbi_otelhar;
    private NavBarItem nbi_ulasimtip;
    private NavBarItem nbi_indirim;
    private NavBarItem nbi_fuarlar;
    private NavBarItem nbi_urunler;
    private NavBarItem nbi_log;
    private NavBarItem nbi_indirimcek;
    private NavBarItem nbi_birimler;
    private BarManager bm1;
    private Bar bar2;
    private BarSubItem bs_dosya;
    private BarSubItem bs_duzen;
    private BarSubItem bs_gorunum;
    private BarLinkContainerItem b_tema;
    private BarDockControl barDockControlTop;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private NavBarGroup nb_ayarlar;
    private NavBarItem nbi_tema;
    private BarSubItem barSubItem4;
    private BarSubItem barSubItem6;
    private BarSubItem barSubItem5;
    private BarSubItem barSubItem7;
    private BarSubItem barSubItem8;
    private BarSubItem barSubItem9;
    private BarButtonItem b_cikis;
    private BarButtonItem b_yazdir;
    private BarButtonItem b_ayarlar;
    private BarButtonItem b_kes;
    private BarButtonItem b_kopyala;
    private BarButtonItem b_yapistir;
    private Bar bar1;
    private BarStaticItem bar_info;
    private BarStaticItem user_info;
    private PictureEdit pb_logo;
    private PictureEdit pb_user_logo;
    private GroupControl grp1;
    private TextEdit txt_yetki;
    private TextEdit txt_kadi;
    private TextEdit txt_soyad;
    private TextEdit txt_ad;
    private LabelControl labelControl4;
    private LabelControl labelControl3;
    private LabelControl labelControl2;
    private LabelControl labelControl1;
    private TextEdit txt_tedarikci;
    private TextEdit txt_eposta;
    private TextEdit txt_unvan;
    private LabelControl labelControl7;
    private LabelControl labelControl6;
    private LabelControl labelControl5;
    private BarButtonItem b_kullbil;
    private NavBarItem nbi_aktarim;
    private NavBarItem nbi_grup;
    private NavBarItem nbi_yetki;
    private NavBarItem nbi_excel;
    private BarButtonItem bb_hakkinda;
    private NavBarItem nbi_fiyatgunc;
    private NavBarItem nbi_excel_stok;
    private NavBarItem nbi_raportanim;
    private NavBarItem nbi_tablorapor;
    private NavBarItem nbi_pivotrapor;
    private NavBarItem grafikrapor;
    private XtraTabbedMdiManager xtraTabbedMdiManager1;
    private NavBarItem nbi_kur;
    private NavBarItem nbi_caritransfer;

    public MainMenu() => this.InitializeComponent();

    private void MainMenu_Load(object sender, EventArgs e)
    {
      this.getuserinfo();
      _main.get_right();
      BonusSkins.Register();
      SkinHelper.InitSkinPopupMenu((BarLinksHolder) this.b_tema);
      UserLookAndFeel.Default.SkinName = this.restore_theme();
      if (_main.y_kartlar[0] == "True")
      {
        this.nb_kart.Visible = true;
        this.nbi_kur.Visible = true;
      }
      else
      {
        this.nb_kart.Visible = false;
        this.nbi_kur.Visible = false;
      }
      if (_main.y_siparisler[0] == "True")
        this.nbi_siparis.Visible = true;
      else
        this.nbi_siparis.Visible = false;
      if (_main.y_gchar[0] == "True")
      {
        this.nbi_fuargc.Visible = true;
        this.nbi_otelhar.Visible = true;
      }
      else
      {
        this.nbi_fuargc.Visible = false;
        this.nbi_otelhar.Visible = false;
      }
      if (_main.y_kull[0] == "True")
        this.nb_kull.Visible = true;
      else
        this.nb_kull.Visible = false;
      if (_main.y_logo_akt[0] == "True")
      {
        this.nbi_caricek.Visible = true;
        this.nbi_indirimcek.Visible = true;
        this.nbi_stokcek.Visible = true;
        this.nbi_fiyatgunc.Visible = true;
      }
      else
      {
        this.nbi_caricek.Visible = false;
        this.nbi_indirimcek.Visible = false;
        this.nbi_stokcek.Visible = false;
        this.nbi_fiyatgunc.Visible = false;
      }
      if (_main.y_excel_akt[0] == "True")
        this.nbi_excel.Visible = true;
      else
        this.nbi_excel.Visible = false;
      if (!this.nbi_excel.Visible && !this.nbi_caricek.Visible && !this.nbi_indirimcek.Visible && !this.nbi_stokcek.Visible)
        this.nb_aktarimlar.Visible = false;
      if (_main.y_rap[0] == "True")
      {
        this.nb_rapor.Visible = true;
      }
      else
      {
        this.nb_rapor.Visible = false;
        if (!this.nbi_excel.Visible)
          this.nbi_aktarim.Visible = false;
        else
          this.nbi_aktarim.Visible = true;
      }
    }

    private void getuserinfo()
    {
      if (_main.dt_user.Rows.Count <= 0)
        return;
      this.bar_info.Caption = "Server : " + _main.s_sunucu + "        Database : " + _main.s_db + "        User : " + _main.dt_user.Rows[0]["KULLANICIADI"] + "        Version : " + Application.ProductVersion;
      this.user_info.Caption = "  Hoşgeldiniz :  " + _main.dt_user.Rows[0]["ADI"] + " " + _main.dt_user.Rows[0]["SOYADI"];
      if (_main.dt_user.Rows[0]["RESIM"] != null)
        this.pb_user_logo.Image = _main.byteArrayToImage((byte[]) _main.dt_user.Rows[0]["RESIM"]);
      this.txt_ad.Text = _main.dt_user.Rows[0]["ADI"].ToString();
      this.txt_soyad.Text = _main.dt_user.Rows[0]["SOYADI"].ToString();
      this.txt_kadi.Text = _main.dt_user.Rows[0]["KULLANICIADI"].ToString();
      this.txt_yetki.Text = _main.dt_user.Rows[0]["GRUPADI"].ToString();
      this.txt_eposta.Text = _main.dt_user.Rows[0]["EPOSTA"].ToString();
      this.txt_tedarikci.Text = _main.dt_user.Rows[0]["TEDARIKCIADI"].ToString();
      this.txt_unvan.Text = _main.dt_user.Rows[0]["UNVAN"].ToString();
    }

    private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
    {
      try
      {
        this.save_theme(UserLookAndFeel.Default.SkinName);
      }
      catch
      {
        Application.Exit();
      }
      Application.Exit();
    }

    private void save_theme(string temaadi)
    {
      RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("DmsFuar", true);
      registryKey.SetValue("ThemeName", (object) temaadi);
      registryKey.Flush();
      registryKey.Dispose();
    }

    private string restore_theme()
    {
      try
      {
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("DmsFuar", true);
        return registryKey.GetValue("ThemeName") != null ? registryKey.GetValue("ThemeName").ToString() : "VS2010";
      }
      catch
      {
        return "VS2010";
      }
    }

    private void nb_cikis_ItemChanged(object sender, EventArgs e) => this.Close();

    private void nbi_kullanici_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["KullaniciBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        KullaniciBrws kullaniciBrws = new KullaniciBrws();
        kullaniciBrws.MdiParent = (Form) this;
        kullaniciBrws.Show();
        this.grp1.SendToBack();
        this.pb_logo.SendToBack();
      }
    }

    private static void clearforms()
    {
      for (int index = 0; index < Application.OpenForms.Count; ++index)
      {
        try
        {
          Form openForm = Application.OpenForms[index];
          if (openForm.Name != nameof (MainMenu))
          {
            if (openForm.Name != "Form1")
              openForm.Close();
          }
        }
        catch (ArgumentOutOfRangeException ex)
        {
        }
      }
    }

    private void set_color()
    {
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        try
        {
          control.BackColor = this.BackColor;
        }
        catch (InvalidCastException ex)
        {
        }
      }
    }

    private void nbi_tedarikciler_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["TedarikcilerBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        TedarikcilerBrws tedarikcilerBrws = new TedarikcilerBrws();
        tedarikcilerBrws.MdiParent = (Form) this;
        tedarikcilerBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_tur_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["TurBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        TurBrws turBrws = new TurBrws();
        turBrws.MdiParent = (Form) this;
        turBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_otel_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["OtelBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        OtelBrws otelBrws = new OtelBrws();
        otelBrws.MdiParent = (Form) this;
        otelBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_fuarlar_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["FuarBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        FuarBrws fuarBrws = new FuarBrws();
        fuarBrws.MdiParent = (Form) this;
        fuarBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_urunler_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["MalzemeBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        MalzemeBrws malzemeBrws = new MalzemeBrws();
        malzemeBrws.MdiParent = (Form) this;
        malzemeBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_birimler_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["BirimlerBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        BirimlerBrws birimlerBrws = new BirimlerBrws();
        birimlerBrws.MdiParent = (Form) this;
        birimlerBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_katilimci_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["KatilimciBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        KatilimciBrws katilimciBrws = new KatilimciBrws();
        katilimciBrws.MdiParent = (Form) this;
        katilimciBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_ulasimtip_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["UlasimBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        UlasimBrws ulasimBrws = new UlasimBrws();
        ulasimBrws.MdiParent = (Form) this;
        ulasimBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_musteri_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["MusteriBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        MusteriBrws musteriBrws = new MusteriBrws();
        musteriBrws.MdiParent = (Form) this;
        musteriBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_indirim_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["IndirimBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        IndirimBrws indirimBrws = new IndirimBrws();
        indirimBrws.MdiParent = (Form) this;
        indirimBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_tema_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      GalleryDropDown gallery = new GalleryDropDown();
      gallery.Manager = this.bm1;
      SkinHelper.InitSkinGalleryDropDown(gallery);
      gallery.ShowPopup(Control.MousePosition);
    }

    private void b_cikis_ItemClick(object sender, ItemClickEventArgs e) => this.Close();

    private void b_ayarlar_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.nbc.Groups["nb_ayarlar"].Expanded = true;
    }

    private void b_kullbil_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.grp1.BringToFront();
    }

    private void nbi_siparis_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["SiparisBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        SiparisBrws siparisBrws = new SiparisBrws();
        siparisBrws.MdiParent = (Form) this;
        siparisBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_indirimcek_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["AktFrmIndirim"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        AktFrmIndirim aktFrmIndirim = new AktFrmIndirim();
        aktFrmIndirim.MdiParent = (Form) this;
        aktFrmIndirim.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_stokcek_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["AktFrmStok"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        AktFrmStok aktFrmStok = new AktFrmStok();
        aktFrmStok.MdiParent = (Form) this;
        aktFrmStok.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_caricek_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["AktFrmCari"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        AktFrmCari aktFrmCari = new AktFrmCari();
        aktFrmCari.MdiParent = (Form) this;
        aktFrmCari.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_aktarim_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["AktAyarFrm"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        AktAyarFrm aktAyarFrm = new AktAyarFrm();
        aktAyarFrm.MdiParent = (Form) this;
        aktAyarFrm.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_grup_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["GrupBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        GrupBrws grupBrws = new GrupBrws();
        grupBrws.MdiParent = (Form) this;
        grupBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_yetki_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["YetkilerFrm"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        YetkilerFrm yetkilerFrm = new YetkilerFrm();
        yetkilerFrm.MdiParent = (Form) this;
        yetkilerFrm.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_excel_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["ExcelFrm"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        ExcelFrm excelFrm = new ExcelFrm();
        excelFrm.MdiParent = (Form) this;
        excelFrm.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void bb_hakkinda_ItemClick(object sender, ItemClickEventArgs e)
    {
      int num = (int) new Hakkinda().ShowDialog();
    }

    private void nbi_fiyatgunc_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["AktFrmFiyat"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        AktFrmFiyat aktFrmFiyat = new AktFrmFiyat();
        aktFrmFiyat.MdiParent = (Form) this;
        aktFrmFiyat.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_excel_stok_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["AktFrmStokExcel"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        AktFrmStokExcel aktFrmStokExcel = new AktFrmStokExcel();
        aktFrmStokExcel.MdiParent = (Form) this;
        aktFrmStokExcel.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_raportanim_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["RaporTanimlariBrws"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        RaporTanimlariBrws raporTanimlariBrws = new RaporTanimlariBrws();
        raporTanimlariBrws.MdiParent = (Form) this;
        raporTanimlariBrws.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_tablorapor_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["Raporlar"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        Raporlar raporlar = new Raporlar();
        raporlar.MdiParent = (Form) this;
        raporlar.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_pivotrapor_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["RaporlarPivot"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        RaporlarPivot raporlarPivot = new RaporlarPivot();
        raporlarPivot.MdiParent = (Form) this;
        raporlarPivot.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void grafikrapor_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["RaporlarGrafik"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        RaporlarGrafik raporlarGrafik = new RaporlarGrafik();
        raporlarGrafik.MdiParent = (Form) this;
        raporlarGrafik.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_kur_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["Kurlar"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        Kurlar kurlar = new Kurlar();
        kurlar.MdiParent = (Form) this;
        kurlar.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
      }
    }

    private void nbi_caritransfer_LinkClicked(object sender, NavBarLinkEventArgs e)
    {
      Form openForm = Application.OpenForms["AktCariTrans"];
      if (openForm != null)
      {
        openForm.Activate();
      }
      else
      {
        AktCariTrans aktCariTrans = new AktCariTrans();
        aktCariTrans.MdiParent = (Form) this;
        aktCariTrans.Show();
        this.pb_logo.SendToBack();
        this.grp1.SendToBack();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainMenu));
      this.nbc = new NavBarControl();
      this.nb_aktarimlar = new NavBarGroup();
      this.nbi_indirimcek = new NavBarItem();
      this.nbi_stokcek = new NavBarItem();
      this.nbi_caricek = new NavBarItem();
      this.nbi_fiyatgunc = new NavBarItem();
      this.nbi_excel = new NavBarItem();
      this.nbi_excel_stok = new NavBarItem();
      this.nbi_caritransfer = new NavBarItem();
      this.nb_kart = new NavBarGroup();
      this.nbi_fuarlar = new NavBarItem();
      this.nbi_otel = new NavBarItem();
      this.nbi_tedarikciler = new NavBarItem();
      this.nbi_tur = new NavBarItem();
      this.nbi_ulasimtip = new NavBarItem();
      this.nbi_urunler = new NavBarItem();
      this.nbi_birimler = new NavBarItem();
      this.nbi_musteri = new NavBarItem();
      this.nbi_indirim = new NavBarItem();
      this.nbi_katilimci = new NavBarItem();
      this.nb_hareket = new NavBarGroup();
      this.nbi_fuargc = new NavBarItem();
      this.nbi_otelhar = new NavBarItem();
      this.nbi_siparis = new NavBarItem();
      this.nb_kull = new NavBarGroup();
      this.nbi_kullanici = new NavBarItem();
      this.nbi_grup = new NavBarItem();
      this.nb_rapor = new NavBarGroup();
      this.nbi_raportanim = new NavBarItem();
      this.nbi_tablorapor = new NavBarItem();
      this.nbi_pivotrapor = new NavBarItem();
      this.grafikrapor = new NavBarItem();
      this.nbi_log = new NavBarItem();
      this.nb_ayarlar = new NavBarGroup();
      this.nbi_aktarim = new NavBarItem();
      this.nbi_kur = new NavBarItem();
      this.nbi_tema = new NavBarItem();
      this.nb_cikis = new NavBarGroup();
      this.nbi_sipgonder = new NavBarItem();
      this.nbi_yetki = new NavBarItem();
      this.bm1 = new BarManager(this.components);
      this.bar2 = new Bar();
      this.bs_dosya = new BarSubItem();
      this.b_kullbil = new BarButtonItem();
      this.b_ayarlar = new BarButtonItem();
      this.b_yazdir = new BarButtonItem();
      this.b_cikis = new BarButtonItem();
      this.bs_duzen = new BarSubItem();
      this.b_kes = new BarButtonItem();
      this.b_kopyala = new BarButtonItem();
      this.b_yapistir = new BarButtonItem();
      this.bs_gorunum = new BarSubItem();
      this.b_tema = new BarLinkContainerItem();
      this.bb_hakkinda = new BarButtonItem();
      this.bar1 = new Bar();
      this.bar_info = new BarStaticItem();
      this.user_info = new BarStaticItem();
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControlRight = new BarDockControl();
      this.barSubItem4 = new BarSubItem();
      this.barSubItem5 = new BarSubItem();
      this.barSubItem6 = new BarSubItem();
      this.barSubItem7 = new BarSubItem();
      this.barSubItem8 = new BarSubItem();
      this.barSubItem9 = new BarSubItem();
      this.pb_logo = new PictureEdit();
      this.pb_user_logo = new PictureEdit();
      this.grp1 = new GroupControl();
      this.txt_yetki = new TextEdit();
      this.txt_kadi = new TextEdit();
      this.txt_tedarikci = new TextEdit();
      this.txt_eposta = new TextEdit();
      this.txt_unvan = new TextEdit();
      this.txt_soyad = new TextEdit();
      this.txt_ad = new TextEdit();
      this.labelControl4 = new LabelControl();
      this.labelControl3 = new LabelControl();
      this.labelControl7 = new LabelControl();
      this.labelControl6 = new LabelControl();
      this.labelControl5 = new LabelControl();
      this.labelControl2 = new LabelControl();
      this.labelControl1 = new LabelControl();
      this.xtraTabbedMdiManager1 = new XtraTabbedMdiManager(this.components);
      this.nbc.BeginInit();
      this.bm1.BeginInit();
      this.pb_logo.Properties.BeginInit();
      this.pb_user_logo.Properties.BeginInit();
      this.grp1.BeginInit();
      this.grp1.SuspendLayout();
      this.txt_yetki.Properties.BeginInit();
      this.txt_kadi.Properties.BeginInit();
      this.txt_tedarikci.Properties.BeginInit();
      this.txt_eposta.Properties.BeginInit();
      this.txt_unvan.Properties.BeginInit();
      this.txt_soyad.Properties.BeginInit();
      this.txt_ad.Properties.BeginInit();
      ((ISupportInitialize) this.xtraTabbedMdiManager1).BeginInit();
      this.SuspendLayout();
      this.nbc.ActiveGroup = this.nb_hareket;
      this.nbc.Dock = DockStyle.Left;
      this.nbc.Groups.AddRange(new NavBarGroup[7]
      {
        this.nb_kart,
        this.nb_hareket,
        this.nb_kull,
        this.nb_aktarimlar,
        this.nb_rapor,
        this.nb_ayarlar,
        this.nb_cikis
      });
      this.nbc.Items.AddRange(new NavBarItem[32]
      {
        this.nbi_otel,
        this.nbi_tur,
        this.nbi_kullanici,
        this.nbi_tedarikciler,
        this.nbi_siparis,
        this.nbi_musteri,
        this.nbi_katilimci,
        this.nbi_stokcek,
        this.nbi_caricek,
        this.nbi_sipgonder,
        this.nbi_urunler,
        this.nbi_fuarlar,
        this.nbi_indirim,
        this.nbi_otelhar,
        this.nbi_ulasimtip,
        this.nbi_fuargc,
        this.nbi_indirimcek,
        this.nbi_log,
        this.nbi_birimler,
        this.nbi_tema,
        this.nbi_aktarim,
        this.nbi_grup,
        this.nbi_yetki,
        this.nbi_excel,
        this.nbi_fiyatgunc,
        this.nbi_excel_stok,
        this.nbi_raportanim,
        this.nbi_tablorapor,
        this.nbi_pivotrapor,
        this.grafikrapor,
        this.nbi_kur,
        this.nbi_caritransfer
      });
      this.nbc.Location = new Point(0, 22);
      this.nbc.Name = "nbc";
      this.nbc.OptionsNavPane.ExpandedWidth = 184;
      this.nbc.PaintStyleKind = NavBarViewKind.NavigationPane;
      this.nbc.Size = new Size(184, 610);
      this.nbc.StoreDefaultPaintStyleName = true;
      this.nbc.TabIndex = 0;
      this.nb_aktarimlar.Caption = "Aktarımlar";
      this.nb_aktarimlar.ItemLinks.AddRange(new NavBarItemLink[7]
      {
        new NavBarItemLink(this.nbi_indirimcek),
        new NavBarItemLink(this.nbi_stokcek),
        new NavBarItemLink(this.nbi_caricek),
        new NavBarItemLink(this.nbi_fiyatgunc),
        new NavBarItemLink(this.nbi_excel),
        new NavBarItemLink(this.nbi_excel_stok),
        new NavBarItemLink(this.nbi_caritransfer)
      });
      this.nb_aktarimlar.LargeImage = (Image) Resources.replace2;
      this.nb_aktarimlar.Name = "nb_aktarimlar";
      this.nbi_indirimcek.Caption = "İndirim Tanımı Aktarımları";
      this.nbi_indirimcek.Name = "nbi_indirimcek";
      this.nbi_indirimcek.LinkClicked += new NavBarLinkEventHandler(this.nbi_indirimcek_LinkClicked);
      this.nbi_stokcek.Caption = "Stok Kartı Aktarımları";
      this.nbi_stokcek.Name = "nbi_stokcek";
      this.nbi_stokcek.LinkClicked += new NavBarLinkEventHandler(this.nbi_stokcek_LinkClicked);
      this.nbi_caricek.Caption = "Cari Hesap Kartı Aktarımları";
      this.nbi_caricek.Name = "nbi_caricek";
      this.nbi_caricek.LinkClicked += new NavBarLinkEventHandler(this.nbi_caricek_LinkClicked);
      this.nbi_fiyatgunc.Caption = "Fiyat Aktarımları";
      this.nbi_fiyatgunc.Name = "nbi_fiyatgunc";
      this.nbi_fiyatgunc.LinkClicked += new NavBarLinkEventHandler(this.nbi_fiyatgunc_LinkClicked);
      this.nbi_excel.Caption = "Excel'den Sipariş Aktarımı";
      this.nbi_excel.Name = "nbi_excel";
      this.nbi_excel.LinkClicked += new NavBarLinkEventHandler(this.nbi_excel_LinkClicked);
      this.nbi_excel_stok.Caption = "Excel'den Ürün Kartı Aktarımı";
      this.nbi_excel_stok.Name = "nbi_excel_stok";
      this.nbi_excel_stok.LinkClicked += new NavBarLinkEventHandler(this.nbi_excel_stok_LinkClicked);
      this.nbi_caritransfer.Caption = "Cari Hesaplar Arası Sip. Akt.";
      this.nbi_caritransfer.Name = "nbi_caritransfer";
      this.nbi_caritransfer.LinkClicked += new NavBarLinkEventHandler(this.nbi_caritransfer_LinkClicked);
      this.nb_kart.Caption = "Kart Tanımları";
      this.nb_kart.ItemLinks.AddRange(new NavBarItemLink[10]
      {
        new NavBarItemLink(this.nbi_fuarlar),
        new NavBarItemLink(this.nbi_otel),
        new NavBarItemLink(this.nbi_tedarikciler),
        new NavBarItemLink(this.nbi_tur),
        new NavBarItemLink(this.nbi_ulasimtip),
        new NavBarItemLink(this.nbi_urunler),
        new NavBarItemLink(this.nbi_birimler),
        new NavBarItemLink(this.nbi_musteri),
        new NavBarItemLink(this.nbi_indirim),
        new NavBarItemLink(this.nbi_katilimci)
      });
      this.nb_kart.LargeImage = (Image) Resources.cube_blue;
      this.nb_kart.Name = "nb_kart";
      this.nbi_fuarlar.Caption = "Fuarlar";
      this.nbi_fuarlar.Name = "nbi_fuarlar";
      this.nbi_fuarlar.LinkClicked += new NavBarLinkEventHandler(this.nbi_fuarlar_LinkClicked);
      this.nbi_otel.Caption = "Otel Tanımları";
      this.nbi_otel.Name = "nbi_otel";
      this.nbi_otel.LinkClicked += new NavBarLinkEventHandler(this.nbi_otel_LinkClicked);
      this.nbi_tedarikciler.Caption = "Tedarikçiler";
      this.nbi_tedarikciler.Name = "nbi_tedarikciler";
      this.nbi_tedarikciler.LinkClicked += new NavBarLinkEventHandler(this.nbi_tedarikciler_LinkClicked);
      this.nbi_tur.Caption = "Tur Şirketleri";
      this.nbi_tur.Name = "nbi_tur";
      this.nbi_tur.LinkClicked += new NavBarLinkEventHandler(this.nbi_tur_LinkClicked);
      this.nbi_ulasimtip.Caption = "Ulaşım Şekilleri";
      this.nbi_ulasimtip.Name = "nbi_ulasimtip";
      this.nbi_ulasimtip.LinkClicked += new NavBarLinkEventHandler(this.nbi_ulasimtip_LinkClicked);
      this.nbi_urunler.Caption = "Ürünler";
      this.nbi_urunler.Name = "nbi_urunler";
      this.nbi_urunler.LinkClicked += new NavBarLinkEventHandler(this.nbi_urunler_LinkClicked);
      this.nbi_birimler.Caption = "Birimler";
      this.nbi_birimler.Name = "nbi_birimler";
      this.nbi_birimler.LinkClicked += new NavBarLinkEventHandler(this.nbi_birimler_LinkClicked);
      this.nbi_musteri.Caption = "Müşteriler";
      this.nbi_musteri.Name = "nbi_musteri";
      this.nbi_musteri.LinkClicked += new NavBarLinkEventHandler(this.nbi_musteri_LinkClicked);
      this.nbi_indirim.Caption = "İndirimler";
      this.nbi_indirim.Name = "nbi_indirim";
      this.nbi_indirim.LinkClicked += new NavBarLinkEventHandler(this.nbi_indirim_LinkClicked);
      this.nbi_katilimci.Caption = "Katılımcılar";
      this.nbi_katilimci.Name = "nbi_katilimci";
      this.nbi_katilimci.LinkClicked += new NavBarLinkEventHandler(this.nbi_katilimci_LinkClicked);
      this.nb_hareket.Caption = "Hareketler";
      this.nb_hareket.Expanded = true;
      this.nb_hareket.ItemLinks.AddRange(new NavBarItemLink[3]
      {
        new NavBarItemLink(this.nbi_fuargc),
        new NavBarItemLink(this.nbi_otelhar),
        new NavBarItemLink(this.nbi_siparis)
      });
      this.nb_hareket.LargeImage = (Image) Resources.shopping_cart;
      this.nb_hareket.Name = "nb_hareket";
      this.nbi_fuargc.Caption = "Fuar Alanı Giriş Çıkış Hareketleri";
      this.nbi_fuargc.Name = "nbi_fuargc";
      this.nbi_otelhar.Caption = "Otel Giriş Çıkış Hareketleri";
      this.nbi_otelhar.Name = "nbi_otelhar";
      this.nbi_siparis.Caption = "Sipariş Hareketi";
      this.nbi_siparis.Name = "nbi_siparis";
      this.nbi_siparis.LinkClicked += new NavBarLinkEventHandler(this.nbi_siparis_LinkClicked);
      this.nb_kull.Caption = "Kullanıcı Tanımları";
      this.nb_kull.ItemLinks.AddRange(new NavBarItemLink[2]
      {
        new NavBarItemLink(this.nbi_kullanici),
        new NavBarItemLink(this.nbi_grup)
      });
      this.nb_kull.LargeImage = (Image) Resources.users1;
      this.nb_kull.Name = "nb_kull";
      this.nbi_kullanici.Caption = "Kullanıcılar";
      this.nbi_kullanici.Name = "nbi_kullanici";
      this.nbi_kullanici.LinkClicked += new NavBarLinkEventHandler(this.nbi_kullanici_LinkClicked);
      this.nbi_grup.Caption = "Gruplar";
      this.nbi_grup.Name = "nbi_grup";
      this.nbi_grup.LinkClicked += new NavBarLinkEventHandler(this.nbi_grup_LinkClicked);
      this.nb_rapor.Caption = "Raporlar";
      this.nb_rapor.ItemLinks.AddRange(new NavBarItemLink[5]
      {
        new NavBarItemLink(this.nbi_raportanim),
        new NavBarItemLink(this.nbi_tablorapor),
        new NavBarItemLink(this.nbi_pivotrapor),
        new NavBarItemLink(this.grafikrapor),
        new NavBarItemLink(this.nbi_log)
      });
      this.nb_rapor.LargeImage = (Image) Resources.printer;
      this.nb_rapor.Name = "nb_rapor";
      this.nbi_raportanim.Caption = "Rapor Tanımları";
      this.nbi_raportanim.Name = "nbi_raportanim";
      this.nbi_raportanim.LinkClicked += new NavBarLinkEventHandler(this.nbi_raportanim_LinkClicked);
      this.nbi_tablorapor.Caption = "Tablo Raporlar";
      this.nbi_tablorapor.Name = "nbi_tablorapor";
      this.nbi_tablorapor.LinkClicked += new NavBarLinkEventHandler(this.nbi_tablorapor_LinkClicked);
      this.nbi_pivotrapor.Caption = "Pivot Raporlar";
      this.nbi_pivotrapor.Name = "nbi_pivotrapor";
      this.nbi_pivotrapor.LinkClicked += new NavBarLinkEventHandler(this.nbi_pivotrapor_LinkClicked);
      this.grafikrapor.Caption = "Grafik Raporlar";
      this.grafikrapor.Name = "grafikrapor";
      this.grafikrapor.LinkClicked += new NavBarLinkEventHandler(this.grafikrapor_LinkClicked);
      this.nbi_log.Caption = "İşlem Kayıtları";
      this.nbi_log.Name = "nbi_log";
      this.nb_ayarlar.Caption = "Ayarlar";
      this.nb_ayarlar.ItemLinks.AddRange(new NavBarItemLink[3]
      {
        new NavBarItemLink(this.nbi_aktarim),
        new NavBarItemLink(this.nbi_kur),
        new NavBarItemLink(this.nbi_tema)
      });
      this.nb_ayarlar.LargeImage = (Image) Resources.preferences1;
      this.nb_ayarlar.Name = "nb_ayarlar";
      this.nbi_aktarim.Caption = "Aktarım Ayarları";
      this.nbi_aktarim.Name = "nbi_aktarim";
      this.nbi_aktarim.LinkClicked += new NavBarLinkEventHandler(this.nbi_aktarim_LinkClicked);
      this.nbi_kur.Caption = "Döviz Kurları";
      this.nbi_kur.Name = "nbi_kur";
      this.nbi_kur.LinkClicked += new NavBarLinkEventHandler(this.nbi_kur_LinkClicked);
      this.nbi_tema.Caption = "Temalar";
      this.nbi_tema.Name = "nbi_tema";
      this.nbi_tema.LinkClicked += new NavBarLinkEventHandler(this.nbi_tema_LinkClicked);
      this.nb_cikis.Caption = "Çıkış";
      this.nb_cikis.LargeImage = (Image) Resources.kapat__Custom_;
      this.nb_cikis.Name = "nb_cikis";
      this.nb_cikis.ItemChanged += new EventHandler(this.nb_cikis_ItemChanged);
      this.nbi_sipgonder.Caption = "Sipariş Hareketleri Aktarımları";
      this.nbi_sipgonder.Name = "nbi_sipgonder";
      this.nbi_yetki.Caption = "Yetkiler";
      this.nbi_yetki.Name = "nbi_yetki";
      this.nbi_yetki.LinkClicked += new NavBarLinkEventHandler(this.nbi_yetki_LinkClicked);
      this.bm1.Bars.AddRange(new Bar[2]
      {
        this.bar2,
        this.bar1
      });
      this.bm1.DockControls.Add(this.barDockControlTop);
      this.bm1.DockControls.Add(this.barDockControlBottom);
      this.bm1.DockControls.Add(this.barDockControlLeft);
      this.bm1.DockControls.Add(this.barDockControlRight);
      this.bm1.Form = (Control) this;
      this.bm1.Items.AddRange(new BarItem[20]
      {
        (BarItem) this.bs_dosya,
        (BarItem) this.bs_duzen,
        (BarItem) this.bs_gorunum,
        (BarItem) this.b_tema,
        (BarItem) this.barSubItem4,
        (BarItem) this.barSubItem5,
        (BarItem) this.barSubItem6,
        (BarItem) this.barSubItem7,
        (BarItem) this.barSubItem8,
        (BarItem) this.barSubItem9,
        (BarItem) this.b_cikis,
        (BarItem) this.b_yazdir,
        (BarItem) this.b_ayarlar,
        (BarItem) this.b_kes,
        (BarItem) this.b_kopyala,
        (BarItem) this.b_yapistir,
        (BarItem) this.bar_info,
        (BarItem) this.user_info,
        (BarItem) this.b_kullbil,
        (BarItem) this.bb_hakkinda
      });
      this.bm1.MainMenu = this.bar2;
      this.bm1.MaxItemId = 21;
      this.bm1.StatusBar = this.bar1;
      this.bar2.BarName = "Main menu";
      this.bar2.CanDockStyle = BarCanDockStyle.Top;
      this.bar2.DockCol = 0;
      this.bar2.DockRow = 0;
      this.bar2.DockStyle = BarDockStyle.Top;
      this.bar2.LinksPersistInfo.AddRange(new LinkPersistInfo[4]
      {
        new LinkPersistInfo((BarItem) this.bs_dosya),
        new LinkPersistInfo(BarLinkUserDefines.None, false, (BarItem) this.bs_duzen, false),
        new LinkPersistInfo((BarItem) this.bs_gorunum),
        new LinkPersistInfo((BarItem) this.bb_hakkinda)
      });
      this.bar2.OptionsBar.AllowQuickCustomization = false;
      this.bar2.OptionsBar.DisableClose = true;
      this.bar2.OptionsBar.DisableCustomization = true;
      this.bar2.OptionsBar.DrawDragBorder = false;
      this.bar2.OptionsBar.UseWholeRow = true;
      this.bar2.Text = "Main menu";
      this.bs_dosya.Caption = "Dosya";
      this.bs_dosya.Id = 0;
      this.bs_dosya.LinksPersistInfo.AddRange(new LinkPersistInfo[4]
      {
        new LinkPersistInfo((BarItem) this.b_kullbil),
        new LinkPersistInfo((BarItem) this.b_ayarlar),
        new LinkPersistInfo(BarLinkUserDefines.None, false, (BarItem) this.b_yazdir, false),
        new LinkPersistInfo((BarItem) this.b_cikis)
      });
      this.bs_dosya.Name = "bs_dosya";
      this.b_kullbil.Caption = "Kullanıcı Bilgileri";
      this.b_kullbil.Id = 19;
      this.b_kullbil.Name = "b_kullbil";
      this.b_kullbil.ItemClick += new ItemClickEventHandler(this.b_kullbil_ItemClick);
      this.b_ayarlar.Caption = "Ayarlar";
      this.b_ayarlar.Id = 12;
      this.b_ayarlar.Name = "b_ayarlar";
      this.b_ayarlar.ItemClick += new ItemClickEventHandler(this.b_ayarlar_ItemClick);
      this.b_yazdir.Caption = "Yazdır";
      this.b_yazdir.Id = 11;
      this.b_yazdir.Name = "b_yazdir";
      this.b_cikis.Caption = "Çıkış";
      this.b_cikis.Id = 10;
      this.b_cikis.Name = "b_cikis";
      this.b_cikis.ItemClick += new ItemClickEventHandler(this.b_cikis_ItemClick);
      this.bs_duzen.Caption = "Düzen";
      this.bs_duzen.Id = 1;
      this.bs_duzen.LinksPersistInfo.AddRange(new LinkPersistInfo[3]
      {
        new LinkPersistInfo((BarItem) this.b_kes),
        new LinkPersistInfo((BarItem) this.b_kopyala),
        new LinkPersistInfo((BarItem) this.b_yapistir)
      });
      this.bs_duzen.Name = "bs_duzen";
      this.b_kes.Caption = "Kes";
      this.b_kes.Id = 13;
      this.b_kes.Name = "b_kes";
      this.b_kopyala.Caption = "Kopyala";
      this.b_kopyala.Id = 14;
      this.b_kopyala.Name = "b_kopyala";
      this.b_yapistir.Caption = "Yapıştır";
      this.b_yapistir.Id = 15;
      this.b_yapistir.Name = "b_yapistir";
      this.bs_gorunum.Caption = "Görünüm";
      this.bs_gorunum.Id = 2;
      this.bs_gorunum.LinksPersistInfo.AddRange(new LinkPersistInfo[1]
      {
        new LinkPersistInfo((BarItem) this.b_tema)
      });
      this.bs_gorunum.Name = "bs_gorunum";
      this.b_tema.Caption = "Temalar";
      this.b_tema.Id = 3;
      this.b_tema.Name = "b_tema";
      this.bb_hakkinda.Alignment = BarItemLinkAlignment.Right;
      this.bb_hakkinda.Caption = "Hakkında";
      this.bb_hakkinda.Id = 20;
      this.bb_hakkinda.Name = "bb_hakkinda";
      this.bb_hakkinda.ItemClick += new ItemClickEventHandler(this.bb_hakkinda_ItemClick);
      this.bar1.BarName = "Status";
      this.bar1.CanDockStyle = BarCanDockStyle.Bottom;
      this.bar1.DockCol = 0;
      this.bar1.DockRow = 0;
      this.bar1.DockStyle = BarDockStyle.Bottom;
      this.bar1.LinksPersistInfo.AddRange(new LinkPersistInfo[2]
      {
        new LinkPersistInfo((BarItem) this.bar_info),
        new LinkPersistInfo((BarItem) this.user_info)
      });
      this.bar1.OptionsBar.AllowQuickCustomization = false;
      this.bar1.OptionsBar.DisableClose = true;
      this.bar1.OptionsBar.DisableCustomization = true;
      this.bar1.OptionsBar.DrawDragBorder = false;
      this.bar1.OptionsBar.RotateWhenVertical = false;
      this.bar1.OptionsBar.UseWholeRow = true;
      this.bar1.Text = "Status";
      this.bar_info.Caption = "bar_info";
      this.bar_info.Id = 17;
      this.bar_info.Name = "bar_info";
      this.bar_info.TextAlignment = StringAlignment.Near;
      this.user_info.Caption = "user_info";
      this.user_info.Id = 18;
      this.user_info.Name = "user_info";
      this.user_info.TextAlignment = StringAlignment.Near;
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = DockStyle.Top;
      this.barDockControlTop.Location = new Point(0, 0);
      this.barDockControlTop.Size = new Size(1215, 22);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 632);
      this.barDockControlBottom.Size = new Size(1215, 25);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 22);
      this.barDockControlLeft.Size = new Size(0, 610);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(1215, 22);
      this.barDockControlRight.Size = new Size(0, 610);
      this.barSubItem4.Caption = "Yazdır";
      this.barSubItem4.Id = 4;
      this.barSubItem4.Name = "barSubItem4";
      this.barSubItem5.Caption = "Çıkış";
      this.barSubItem5.Id = 5;
      this.barSubItem5.Name = "barSubItem5";
      this.barSubItem6.Caption = "Ayarlar";
      this.barSubItem6.Id = 6;
      this.barSubItem6.Name = "barSubItem6";
      this.barSubItem7.Caption = "Kes";
      this.barSubItem7.Id = 7;
      this.barSubItem7.Name = "barSubItem7";
      this.barSubItem8.Caption = "Kopyala";
      this.barSubItem8.Id = 8;
      this.barSubItem8.Name = "barSubItem8";
      this.barSubItem9.Caption = "Yapıştır";
      this.barSubItem9.Id = 9;
      this.barSubItem9.Name = "barSubItem9";
      this.pb_logo.EditValue = (object) Resources.logo03;
      this.pb_logo.Location = new Point(121, (int) byte.MaxValue);
      this.pb_logo.Name = "pb_logo";
      this.pb_logo.Properties.ReadOnly = true;
      this.pb_logo.Properties.ShowMenu = false;
      this.pb_logo.Properties.ShowZoomSubMenu = DefaultBoolean.False;
      this.pb_logo.Size = new Size(256, 56);
      this.pb_logo.TabIndex = 16;
      this.pb_user_logo.Location = new Point(9, 30);
      this.pb_user_logo.Name = "pb_user_logo";
      this.pb_user_logo.Properties.AllowScrollViaMouseDrag = false;
      this.pb_user_logo.Properties.ReadOnly = true;
      this.pb_user_logo.Properties.ShowMenu = false;
      this.pb_user_logo.Properties.SizeMode = PictureSizeMode.Zoom;
      this.pb_user_logo.ShowToolTips = false;
      this.pb_user_logo.Size = new Size(197, 219);
      this.pb_user_logo.TabIndex = 28;
      this.grp1.Controls.Add((Control) this.txt_yetki);
      this.grp1.Controls.Add((Control) this.pb_logo);
      this.grp1.Controls.Add((Control) this.txt_kadi);
      this.grp1.Controls.Add((Control) this.txt_tedarikci);
      this.grp1.Controls.Add((Control) this.txt_eposta);
      this.grp1.Controls.Add((Control) this.txt_unvan);
      this.grp1.Controls.Add((Control) this.txt_soyad);
      this.grp1.Controls.Add((Control) this.txt_ad);
      this.grp1.Controls.Add((Control) this.labelControl4);
      this.grp1.Controls.Add((Control) this.labelControl3);
      this.grp1.Controls.Add((Control) this.labelControl7);
      this.grp1.Controls.Add((Control) this.labelControl6);
      this.grp1.Controls.Add((Control) this.labelControl5);
      this.grp1.Controls.Add((Control) this.labelControl2);
      this.grp1.Controls.Add((Control) this.labelControl1);
      this.grp1.Controls.Add((Control) this.pb_user_logo);
      this.grp1.Dock = DockStyle.Fill;
      this.grp1.Location = new Point(184, 22);
      this.grp1.Name = "grp1";
      this.grp1.Size = new Size(1031, 610);
      this.grp1.TabIndex = 34;
      this.grp1.Text = "Kullanıcı Bilgileri";
      this.txt_yetki.Enabled = false;
      this.txt_yetki.Location = new Point(300, 217);
      this.txt_yetki.Name = "txt_yetki";
      this.txt_yetki.Size = new Size(178, 20);
      this.txt_yetki.TabIndex = 30;
      this.txt_kadi.Enabled = false;
      this.txt_kadi.Location = new Point(300, 186);
      this.txt_kadi.Name = "txt_kadi";
      this.txt_kadi.Size = new Size(178, 20);
      this.txt_kadi.TabIndex = 30;
      this.txt_tedarikci.Enabled = false;
      this.txt_tedarikci.Location = new Point(300, 155);
      this.txt_tedarikci.Name = "txt_tedarikci";
      this.txt_tedarikci.Size = new Size(178, 20);
      this.txt_tedarikci.TabIndex = 30;
      this.txt_eposta.Enabled = false;
      this.txt_eposta.Location = new Point(300, 124);
      this.txt_eposta.Name = "txt_eposta";
      this.txt_eposta.Size = new Size(178, 20);
      this.txt_eposta.TabIndex = 30;
      this.txt_unvan.Enabled = false;
      this.txt_unvan.Location = new Point(300, 93);
      this.txt_unvan.Name = "txt_unvan";
      this.txt_unvan.Size = new Size(178, 20);
      this.txt_unvan.TabIndex = 30;
      this.txt_soyad.Enabled = false;
      this.txt_soyad.Location = new Point(300, 62);
      this.txt_soyad.Name = "txt_soyad";
      this.txt_soyad.Size = new Size(178, 20);
      this.txt_soyad.TabIndex = 30;
      this.txt_ad.Enabled = false;
      this.txt_ad.Location = new Point(300, 31);
      this.txt_ad.MenuManager = (IDXMenuManager) this.bm1;
      this.txt_ad.Name = "txt_ad";
      this.txt_ad.Size = new Size(178, 20);
      this.txt_ad.TabIndex = 30;
      this.labelControl4.Location = new Point(225, 220);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new Size(36, 13);
      this.labelControl4.TabIndex = 29;
      this.labelControl4.Text = "Grubu :";
      this.labelControl3.Location = new Point(224, 189);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new Size(62, 13);
      this.labelControl3.TabIndex = 29;
      this.labelControl3.Text = "Kullanıcı Adı :";
      this.labelControl7.Location = new Point(225, 158);
      this.labelControl7.Name = "labelControl7";
      this.labelControl7.Size = new Size(49, 13);
      this.labelControl7.TabIndex = 29;
      this.labelControl7.Text = "Tedarikçi :";
      this.labelControl6.Location = new Point(225, (int) sbyte.MaxValue);
      this.labelControl6.Name = "labelControl6";
      this.labelControl6.Size = new Size(40, 13);
      this.labelControl6.TabIndex = 29;
      this.labelControl6.Text = "Eposta :";
      this.labelControl5.Location = new Point(224, 96);
      this.labelControl5.Name = "labelControl5";
      this.labelControl5.Size = new Size(40, 13);
      this.labelControl5.TabIndex = 29;
      this.labelControl5.Text = "Ünvanı :";
      this.labelControl2.Location = new Point(225, 65);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new Size(39, 13);
      this.labelControl2.TabIndex = 29;
      this.labelControl2.Text = "Soyadı :";
      this.labelControl1.Location = new Point(225, 34);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new Size(22, 13);
      this.labelControl1.TabIndex = 29;
      this.labelControl1.Text = "Adı :";
      this.xtraTabbedMdiManager1.ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders;
      this.xtraTabbedMdiManager1.MdiParent = (Form) this;
      this.Appearance.BackColor = SystemColors.Control;
      this.Appearance.Options.UseBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.ClientSize = new Size(1215, 657);
      this.Controls.Add((Control) this.grp1);
      this.Controls.Add((Control) this.nbc);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.DoubleBuffered = true;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.IsMdiContainer = true;
      this.Name = nameof (MainMenu);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Dms Bilgisayar Yazılım ve İletişim Sistemleri  San. Tic. Ltd. Şti.";
      this.WindowState = FormWindowState.Maximized;
      this.FormClosed += new FormClosedEventHandler(this.MainMenu_FormClosed);
      this.Load += new EventHandler(this.MainMenu_Load);
      this.nbc.EndInit();
      this.bm1.EndInit();
      this.pb_logo.Properties.EndInit();
      this.pb_user_logo.Properties.EndInit();
      this.grp1.EndInit();
      this.grp1.ResumeLayout(false);
      this.grp1.PerformLayout();
      this.txt_yetki.Properties.EndInit();
      this.txt_kadi.Properties.EndInit();
      this.txt_tedarikci.Properties.EndInit();
      this.txt_eposta.Properties.EndInit();
      this.txt_unvan.Properties.EndInit();
      this.txt_soyad.Properties.EndInit();
      this.txt_ad.Properties.EndInit();
      ((ISupportInitialize) this.xtraTabbedMdiManager1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
