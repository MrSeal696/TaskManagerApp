using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManagerApp.Models;

namespace TaskManagerApp.ViewModels;

public class TaskListViewModel : BaseViewModel
{
    public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

    private TaskItem? selectedTask;
    public TaskItem? SelectedTask
    {
        get => selectedTask;
        set => SetProperty(ref selectedTask, value);
    }

    public ICommand LoadTasksCommand { get; }
    public ICommand SelectTaskCommand { get; }

    public TaskListViewModel()
    {
        LoadTasksCommand = new Command(LoadTasks);
        SelectTaskCommand = new Command<TaskItem>(OnSelectTask);
    }

    private void LoadTasks()
    {
        // Тестовые задачи
        Tasks.Clear();
        Tasks.Add(new TaskItem { Id = 1, Title = "Купить продукты", Description = "Хлеб, молоко, яйца", DueDate = DateTime.Now.AddDays(1), Priority = 2 });
        Tasks.Add(new TaskItem { Id = 2, Title = "Позвонить врачу", Description = "Записаться на прием", DueDate = DateTime.Now.AddDays(2), Priority = 3 });
        Tasks.Add(new TaskItem { Id = 3, Title = "Сделать домашку", Description = "MAUI задание", DueDate = DateTime.Now, Priority = 1 });
    }

    private async void OnSelectTask(TaskItem task)
    {
        if (task == null)
            return;

        // Переход к деталям
        await Shell.Current.GoToAsync($"{nameof(TaskDetailPage)}?taskId={task.Id}");
    }
}