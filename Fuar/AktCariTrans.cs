// Decompiled with JetBrains decompiler
// Type: Fuar.AktCariTrans
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

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
  public class AktCariTrans : XtraForm
  {
    public static string mus_id = string.Empty;
    public static string mus_id_y = string.Empty;
    private IContainer components;
    private ButtonEdit t_firmakod;
    private Label label3;
    private GroupControl groupControl1;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label2;
    private Label label1;
    private TextEdit t_satiselemani;
    private TextEdit t_il;
    private TextEdit t_ilce;
    private TextEdit t_yetkili;
    private TextEdit t_firmaadi;
    private SimpleButton btn_kapat;
    private SimpleButton btn_aktar;
    private GroupControl groupControl2;
    private TextEdit t_satiselemani_y;
    private TextEdit t_il_y;
    private TextEdit t_ilce_y;
    private TextEdit t_yetkili_y;
    private TextEdit t_firmaadi_y;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private ButtonEdit t_firmakod_y;
    private Label label12;

    public AktCariTrans() => this.InitializeComponent();

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void t_firmakod_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      if (new MusteriSel() { s_sender = "cariakt" }.ShowDialog() != DialogResult.OK || !(AktCariTrans.mus_id != ""))
        return;
      DataTable musteri = this.get_musteri(AktCariTrans.mus_id);
      if (musteri.Rows.Count <= 0)
        return;
      this.t_firmakod.Text = musteri.Rows[0]["FIRMAKODU"].ToString();
      this.t_firmaadi.Text = musteri.Rows[0]["FIRMAADI"].ToString();
      this.t_yetkili.Text = musteri.Rows[0]["YETKILI"].ToString();
      this.t_ilce.Text = musteri.Rows[0]["ILCE"].ToString();
      this.t_il.Text = musteri.Rows[0]["IL"].ToString();
      this.t_satiselemani.Text = musteri.Rows[0]["SATISELEMANI"].ToString();
    }

    private void t_firmakod_DoubleClick(object sender, EventArgs e)
    {
      this.t_firmakod_ButtonClick(sender, (ButtonPressedEventArgs) null);
    }

    private DataTable get_musteri(string _musid)
    {
      return _main.komutcalistir_dt("SELECT * FROM MUSTERILER WHERE ID = '" + _musid + "'");
    }

    private void t_firmakod_y_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      if (new MusteriSel() { s_sender = "cariakt_y" }.ShowDialog() != DialogResult.OK || !(AktCariTrans.mus_id_y != ""))
        return;
      DataTable musteri = this.get_musteri(AktCariTrans.mus_id_y);
      if (musteri.Rows.Count <= 0)
        return;
      this.t_firmakod_y.Text = musteri.Rows[0]["FIRMAKODU"].ToString();
      this.t_firmaadi_y.Text = musteri.Rows[0]["FIRMAADI"].ToString();
      this.t_yetkili_y.Text = musteri.Rows[0]["YETKILI"].ToString();
      this.t_ilce_y.Text = musteri.Rows[0]["ILCE"].ToString();
      this.t_il_y.Text = musteri.Rows[0]["IL"].ToString();
      this.t_satiselemani_y.Text = musteri.Rows[0]["SATISELEMANI"].ToString();
    }

    private void t_firmakod_y_DoubleClick(object sender, EventArgs e)
    {
      this.t_firmakod_y_ButtonClick(sender, (ButtonPressedEventArgs) null);
    }

    private void btn_aktar_Click(object sender, EventArgs e)
    {
      if (!this.alankontrol() || MessageBox.Show("Aktarım başlayacaktır, Eminmisiniz?", "Dikkat", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      this.caridegistir(AktCariTrans.mus_id, AktCariTrans.mus_id_y);
      int num = (int) MessageBox.Show("Tamamlandı");
      this.Close();
    }

    private bool alankontrol()
    {
      bool flag = true;
      if (this.t_firmakod.Text == "")
      {
        int num = (int) MessageBox.Show("Eski cari hesap kartı seçilmelidir.");
        flag = false;
      }
      if (this.t_firmakod_y.Text == "")
      {
        int num = (int) MessageBox.Show("Yeni cari hesap kartı seçilmelidir.");
        flag = false;
      }
      return flag;
    }

    private void caridegistir(string _eski_id, string _yeni_id)
    {
      _main.komutcalistir("UPDATE SIPARISLER SET MUSTERIREF = " + _yeni_id + " WHERE MUSTERIREF = " + _eski_id);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.t_firmakod = new ButtonEdit();
      this.label3 = new Label();
      this.groupControl1 = new GroupControl();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.t_firmaadi = new TextEdit();
      this.t_yetkili = new TextEdit();
      this.t_ilce = new TextEdit();
      this.t_il = new TextEdit();
      this.t_satiselemani = new TextEdit();
      this.btn_kapat = new SimpleButton();
      this.btn_aktar = new SimpleButton();
      this.groupControl2 = new GroupControl();
      this.t_satiselemani_y = new TextEdit();
      this.t_il_y = new TextEdit();
      this.t_ilce_y = new TextEdit();
      this.t_yetkili_y = new TextEdit();
      this.t_firmaadi_y = new TextEdit();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.t_firmakod_y = new ButtonEdit();
      this.label12 = new Label();
      this.t_firmakod.Properties.BeginInit();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.t_firmaadi.Properties.BeginInit();
      this.t_yetkili.Properties.BeginInit();
      this.t_ilce.Properties.BeginInit();
      this.t_il.Properties.BeginInit();
      this.t_satiselemani.Properties.BeginInit();
      this.groupControl2.BeginInit();
      this.groupControl2.SuspendLayout();
      this.t_satiselemani_y.Properties.BeginInit();
      this.t_il_y.Properties.BeginInit();
      this.t_ilce_y.Properties.BeginInit();
      this.t_yetkili_y.Properties.BeginInit();
      this.t_firmaadi_y.Properties.BeginInit();
      this.t_firmakod_y.Properties.BeginInit();
      this.SuspendLayout();
      this.t_firmakod.Location = new Point(89, 38);
      this.t_firmakod.Name = "t_firmakod";
      this.t_firmakod.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.t_firmakod.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
      this.t_firmakod.Size = new Size(244, 20);
      this.t_firmakod.TabIndex = 17;
      this.t_firmakod.ButtonClick += new ButtonPressedEventHandler(this.t_firmakod_ButtonClick);
      this.t_firmakod.DoubleClick += new EventHandler(this.t_firmakod_DoubleClick);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(14, 41);
      this.label3.Name = "label3";
      this.label3.Size = new Size(60, 13);
      this.label3.TabIndex = 18;
      this.label3.Text = "Firma Kodu";
      this.groupControl1.Controls.Add((Control) this.t_satiselemani);
      this.groupControl1.Controls.Add((Control) this.t_il);
      this.groupControl1.Controls.Add((Control) this.t_ilce);
      this.groupControl1.Controls.Add((Control) this.t_yetkili);
      this.groupControl1.Controls.Add((Control) this.t_firmaadi);
      this.groupControl1.Controls.Add((Control) this.label6);
      this.groupControl1.Controls.Add((Control) this.label5);
      this.groupControl1.Controls.Add((Control) this.label4);
      this.groupControl1.Controls.Add((Control) this.label2);
      this.groupControl1.Controls.Add((Control) this.label1);
      this.groupControl1.Controls.Add((Control) this.t_firmakod);
      this.groupControl1.Controls.Add((Control) this.label3);
      this.groupControl1.Location = new Point(12, 12);
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(381, 259);
      this.groupControl1.TabIndex = 19;
      this.groupControl1.Text = "Eski Firma Bilgileri";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(14, 77);
      this.label1.Name = "label1";
      this.label1.Size = new Size(51, 13);
      this.label1.TabIndex = 19;
      this.label1.Text = "Firma Adı";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(14, 109);
      this.label2.Name = "label2";
      this.label2.Size = new Size(34, 13);
      this.label2.TabIndex = 20;
      this.label2.Text = "Yetkili";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(14, 141);
      this.label4.Name = "label4";
      this.label4.Size = new Size(24, 13);
      this.label4.TabIndex = 21;
      this.label4.Text = "İlçe";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(14, 173);
      this.label5.Name = "label5";
      this.label5.Size = new Size(13, 13);
      this.label5.TabIndex = 22;
      this.label5.Text = "İl";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(14, 205);
      this.label6.Name = "label6";
      this.label6.Size = new Size(69, 13);
      this.label6.TabIndex = 23;
      this.label6.Text = "Satış Elemanı";
      this.t_firmaadi.Enabled = false;
      this.t_firmaadi.Location = new Point(89, 74);
      this.t_firmaadi.Name = "t_firmaadi";
      this.t_firmaadi.Size = new Size(244, 20);
      this.t_firmaadi.TabIndex = 24;
      this.t_yetkili.Enabled = false;
      this.t_yetkili.Location = new Point(89, 106);
      this.t_yetkili.Name = "t_yetkili";
      this.t_yetkili.Size = new Size(244, 20);
      this.t_yetkili.TabIndex = 25;
      this.t_ilce.Enabled = false;
      this.t_ilce.Location = new Point(89, 138);
      this.t_ilce.Name = "t_ilce";
      this.t_ilce.Size = new Size(244, 20);
      this.t_ilce.TabIndex = 26;
      this.t_il.Enabled = false;
      this.t_il.Location = new Point(89, 170);
      this.t_il.Name = "t_il";
      this.t_il.Size = new Size(244, 20);
      this.t_il.TabIndex = 27;
      this.t_satiselemani.Enabled = false;
      this.t_satiselemani.Location = new Point(89, 202);
      this.t_satiselemani.Name = "t_satiselemani";
      this.t_satiselemani.Size = new Size(244, 20);
      this.t_satiselemani.TabIndex = 28;
      this.btn_kapat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btn_kapat.Location = new Point(767, 464);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(75, 33);
      this.btn_kapat.TabIndex = 36;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.btn_aktar.Location = new Point(306, 295);
      this.btn_aktar.Name = "btn_aktar";
      this.btn_aktar.Size = new Size(257, 33);
      this.btn_aktar.TabIndex = 37;
      this.btn_aktar.Text = ">>>>> Aktar >>>>>";
      this.btn_aktar.Click += new EventHandler(this.btn_aktar_Click);
      this.groupControl2.Controls.Add((Control) this.t_satiselemani_y);
      this.groupControl2.Controls.Add((Control) this.t_il_y);
      this.groupControl2.Controls.Add((Control) this.t_ilce_y);
      this.groupControl2.Controls.Add((Control) this.t_yetkili_y);
      this.groupControl2.Controls.Add((Control) this.t_firmaadi_y);
      this.groupControl2.Controls.Add((Control) this.label7);
      this.groupControl2.Controls.Add((Control) this.label8);
      this.groupControl2.Controls.Add((Control) this.label9);
      this.groupControl2.Controls.Add((Control) this.label10);
      this.groupControl2.Controls.Add((Control) this.label11);
      this.groupControl2.Controls.Add((Control) this.t_firmakod_y);
      this.groupControl2.Controls.Add((Control) this.label12);
      this.groupControl2.Location = new Point(458, 12);
      this.groupControl2.Name = "groupControl2";
      this.groupControl2.Size = new Size(381, 259);
      this.groupControl2.TabIndex = 38;
      this.groupControl2.Text = "Yeni Firma Bilgileri";
      this.t_satiselemani_y.Enabled = false;
      this.t_satiselemani_y.Location = new Point(89, 202);
      this.t_satiselemani_y.Name = "t_satiselemani_y";
      this.t_satiselemani_y.Size = new Size(244, 20);
      this.t_satiselemani_y.TabIndex = 28;
      this.t_il_y.Enabled = false;
      this.t_il_y.Location = new Point(89, 170);
      this.t_il_y.Name = "t_il_y";
      this.t_il_y.Size = new Size(244, 20);
      this.t_il_y.TabIndex = 27;
      this.t_ilce_y.Enabled = false;
      this.t_ilce_y.Location = new Point(89, 138);
      this.t_ilce_y.Name = "t_ilce_y";
      this.t_ilce_y.Size = new Size(244, 20);
      this.t_ilce_y.TabIndex = 26;
      this.t_yetkili_y.Enabled = false;
      this.t_yetkili_y.Location = new Point(89, 106);
      this.t_yetkili_y.Name = "t_yetkili_y";
      this.t_yetkili_y.Size = new Size(244, 20);
      this.t_yetkili_y.TabIndex = 25;
      this.t_firmaadi_y.Enabled = false;
      this.t_firmaadi_y.Location = new Point(89, 74);
      this.t_firmaadi_y.Name = "t_firmaadi_y";
      this.t_firmaadi_y.Size = new Size(244, 20);
      this.t_firmaadi_y.TabIndex = 24;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(14, 205);
      this.label7.Name = "label7";
      this.label7.Size = new Size(69, 13);
      this.label7.TabIndex = 23;
      this.label7.Text = "Satış Elemanı";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(14, 173);
      this.label8.Name = "label8";
      this.label8.Size = new Size(13, 13);
      this.label8.TabIndex = 22;
      this.label8.Text = "İl";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(14, 141);
      this.label9.Name = "label9";
      this.label9.Size = new Size(24, 13);
      this.label9.TabIndex = 21;
      this.label9.Text = "İlçe";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(14, 109);
      this.label10.Name = "label10";
      this.label10.Size = new Size(34, 13);
      this.label10.TabIndex = 20;
      this.label10.Text = "Yetkili";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(14, 77);
      this.label11.Name = "label11";
      this.label11.Size = new Size(51, 13);
      this.label11.TabIndex = 19;
      this.label11.Text = "Firma Adı";
      this.t_firmakod_y.Location = new Point(89, 38);
      this.t_firmakod_y.Name = "t_firmakod_y";
      this.t_firmakod_y.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.t_firmakod_y.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
      this.t_firmakod_y.Size = new Size(244, 20);
      this.t_firmakod_y.TabIndex = 17;
      this.t_firmakod_y.ButtonClick += new ButtonPressedEventHandler(this.t_firmakod_y_ButtonClick);
      this.t_firmakod_y.DoubleClick += new EventHandler(this.t_firmakod_y_DoubleClick);
      this.label12.AutoSize = true;
      this.label12.Location = new Point(14, 41);
      this.label12.Name = "label12";
      this.label12.Size = new Size(60, 13);
      this.label12.TabIndex = 18;
      this.label12.Text = "Firma Kodu";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(869, 518);
      this.Controls.Add((Control) this.groupControl2);
      this.Controls.Add((Control) this.btn_aktar);
      this.Controls.Add((Control) this.btn_kapat);
      this.Controls.Add((Control) this.groupControl1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AktCariTrans);
      this.ShowIcon = false;
      this.Text = "Sipariş Cari Hesap Tranfer İşlemi";
      this.t_firmakod.Properties.EndInit();
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      this.t_firmaadi.Properties.EndInit();
      this.t_yetkili.Properties.EndInit();
      this.t_ilce.Properties.EndInit();
      this.t_il.Properties.EndInit();
      this.t_satiselemani.Properties.EndInit();
      this.groupControl2.EndInit();
      this.groupControl2.ResumeLayout(false);
      this.groupControl2.PerformLayout();
      this.t_satiselemani_y.Properties.EndInit();
      this.t_il_y.Properties.EndInit();
      this.t_ilce_y.Properties.EndInit();
      this.t_yetkili_y.Properties.EndInit();
      this.t_firmaadi_y.Properties.EndInit();
      this.t_firmakod_y.Properties.EndInit();
      this.ResumeLayout(false);
    }
  }
}
