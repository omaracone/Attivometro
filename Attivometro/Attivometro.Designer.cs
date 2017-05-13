namespace Attivometro
{
    partial class Attivometro
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
            this.buttonCalcolaAttivi = new System.Windows.Forms.Button();
            this.dateUltimaDataCalcoloAttivi = new System.Windows.Forms.DateTimePicker();
            this.labelUltimaDataCalcoloAttivi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataRisultatoCalcolo = new System.Windows.Forms.DataGridView();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attivita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataAttiviAllaData = new System.Windows.Forms.DataGridView();
            this.NomeAllaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttivitaAllaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataMenoDiOtto = new System.Windows.Forms.DataGridView();
            this.NomeMenoDiOtto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttivitaMenoDiOtto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEsporta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataRisultatoCalcolo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAttiviAllaData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMenoDiOtto)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCalcolaAttivi
            // 
            this.buttonCalcolaAttivi.Location = new System.Drawing.Point(534, 20);
            this.buttonCalcolaAttivi.Name = "buttonCalcolaAttivi";
            this.buttonCalcolaAttivi.Size = new System.Drawing.Size(130, 42);
            this.buttonCalcolaAttivi.TabIndex = 0;
            this.buttonCalcolaAttivi.Text = "Calcola";
            this.buttonCalcolaAttivi.UseVisualStyleBackColor = true;
            this.buttonCalcolaAttivi.Click += new System.EventHandler(this.buttonCalcolaAttivi_Click);
            // 
            // dateUltimaDataCalcoloAttivi
            // 
            this.dateUltimaDataCalcoloAttivi.Location = new System.Drawing.Point(48, 40);
            this.dateUltimaDataCalcoloAttivi.Name = "dateUltimaDataCalcoloAttivi";
            this.dateUltimaDataCalcoloAttivi.Size = new System.Drawing.Size(200, 22);
            this.dateUltimaDataCalcoloAttivi.TabIndex = 1;
            // 
            // labelUltimaDataCalcoloAttivi
            // 
            this.labelUltimaDataCalcoloAttivi.AutoSize = true;
            this.labelUltimaDataCalcoloAttivi.Location = new System.Drawing.Point(33, 20);
            this.labelUltimaDataCalcoloAttivi.Name = "labelUltimaDataCalcoloAttivi";
            this.labelUltimaDataCalcoloAttivi.Size = new System.Drawing.Size(233, 17);
            this.labelUltimaDataCalcoloAttivi.TabIndex = 2;
            this.labelUltimaDataCalcoloAttivi.Text = "Data Ultimo Calcolo della Lista Attivi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lista Attivi alla Data:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(313, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dataRisultatoCalcolo
            // 
            this.dataRisultatoCalcolo.AllowUserToAddRows = false;
            this.dataRisultatoCalcolo.AllowUserToDeleteRows = false;
            this.dataRisultatoCalcolo.AllowUserToOrderColumns = true;
            this.dataRisultatoCalcolo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRisultatoCalcolo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nome,
            this.Attivita});
            this.dataRisultatoCalcolo.Location = new System.Drawing.Point(36, 124);
            this.dataRisultatoCalcolo.Name = "dataRisultatoCalcolo";
            this.dataRisultatoCalcolo.ReadOnly = true;
            this.dataRisultatoCalcolo.RowTemplate.Height = 24;
            this.dataRisultatoCalcolo.Size = new System.Drawing.Size(351, 435);
            this.dataRisultatoCalcolo.TabIndex = 5;
            this.dataRisultatoCalcolo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataRisultatoCalcolo_CellContentClick);
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Attivita
            // 
            this.Attivita.HeaderText = "Attività";
            this.Attivita.Name = "Attivita";
            this.Attivita.ReadOnly = true;
            // 
            // dataAttiviAllaData
            // 
            this.dataAttiviAllaData.AllowUserToAddRows = false;
            this.dataAttiviAllaData.AllowUserToDeleteRows = false;
            this.dataAttiviAllaData.AllowUserToOrderColumns = true;
            this.dataAttiviAllaData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAttiviAllaData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomeAllaData,
            this.AttivitaAllaData});
            this.dataAttiviAllaData.Location = new System.Drawing.Point(433, 124);
            this.dataAttiviAllaData.Name = "dataAttiviAllaData";
            this.dataAttiviAllaData.ReadOnly = true;
            this.dataAttiviAllaData.RowTemplate.Height = 24;
            this.dataAttiviAllaData.Size = new System.Drawing.Size(351, 435);
            this.dataAttiviAllaData.TabIndex = 6;
            // 
            // NomeAllaData
            // 
            this.NomeAllaData.HeaderText = "Nome";
            this.NomeAllaData.Name = "NomeAllaData";
            this.NomeAllaData.ReadOnly = true;
            // 
            // AttivitaAllaData
            // 
            this.AttivitaAllaData.HeaderText = "Attività";
            this.AttivitaAllaData.Name = "AttivitaAllaData";
            this.AttivitaAllaData.ReadOnly = true;
            // 
            // dataMenoDiOtto
            // 
            this.dataMenoDiOtto.AllowUserToAddRows = false;
            this.dataMenoDiOtto.AllowUserToDeleteRows = false;
            this.dataMenoDiOtto.AllowUserToOrderColumns = true;
            this.dataMenoDiOtto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMenoDiOtto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomeMenoDiOtto,
            this.AttivitaMenoDiOtto});
            this.dataMenoDiOtto.Location = new System.Drawing.Point(831, 124);
            this.dataMenoDiOtto.Name = "dataMenoDiOtto";
            this.dataMenoDiOtto.ReadOnly = true;
            this.dataMenoDiOtto.RowTemplate.Height = 24;
            this.dataMenoDiOtto.Size = new System.Drawing.Size(351, 435);
            this.dataMenoDiOtto.TabIndex = 7;
            // 
            // NomeMenoDiOtto
            // 
            this.NomeMenoDiOtto.HeaderText = "Nome";
            this.NomeMenoDiOtto.Name = "NomeMenoDiOtto";
            this.NomeMenoDiOtto.ReadOnly = true;
            // 
            // AttivitaMenoDiOtto
            // 
            this.AttivitaMenoDiOtto.HeaderText = "Attività";
            this.AttivitaMenoDiOtto.Name = "AttivitaMenoDiOtto";
            this.AttivitaMenoDiOtto.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Con 8 Attività Nei 4 Mesi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hanno già fatto 8 attività alla data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(844, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Meno di 8 attività alla data";
            // 
            // buttonEsporta
            // 
            this.buttonEsporta.Location = new System.Drawing.Point(1052, 20);
            this.buttonEsporta.Name = "buttonEsporta";
            this.buttonEsporta.Size = new System.Drawing.Size(130, 42);
            this.buttonEsporta.TabIndex = 11;
            this.buttonEsporta.Text = "Esporta";
            this.buttonEsporta.UseVisualStyleBackColor = true;
            this.buttonEsporta.Click += new System.EventHandler(this.buttonEsporta_Click);
            // 
            // Attivometro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 588);
            this.Controls.Add(this.buttonEsporta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataMenoDiOtto);
            this.Controls.Add(this.dataAttiviAllaData);
            this.Controls.Add(this.dataRisultatoCalcolo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelUltimaDataCalcoloAttivi);
            this.Controls.Add(this.dateUltimaDataCalcoloAttivi);
            this.Controls.Add(this.buttonCalcolaAttivi);
            this.Name = "Attivometro";
            this.Text = "Attivometro";
            ((System.ComponentModel.ISupportInitialize)(this.dataRisultatoCalcolo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAttiviAllaData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMenoDiOtto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCalcolaAttivi;
        private System.Windows.Forms.DateTimePicker dateUltimaDataCalcoloAttivi;
        private System.Windows.Forms.Label labelUltimaDataCalcoloAttivi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataRisultatoCalcolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attivita;
        private System.Windows.Forms.DataGridView dataAttiviAllaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeAllaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttivitaAllaData;
        private System.Windows.Forms.DataGridView dataMenoDiOtto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeMenoDiOtto;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttivitaMenoDiOtto;
        private System.Windows.Forms.Button buttonEsporta;
    }
}