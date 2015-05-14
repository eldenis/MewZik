﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MewZik.Views
{
    /// <summary>
    /// Interaction logic for ImagedCircleButton.xaml
    /// </summary>
    public partial class ImagedCircleButton : UserControl
    {
        public ImagedCircleButton()
        {
            InitializeComponent();
        }
        
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ImagedCircleButton), new PropertyMetadata(null));




        public Visual Visual
        {
            get { return (Visual)GetValue(VisualProperty); }
            set { SetValue(VisualProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Visual.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisualProperty =
            DependencyProperty.Register("Visual", typeof(Visual), typeof(ImagedCircleButton), new PropertyMetadata(null));



    }
}