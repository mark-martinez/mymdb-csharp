using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;
using MyMDB.Core.Controller;
using System.Collections.ObjectModel;

namespace MyMDB.Core.Model
{
    public class ResultsModel
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Media> results { get; set; }
        
    }

    public class ResultsReader
    {
        private string _currentQuery;
        private string _data;
        public ResultsModel Results { get; set; }
        public string current_query
        {
            get
            {
                return _currentQuery;
            }
            set
            {
                _currentQuery = value;
                data = ResultsController.CallApi(_currentQuery);
            }
        }
        public string data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                Results = JsonConvert.DeserializeObject<ResultsModel>(data);
            }
        }
    }
}
