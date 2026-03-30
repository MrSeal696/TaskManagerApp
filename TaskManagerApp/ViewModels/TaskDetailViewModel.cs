using System.Windows.Input;
using TaskManagerApp.Models;

namespace TaskManagerApp.ViewModels;

[QueryProperty(nameof(TaskId), "taskId")]
public class TaskDetailViewModel : BaseViewModel
{
    private TaskItem currentTask = new TaskItem();
    public TaskItem CurrentTask
    {
        get => currentTask;
        set => SetProperty(ref currentTask, value);
    }

    private int taskId;
    public int TaskId
    {
        get => taskId;
        set
        {
            taskId = value;
            LoadTask(value);
        }
    }

    public ICommand ToggleCompletedCommand { get; }
    public ICommand SaveCommand { get; }

    public TaskDetailViewModel()
    {
        ToggleCompletedCommand = new Command(() => CurrentTask.IsCompleted = !CurrentTask.IsCompleted);
        SaveCommand = new Command(() => { /* Здесь можно добавить логику сохранения */ });
    }

    private void LoadTask(int id)
    {
        // Тестовая загрузка, в реальном приложении заменяется на поиск в БД
        CurrentTask = new TaskItem
        {
            Id = id,
            Title = $"Задача {id}",
            Description = "Описание задачи",
            DueDate = DateTime.Now.AddDays(1),
            Priority = 2,
            IsCompleted = false
        };
    }
}