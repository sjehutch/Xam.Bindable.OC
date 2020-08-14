using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace DeleteListItems
{
    public class MainPageViewModel : BindableObject
    {
  
        private ObservableCollection<OffersModel> _CollectionsList;

        public ObservableCollection<OffersModel> CollectionsList
        {
            get { return _CollectionsList; }
            set
            {
                _CollectionsList = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteCommand { get;}

        public ICommand AddCommand { get; }


        public MainPageViewModel()
        {
            CollectionsList = new ObservableCollection<OffersModel>()
            {
                new OffersModel{ Name= "MM50"},
                new OffersModel{ Name= "MM50123"},
                new OffersModel{ Name= "MM50111"},
                new OffersModel{ Name= "MM50356"},
            };

            DeleteCommand = new Command(OnDeleteTapped);

            AddCommand = new Command(AddItmes);
        }

        private void AddItmes(object obj)
        {
            OffersModel offersModel = new OffersModel
            {
                Name = $"New Item Added {Guid.NewGuid():N}"
            };
            CollectionsList.Add(offersModel);
        }

        private void OnDeleteTapped(object obj)
        {
            var content = obj as OffersModel;
            CollectionsList.Remove(content);
        }
    }
}
