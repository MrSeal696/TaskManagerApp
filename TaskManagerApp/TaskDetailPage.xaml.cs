namespace TaskManagerApp;

public partial class TaskDetailPage : ContentPage
{
    public TaskDetailPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}