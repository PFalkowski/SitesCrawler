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
        private string _uriSelected = "https://open.spotify.com/track/0Whk9DxnRVIYDT5cpa1dML";
        public string SelectedUri
        {
            get { return _uriSelected; }
            set
            {
                if (value != _uriSelected)
                {
                    _uriSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedElement = "title";
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
            private set
            {
                if (value != _result)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }
        private readonly Crawler _crawler = new Crawler();

        public DelegateCommand GoCommand { get; private set; }

        private async void Go()
        {
            var temp = string.Empty;
            await Task.Run(() =>
            {
                temp = _crawler.GetFirstById(SelectedUri, SelectedElement);
            });
            Result = temp;
        }
    }
}

