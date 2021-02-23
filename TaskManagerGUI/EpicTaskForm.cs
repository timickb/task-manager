using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaskManagerAPI;
using TaskManagerCLI;

namespace TaskManagerGUI
{
    public partial class EpicTaskForm : Form
    {
        private Project ConnectedProject { get; }
        private EpicTask ConnectedTask { get; }
        private CommandExecutor CmdExecutor { get; }

        public EpicTaskForm(Project project, EpicTask task, CommandExecutor ex)
        {
            ConnectedProject = project;
            ConnectedTask = task;
            CmdExecutor = ex;
            InitializeComponent();

            label1.Text = task.Name;
            label2.Text = $"Создана {task.CreationDate}";

            UpdateSubtasksList();

        
        }

        /// <summary>
        /// Запрашивает айдишник какой-нибудь задачи из проекта
        /// и включает ее в список подзадач данной эпик-задачи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSubtaskButton_Click(object sender, EventArgs e)
        {
            var dialog = new InputDialog("Введите Id задачи в ДАННОМ проекте, которую хотите сюда добавить");
            dialog.ShowDialog();
            var IdRaw = dialog.Value;

            if(!int.TryParse(IdRaw, out var id))
            {
                MessageBox.Show("Введите целое положительное число", "Ошибка");
                return;
            }

            var result = CmdExecutor.Execute($"insert_task_to_epic {ConnectedProject.Id} {id} {ConnectedTask.Id}");
            MessageBox.Show(result.TextOutput, "Сообщение");

            if(result.Status == CommandExecutionStatus.OK)
            {
                TaskManager.GetInstance().CommitChanges();
                UpdateSubtasksList();
            }
        
        }

        private void RemoveSubtaskButton_Click(object sender, EventArgs e)
        {
            var selectedItem = listView.SelectedItems;

            if (selectedItem == null) return;

            int taskId = (int)selectedItem[0].Tag;

            var result = CmdExecutor.Execute(
                $"remove_task_from_epic {ConnectedProject.Id} {taskId} {ConnectedTask.Id}");
            MessageBox.Show(result.TextOutput,
                result.Status == CommandExecutionStatus.OK ? "Сообщение" : "Ошибка");

            if (result.Status == CommandExecutionStatus.OK)
            {
                UpdateSubtasksList();
                TaskManager.GetInstance().CommitChanges();
            }
        }

        /// <summary>
        /// Читает по очереди сначала все простые подзадачи
        /// это задачи, а затем все story подзадачи. После этого
        /// кидает их в listView.
        /// </summary>
        private void UpdateSubtasksList()
        {
            listView.Items.Clear();
            var simpleSubtasks = ConnectedTask.SimpleTasks;
            var storySubtasks = ConnectedTask.StoryTasks;

            foreach(var simple in simpleSubtasks)
            {
                var item = new ListViewItem(simple.Name);
                item.Tag = simple.Id;
                listView.Items.Add(item);
            }
            foreach (var story in storySubtasks)
            {
                var item = new ListViewItem(story.Name);
                item.Tag = story.Id;
                listView.Items.Add(item);
            }
        }
    }
}
