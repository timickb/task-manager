using System;
using System.Windows.Forms;
using TaskManagerAPI;
using TaskManagerCLI;

namespace TaskManagerGUI
{
    public partial class ProjectForm : Form
    {
        public Project ConnectedProject { get; private set; }
        private CommandExecutor CmdExecutor { get; }

        public ProjectForm(Project project, CommandExecutor ex)
        {
            ConnectedProject = project;
            CmdExecutor = ex;

            InitializeComponent();

            projectName.Text = project.Name;
            this.Text = "Проект";

            SetupListView();
            UpdateTasksList();

        }


        /// <summary>
        /// Установка параметров для списка задач.
        /// </summary>
        private void SetupListView()
        {
            listView.Alignment = ListViewAlignment.Default;
            listView.View = View.List;
            listView.Scrollable = true;
            listView.MouseDoubleClick += OnListItemDoubleClick;
            listView.Scrollable = true;
        }

        /// <summary>
        /// Обработка двойного клика по задаче в списке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mouseEventArgs"></param>
        private void OnListItemDoubleClick(object sender, MouseEventArgs mouseEventArgs)
        {
            var senderList = (ListView)sender;
            var clickedItem = senderList.HitTest(mouseEventArgs.Location).Item;
            if (clickedItem != null)
            {
                var taskId = (int)clickedItem.Tag;
                var task = TaskManager.GetInstance().GetTaskByIdInProject(ConnectedProject, taskId);
                if (task == null) return;

                using var form = new TaskForm(ConnectedProject, task, CmdExecutor);
                form.ShowDialog();
            }
        }

        public void UpdateTasksList()
        {
            listView.Clear();
            foreach (var task in ConnectedProject.Tasks)
            {
                var item = new ListViewItem(task.ToString());
                // Запишем в метаданные элемента списка айди задачи.
                item.Tag = task.Id;
                listView.Items.Add(item);
            }
        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            using var nameForm = new InputDialog("Введите название задачи");
            nameForm.ShowDialog();
            var taskName = nameForm.Value;

            using var typeForm = new InputDialog("Введите тип задачи (epic, bug, task, story)");
            typeForm.ShowDialog();
            var taskType = typeForm.Value;

            var response = CmdExecutor.Execute($"add_task {ConnectedProject.Id} {taskType} {taskName}");
            MessageBox.Show(response.TextOutput,
                response.Status == CommandExecutionStatus.Fail ? "Ошибка" : "Сообщение");

            TaskManager.GetInstance().CommitChanges();
            UpdateTasksList();
        }

        private void removeProjectButton_Click(object sender, EventArgs e)
        {
            var result = CmdExecutor.Execute($"remove_project {ConnectedProject.Id}");
            if (result.Status == CommandExecutionStatus.OK)
            {
                MessageBox.Show(result.TextOutput, "Сообщение");
                Close();
            }
        }
    }
}