// Decompiled with JetBrains decompiler
// Type: Fuar.SiparisFrmSimple
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class SiparisFrmSimple : XtraForm
  {
    public string _sipno = string.Empty;
    public static string mus_kod = string.Empty;
    public static string mus_name = string.Empty;
    public static string mus_id = string.Empty;
    public static DataTable dt_musteri = new DataTable();
    public string stat = string.Empty;
    private string s_odeme = "P";
    private IContainer components;
    private GroupBox groupBox1;
    private TextEdit txt_tutar;
    private Label label9;
    private ButtonEdit txt_firmaunvan;
    private ButtonEdit txt_firmakod;
    private Label label4;
    private Label label3;
    private Label label6;
    private Label label5;
    private Label label2;
    private Label label1;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private BarDockControl barDockControlLeft;
    private ErrorProvider ep1;
    private SimpleButton btn_kapat;
    private ButtonEdit txt_firmaid;

    public SiparisFrmSimple() => this.InitializeComponent();

    private void SiparisFrmSimple_Load(object sender, EventArgs e)
    {
      this.get_data();
      if (!(this.stat == "view"))
        return;
      this.txt_firmakod.Enabled = false;
      this.txt_firmaunvan.Enabled = false;
      this.txt_tutar.Enabled = false;
      this.btn_iptal.Visible = false;
      this.btn_kaydet.Visible = false;
      this.btn_kapat.Visible = true;
    }

    private void get_data()
    {
      if (!(this._sipno != ""))
        return;
      DataTable dataTable = _main.komutcalistir_dt("SELECT M.FIRMAKODU, M.FIRMAADI, S.NETTUTAR, M.ID AS MUSID FROM SIPARISLER AS S LEFT OUTER JOIN MUSTERILER AS M ON S.MUSTERIREF = M.ID WHERE S.SIPARISNO = '" + this._sipno + "'");
      if (dataTable.Rows.Count <= 0)
        return;
      this.txt_firmaid.EditValue = dataTable.Rows[0]["MUSID"];
      this.txt_firmakod.EditValue = dataTable.Rows[0]["FIRMAKODU"];
      this.txt_firmaunvan.EditValue = dataTable.Rows[0]["FIRMAADI"];
      this.txt_tutar.EditValue = dataTable.Rows[0]["NETTUTAR"];
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (!this.alankontrol())
        return;
      this.save_data();
      this.Close();
    }

    private void save_data()
    {
      string empty = string.Empty;
      try
      {
        string str1 = !(this.stat == "edit") ? this.get_max_sipno() : this._sipno;
        string str2 = !(_main.dt_user.Rows[0]["KULLANICIADI"].ToString() == "ADMIN") ? _main.dt_user.Rows[0]["TEDARIKCIID"].ToString() : "-1";
        SiparisFrmSimple.mus_id = this.txt_firmaid.Text;
        _main.komutcalistir("DELETE FROM SIPARISLER WHERE SIPARISNO = '" + str1 + "'");
        _main.komutcalistir("INSERT INTO SIPARISLER (SIPARISTARIHI, SIPARISSAATI, SIPARISNO, MUSTERIREF, KULLANICIREF, TEDARIKCIREF, ODEMESEKLI, SATIRTURU, MALZEMEREF, MALZEMEKOD, " + "BIRIM, MIKTAR, BIRIMFIYAT, TUTAR, INDIRIMREF, INDIRIMORANI1, INDIRIMORANI2,TEDIND, INDIRIMTUTARI, NETTUTAR, TESLIMTARIHI, SATIRNO, KDVORANI, KDVTUTARI, ACIKLAMA, SATIRACIKLAMA, ISFAST) " + "VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + str1 + "','" + SiparisFrmSimple.mus_id + "','" + _main.dt_user.Rows[0]["ID"].ToString() + "', " + "'" + str2 + "','" + this.s_odeme + "','Malzeme', '0', '1', 'ADET', '1', '" + this.txt_tutar.EditValue.ToString().Replace(",", ".") + "', " + "'" + this.txt_tutar.EditValue.ToString().Replace(",", ".") + "', '0', '0', '0', " + "'0', '0', '" + this.txt_tutar.EditValue.ToString().Replace(",", ".") + "', " + "'" + DateTime.Now.ToString("yyyy-MM-dd") + "', 1, 0, 0,'','','True')");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void txt_firmakod_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      MusteriSel musteriSel = new MusteriSel();
      musteriSel.s_sender = "fast_sip";
      if (this.txt_firmakod.Text != "")
      {
        musteriSel.s_kod_sel = this.txt_firmakod.Text;
        musteriSel.s_name_sel = "";
      }
      else
      {
        musteriSel.s_kod_sel = "";
        musteriSel.s_name_sel = "";
      }
      if (musteriSel.ShowDialog() != DialogResult.OK || !(SiparisFrmSimple.mus_kod != "") || !(SiparisFrmSimple.mus_id != ""))
        return;
      this.txt_firmakod.Text = SiparisFrmSimple.mus_kod;
      this.txt_firmaunvan.Text = SiparisFrmSimple.mus_name;
      SiparisFrmSimple.dt_musteri = this.get_musteri(this.txt_firmakod.Text);
      if (SiparisFrmSimple.dt_musteri.Rows.Count <= 0)
        return;
      this.s_odeme = SiparisFrmSimple.dt_musteri.Rows[0]["ODEMESEKLI"].ToString();
    }

    private void txt_firmakod_DoubleClick(object sender, EventArgs e)
    {
      this.txt_firmakod_ButtonClick(sender, (ButtonPressedEventArgs) null);
    }

    private DataTable get_musteri(string musterikodu)
    {
      return _main.komutcalistir_dt("SELECT * FROM MUSTERILER WHERE FIRMAKODU = '" + musterikodu + "'");
    }

    private DataTable get_musteri_byid(string musteriid)
    {
      return _main.komutcalistir_dt("SELECT * FROM MUSTERILER WHERE ID = '" + musteriid + "'");
    }

    private bool alankontrol()
    {
      bool flag = true;
      if (this.txt_firmaid.Text == "")
      {
        this.ep1.SetError((Control) this.txt_firmaid, "Müşteri seçilmelidir.");
        return false;
      }
      this.ep1.Clear();
      if (this.txt_tutar.EditValue == null)
      {
        this.ep1.SetError((Control) this.txt_tutar, "Tutar girilmelidir.");
        return false;
      }
      this.ep1.Clear();
      return flag;
    }

    private void txt_firmakod_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.txt_firmakod.Text != "")
      {
        SiparisFrmSimple.dt_musteri = this.get_musteri(this.txt_firmakod.Text);
        if (SiparisFrmSimple.dt_musteri.Rows.Count <= 0)
          return;
        this.txt_firmaunvan.Text = SiparisFrmSimple.dt_musteri.Rows[0]["FIRMAADI"].ToString();
      }
      else
        this.txt_firmaunvan.Text = "";
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

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void txt_firmaid_Validating(object sender, CancelEventArgs e)
    {
      SiparisFrmSimple.dt_musteri = this.get_musteri_byid(this.txt_firmaid.Text);
      if (SiparisFrmSimple.dt_musteri.Rows.Count > 0)
      {
        SiparisFrmSimple.mus_id = this.txt_firmaid.Text;
        this.txt_firmakod.Text = SiparisFrmSimple.dt_musteri.Rows[0]["FIRMAKODU"].ToString();
        this.txt_firmaunvan.Text = SiparisFrmSimple.dt_musteri.Rows[0]["FIRMAADI"].ToString();
        this.s_odeme = SiparisFrmSimple.dt_musteri.Rows[0]["ODEMESEKLI"].ToString();
      }
      else
      {
        this.txt_firmaid.Text = "";
        this.txt_firmakod.Text = "";
        this.txt_firmaunvan.Text = "";
        this.s_odeme = "P";
      }
    }

    private void txt_firmaid_DoubleClick(object sender, EventArgs e)
    {
      this.txt_firmaid_ButtonClick(sender, (ButtonPressedEventArgs) null);
    }

    private void txt_firmaid_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      if (new MusteriSel() { s_sender = "fast_sip" }.ShowDialog() != DialogResult.OK || !(SiparisFrmSimple.mus_kod != "") || !(SiparisFrmSimple.mus_id != ""))
        return;
      this.txt_firmaid.Text = SiparisFrmSimple.mus_id;
      this.txt_firmakod.Text = SiparisFrmSimple.mus_kod;
      this.txt_firmaunvan.Text = SiparisFrmSimple.mus_name;
      SiparisFrmSimple.dt_musteri = this.get_musteri_byid(SiparisFrmSimple.mus_id);
      if (SiparisFrmSimple.dt_musteri.Rows.Count <= 0)
        return;
      this.s_odeme = SiparisFrmSimple.dt_musteri.Rows[0]["ODEMESEKLI"].ToString();
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
      SerializableAppearanceObject appearance1 = new SerializableAppearanceObject();
      SerializableAppearanceObject appearance2 = new SerializableAppearanceObject();
      SerializableAppearanceObject appearance3 = new SerializableAppearanceObject();
      this.groupBox1 = new GroupBox();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.txt_tutar = new TextEdit();
      this.label9 = new Label();
      this.txt_firmaunvan = new ButtonEdit();
      this.txt_firmakod = new ButtonEdit();
      this.label4 = new Label();
      this.label3 = new Label();
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.barDockControlLeft = new BarDockControl();
      this.ep1 = new ErrorProvider(this.components);
      this.btn_kapat = new SimpleButton();
      this.txt_firmaid = new ButtonEdit();
      this.groupBox1.SuspendLayout();
      this.txt_tutar.Properties.BeginInit();
      this.txt_firmaunvan.Properties.BeginInit();
      this.txt_firmakod.Properties.BeginInit();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.txt_firmaid.Properties.BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.txt_firmaid);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.txt_tutar);
      this.groupBox1.Controls.Add((Control) this.label9);
      this.groupBox1.Controls.Add((Control) this.txt_firmaunvan);
      this.groupBox1.Controls.Add((Control) this.txt_firmakod);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(298, 110);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Sipariş Tanımları";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(217, 80);
      this.label6.Name = "label6";
      this.label6.Size = new Size(26, 13);
      this.label6.TabIndex = 28;
      this.label6.Text = ".-TL";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(97, 80);
      this.label5.Name = "label5";
      this.label5.Size = new Size(11, 13);
      this.label5.TabIndex = 27;
      this.label5.Text = ":";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(97, 45);
      this.label2.Name = "label2";
      this.label2.Size = new Size(11, 13);
      this.label2.TabIndex = 26;
      this.label2.Text = ":";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(97, 19);
      this.label1.Name = "label1";
      this.label1.Size = new Size(11, 13);
      this.label1.TabIndex = 25;
      this.label1.Text = ":";
      this.txt_tutar.Location = new Point(108, 77);
      this.txt_tutar.Name = "txt_tutar";
      this.txt_tutar.Properties.AllowNullInput = DefaultBoolean.False;
      this.txt_tutar.Properties.Mask.EditMask = "n2";
      this.txt_tutar.Properties.Mask.MaskType = MaskType.Numeric;
      this.txt_tutar.Properties.Mask.UseMaskAsDisplayFormat = true;
      this.txt_tutar.Properties.NullText = "Giriniz...";
      this.txt_tutar.Properties.ValidateOnEnterKey = true;
      this.txt_tutar.Size = new Size(98, 20);
      this.txt_tutar.TabIndex = 3;
      this.label9.AutoSize = true;
      this.label9.Location = new Point(12, 80);
      this.label9.Name = "label9";
      this.label9.Size = new Size(88, 13);
      this.label9.TabIndex = 23;
      this.label9.Text = "Kdv'siz Net Tutar";
      this.txt_firmaunvan.Location = new Point(108, 42);
      this.txt_firmaunvan.Name = "txt_firmaunvan";
      this.txt_firmaunvan.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Ellipsis, "", -1, true, false, false, ImageLocation.MiddleCenter, (Image) null, new KeyShortcut(Keys.None), (AppearanceObject) appearance1, "", (object) null, (SuperToolTip) null, true)
      });
      this.txt_firmaunvan.Size = new Size(158, 20);
      this.txt_firmaunvan.TabIndex = 1;
      this.txt_firmakod.Location = new Point(249, 77);
      this.txt_firmakod.Name = "txt_firmakod";
      this.txt_firmakod.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Ellipsis, "Seç", -1, true, true, false, ImageLocation.MiddleCenter, (Image) null, new KeyShortcut(Keys.None), (AppearanceObject) appearance2, "", (object) null, (SuperToolTip) null, true)
      });
      this.txt_firmakod.Size = new Size(43, 20);
      this.txt_firmakod.TabIndex = 0;
      this.txt_firmakod.Visible = false;
      this.txt_firmakod.ButtonClick += new ButtonPressedEventHandler(this.txt_firmakod_ButtonClick);
      this.txt_firmakod.DoubleClick += new EventHandler(this.txt_firmakod_DoubleClick);
      this.txt_firmakod.KeyUp += new KeyEventHandler(this.txt_firmakod_KeyUp);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(31, 45);
      this.label4.Name = "label4";
      this.label4.Size = new Size(69, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "Firma Ünvanı";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(31, 19);
      this.label3.Name = "label3";
      this.label3.Size = new Size(60, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Firma Kodu";
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(12, 132);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 4;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(98, 132);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 5;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 177);
      this.ep1.ContainerControl = (ContainerControl) this;
      this.btn_kapat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_kapat.Location = new Point(235, 132);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(75, 33);
      this.btn_kapat.TabIndex = 6;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Visible = false;
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.txt_firmaid.Location = new Point(108, 16);
      this.txt_firmaid.Name = "txt_firmaid";
      this.txt_firmaid.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Ellipsis, "Seç", -1, true, true, false, ImageLocation.MiddleCenter, (Image) null, new KeyShortcut(Keys.None), (AppearanceObject) appearance3, "", (object) null, (SuperToolTip) null, true)
      });
      this.txt_firmaid.Properties.ValidateOnEnterKey = true;
      this.txt_firmaid.Size = new Size(158, 20);
      this.txt_firmaid.TabIndex = 29;
      this.txt_firmaid.ButtonClick += new ButtonPressedEventHandler(this.txt_firmaid_ButtonClick);
      this.txt_firmaid.DoubleClick += new EventHandler(this.txt_firmaid_DoubleClick);
      this.txt_firmaid.Validating += new CancelEventHandler(this.txt_firmaid_Validating);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(331, 177);
      this.Controls.Add((Control) this.btn_kapat);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Name = nameof (SiparisFrmSimple);
      this.ShowIcon = false;
      this.Text = "Hızlı Sipariş Formu";
      this.Load += new EventHandler(this.SiparisFrmSimple_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.txt_tutar.Properties.EndInit();
      this.txt_firmaunvan.Properties.EndInit();
      this.txt_firmakod.Properties.EndInit();
      ((ISupportInitialize) this.ep1).EndInit();
      this.txt_firmaid.Properties.EndInit();
      this.ResumeLayout(false);
    }
  }
}
