// Decompiled with JetBrains decompiler
// Type: Fuar.FuarFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class FuarFrm : XtraForm
  {
    public string _id = string.Empty;
    private IContainer components;
    private MaskedTextBox txt_tel;
    private Label label5;
    private TextBox txt_eposta;
    private Label label4;
    private TextBox txt_ilgili;
    private Label label3;
    private Label label2;
    private TextBox txt_yer;
    private Label label1;
    private TextBox txt_ad;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private DateEdit date_bas;
    private DateEdit date_bit;
    private Label label6;
    private Label label7;
    private GroupBox groupBox1;
    private CheckEdit chk_aktif;
    private ErrorProvider ep1;

    public FuarFrm() => this.InitializeComponent();

    private void FuarFrm_Load(object sender, EventArgs e)
    {
      if (!(this._id != ""))
        return;
      DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM FUARLAR WHERE ID = " + this._id);
      if (dataTable.Rows.Count <= 0)
        return;
      this.txt_ad.Text = dataTable.Rows[0]["FUARADI"].ToString();
      this.txt_yer.Text = dataTable.Rows[0]["FUARYERI"].ToString();
      this.txt_tel.Text = dataTable.Rows[0]["TELEFON"].ToString();
      this.txt_ilgili.Text = dataTable.Rows[0]["ILGILI"].ToString();
      this.txt_eposta.Text = dataTable.Rows[0]["EPOSTA"].ToString();
      bool result;
      if (bool.TryParse(dataTable.Rows[0]["AKTIF"].ToString(), out result))
        this.chk_aktif.Checked = result;
      this.date_bas.DateTime = Convert.ToDateTime(dataTable.Rows[0]["BASLANGICTARIHI"]);
      this.date_bit.DateTime = Convert.ToDateTime(dataTable.Rows[0]["BITISTARIHI"]);
    }

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (!this.alan_kontrol())
        return;
      if (this._id == "")
        this.insert_fuar();
      else
        this.update_fuar();
      this.Close();
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void insert_fuar()
    {
      if (this.chk_aktif.Checked)
        _main.komutcalistir("UPDATE FUARLAR SET AKTIF = 0");
      _main.komutcalistir("INSERT INTO FUARLAR (FUARADI,FUARYERI,BASLANGICTARIHI,BITISTARIHI,ILGILI,TELEFON,EPOSTA,AKTIF) " + "VALUES ('" + this.txt_ad.Text + "','" + this.txt_yer.Text + "','" + this.date_bas.DateTime.ToString("s") + "','" + this.date_bit.DateTime.ToString("s") + "','" + this.txt_ilgili.Text + "','" + this.txt_tel.Text + "','" + this.txt_eposta.Text + "','" + (object) this.chk_aktif.Checked + "')");
    }

    private void update_fuar()
    {
      if (this.chk_aktif.Checked)
        _main.komutcalistir("UPDATE FUARLAR SET AKTIF = 0");
      _main.komutcalistir("UPDATE FUARLAR SET FUARADI = '" + this.txt_ad.Text + "',FUARYERI = '" + this.txt_yer.Text + "',BASLANGICTARIHI = '" + this.date_bas.DateTime.ToString("s") + "',BITISTARIHI = '" + this.date_bit.DateTime.ToString("s") + "',ILGILI = '" + this.txt_ilgili.Text + "',TELEFON = '" + this.txt_tel.Text + "',EPOSTA = '" + this.txt_eposta.Text + "',AKTIF = '" + (object) this.chk_aktif.Checked + "'" + " WHERE ID = " + this._id);
    }

    private bool alan_kontrol()
    {
      if (this.txt_ad.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_ad, "Alan Boş olamaz!");
        return false;
      }
      this.ep1.Clear();
      if (this.date_bas.EditValue == null)
      {
        this.ep1.SetError((Control) this.date_bas, "Başlangıç tarihi belirtiniz!");
        return false;
      }
      this.ep1.Clear();
      if (this.date_bit.EditValue == null)
      {
        this.ep1.SetError((Control) this.date_bit, "Bitiş tarihi belirtiniz!");
        return false;
      }
      this.ep1.Clear();
      return true;
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
      this.txt_tel = new MaskedTextBox();
      this.label5 = new Label();
      this.txt_eposta = new TextBox();
      this.label4 = new Label();
      this.txt_ilgili = new TextBox();
      this.label3 = new Label();
      this.label2 = new Label();
      this.txt_yer = new TextBox();
      this.label1 = new Label();
      this.txt_ad = new TextBox();
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.date_bas = new DateEdit();
      this.date_bit = new DateEdit();
      this.label6 = new Label();
      this.label7 = new Label();
      this.groupBox1 = new GroupBox();
      this.chk_aktif = new CheckEdit();
      this.ep1 = new ErrorProvider(this.components);
      this.date_bas.Properties.VistaTimeProperties.BeginInit();
      this.date_bas.Properties.BeginInit();
      this.date_bit.Properties.VistaTimeProperties.BeginInit();
      this.date_bit.Properties.BeginInit();
      this.groupBox1.SuspendLayout();
      this.chk_aktif.Properties.BeginInit();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.SuspendLayout();
      this.txt_tel.Location = new Point(121, 194);
      this.txt_tel.Mask = "(0000) 000 00 00";
      this.txt_tel.Name = "txt_tel";
      this.txt_tel.Size = new Size(244, 21);
      this.txt_tel.TabIndex = 18;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(27, 272);
      this.label5.Name = "label5";
      this.label5.Size = new Size(44, 13);
      this.label5.TabIndex = 27;
      this.label5.Text = "E-posta";
      this.txt_eposta.CharacterCasing = CharacterCasing.Lower;
      this.txt_eposta.Location = new Point(121, 269);
      this.txt_eposta.Name = "txt_eposta";
      this.txt_eposta.Size = new Size(244, 21);
      this.txt_eposta.TabIndex = 20;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(27, 235);
      this.label4.Name = "label4";
      this.label4.Size = new Size(25, 13);
      this.label4.TabIndex = 26;
      this.label4.Text = "İlgili";
      this.txt_ilgili.Location = new Point(121, 232);
      this.txt_ilgili.Name = "txt_ilgili";
      this.txt_ilgili.Size = new Size(244, 21);
      this.txt_ilgili.TabIndex = 19;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(27, 197);
      this.label3.Name = "label3";
      this.label3.Size = new Size(43, 13);
      this.label3.TabIndex = 25;
      this.label3.Text = "Telefon";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(27, 80);
      this.label2.Name = "label2";
      this.label2.Size = new Size(50, 13);
      this.label2.TabIndex = 24;
      this.label2.Text = "Fuar Yeri";
      this.txt_yer.Location = new Point(121, 77);
      this.txt_yer.Name = "txt_yer";
      this.txt_yer.Size = new Size(244, 21);
      this.txt_yer.TabIndex = 17;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(27, 40);
      this.label1.Name = "label1";
      this.label1.Size = new Size(47, 13);
      this.label1.TabIndex = 22;
      this.label1.Text = "Fuar Adı";
      this.txt_ad.Location = new Point(121, 37);
      this.txt_ad.Name = "txt_ad";
      this.txt_ad.Size = new Size(244, 21);
      this.txt_ad.TabIndex = 16;
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(24, 365);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 21;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(110, 365);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 23;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.date_bas.EditValue = (object) null;
      this.date_bas.Location = new Point(121, 117);
      this.date_bas.Name = "date_bas";
      this.date_bas.Properties.AllowNullInput = DefaultBoolean.False;
      this.date_bas.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.date_bas.Properties.MaxValue = new DateTime(2100, 12, 31, 0, 0, 0, 0);
      this.date_bas.Properties.MinValue = new DateTime(2000, 1, 1, 0, 0, 0, 0);
      this.date_bas.Properties.NullValuePrompt = "Tarih Seçiniz...";
      this.date_bas.Properties.NullValuePromptShowForEmptyValue = true;
      this.date_bas.Properties.VistaTimeProperties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.date_bas.Size = new Size(100, 20);
      this.date_bas.TabIndex = 28;
      this.date_bit.EditValue = (object) null;
      this.date_bit.Location = new Point(121, 157);
      this.date_bit.Name = "date_bit";
      this.date_bit.Properties.AllowNullInput = DefaultBoolean.False;
      this.date_bit.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.date_bit.Properties.NullValuePrompt = "Tarih Seçiniz...";
      this.date_bit.Properties.NullValuePromptShowForEmptyValue = true;
      this.date_bit.Properties.VistaTimeProperties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.date_bit.Size = new Size(100, 20);
      this.date_bit.TabIndex = 29;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(27, 120);
      this.label6.Name = "label6";
      this.label6.Size = new Size(80, 13);
      this.label6.TabIndex = 30;
      this.label6.Text = "Başlangıç Tarihi";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(27, 160);
      this.label7.Name = "label7";
      this.label7.Size = new Size(55, 13);
      this.label7.TabIndex = 31;
      this.label7.Text = "Bitiş Tarihi";
      this.groupBox1.Controls.Add((Control) this.chk_aktif);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.label7);
      this.groupBox1.Controls.Add((Control) this.txt_ad);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.txt_yer);
      this.groupBox1.Controls.Add((Control) this.date_bit);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.date_bas);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.txt_tel);
      this.groupBox1.Controls.Add((Control) this.txt_ilgili);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.txt_eposta);
      this.groupBox1.Location = new Point(24, 22);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(396, 335);
      this.groupBox1.TabIndex = 32;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Fuar Tanımları";
      this.chk_aktif.Location = new Point(119, 303);
      this.chk_aktif.Name = "chk_aktif";
      this.chk_aktif.Properties.Caption = "Varsalıyan fuar olarak işaretle";
      this.chk_aktif.Size = new Size(246, 19);
      this.chk_aktif.TabIndex = 33;
      this.ep1.ContainerControl = (ContainerControl) this;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(452, 410);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.btn_iptal);
      this.MinimizeBox = false;
      this.Name = nameof (FuarFrm);
      this.Text = "Fuar";
      this.Load += new EventHandler(this.FuarFrm_Load);
      this.date_bas.Properties.VistaTimeProperties.EndInit();
      this.date_bas.Properties.EndInit();
      this.date_bit.Properties.VistaTimeProperties.EndInit();
      this.date_bit.Properties.EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.chk_aktif.Properties.EndInit();
      ((ISupportInitialize) this.ep1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
