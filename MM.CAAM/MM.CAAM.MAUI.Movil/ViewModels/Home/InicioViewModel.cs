using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Icu.Util.LocaleData;

namespace MM.CAAM.MAUI.Movil.ViewModels.Home
{
    public class InicioViewModel : BaseViewModel
    {


        public InicioViewModel() 
        {
            RefreshCommand = new Command(async () => { IsRefreshing = true; await Load(); IsRefreshing = false; });
            //FilterCommand = new Command(async () => await Load());

            InitializeAsync();

            IsRefreshing = true;

            Load();
        }

        //VIEWMODEL
        private void InitializeAsync()
        {
            LoadEstadosDiligencia();
            ChangeEstado();
        }

        //VIEWMODEL
        private void ChangeEstado()
        {
            //CurrentSelectedEstadoDiligenciaIndex = EstadosItems.FindIndex(x => x.Id == EstadoDiligenciaId);
        }

        //VIEWMODEL
        public void LoadEstadosDiligencia()
        {
            //EstadosItems = ValuesService.GetEstadosDiligenciasBandejaDiligencia();
        }

        //VIEW-MODEL
        public void OnAppearing()
        {
            //IsRefreshing = true; //TMP
            //SelectedItem = null;
        }

        //VIEW-MODEL
        public void OnDisappearing()
        {
            //IsBusy = false;
            IsRefreshing = false;
        }

        //VIEWMODEL
        private async Task LoadItemData()
        {
            //IsBusy = true;
            await Load();
            //IsBusy = false;
        }

        //VIEWMODEL
        private async Task RefreshData()
        {
            await Task.WhenAll(Load());
        }

        //VIEWMODEL
        private async Task Load()
        {
            try
            {
                //ListaNotificacionTribunalCompleto = await NotificacionTribunalService.ObtenerNotificacionesPorProfesionista(5);

                ////var listTmp = ListaNotificacionTribunalCompleto.Take(PageSize).ToList();  //LIMITADA a PageSize
                //var listTmp = ListaNotificacionTribunalCompleto.Take(PageSize).ToList();  //LIMITADA a 50 
                //ListaNotificacionTribunal.Clear();
                //foreach (var tmp in listTmp)
                //{
                //    ListaNotificacionTribunal.Add(tmp);
                //}

            }
            catch (Exception ex)
            {
                //ShowToastMessage(ex.Message, Constants.ToastMessage.Long);
                IsRefreshing = false;
                //await DisplayAlert("AVISO", ex.Message, "OK");
                Debug.WriteLine($"Error in [{this}]Load_BandejaDiligencia: {ex}");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        //[RelayCommand]
        public async Task<int> GetNextData(int lastVisibleItemIndex)
        {
            //if (ListaNotificacionTribunal.Count == lastVisibleItemIndex)
            //{
            //    IsBusy = true;
            //    if (ListaNotificacionTribunal != null && ListaNotificacionTribunal.Count > 0)
            //    {
            //        await Task.Delay(2000); 
            //        var listNew = ListaNotificacionTribunalCompleto.Skip(ListaNotificacionTribunal.Count).Take(PageSize);


            //        foreach (var notificacion_Tribunal in listNew.ToList())
            //        {
            //            ListaNotificacionTribunal.Add(notificacion_Tribunal);
            //        }
            //    }
            //    IsBusy = false;

            //    return lastVisibleItemIndex;
            //}
            //else
            //{
            //    return 0;
            //}

            return 0;
        }
    }
}
