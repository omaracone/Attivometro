using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Discovery;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace GoogleDriveDataLayer
{

    public class CacheFoglio
    {
        string _nomefoglio;
        ValueRange _contenutofoglio;

        public string NomeFoglio
        {
            get { return _nomefoglio; }
            set { _nomefoglio = value;  }
        }

        public ValueRange ContenutoFoglio
        {
            get { return _contenutofoglio; }
            set { _contenutofoglio = value; }
        }


    }


    public class GoogleSheets
    {

        private Spreadsheet _spreadsheet;
        
        private string _spreadsheetid;
        private UserCredential credential;
        private string ApplicationName = "Attivometro";
        private List<CacheFoglio> _CacheFogli = new List<CacheFoglio>();


        public GoogleSheets(string SpreadsheetId)
        {
            _spreadsheetid = SpreadsheetId;
            if (!LogInAndGetSpreadsheet(SpreadsheetId, ref _spreadsheet)) _spreadsheet = null;
        }

        public Spreadsheet FullSheet
        {
            get { return _spreadsheet; }
        }

        public string GetSpreadsheetId
        {
            get { return _spreadsheetid; }
        }


        public ValueRange GetFoglio(string SpreadsheetId, string Foglio)
        {
            ValueRange d = new ValueRange();
            CacheFoglio c = new CacheFoglio();
            c = _CacheFogli.FirstOrDefault(x => x.NomeFoglio == Foglio);
            if (c != null) { 
                d = c.ContenutoFoglio;
                if (d != null) return d;
            }
            d = GetValueRange(SpreadsheetId, Foglio, "A1:ZZZ99999");
            _CacheFogli.Add(new CacheFoglio { NomeFoglio = Foglio, ContenutoFoglio = d });
            return d;
        }




        public ValueRange GetValueRange(string SpreadsheetId, string Foglio, string Range)
        {
            ValueRange d = new ValueRange();
            try
            {
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                String range = Foglio + "!" + Range;
                SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(this.GetSpreadsheetId, range);
                d = request.Execute();
                    
                return d;
            }
            catch (Exception e)
            {
                return d;
            }
        }


        public List<string> GetRange(string SpreadsheetId, string Foglio, string Range)
        {
            List<string> l = new List<string>();
                try
                {
                    var service = new SheetsService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = ApplicationName,
                    });
                    String range = Foglio + "!" + Range;
                    ValueRange d = GetValueRange(SpreadsheetId, Foglio, Range);
                    for (int i=0;i< d.Values.Count;i++) {
                        for (int j=0;j<d.Values[i].Count;j++) { 
                            if (!l.Contains(d.Values[i][j].ToString())) { 
                                l.Add(d.Values[i][j].ToString());
                            }
                        }
                    }
                    return l;
                }
                catch (Exception e)
                {
                    return l;
                }
        }


        private Boolean LogInAndGetSpreadsheet(string SpreadsheetId, ref Spreadsheet s )
        {
            // If modifying these scopes, delete your previously saved credentials
            // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
            string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
            using (var stream = new FileStream(@"Key/client_secret.json", FileMode.Open, FileAccess.Read))
            {
                try
                {
                    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
                    var service = new SheetsService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = ApplicationName,
                    });
                    SpreadsheetsResource.GetRequest requestFogli = service.Spreadsheets.Get(SpreadsheetId);
                    Spreadsheet responseFogli = requestFogli.Execute();
                    _spreadsheet = responseFogli;
                    s = responseFogli;
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }
    }
}
