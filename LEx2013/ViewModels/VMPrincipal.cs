using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MewZik.Nucleo;
using MewZik.ProveedoresCanciones;
using MewZik.Utils;

namespace MewZik.ViewModels
{
    public class VMPrincipal : ViewModelBase
    {
        IProveedorCanciones _proveedor;

        public VMPrincipal()
        {
            CargarProveedor();
            RefrescarLista();

        }

        #region Métodos

        private void CargarProveedor()
        {
            try
            {
                _proveedor = FabricaProveedorCanciones.ObtenerLector();
            }
            catch (Exception ex)
            {
                //TODO: Hacer que esta parte muestre el diálogo de configuración
                throw new Exception(string.Format("No se pudieron cargar los datos del proveedor de canciones {0}", ex.Message));
            }

            var fuentes = _proveedor.Fuentes;
            if (fuentes.EsNuloOVacio())
                throw new Exception("No se encontró ninguna fuente para el proveedor establecido. Revisar configuración.");

            var ultimaFuenteUtilizada = Utilitarios
                .EnumNullableTryParse<TiposFuentesProveedor>(Properties.Settings.Default.UltimaFuenteUsada);

            //TODO Mejorar esto cuando se tenga más proveedores
            TieneFuenteLetras = _proveedor.Fuentes.Any(x => x == TiposFuentesProveedor.Letras);
            TieneFuenteAcordes = _proveedor.Fuentes.Any(x => x == TiposFuentesProveedor.Acordes);
            FuenteLetras = ultimaFuenteUtilizada.HasValue ? ultimaFuenteUtilizada.Value == TiposFuentesProveedor.Letras : TieneFuenteLetras;
            FuenteAcordes = ultimaFuenteUtilizada.HasValue ? ultimaFuenteUtilizada.Value == TiposFuentesProveedor.Acordes : !FuenteLetras;
        }

        void MostrarMensajeTemporal(string mensaje)
        {
            MensajeTemporal = mensaje;
            MostrandoMensajeTemporal = true;
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Dispatcher.CurrentDispatcher.Invoke(() => MostrandoMensajeTemporal = false);
            });
        }

        void RefrescarLista()
        {
            ListaCancionesReal = _proveedor.ObtenerArchivos(Filtro);
            LimpiarEstadoLista = true;
            ListaCanciones.MoveCurrentToPrevious();
        }

        void LeerCancionSeleccionada()
        {
            CancionLeida = CancionSeleccionada;
            Texto = _proveedor.LeerCancion(CancionLeida);
            LimpiarEstadoTexto = true;
        }

        private void CambiarFuenteCanciones(TiposFuentesProveedor tipoFuente)
        {
            _proveedor.SeleccionarFuente(tipoFuente);
            RefrescarLista();

            Properties.Settings.Default.UltimaFuenteUsada = tipoFuente.ToString();
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Props

        private bool _limpiarEstadoTexto;
        public bool LimpiarEstadoTexto
        {
            get { return _limpiarEstadoTexto; }
            set
            {
                _limpiarEstadoTexto = value;
                RaisePropertyChanged(() => LimpiarEstadoTexto);
            }
        }



        private string _mensajeTemporal;
        public string MensajeTemporal
        {
            get { return _mensajeTemporal; }
            set
            {
                _mensajeTemporal = value;
                RaisePropertyChanged(() => MensajeTemporal);
            }
        }


        private bool _limpiarEstadoLista;
        public bool LimpiarEstadoLista
        {
            get { return _limpiarEstadoLista; }
            set
            {
                _limpiarEstadoLista = value;
                RaisePropertyChanged(() => LimpiarEstadoLista);
            }
        }



        private string _texto;
        public string Texto
        {
            get { return _texto; }
            set
            {
                _texto = value;
                RaisePropertyChanged(() => Texto);
            }
        }

        private IList<ProtoCancion> _listaCancionesReal;
        private IList<ProtoCancion> ListaCancionesReal
        {
            get
            {
                return _listaCancionesReal;
            }
            set
            {
                _listaCancionesReal = value;
                ListaCanciones = CollectionViewSource.GetDefaultView(value);
                RaisePropertyChanged(() => ListaCanciones);
            }
        }

        public ICollectionView ListaCanciones { get; private set; }


        private string _filtro;
        public string Filtro
        {
            get { return _filtro; }
            set
            {
                _filtro = value;
                RefrescarLista();
                RaisePropertyChanged(() => Filtro);
            }
        }


        private bool _tieneFuenteLetras;
        public bool TieneFuenteLetras
        {
            get { return _tieneFuenteLetras; }
            set
            {
                _tieneFuenteLetras = value;
                RaisePropertyChanged(() => TieneFuenteLetras);
            }
        }

        private bool _tieneFuenteAcordes;
        public bool TieneFuenteAcordes
        {
            get { return _tieneFuenteAcordes; }
            set
            {
                _tieneFuenteAcordes = value;
                RaisePropertyChanged(() => TieneFuenteAcordes);
            }
        }


        private ProtoCancion _cancionSeleccionada;
        public ProtoCancion CancionSeleccionada
        {
            get { return _cancionSeleccionada; }
            set
            {
                _cancionSeleccionada = value;
                RaisePropertyChanged(() => CancionSeleccionada);
            }
        }


        private ProtoCancion _cancionLeida;
        public ProtoCancion CancionLeida
        {
            get { return _cancionLeida; }
            set
            {
                _cancionLeida = value;
                RaisePropertyChanged(() => CancionLeida);
            }
        }


        private bool _focoEnBuscar;
        public bool FocoEnBuscar
        {
            get { return _focoEnBuscar; }
            set
            {
                _focoEnBuscar = value;
                RaisePropertyChanged(() => FocoEnBuscar);
            }
        }


        private bool _focoEnLista;
        public bool FocoEnLista
        {
            get { return _focoEnLista; }
            set
            {
                _focoEnLista = value;
                RaisePropertyChanged(() => FocoEnLista);
            }
        }


        private bool _focoEnTexto;
        public bool FocoEnTexto
        {
            get { return _focoEnTexto; }
            set
            {
                _focoEnTexto = value;
                RaisePropertyChanged(() => FocoEnTexto);
            }
        }



        #endregion

        #region Commands

        private RelayCommand _abrirPrimeraCancion;
        public RelayCommand AbrirPrimeraCancion
        {
            get
            {
                return _abrirPrimeraCancion ?? (_abrirPrimeraCancion = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        ListaCanciones.MoveCurrentToFirst();
                        if (CancionSeleccionada != null)
                            LeerCancionSeleccionada();
                    },
                    () =>
                    {
                        return true;
                    }));
            }
        }


        private RelayCommand _abrirSiguienteCancion;
        public RelayCommand AbrirSiguienteCancion
        {
            get
            {
                return _abrirSiguienteCancion ?? (_abrirSiguienteCancion = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        ListaCanciones.MoveCurrentToNext();
                        if (CancionSeleccionada != null)
                            LeerCancionSeleccionada();
                    },
                    () =>
                    {
                        return true;
                    }));
            }
        }


        private RelayCommand _guardarCancion;
        public RelayCommand GuardarCancion
        {
            get
            {
                return _guardarCancion ?? (_guardarCancion = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        _proveedor.GuardarCancion(CancionLeida, Texto);
                        MostrarMensajeTemporal("Guardado...");
                    },
                    () =>
                    {
                        return CancionLeida != null;
                    }));
            }
        }


        private RelayCommand _salir;
        public RelayCommand Salir
        {
            get
            {
                return _salir ?? (_salir = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        App.Salir();
                    },
                    () =>
                    {
                        return true;
                    }));
            }
        }


        private RelayCommand _eliminarCancionLeida;
        public RelayCommand EliminarCancionLeida
        {
            get
            {
                return _eliminarCancionLeida ?? (_eliminarCancionLeida = new RelayCommand(
                    () =>
                    {
                        // Execute delegate

                        if (MetroMessageBox.Show("¿Seguro de querer eliminar la canción?", string.Empty,
                            MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;

                        _proveedor.EliminarCancion(CancionLeida);
                        CancionLeida = null;
                        MostrarMensajeTemporal("Eliminado...");
                        Texto = null;
                        LimpiarEstadoTexto = true;
                        Filtro = null;
                    },
                    () =>
                    {
                        return CancionLeida != null;
                    }));
            }
        }



        private RelayCommand _establecerFocoBuscar;
        public RelayCommand EstablecerFocoBuscar
        {
            get
            {
                return _establecerFocoBuscar ?? (_establecerFocoBuscar = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        FocoEnBuscar = true;
                    },
                    () =>
                    {
                        return true;
                    }));
            }
        }


        private RelayCommand _establecerFocoLista;
        public RelayCommand EstablecerFocoLista
        {
            get
            {
                return _establecerFocoLista ?? (_establecerFocoLista = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        FocoEnLista = true;
                    },
                    () =>
                    {
                        return true;
                    }));
            }
        }


        private RelayCommand _establecerFocoTexto;
        public RelayCommand EstablecerFocoTexto
        {
            get
            {
                return _establecerFocoTexto ?? (_establecerFocoTexto = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        FocoEnTexto = true;
                    },
                    () =>
                    {
                        return true;
                    }));
            }
        }



        private RelayCommand _seleccionarFuenteLetras;
        public RelayCommand SeleccionarFuenteLetras
        {
            get
            {
                return _seleccionarFuenteLetras ?? (_seleccionarFuenteLetras = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        FuenteLetras = true;
                    },
                    () =>
                    {
                        return TieneFuenteLetras;
                    }));
            }
        }



        private RelayCommand _seleccionarFuenteAcordes;
        public RelayCommand SeleccionarFuenteAcordes
        {
            get
            {
                return _seleccionarFuenteAcordes ?? (_seleccionarFuenteAcordes = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        FuenteAcordes = true;
                    },
                    () =>
                    {
                        return TieneFuenteAcordes;
                    }));
            }
        }



        private RelayCommand _abrirCancionAnterior;
        public RelayCommand AbrirCancionAnterior
        {
            get
            {
                return _abrirCancionAnterior ?? (_abrirCancionAnterior = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        ListaCanciones.MoveCurrentToPrevious();
                        if (CancionSeleccionada != null)
                            LeerCancionSeleccionada();
                    },
                    () =>
                    {
                        return true;
                    }));
            }
        }



        private RelayCommand _abrirCancionSeleccionada;
        public RelayCommand AbrirCancionSeleccionada
        {
            get
            {
                return _abrirCancionSeleccionada ?? (_abrirCancionSeleccionada = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        LeerCancionSeleccionada();
                    },
                    () =>
                    {
                        return CancionSeleccionada != null;
                    }));
            }
        }
        #endregion

        #region Fuentes Canciones


        private bool _fuenteAcordes;
        public bool FuenteAcordes
        {
            get { return _fuenteAcordes; }
            set
            {
                _fuenteAcordes = value;
                if (_fuenteAcordes && TieneFuenteAcordes)
                    CambiarFuenteCanciones(TiposFuentesProveedor.Acordes);

                RaisePropertyChanged(() => FuenteAcordes);
            }
        }



        private bool _fuenteLetras;
        public bool FuenteLetras
        {
            get { return _fuenteLetras; }
            set
            {
                _fuenteLetras = value;
                if (_fuenteLetras && TieneFuenteLetras)
                    CambiarFuenteCanciones(TiposFuentesProveedor.Letras);

                RaisePropertyChanged(() => FuenteLetras);
            }
        }




        #endregion

        #region Diálogo

        private object _dialogo;// = new VMNombreCancion();
        public object Dialogo
        {
            get { return _dialogo; }
            set
            {
                _dialogo = value;
                RaisePropertyChanged(() => Dialogo);
            }
        }

        private bool _mostrandoMensajeTemporal;
        public bool MostrandoMensajeTemporal
        {
            get { return _mostrandoMensajeTemporal; }
            set
            {
                _mostrandoMensajeTemporal = value;
                RaisePropertyChanged(() => MostrandoMensajeTemporal);
            }
        }

        #endregion

        #region Comandos menú contextual lista

        private RelayCommand _duplicarCancion;
        public RelayCommand DuplicarCancion
        {
            get
            {
                return _duplicarCancion ?? (_duplicarCancion = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        Dialogo = new VMNombreCancion(nombreCancionNueva =>
                        {
                            Dialogo = null;
                            var textoCancion = _proveedor.LeerCancion(CancionSeleccionada);
                            var cancionNueva = _proveedor.AgregarCancion(nombreCancionNueva, textoCancion);
                            Filtro = cancionNueva.Nombre;
                            ListaCanciones.MoveCurrentToFirst();
                            LeerCancionSeleccionada();
                        }, () => Dialogo = null, _proveedor.ObtenerNombreDuplicado(CancionSeleccionada));
                    },
                    () =>
                    {
                        return CancionSeleccionada != null; ;
                    }));
            }
        }


        private RelayCommand _cambiarNombre;
        public RelayCommand CambiarNombre
        {
            get
            {
                return _cambiarNombre ?? (_cambiarNombre = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        Dialogo = new VMNombreCancion(nombreCancionNueva =>
                        {
                            Dialogo = null;
                            _proveedor.RenombrarCancion(CancionSeleccionada, nombreCancionNueva);
                            Filtro = nombreCancionNueva;
                            ListaCanciones.MoveCurrentToFirst();
                            LeerCancionSeleccionada();
                        }, () => Dialogo = null, CancionSeleccionada.Nombre);
                    },
                    () =>
                    {
                        return CancionSeleccionada != null;
                    }));
            }
        }


        private RelayCommand _agregarCancion;
        public RelayCommand AgregarCancion
        {
            get
            {
                return _agregarCancion ?? (_agregarCancion = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        Dialogo = new VMNombreCancion(nombreCancionNueva =>
                        {
                            Dialogo = null;
                            var cancion = _proveedor.AgregarCancion(nombreCancionNueva);
                            Filtro = cancion.Nombre;
                            ListaCanciones.MoveCurrentToFirst();
                            LeerCancionSeleccionada();
                            FocoEnTexto = true;
                        }, () => Dialogo = null);
                    },
                    () =>
                    {
                        return true;
                    }));
            }
        }

        private RelayCommand _eliminarCancion;
        public RelayCommand EliminarCancion
        {
            get
            {
                return _eliminarCancion ?? (_eliminarCancion = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        if (MetroMessageBox.Show("¿Seguro de querer eliminar la canción seleccionada?",
                            string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                            return;

                        _proveedor.EliminarCancion(CancionSeleccionada);
                        Texto = "";
                        Filtro = "";
                    },
                    () =>
                    {
                        return CancionSeleccionada != null;
                    }));
            }
        }


        private RelayCommand _abrirWord;
        public RelayCommand AbrirWord
        {
            get
            {
                return _abrirWord ?? (_abrirWord = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        Process.Start("winword.exe", "/n \"" + CancionSeleccionada.Identificacion.Replace("/", "\\") + "\"");
                    },
                    () =>
                    {
                        return CancionSeleccionada != null;
                    }));
            }
        }


        private RelayCommand _localizarExplorer;
        public RelayCommand LocalizarExplorer
        {
            get
            {
                return _localizarExplorer ?? (_localizarExplorer = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        Process.Start("explorer.exe", "/select," + CancionSeleccionada.Identificacion.Replace("/", "\\"));

                    },
                    () =>
                    {
                        return CancionSeleccionada != null;
                    }));
            }
        }


        private RelayCommand _abrirNotepad;
        public RelayCommand AbrirNotepad
        {
            get
            {
                return _abrirNotepad ?? (_abrirNotepad = new RelayCommand(
                    () =>
                    {
                        // Execute delegate
                        Process.Start("notepad2.exe", CancionSeleccionada.Identificacion);
                    },
                    () =>
                    {
                        return CancionSeleccionada != null;
                    }));
            }
        }

        #endregion

    }
}
