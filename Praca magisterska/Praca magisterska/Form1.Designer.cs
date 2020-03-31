namespace Praca_magisterska
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Send_Button = new System.Windows.Forms.Button();
            this.panel_KontrolkaPolaczenieTCP = new System.Windows.Forms.Panel();
            this.textBox_WiadomoscOdSlave = new System.Windows.Forms.TextBox();
            this.WiadomoscOdSlave_Napis = new System.Windows.Forms.Label();
            this.textBox_WiadomoscDoSlave = new System.Windows.Forms.TextBox();
            this.WiadomoscDoSlave_Napis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Send_Button
            // 
            this.Send_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Send_Button.Location = new System.Drawing.Point(775, 38);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(91, 33);
            this.Send_Button.TabIndex = 0;
            this.Send_Button.Text = "Wyslij";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // panel_KontrolkaPolaczenieTCP
            // 
            this.panel_KontrolkaPolaczenieTCP.BackColor = System.Drawing.Color.DarkGray;
            this.panel_KontrolkaPolaczenieTCP.Location = new System.Drawing.Point(775, 89);
            this.panel_KontrolkaPolaczenieTCP.Name = "panel_KontrolkaPolaczenieTCP";
            this.panel_KontrolkaPolaczenieTCP.Size = new System.Drawing.Size(14, 14);
            this.panel_KontrolkaPolaczenieTCP.TabIndex = 1;
            // 
            // textBox_WiadomoscOdSlave
            // 
            this.textBox_WiadomoscOdSlave.Location = new System.Drawing.Point(31, 260);
            this.textBox_WiadomoscOdSlave.Multiline = true;
            this.textBox_WiadomoscOdSlave.Name = "textBox_WiadomoscOdSlave";
            this.textBox_WiadomoscOdSlave.Size = new System.Drawing.Size(229, 105);
            this.textBox_WiadomoscOdSlave.TabIndex = 2;
            // 
            // WiadomoscOdSlave_Napis
            // 
            this.WiadomoscOdSlave_Napis.AutoSize = true;
            this.WiadomoscOdSlave_Napis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WiadomoscOdSlave_Napis.Location = new System.Drawing.Point(27, 213);
            this.WiadomoscOdSlave_Napis.Name = "WiadomoscOdSlave_Napis";
            this.WiadomoscOdSlave_Napis.Size = new System.Drawing.Size(180, 20);
            this.WiadomoscOdSlave_Napis.TabIndex = 3;
            this.WiadomoscOdSlave_Napis.Text = "Wiadomość od Slave:";
            // 
            // textBox_WiadomoscDoSlave
            // 
            this.textBox_WiadomoscDoSlave.Location = new System.Drawing.Point(31, 67);
            this.textBox_WiadomoscDoSlave.Multiline = true;
            this.textBox_WiadomoscDoSlave.Name = "textBox_WiadomoscDoSlave";
            this.textBox_WiadomoscDoSlave.Size = new System.Drawing.Size(229, 105);
            this.textBox_WiadomoscDoSlave.TabIndex = 4;
            // 
            // WiadomoscDoSlave_Napis
            // 
            this.WiadomoscDoSlave_Napis.AutoSize = true;
            this.WiadomoscDoSlave_Napis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WiadomoscDoSlave_Napis.Location = new System.Drawing.Point(27, 26);
            this.WiadomoscDoSlave_Napis.Name = "WiadomoscDoSlave_Napis";
            this.WiadomoscDoSlave_Napis.Size = new System.Drawing.Size(180, 20);
            this.WiadomoscDoSlave_Napis.TabIndex = 5;
            this.WiadomoscDoSlave_Napis.Text = "Wiadomość do Slave:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 524);
            this.Controls.Add(this.WiadomoscDoSlave_Napis);
            this.Controls.Add(this.textBox_WiadomoscDoSlave);
            this.Controls.Add(this.WiadomoscOdSlave_Napis);
            this.Controls.Add(this.textBox_WiadomoscOdSlave);
            this.Controls.Add(this.panel_KontrolkaPolaczenieTCP);
            this.Controls.Add(this.Send_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.Panel panel_KontrolkaPolaczenieTCP;
        private System.Windows.Forms.TextBox textBox_WiadomoscOdSlave;
        private System.Windows.Forms.Label WiadomoscOdSlave_Napis;
        private System.Windows.Forms.TextBox textBox_WiadomoscDoSlave;
        private System.Windows.Forms.Label WiadomoscDoSlave_Napis;
    }
}

