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
    public partial class TaskForm : Form
    {
        private CommandExecutor CmdExecutor { get; }
        private Task ConnectedTask { get; }
        private Project ConnectedProject { get; }

        public TaskForm(Project project, Task task, CommandExecutor ex)
        {
            ConnectedTask = task;
            ConnectedProject = project;
            CmdExecutor = ex;
            InitializeComponent();
            UpdateExecutorsComboBox();

            label1.Text = task.Name;
            label4.Text = $"Создана {task.CreationDate.ToString()}";
        }

        private void addExecutorButton_Click(object sender, EventArgs e)
        {
            var dialog = new InputDialog("Введите имя пользователя");
            dialog.ShowDialog();
            var userName = dialog.Value;
            var user = TaskManager.GetInstance().GetUserByName(userName);

            if (user == null)
            {
                MessageBox.Show("Такого пользователя не существует.", "Ошибка");
                return;
            }

            var result = CmdExecutor.Execute(
                $"add_executor {ConnectedProject.Id} {ConnectedTask.Id} {user.Id}");

            MessageBox.Show(result.TextOutput, "Сообщение");
            TaskManager.GetInstance().CommitChanges();
            UpdateExecutorsComboBox();

        }

        private void UpdateExecutorsComboBox()
        {
            var executors = (ConnectedTask as IAssignable).Executors;
            executorsComboBox.Items.Clear();
            foreach(var user in executors)
            {
                executorsComboBox.Items.Add(user.Name);
            }
        }

        private void removeExecutorButton_Click(object sender, EventArgs e)
        {
            if (executorsComboBox.SelectedItem == null) return;
            string userName = (string)executorsComboBox.SelectedItem;
            //MessageBox.Show($"you want to remove {userName}", "");

            var user = TaskManager.GetInstance().GetUserByName(userName);
            if (user == null) return;

            var result = CmdExecutor.Execute(
                $"remove_executor {ConnectedProject.Id} {ConnectedTask.Id} {user.Id}");
            MessageBox.Show(result.TextOutput, "Сообщение");

            UpdateExecutorsComboBox();
            TaskManager.GetInstance().CommitChanges();
        }

        private void statusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
