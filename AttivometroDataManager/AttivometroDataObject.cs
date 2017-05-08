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
        static GoogleSheets _g;
        static Spreadsheet _s;
        static List<string> _listafogli;
        static List<string> _listanomi;
        static List<Attivista> _listaatiivisti;
        static String SpreadsheetId = "1ubhVmTLRBb6jXC98TL0Z8_GiNUk-9_CRwSS0TEXZ6mM"; //"1N5821LYxWpyycBuvsMf5OM5gKdE0be96VJ_mKlU1WzA";
        
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
                if (s=="Assemblea")
                {
                    l.AddRange(_g.GetRange(SpreadsheetId, s, "A5:A2000"));
                }
                else if (s == "Sociale")
                {
                    l.AddRange(_g.GetRange(SpreadsheetId, s, "B3:B2000"));
                }

                else if (s == "Ambiente" || s == "Riepilogo - NON TOCCARE")
                {
                    l.AddRange(_g.GetRange(SpreadsheetId, s, "A4:A2000"));
                }
                else {
                    l.AddRange(_g.GetRange(SpreadsheetId, s, "A3:A2000"));
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
            vr = _g.GetFoglio(SpreadsheetId, foglio);

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

            foreach(string nome in _listanomi)
            {
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
        
        public AttivometroDataObject()
        {
            _g = new GoogleSheets(SpreadsheetId);
            _s = _g.FullSheet;
            _listafogli = GetListaFogli();
            _listanomi = GetListaNomi();
            _listaatiivisti = GetAttivisti();
            ListaAttiviQuotaFissa(DateTime.Now, 8, 4);
        }

    }
}
