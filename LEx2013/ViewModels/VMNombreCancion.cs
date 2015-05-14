using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MewZik.Nucleo;

namespace MewZik.ViewModels
{
    public class VMNombreCancion : ViewModelBase
    {
        Action<string> _accionAceptar;
        Action _accionCancelar;
        string _nombreViejoCancion;
        public VMNombreCancion(Action<string> accionAceptar,
            Action accionCancelar, string nombreViejoCancion = null)
        {
            _accionAceptar = accionAceptar;
            _accionCancelar = accionCancelar;
            _nombreViejoCancion = nombreViejoCancion;
            NombreCancion = _nombreViejoCancion;
        }



        private string _nombreCancion;
        public string NombreCancion
        {
            get { return _nombreCancion; }
            set
            {
                _nombreCancion = value;
                RaisePropertyChanged(() => NombreCancion);
            }
        }



        private RelayCommand _aceptar;
        public RelayCommand Aceptar
        {
            get
            {
                return _aceptar ?? (_aceptar = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        _accionAceptar(NombreCancion);
                    },
                    () =>
                    {
                        return !string.IsNullOrWhiteSpace(NombreCancion);
                    }));
            }
        }



        private RelayCommand _cancelar;
        public RelayCommand Cancelar
        {
            get
            {
                return _cancelar ?? (_cancelar = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        _accionCancelar();
                    },
                    () =>
                    {
                        return true;
                    }));
            }
        }


    }
}
