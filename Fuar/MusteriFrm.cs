// Decompiled with JetBrains decompiler
// Type: Fuar.MusteriFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class MusteriFrm : XtraForm
  {
    public string _id = string.Empty;
    private IContainer components;
    private GroupBox groupBox1;
    private MaskedTextBox txt_tel2;
    private MaskedTextBox txt_tel1;
    private TextBox txt_ilce;
    private TextBox txt_il;
    private TextBox txt_yetkili;
    private Label label7;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label1;
    private TextBox txt_ad;
    private Label label2;
    private TextBox txt_kod;
    private SimpleButton btn_iptal;
    private SimpleButton btn_kaydet;
    private ErrorProvider ep1;
    private Label label8;
    private ComboBoxEdit cmb_odeme;
    private TextBox t_ozelkod2;
    private TextBox t_ozelkod1;
    private TextBox t_satiselemani;
    private Label label11;
    private Label label10;
    private Label label9;

    public MusteriFrm() => this.InitializeComponent();

    private void MusteriFrm_Load(object sender, EventArgs e)
    {
      this.cmb_odeme.Properties.Items.Add((object) "P");
      this.cmb_odeme.Properties.Items.Add((object) "A");
      this.cmb_odeme.Properties.Items.Add((object) "B");
      this.cmb_odeme.Properties.Items.Add((object) "C");
      this.cmb_odeme.Properties.Items.Add((object) "F");
      this.cmb_odeme.SelectedIndex = 0;
      if (!(this._id != ""))
        return;
      DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM MUSTERILER WHERE ID = " + this._id);
      if (dataTable.Rows.Count <= 0)
        return;
      this.txt_kod.Text = dataTable.Rows[0]["FIRMAKODU"].ToString();
      this.txt_ad.Text = dataTable.Rows[0]["FIRMAADI"].ToString();
      this.txt_yetkili.Text = dataTable.Rows[0]["YETKILI"].ToString();
      this.txt_tel1.Text = dataTable.Rows[0]["TELEFON1"].ToString();
      this.txt_tel2.Text = dataTable.Rows[0]["TELEFON2"].ToString();
      this.txt_il.Text = dataTable.Rows[0]["IL"].ToString();
      this.txt_ilce.Text = dataTable.Rows[0]["ILCE"].ToString();
      this.t_satiselemani.Text = dataTable.Rows[0]["SATISELEMANI"].ToString();
      this.t_ozelkod1.Text = dataTable.Rows[0]["OZELKOD1"].ToString();
      this.t_ozelkod2.Text = dataTable.Rows[0]["OZELKOD2"].ToString();
      this.cmb_odeme.SelectedItem = (object) dataTable.Rows[0]["ODEMESEKLI"].ToString();
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (!this.alan_kontrol())
        return;
      if (this._id == "")
      {
        if (!this.insert_mus())
          return;
        this.Close();
      }
      else
      {
        if (!this.update_mus())
          return;
        this.Close();
      }
    }

    private bool insert_mus()
    {
      bool flag = false;
      try
      {
        string str = "INSERT INTO MUSTERILER (FIRMAKODU,FIRMAADI,YETKILI,TELEFON1,TELEFON2,IL,ILCE,ODEMESEKLI,SATISELEMANI,OZELKOD1,OZELKOD2) " + "VALUES ('" + this.txt_kod.Text + "','" + this.txt_ad.Text + "','" + this.txt_yetkili.Text + "','" + this.txt_tel1.Text + "','" + this.txt_tel2.Text + "','" + this.txt_il.Text + "','" + this.txt_ilce.Text + "','" + this.cmb_odeme.SelectedItem.ToString() + "','" + this.t_satiselemani.Text + "','" + this.t_ozelkod1.Text + "','" + this.t_ozelkod2.Text + "')";
        using (SqlConnection sqlConnection = new SqlConnection(_main.str_connection))
        {
          sqlConnection.Open();
          SqlCommand command = sqlConnection.CreateCommand();
          command.CommandText = str;
          command.ExecuteNonQuery();
          flag = true;
        }
        return flag;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        return flag;
      }
    }

    private bool update_mus()
    {
      bool flag = false;
      try
      {
        string str = "UPDATE MUSTERILER SET FIRMAKODU = '" + this.txt_kod.Text + "',FIRMAADI = '" + this.txt_ad.Text + "',YETKILI = '" + this.txt_yetkili.Text + "',TELEFON1 = '" + this.txt_tel1.Text + "',TELEFON2 = '" + this.txt_tel2.Text + "',IL = '" + this.txt_il.Text + "',ILCE = '" + this.txt_ilce.Text + "',ODEMESEKLI = '" + this.cmb_odeme.SelectedItem.ToString() + "',SATISELEMANI = '" + this.t_satiselemani.Text + "', OZELKOD1 = '" + this.t_ozelkod1.Text + "', OZELKOD2 = '" + this.t_ozelkod2.Text + "'" + " WHERE ID = " + this._id;
        using (SqlConnection sqlConnection = new SqlConnection(_main.str_connection))
        {
          sqlConnection.Open();
          SqlCommand command = sqlConnection.CreateCommand();
          command.CommandText = str;
          command.ExecuteNonQuery();
          flag = true;
        }
        return flag;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        return flag;
      }
    }

    private bool alan_kontrol()
    {
      bool flag = true;
      if (this.txt_kod.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_kod, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.txt_ad.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_ad, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      return flag;
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
      this.label8 = new Label();
      this.cmb_odeme = new ComboBoxEdit();
      this.txt_tel2 = new MaskedTextBox();
      this.txt_tel1 = new MaskedTextBox();
      this.txt_ilce = new TextBox();
      this.txt_il = new TextBox();
      this.txt_yetkili = new TextBox();
      this.label7 = new Label();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label1 = new Label();
      this.txt_ad = new TextBox();
      this.label2 = new Label();
      this.txt_kod = new TextBox();
      this.btn_iptal = new SimpleButton();
      this.btn_kaydet = new SimpleButton();
      this.ep1 = new ErrorProvider(this.components);
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.t_satiselemani = new TextBox();
      this.t_ozelkod1 = new TextBox();
      this.t_ozelkod2 = new TextBox();
      this.groupBox1.SuspendLayout();
      this.cmb_odeme.Properties.BeginInit();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.t_ozelkod2);
      this.groupBox1.Controls.Add((Control) this.t_ozelkod1);
      this.groupBox1.Controls.Add((Control) this.t_satiselemani);
      this.groupBox1.Controls.Add((Control) this.label11);
      this.groupBox1.Controls.Add((Control) this.label10);
      this.groupBox1.Controls.Add((Control) this.label9);
      this.groupBox1.Controls.Add((Control) this.label8);
      this.groupBox1.Controls.Add((Control) this.cmb_odeme);
      this.groupBox1.Controls.Add((Control) this.txt_tel2);
      this.groupBox1.Controls.Add((Control) this.txt_tel1);
      this.groupBox1.Controls.Add((Control) this.txt_ilce);
      this.groupBox1.Controls.Add((Control) this.txt_il);
      this.groupBox1.Controls.Add((Control) this.txt_yetkili);
      this.groupBox1.Controls.Add((Control) this.label7);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.txt_ad);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.txt_kod);
      this.groupBox1.Location = new Point(24, 24);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(349, 436);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Müşteri Tanımları";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(20, 283);
      this.label8.Name = "label8";
      this.label8.Size = new Size(65, 13);
      this.label8.TabIndex = 11;
      this.label8.Text = "Ödeme Şekli";
      this.cmb_odeme.Location = new Point(111, 280);
      this.cmb_odeme.Name = "cmb_odeme";
      this.cmb_odeme.Properties.AllowNullInput = DefaultBoolean.False;
      this.cmb_odeme.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.cmb_odeme.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
      this.cmb_odeme.Size = new Size(100, 20);
      this.cmb_odeme.TabIndex = 10;
      this.txt_tel2.Location = new Point(111, 180);
      this.txt_tel2.Mask = "(0000) 000 00 00";
      this.txt_tel2.Name = "txt_tel2";
      this.txt_tel2.Size = new Size(100, 21);
      this.txt_tel2.TabIndex = 5;
      this.txt_tel2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.txt_tel1.Location = new Point(111, 146);
      this.txt_tel1.Mask = "(0000) 000 00 00";
      this.txt_tel1.Name = "txt_tel1";
      this.txt_tel1.Size = new Size(100, 21);
      this.txt_tel1.TabIndex = 4;
      this.txt_tel1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
      this.txt_ilce.Location = new Point(111, 248);
      this.txt_ilce.Name = "txt_ilce";
      this.txt_ilce.Size = new Size(196, 21);
      this.txt_ilce.TabIndex = 7;
      this.txt_il.Location = new Point(111, 214);
      this.txt_il.Name = "txt_il";
      this.txt_il.Size = new Size(196, 21);
      this.txt_il.TabIndex = 6;
      this.txt_yetkili.Location = new Point(111, 112);
      this.txt_yetkili.Name = "txt_yetkili";
      this.txt_yetkili.Size = new Size(196, 21);
      this.txt_yetkili.TabIndex = 3;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(20, 251);
      this.label7.Name = "label7";
      this.label7.Size = new Size(24, 13);
      this.label7.TabIndex = 9;
      this.label7.Text = "İlçe";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(20, 217);
      this.label6.Name = "label6";
      this.label6.Size = new Size(13, 13);
      this.label6.TabIndex = 9;
      this.label6.Text = "İl";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(20, 183);
      this.label5.Name = "label5";
      this.label5.Size = new Size(49, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Telefon2";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(20, 149);
      this.label4.Name = "label4";
      this.label4.Size = new Size(49, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Telefon1";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(20, 115);
      this.label3.Name = "label3";
      this.label3.Size = new Size(34, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Yetkili";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(20, 47);
      this.label1.Name = "label1";
      this.label1.Size = new Size(60, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Firma Kodu";
      this.txt_ad.Location = new Point(111, 78);
      this.txt_ad.Name = "txt_ad";
      this.txt_ad.Size = new Size(196, 21);
      this.txt_ad.TabIndex = 2;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(20, 81);
      this.label2.Name = "label2";
      this.label2.Size = new Size(51, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Firma Adı";
      this.txt_kod.Location = new Point(111, 44);
      this.txt_kod.Name = "txt_kod";
      this.txt_kod.Size = new Size(196, 21);
      this.txt_kod.TabIndex = 1;
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(112, 477);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 9;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(24, 477);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 8;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.ep1.ContainerControl = (ContainerControl) this;
      this.label9.AutoSize = true;
      this.label9.Location = new Point(20, 318);
      this.label9.Name = "label9";
      this.label9.Size = new Size(69, 13);
      this.label9.TabIndex = 12;
      this.label9.Text = "Satış Elemanı";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(20, 354);
      this.label10.Name = "label10";
      this.label10.Size = new Size(58, 13);
      this.label10.TabIndex = 13;
      this.label10.Text = "Özel Kod 1";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(20, 393);
      this.label11.Name = "label11";
      this.label11.Size = new Size(58, 13);
      this.label11.TabIndex = 14;
      this.label11.Text = "Özel Kod 2";
      this.t_satiselemani.Location = new Point(111, 315);
      this.t_satiselemani.Name = "t_satiselemani";
      this.t_satiselemani.Size = new Size(196, 21);
      this.t_satiselemani.TabIndex = 15;
      this.t_ozelkod1.Location = new Point(111, 351);
      this.t_ozelkod1.Name = "t_ozelkod1";
      this.t_ozelkod1.Size = new Size(196, 21);
      this.t_ozelkod1.TabIndex = 16;
      this.t_ozelkod2.Location = new Point(111, 390);
      this.t_ozelkod2.Name = "t_ozelkod2";
      this.t_ozelkod2.Size = new Size(196, 21);
      this.t_ozelkod2.TabIndex = 17;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(413, 522);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Name = nameof (MusteriFrm);
      this.ShowIcon = false;
      this.Text = "Müşteri";
      this.Load += new EventHandler(this.MusteriFrm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.cmb_odeme.Properties.EndInit();
      ((ISupportInitialize) this.ep1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
