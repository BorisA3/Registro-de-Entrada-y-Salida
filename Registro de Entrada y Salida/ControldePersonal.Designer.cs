
namespace Registro_de_Entrada_y_Salida
{
    partial class ControldePersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControldePersonal));
            this.label1 = new System.Windows.Forms.Label();
            this.dgControlPersonal = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgControlPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(190, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control de Personal";
            // 
            // dgControlPersonal
            // 
            this.dgControlPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgControlPersonal.Location = new System.Drawing.Point(12, 127);
            this.dgControlPersonal.Name = "dgControlPersonal";
            this.dgControlPersonal.RowHeadersWidth = 51;
            this.dgControlPersonal.RowTemplate.Height = 29;
            this.dgControlPersonal.Size = new System.Drawing.Size(812, 499);
            this.dgControlPersonal.TabIndex = 1;
            this.dgControlPersonal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgControlPersonal_CellContentClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Transparent;
            this.btnActualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.BackgroundImage")));
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Location = new System.Drawing.Point(779, 75);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(45, 46);
            this.btnActualizar.TabIndex = 34;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // ControldePersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 638);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgControlPersonal);
            this.Controls.Add(this.label1);
            this.Name = "ControldePersonal";
            this.Text = "ControldePersonal";
            this.Load += new System.EventHandler(this.ControldePersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgControlPersonal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgControlPersonal;
        private System.Windows.Forms.Button btnActualizar;
    }
}