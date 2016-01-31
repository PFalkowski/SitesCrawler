using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace WebCrawler
{
    public class ViewModel : BindableBase
    {
        private string _uriSelected = "http//:";
        public string SelectedUri
        {
            get { return _uriSelected; }
            set
            {
                if (value != _uriSelected)
                {
                    OnPropertyChanged();
                    if (Uri.IsWellFormedUriString(value, UriKind.Absolute))
                    {
                        _uriSelected = value;
                    }
                }
            }
        }
    }
}
