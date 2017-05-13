using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttivometroDataManager;
using Esporta;

namespace Attivometro
{



    public partial class Attivometro : Form
    {
        private AttivometroDataObject data;

        public Attivometro()
        {
            InitializeComponent();
            data = new AttivometroDataObject();
            this.Show();
        }



        private void buttonCalcolaAttivi_Click(object sender, EventArgs e)
        {
            List<Attivista> l = new List<Attivista>();
            l=data.ListaAttiviQuotaFissa(this.dateUltimaDataCalcoloAttivi.Value, 8, 4);
            List<Attivista> l_temp = new List<Attivista>();
            l_temp = data.ListaAttiviPrimaDelRicalcolo(this.dateTimePicker1.Value, 8, this.dateUltimaDataCalcoloAttivi.Value);

            this.dataRisultatoCalcolo.Rows.Clear();
            this.dataAttiviAllaData.Rows.Clear();
            this.dataMenoDiOtto.Rows.Clear();

            foreach (Attivista a in l) {           
                DataGridViewRow r = dataRisultatoCalcolo.Rows[dataRisultatoCalcolo.Rows.Add()];
                r.Cells["Nome"].Value = a.Nome;
                r.Cells["Attivita"].Value = a.ContaAttivita(this.dateUltimaDataCalcoloAttivi.Value.AddMonths(-4), this.dateUltimaDataCalcoloAttivi.Value);
            }
            foreach (Attivista a in l_temp.FindAll(x=>(!l.Contains(x))))
            {
                DataGridViewRow r = dataAttiviAllaData.Rows[dataAttiviAllaData.Rows.Add()];
                r.Cells["NomeAllaData"].Value = a.Nome;
                r.Cells["AttivitaAllaData"].Value = a.ContaAttivita(this.dateUltimaDataCalcoloAttivi.Value, this.dateTimePicker1.Value);
            }
            foreach (Attivista a in data.ListaAttivisti.FindAll(x => (!l.Contains(x)) && (!l_temp.Contains(x))))
            {
                DataGridViewRow r = dataMenoDiOtto.Rows[dataMenoDiOtto.Rows.Add()];
                r.Cells["NomeMenoDiOtto"].Value = a.Nome;
                r.Cells["AttivitaMenoDiOtto"].Value = a.ContaAttivita(this.dateUltimaDataCalcoloAttivi.Value, this.dateTimePicker1.Value);
            }

        }

        private void dataRisultatoCalcolo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonEsporta_Click(object sender, EventArgs e)
        {
            EsportaInExcel exp = new EsportaInExcel();

            List<object> lo = new List<object>();

            List<NumeroAttivitaAttivista> l = new List<NumeroAttivitaAttivista>();
            l = data.ElencoAttiviQuotaFissa(this.dateUltimaDataCalcoloAttivi.Value, 8, 4);

            foreach (NumeroAttivitaAttivista a in l)
            {
                lo.Add(new { Nome = a.Nome, Attivita = a.NumeroAttivita });
            }
            

            exp.SaveObjectAsExcel<NumeroAttivitaAttivista>(l, @"c:\temp\attivometro.xlsx");
        }
    }
}