using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListViewsex.Models;
using Xamarin.Forms;

namespace ListViewsex
{
	public partial class MainPage : ContentPage
	{

	    private ObservableCollection<Person> people;

	    private List<Person> GetPeople(string searchText = null)
	    {
            var people = new List<Person>()
            {
                new Person{Id=1,Name="Bryan1"},
                new Person{Id=2,Name="Bryan2"},
                new Person{Id=3,Name="Bryan3"}

            };
	        if (string.IsNullOrWhiteSpace(searchText))
	        {
	            return people;
	        }
	        else
	        {
	            var selected = people.Where(p => p.Name.StartsWith(searchText));
	            return new List<Person>(selected);
	        }

	    }

	    
		public MainPage()
		{
			InitializeComponent();
		    people = new ObservableCollection<Person>(GetPeople());
		    
		    lst.ItemsSource = people;
		}

        
        private void details_Clicked(object sender, EventArgs e)
        {
            var person = ((MenuItem) sender).CommandParameter as Person;
            DisplayAlert("Details",person.Name , "Ok");
        }

        private void delete_Clicked(object sender, EventArgs e)
        {
            var person = ((MenuItem) sender).CommandParameter as Person;
            people.Remove(person);
        }

        private void lst_Refreshing(object sender, EventArgs e)
        {
            people = new ObservableCollection<Person>(GetPeople());
		    
            lst.ItemsSource = people;
            lst.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lst.ItemsSource = GetPeople(e.NewTextValue);

        }
    }
}
