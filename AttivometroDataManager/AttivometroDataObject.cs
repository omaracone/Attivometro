using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleDriveDataLayer;
using Google.Apis.Sheets.v4.Data;
using System.Collections;

namespace AttivometroDataManager
{

    public class AttivometroDataObject
    {
        private GoogleSheets _g;
        private Spreadsheet _s;
        private List<string> _listafogli;
        private List<string> _listanomi;
        private List<Attivista> _listaatiivisti;
        private String SpreadsheetId = "1xXkwdm7AH0xbr5ilK86aK5vMbVCkNnwGzcFjwDveysY"; //"1ubhVmTLRBb6jXC98TL0Z8_GiNUk-9_CRwSS0TEXZ6mM"; //"1N5821LYxWpyycBuvsMf5OM5gKdE0be96VJ_mKlU1WzA";

        private List<string> GetListaFogli()
        {
            List<string> l = new List<string>();
            foreach(Sheet s in _s.Sheets.Where(x => (x.Properties.Title != "Lista Attivisti Operativi" && x.Properties.Title != "Riepilogo - NON TOCCARE")).Select(x => x))
            {
                l.Add(s.Properties.Title);
            }
            return l;
        }

        private List<string> GetListaNomi()
        {
            List<string> l = new List<string>();
            

            foreach (string s in _listafogli)
            {
                Console.WriteLine("Acquisisco Nomi da {0}",s);
                if (s=="Assemblea")
                {
                    l.AddRange(_g.GetRange( s, "A5:A2000"));
                }
                else if (s == "Sociale")
                {
                    l.AddRange(_g.GetRange( s, "B3:B2000"));
                }

                else if (s == "Ambiente" || s == "Riepilogo - NON TOCCARE")
                {
                    l.AddRange(_g.GetRange(s, "A4:A2000"));
                }
                else {
                    l.AddRange(_g.GetRange(s, "A3:A2000"));
                }
            }

            return l.Distinct<string>().ToList<string>();
        }

        private bool EstraiData(ValueRange vr, int vr_colonna, ref DateTime d)
        {
            bool r = false;
            for (int j = 0; j < vr.Values.Count; j++)
            {

                if ((vr.Values[j].Count > vr_colonna) && DateTime.TryParse((vr.Values[j][vr_colonna].ToString()), out d ))
                {
                    r = true;
                    return r;
                }
            }
            return r;
        }

        private List<Attivita> GetAttivita(string nome, string foglio)
        {
            List<Attivita> r= new List<Attivita>();
            
            ValueRange vr = new ValueRange();
            int _nome_i = 0;
            int _nome_j = 0;

            //vr = _g.GetValueRange(SpreadsheetId, foglio, "A1:ZZ9999");
            vr = _g.GetFoglio( foglio);

            for (int i = 0; i < vr.Values.Count; i++)
            {
                for (int j = 0; j < vr.Values[i].Count; j++)
                {
                    if (nome == (vr.Values[i][j].ToString()))
                    {
                        _nome_i = i;
                        _nome_j = j;

                        for (int k = j + 1; k < vr.Values[i].Count;k++)
                        {
                            if( vr.Values[i][k].ToString() == "1") {
                                DateTime d = new DateTime();
                                if (EstraiData(vr, k, ref d))
                                {
                                    Attivita a = new Attivita();
                                    a.Nome = foglio;
                                    a.Data = d;
                                    r.Add(a);
                                }
                            }
                        }
                        return r;
                    }
                }
            }
            return r;
        }

        private List<Attivista> GetAttivisti()
        {
            List<Attivista> l = new List<Attivista>();
            int i = 0;
            int j = 0;
            foreach (string nome in _listanomi)
            {
                i++;
                j++;
                if (j>20) { 
                    Console.WriteLine("Build Attivometro {0}% completata...", (100*i / (double)_listanomi.Count).ToString("#0.00"));
                    j = 0;
                }
                Attivista a = new Attivista();
                a.Nome = nome;
                foreach(string foglio in _listafogli) {
                    List<Attivita> la = new List<Attivita>();
                    la = GetAttivita(nome, foglio);
                    if (la != null && la.Count != 0)
                    {
                        a.AddAttivita(la);
                    }
                }
                l.Add(a);
            }

            return l;
        }

        public List<Attivista> ListaAttiviQuotaFissa(DateTime DataCalcolo, int SogliaAttivita, int MesiIntervallo)
        {
            List<Attivista> la = new List<Attivista>();
            la = _listaatiivisti.Where(x => x.ContaAttivita(DataCalcolo.AddMonths(-MesiIntervallo), DataCalcolo) >= SogliaAttivita).ToList<Attivista>();
            return la;
        }

        public List<Attivista> ListaAttiviPrimaDelRicalcolo(DateTime DataAttuale, int SogliaAttivita, DateTime DataUltimoCalcolo)
        {
            List<Attivista> la = new List<Attivista>();
            la = _listaatiivisti.Where(x => x.ContaAttivita(DataUltimoCalcolo, DataAttuale) >= SogliaAttivita).ToList<Attivista>();
            return la;
        }

        public List<string> ListaFogli
        {
            get { return _listafogli; }
            
        }

        public List<string> ListaNomi
        {
            get { return _listanomi; }
        }

        public List<Attivista> ListaAttivisti
        {
            get { return _listaatiivisti; }
        }

        public List<NumeroAttivitaAttivista> ElencoAttiviQuotaFissa(DateTime DataCalcolo, int SogliaAttivita, int MesiIntervallo)
        {
            List<NumeroAttivitaAttivista> l = new List<NumeroAttivitaAttivista>();
            foreach (Attivista a in this.ListaAttiviQuotaFissa(DataCalcolo, SogliaAttivita, MesiIntervallo))
            {
                NumeroAttivitaAttivista n = new NumeroAttivitaAttivista();
                n.Nome = a.Nome;
                n.NumeroAttivita = a.ContaAttivita(DataCalcolo.AddMonths(-4), DataCalcolo);
                l.Add(n);
            }
            return l;
        }

        public List<NumeroAttivitaAttivista> ElencoPrimaDelRicalcolo(DateTime DataAttuale, int SogliaAttivita, DateTime DataUltimoCalcolo)
        {
            List<NumeroAttivitaAttivista> l = new List<NumeroAttivitaAttivista>();
            foreach (Attivista a in this.ListaAttiviPrimaDelRicalcolo(DataAttuale, SogliaAttivita, DataUltimoCalcolo))
            {
                NumeroAttivitaAttivista n = new NumeroAttivitaAttivista();
                n.Nome = a.Nome;
                n.NumeroAttivita = a.ContaAttivita(DataUltimoCalcolo, DataAttuale);
                l.Add(n);
            }
            return l;
        }

        public List<NumeroAttivitaAttivista> ElencoNonAttivi(DateTime DataAttuale, int SogliaAttivita, int MesiIntervallo, DateTime DataUltimoCalcolo)
        {
            List<NumeroAttivitaAttivista> l = new List<NumeroAttivitaAttivista>();
            foreach (Attivista a in this.ListaAttivisti.FindAll(x => (!this.ListaAttiviQuotaFissa(DataUltimoCalcolo, SogliaAttivita, MesiIntervallo).Contains(x)) && (!this.ListaAttiviPrimaDelRicalcolo(DataAttuale, SogliaAttivita, DataUltimoCalcolo).Contains(x))))
            {
                NumeroAttivitaAttivista n = new NumeroAttivitaAttivista();
                n.Nome = a.Nome;
                n.NumeroAttivita = a.ContaAttivita(DataUltimoCalcolo, DataAttuale);
                l.Add(n);
            }
            return l;

        }

        public AttivometroDataObject()
        {
            Console.WriteLine("Starting Attivometro...");
            _g = new GoogleSheets(SpreadsheetId);
            if (_g.Logged) { 
                _s = _g.FullSheet;

                Console.WriteLine("Loading Attività...");
                _listafogli = GetListaFogli();

                Console.WriteLine("Loading Attivisti...");
                _listanomi = GetListaNomi();

                Console.WriteLine("Loading Attivometro...");
                _listaatiivisti = GetAttivisti();

                Console.WriteLine("Attivometro Pronto!");
            }
            else
            {
                Console.Write("Non è stato possibile leggere i dati.");
                Console.ReadKey();
            }
        }

    }
}
