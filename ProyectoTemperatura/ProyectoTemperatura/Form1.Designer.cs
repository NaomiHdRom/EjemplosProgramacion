namespace ProyectoTemperatura
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PictureBox pbMechero;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            txtbRangoSup = new TextBox();
            txtbRangoInf = new TextBox();
            label3 = new Label();
            label4 = new Label();
            btnStop = new Button();
            fuego = new PictureBox();
            txtAlgo = new TextBox();
            alerta = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            pbMechero = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbMechero).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fuego).BeginInit();
            SuspendLayout();
            // 
            // pbMechero
            // 
            pbMechero.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pbMechero.Enabled = false;
            pbMechero.Image = (Image)resources.GetObject("pbMechero.Image");
            pbMechero.Location = new Point(-79, 328);
            pbMechero.Margin = new Padding(2, 3, 3, 3);
            pbMechero.Name = "pbMechero";
            pbMechero.Size = new Size(330, 258);
            pbMechero.SizeMode = PictureBoxSizeMode.Zoom;
            pbMechero.TabIndex = 2;
            pbMechero.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(264, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(683, 374);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 255, 128);
            button1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(756, 443);
            button1.Name = "button1";
            button1.Size = new Size(140, 52);
            button1.TabIndex = 1;
            button1.Text = "INICIAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(294, 450);
            label1.Name = "label1";
            label1.Size = new Size(289, 29);
            label1.TabIndex = 3;
            label1.Text = "Ingrese el rango superior:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(294, 507);
            label2.Name = "label2";
            label2.Size = new Size(275, 29);
            label2.TabIndex = 4;
            label2.Text = "Ingrese el rango inferior:";
            // 
            // txtbRangoSup
            // 
            txtbRangoSup.Location = new Point(585, 454);
            txtbRangoSup.Name = "txtbRangoSup";
            txtbRangoSup.Size = new Size(48, 27);
            txtbRangoSup.TabIndex = 5;
            txtbRangoSup.TextChanged += txtbRangoSup_TextChanged;
            txtbRangoSup.KeyPress += txtbRangoSup_KeyPress;
            // 
            // txtbRangoInf
            // 
            txtbRangoInf.Location = new Point(585, 511);
            txtbRangoInf.Name = "txtbRangoInf";
            txtbRangoInf.Size = new Size(48, 27);
            txtbRangoInf.TabIndex = 6;
            txtbRangoInf.TextChanged += txtbRangoInf_TextChanged;
            txtbRangoInf.KeyPress += txtbRangoInf_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(639, 461);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 7;
            label3.Text = "°C";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(639, 518);
            label4.Name = "label4";
            label4.Size = new Size(24, 20);
            label4.TabIndex = 8;
            label4.Text = "°C";
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.IndianRed;
            btnStop.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnStop.Location = new Point(756, 501);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(140, 51);
            btnStop.TabIndex = 9;
            btnStop.Text = "DETENER";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // fuego
            // 
            fuego.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            fuego.Image = (Image)resources.GetObject("fuego.Image");
            fuego.Location = new Point(12, 178);
            fuego.Name = "fuego";
            fuego.Size = new Size(125, 143);
            fuego.SizeMode = PictureBoxSizeMode.Zoom;
            fuego.TabIndex = 11;
            fuego.TabStop = false;
            fuego.Visible = false;
            // 
            // txtAlgo
            // 
            txtAlgo.Location = new Point(738, 7);
            txtAlgo.Name = "txtAlgo";
            txtAlgo.Size = new Size(209, 27);
            txtAlgo.TabIndex = 12;
            txtAlgo.Tag = "";
            // 
            // alerta
            // 
            alerta.AutoSize = true;
            alerta.Font = new Font("Swis721 Blk BT", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            alerta.Location = new Point(24, 40);
            alerta.MaximumSize = new Size(230, 230);
            alerta.Name = "alerta";
            alerta.Size = new Size(69, 21);
            alerta.TabIndex = 13;
            alerta.Text = "Alerta";
            alerta.Visible = false;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(983, 598);
            Controls.Add(alerta);
            Controls.Add(txtAlgo);
            Controls.Add(fuego);
            Controls.Add(btnStop);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtbRangoInf);
            Controls.Add(txtbRangoSup);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pbMechero);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbMechero).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fuego).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private PictureBox pbMechero;
        private Label label1;
        private Label label2;
        private TextBox txtbRangoSup;
        private TextBox txtbRangoInf;
        private Label label3;
        private Label label4;
        private Button btnStop;
        private PictureBox fuego;
        private TextBox txtAlgo;
        private Label alerta;
        private System.Windows.Forms.Timer timer1;
    }
}