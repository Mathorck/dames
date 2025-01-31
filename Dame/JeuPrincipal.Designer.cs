namespace Dame
{
    partial class JeuPrincipal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JeuPrincipal));
            this.pnlDamier = new System.Windows.Forms.Panel();
            this.lbl_Tour = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlDamier
            // 
            this.pnlDamier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlDamier.Location = new System.Drawing.Point(12, 12);
            this.pnlDamier.MaximumSize = new System.Drawing.Size(500, 500);
            this.pnlDamier.Name = "pnlDamier";
            this.pnlDamier.Size = new System.Drawing.Size(500, 500);
            this.pnlDamier.TabIndex = 0;
            // 
            // lbl_Tour
            // 
            this.lbl_Tour.AutoSize = true;
            this.lbl_Tour.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tour.ForeColor = System.Drawing.Color.White;
            this.lbl_Tour.Location = new System.Drawing.Point(12, 515);
            this.lbl_Tour.Name = "lbl_Tour";
            this.lbl_Tour.Size = new System.Drawing.Size(154, 25);
            this.lbl_Tour.TabIndex = 1;
            this.lbl_Tour.Text = "Au tour de blanc";
            // 
            // JeuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(527, 615);
            this.Controls.Add(this.lbl_Tour);
            this.Controls.Add(this.pnlDamier);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JeuPrincipal";
            this.Text = "Dames";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDamier;
        private System.Windows.Forms.Label lbl_Tour;
    }
}

