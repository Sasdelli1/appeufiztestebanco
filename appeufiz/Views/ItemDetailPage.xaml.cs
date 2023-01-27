using appeufiz.Models;
using appeufiz.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace appeufiz.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Lembrete();
        }



        async void LoadLembrete(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Lembrete olembrete = await App.Database.GetLembreteAsync(id);
                BindingContext = olembrete;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var olembrete = (Lembrete)BindingContext;
            if (!string.IsNullOrWhiteSpace(olembrete.Nome))
            {
                await App.Database.SaveLembreteAsync(olembrete);
            }


        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var olembrete = (Lembrete)BindingContext;
            await App.Database.DeleteLembreteAsync(olembrete);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }

}
    
