// Decompiled with JetBrains decompiler
// Type: Yönetim.frmSifre
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Yönetim
{
  public class frmSifre : Form
  {
    private IContainer components = (IContainer) null;
    private Button button1;
    public TextBox textBox1;

    public frmSifre() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.textBox1 = new TextBox();
      this.button1 = new Button();
      this.SuspendLayout();
      this.textBox1.Location = new Point(44, 26);
      this.textBox1.Margin = new Padding(6, 6, 6, 6);
      this.textBox1.Name = "textBox1";
      this.textBox1.PasswordChar = '*';
      this.textBox1.Size = new Size(165, 29);
      this.textBox1.TabIndex = 0;
      this.button1.Location = new Point(44, 64);
      this.button1.Name = "button1";
      this.button1.Size = new Size(165, 34);
      this.button1.TabIndex = 1;
      this.button1.Text = "Giriş";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(12f, 24f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(248, 117);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox1);
      this.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.Margin = new Padding(6, 6, 6, 6);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmSifre);
      this.Text = "Şifre";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
