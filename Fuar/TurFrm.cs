// Decompiled with JetBrains decompiler
// Type: Fuar.TurFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class TurFrm : XtraForm
  {
    public string _id = string.Empty;
    private IContainer components;
    private SimpleButton btn_iptal;
    private SimpleButton btn_kaydet;
    private TextBox txt_kod;
    private Label label1;
    private Label label2;
    private TextBox txt_ad;
    private Label label3;
    private Label label4;
    private TextBox txt_yetkili;
    private Label label5;
    private TextBox txt_eposta;
    private MaskedTextBox txt_tel;
    private GroupBox groupBox1;

    public TurFrm() => this.InitializeComponent();

    private void TurFrm_Load(object sender, EventArgs e)
    {
      if (!(this._id != ""))
        return;
      DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM TURBILGI WHERE ID = " + this._id);
      if (dataTable.Rows.Count <= 0)
        return;
      this.txt_kod.Text = dataTable.Rows[0]["TURKODU"].ToString();
      this.txt_ad.Text = dataTable.Rows[0]["TURADI"].ToString();
      this.txt_tel.Text = dataTable.Rows[0]["TELEFON"].ToString();
      this.txt_yetkili.Text = dataTable.Rows[0]["YETKILI"].ToString();
      this.txt_eposta.Text = dataTable.Rows[0]["EPOSTA"].ToString();
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (this._id == "")
        this.insert_tur();
      else
        this.update_tur();
      this.Close();
    }

    private void insert_tur()
    {
      _main.komutcalistir("INSERT INTO TURBILGI (TURKODU,TURADI,TELEFON,YETKILI,EPOSTA) " + "VALUES ('" + this.txt_kod.Text + "','" + this.txt_ad.Text + "','" + this.txt_tel.Text + "','" + this.txt_yetkili.Text + "','" + this.txt_eposta.Text + "')");
    }

    private void update_tur()
    {
      _main.komutcalistir("UPDATE TURBILGI SET TURKODU = '" + this.txt_kod.Text + "',TURADI = '" + this.txt_ad.Text + "',TELEFON = '" + this.txt_tel.Text + "',YETKILI = '" + this.txt_yetkili.Text + "',EPOSTA = '" + this.txt_eposta.Text + "'" + " WHERE ID = " + this._id);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btn_iptal = new SimpleButton();
      this.btn_kaydet = new SimpleButton();
      this.txt_kod = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.txt_ad = new TextBox();
      this.label3 = new Label();
      this.label4 = new Label();
      this.txt_yetkili = new TextBox();
      this.label5 = new Label();
      this.txt_eposta = new TextBox();
      this.txt_tel = new MaskedTextBox();
      this.groupBox1 = new GroupBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(110, 264);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 7;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(24, 264);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 6;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.txt_kod.Location = new Point(116, 25);
      this.txt_kod.Name = "txt_kod";
      this.txt_kod.Size = new Size(244, 20);
      this.txt_kod.TabIndex = 1;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(22, 28);
      this.label1.Name = "label1";
      this.label1.Size = new Size(83, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Tur Şirketi Kodu";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(22, 68);
      this.label2.Name = "label2";
      this.label2.Size = new Size(73, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "Tur Şirketi Adı";
      this.txt_ad.Location = new Point(116, 65);
      this.txt_ad.Name = "txt_ad";
      this.txt_ad.Size = new Size(244, 20);
      this.txt_ad.TabIndex = 2;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(22, 108);
      this.label3.Name = "label3";
      this.label3.Size = new Size(43, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "Telefon";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(22, 146);
      this.label4.Name = "label4";
      this.label4.Size = new Size(35, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Yetkili";
      this.txt_yetkili.Location = new Point(116, 143);
      this.txt_yetkili.Name = "txt_yetkili";
      this.txt_yetkili.Size = new Size(244, 20);
      this.txt_yetkili.TabIndex = 4;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(22, 183);
      this.label5.Name = "label5";
      this.label5.Size = new Size(43, 13);
      this.label5.TabIndex = 15;
      this.label5.Text = "E-posta";
      this.txt_eposta.CharacterCasing = CharacterCasing.Lower;
      this.txt_eposta.Location = new Point(116, 180);
      this.txt_eposta.Name = "txt_eposta";
      this.txt_eposta.Size = new Size(244, 20);
      this.txt_eposta.TabIndex = 5;
      this.txt_tel.Location = new Point(116, 105);
      this.txt_tel.Mask = "(0000) 000 00 00";
      this.txt_tel.Name = "txt_tel";
      this.txt_tel.Size = new Size(244, 20);
      this.txt_tel.TabIndex = 3;
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.txt_tel);
      this.groupBox1.Controls.Add((Control) this.txt_kod);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.txt_ad);
      this.groupBox1.Controls.Add((Control) this.txt_eposta);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.txt_yetkili);
      this.groupBox1.Location = new Point(24, 23);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(390, 224);
      this.groupBox1.TabIndex = 16;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Tur Şirketi Tanımları";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(442, 309);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.btn_iptal);
      this.Name = nameof (TurFrm);
      this.Text = "Tur Şirketi";
      this.Load += new EventHandler(this.TurFrm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
