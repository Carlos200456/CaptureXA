namespace CaptureXA
{
    partial class CaptureXA
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonFluoro = new System.Windows.Forms.Button();
            this.buttonCine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFluoro
            // 
            this.buttonFluoro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFluoro.Location = new System.Drawing.Point(7, 12);
            this.buttonFluoro.Name = "buttonFluoro";
            this.buttonFluoro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonFluoro.Size = new System.Drawing.Size(89, 39);
            this.buttonFluoro.TabIndex = 55;
            this.buttonFluoro.Text = "Fluoro";
            this.buttonFluoro.UseVisualStyleBackColor = true;
            this.buttonFluoro.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonFLOn_MouseDw);
            this.buttonFluoro.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonFLOn_MouseUp);
            // 
            // buttonCine
            // 
            this.buttonCine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCine.Location = new System.Drawing.Point(104, 12);
            this.buttonCine.Name = "buttonCine";
            this.buttonCine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonCine.Size = new System.Drawing.Size(89, 39);
            this.buttonCine.TabIndex = 56;
            this.buttonCine.Text = "Cine";
            this.buttonCine.UseVisualStyleBackColor = true;
            this.buttonCine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonCine_MouseDw);
            this.buttonCine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonCine_MouseUp);
            // 
            // CaptureXA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 66);
            this.Controls.Add(this.buttonCine);
            this.Controls.Add(this.buttonFluoro);
            this.Location = new System.Drawing.Point(1600, 0);
            this.Name = "CaptureXA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CaptureXA";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CaptureXA_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonFluoro;
        private System.Windows.Forms.Button buttonCine;
    }
}

