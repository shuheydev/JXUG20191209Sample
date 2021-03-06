﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsUiPractice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpandBar : ContentView
    {
        public ExpandBar()
        {
            InitializeComponent();
        }

        public bool IsLabelVisible
        {
            get { return ExpandLabel.IsVisible; }
            set { ExpandLabel.IsVisible = value; }

        }
    }
}