using GalaSoft.MvvmLight;
using Heimdall.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Heimdall.Core.ViewModel
{
    public class ResultListingViewModel : UserControl
    {
        private Result _result;

        public ResultListingViewModel()
        {
        }

        public Result Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public string Title
        {
            get { return Result.title; }
        }
        
        public string Genres
        {
            get { return Result.genre_ids.ToString(); }
        }

        public string Overview
        {
            get { return Result.overview; }
        }

        public string VoteAverage
        {
            get { return Result.vote_average.ToString(); }
        }
    }
}
