using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace WebCrawler
{
    public class ViewModel : BindableBase
    {
        public ViewModel()
        {
            GoCommand = new DelegateCommand(Go);
        }
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

        private string _selectedElement;
        public string SelectedElement
        {
            get { return _selectedElement; }
            set
            {
                if (value != _selectedElement)
                {
                    _selectedElement = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                if (value != _result)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }
        private Crawler _crawler = new Crawler();

        public DelegateCommand GoCommand { get; private set; }

        private void Go()
        {
            Result = _crawler.GetFirstById(new Uri(SelectedUri), SelectedElement).Result;
        }
    }
}
