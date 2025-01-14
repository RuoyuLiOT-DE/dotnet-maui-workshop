﻿namespace MonkeyFinder.ViewModel;

//[INotifyPropertyChanged] if BaseViewModel inherits another base class
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    [ObservableProperty]
    private string _title;

    public bool IsNotBusy => !IsBusy;

    public BaseViewModel()
    {

    }

}
