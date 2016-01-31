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
        private string _uriSelected ;
        public string SelectedUri
        {
            get { return _uriSelected; }
            set
            {
                if (Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute))
                {
                    _uriSelected = value;
                }
            }
        }
    }
}
