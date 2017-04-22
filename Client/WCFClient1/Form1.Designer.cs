namespace WCFClient1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btWordCount = new System.Windows.Forms.Button();
            this.btIsPalindrom = new System.Windows.Forms.Button();
            this.btCaesarEncode = new System.Windows.Forms.Button();
            this.txtSentence = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btCaesarDecode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btWordCount
            // 
            this.btWordCount.Location = new System.Drawing.Point(25, 73);
            this.btWordCount.Name = "btWordCount";
            this.btWordCount.Size = new System.Drawing.Size(87, 46);
            this.btWordCount.TabIndex = 0;
            this.btWordCount.Text = "Szavak száma";
            this.btWordCount.UseVisualStyleBackColor = true;
            this.btWordCount.Click += new System.EventHandler(this.btWordCount_Click);
            // 
            // btIsPalindrom
            // 
            this.btIsPalindrom.Location = new System.Drawing.Point(131, 73);
            this.btIsPalindrom.Name = "btIsPalindrom";
            this.btIsPalindrom.Size = new System.Drawing.Size(75, 46);
            this.btIsPalindrom.TabIndex = 1;
            this.btIsPalindrom.Text = "Palindrom?";
            this.btIsPalindrom.UseVisualStyleBackColor = true;
            this.btIsPalindrom.Click += new System.EventHandler(this.btIsPalindrom_Click);
            // 
            // btCaesarEncode
            // 
            this.btCaesarEncode.Location = new System.Drawing.Point(241, 73);
            this.btCaesarEncode.Name = "btCaesarEncode";
            this.btCaesarEncode.Size = new System.Drawing.Size(75, 46);
            this.btCaesarEncode.TabIndex = 2;
            this.btCaesarEncode.Text = "Caesar-kód";
            this.btCaesarEncode.UseVisualStyleBackColor = true;
            this.btCaesarEncode.Click += new System.EventHandler(this.btCaesarEncode_Click);
            // 
            // txtSentence
            // 
            this.txtSentence.Location = new System.Drawing.Point(25, 32);
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(398, 20);
            this.txtSentence.TabIndex = 3;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(25, 137);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(398, 20);
            this.txtOutput.TabIndex = 4;
            // 
            // btCaesarDecode
            // 
            this.btCaesarDecode.Location = new System.Drawing.Point(348, 73);
            this.btCaesarDecode.Name = "btCaesarDecode";
            this.btCaesarDecode.Size = new System.Drawing.Size(75, 46);
            this.btCaesarDecode.TabIndex = 5;
            this.btCaesarDecode.Text = "Caesar-kód visszafejtése";
            this.btCaesarDecode.UseVisualStyleBackColor = true;
            this.btCaesarDecode.Click += new System.EventHandler(this.btCaesarDecode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Adja meg a szöveget:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 196);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCaesarDecode);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtSentence);
            this.Controls.Add(this.btCaesarEncode);
            this.Controls.Add(this.btIsPalindrom);
            this.Controls.Add(this.btWordCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Műveletek szöveggel (Kasza Róbert)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btWordCount;
        private System.Windows.Forms.Button btIsPalindrom;
        private System.Windows.Forms.Button btCaesarEncode;
        private System.Windows.Forms.TextBox txtSentence;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btCaesarDecode;
        private System.Windows.Forms.Label label1;
    }
}

