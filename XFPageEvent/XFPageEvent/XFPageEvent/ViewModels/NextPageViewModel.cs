using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XFPageEvent.Models;

namespace XFPageEvent.ViewModels
{
    public class NextPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string YourAnswer { get; set; }


        public DelegateCommand PublishCommand { get; set; }


        private readonly IEventAggregator _eventAggregator;
        public NextPageViewModel(IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            PublishCommand = new DelegateCommand(() =>
            {
                _eventAggregator.GetEvent<GoBackEvent>().Publish(new GoBackPayload
                {
                    Content = YourAnswer,
                });
            });
        }
    }
}
