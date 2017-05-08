using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttivometroDataManager
{
    public class Attivista
    {
        private string _nome;
        private List<Attivita> _listaattivita = new List<Attivita>();

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public bool AddAttivita(List<Attivita> a)
        {
            bool r = false;
            try
            {
                _listaattivita.AddRange(a);
                r = true;
            }
            catch (Exception e)
            {
                r = false;
            }
            return r;
        }

        public int ContaAttivita(DateTime DataStart, DateTime DataEnd)
        {
            int r = 0;
            r = _listaattivita.Where(x=>x.Data >= DataStart && x.Data<= DataEnd).Select(x=>x.Nome).Count();
            return r;
        }

    }

    public class Attivita
    {
        private string _nome;
        private DateTime _data;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Attivita()
        {
        }

        public Attivita(string nome, DateTime data)
        {
            _nome = nome;
            _data = data;
        }

    }

}
