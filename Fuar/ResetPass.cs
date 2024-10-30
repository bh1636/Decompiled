// Decompiled with JetBrains decompiler
// Type: Fuar.ResetPass
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class ResetPass : XtraForm
  {
    private IContainer components;
    private TextBox txt_mail;
    private SimpleButton btn_reset;
    private Label label1;

    public ResetPass() => this.InitializeComponent();

    private void btn_reset_Click(object sender, EventArgs e)
    {
      if (this.isEmail(this.txt_mail.Text))
      {
        DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM KULLANICILAR WHERE EPOSTA = '" + this.txt_mail.Text + "'");
        if (dataTable.Rows.Count > 0)
        {
          if (!_main.mail_gonder_simple(this.txt_mail.Text, "Parola Hatırlatma", "Merhaba " + dataTable.Rows[0]["ADI"] + " " + dataTable.Rows[0]["SOYADI"] + "\nFuar sistemine giriş için gerekli bilgileriniz aşağıdadır.\n\nKullanıcı Adınız : " + dataTable.Rows[0]["KULLANICIADI"] + "\nŞifreniz : " + _main.Decrypt(dataTable.Rows[0]["SIFRE"].ToString(), "951623")))
            return;
          int num = (int) MessageBox.Show("Belirtmiş olduğunuz mail adrresine gerekli bilgiler gönderilmiştir.");
          this.Close();
        }
        else
        {
          int num1 = (int) MessageBox.Show("Girmiş olduğunuz mail adresi sistemde kayıtlı görünmüyor.");
        }
      }
      else
      {
        int num2 = (int) MessageBox.Show("Girmiş olduğunuz mail adresi geçerli görünmüyor.");
      }
    }

    private bool isEmail(string inputEmail)
    {
      return new Regex("^[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}$", RegexOptions.IgnoreCase).IsMatch(inputEmail);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.txt_mail = new TextBox();
      this.btn_reset = new SimpleButton();
      this.label1 = new Label();
      this.SuspendLayout();
      this.txt_mail.Font = new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txt_mail.Location = new Point(19, 58);
      this.txt_mail.Name = "txt_mail";
      this.txt_mail.Size = new Size(365, 26);
      this.txt_mail.TabIndex = 0;
      this.btn_reset.Font = new Font("Courier New", 12f, FontStyle.Bold);
      this.btn_reset.Location = new Point(87, 100);
      this.btn_reset.Name = "btn_reset";
      this.btn_reset.Size = new Size(209, 42);
      this.btn_reset.TabIndex = 1;
      this.btn_reset.Text = "Şifremi Gönder";
      this.btn_reset.Click += new EventHandler(this.btn_reset_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label1.Location = new Point(16, 27);
      this.label1.Name = "label1";
      this.label1.Size = new Size(368, 18);
      this.label1.TabIndex = 2;
      this.label1.Text = "Geçerli mail adresinizi giriniz ....";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(400, 181);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.btn_reset);
      this.Controls.Add((Control) this.txt_mail);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ResetPass);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Şifre Hatırlatma";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
