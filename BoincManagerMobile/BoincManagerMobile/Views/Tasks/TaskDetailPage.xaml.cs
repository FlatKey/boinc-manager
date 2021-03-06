﻿using System.ComponentModel;
using Xamarin.Forms;

using BoincManagerMobile.ViewModels;

namespace BoincManagerMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TaskDetailPage : ContentPage
    {
        public TaskDetailPage(TaskDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}