using System;
using System.Windows.Forms;

using TaskManagerAPI;
using TaskManagerCLI;

namespace TaskManagerGUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// В наглую забираем весь функционал у консольной версии приложения.
        /// </summary>
        public CommandExecutor CmdExecutor { get; }

        public MainForm()
        {
            InitializeComponent();
            
            CmdExecutor = new CommandExecutor();
            SetupListView();
            UpdateProjectsList();
            
        }
        
        /// <summary>
        /// Установка параметров для списка проектов.
        /// </summary>
        private void SetupListView()
        {
            listView.Alignment = ListViewAlignment.Default;
            listView.View = View.List;
            listView.Scrollable = true;
            listView.MouseDoubleClick += OnListItemDoubleClick;
        }
        
        /// <summary>
        /// Обработка двойного клика по проекту в списке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mouseEventArgs"></param>
        private void OnListItemDoubleClick(object sender, MouseEventArgs mouseEventArgs)
        {
            var senderList = (ListView) sender;
            var clickedItem = senderList.HitTest(mouseEventArgs.Location).Item;
            if (clickedItem != null)
            {
                using var form = new ProjectForm((clickedItem as ProjectListViewItem).ConnectedProject, CmdExecutor);
                var result = form.ShowDialog();
                UpdateProjectsList();
            }
        }

        /// <summary>
        /// Вызывается диалоговое окно для ввода
        /// названия проекта, затем вызывается команда
        /// add_project от этого названия.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createProjectButton_Click(object sender, EventArgs e)
        {
            using var form = new InputDialog("Введите название проекта");
            var result = form.ShowDialog();

            //if (result != DialogResult.OK) return;

            var response = CmdExecutor.Execute($"add_project {form.Value}");
            MessageBox.Show(response.TextOutput,
                response.Status == CommandExecutionStatus.Fail ? "Ошибка" : "Сообщение");
            
            TaskManager.GetInstance().CommitChanges();
            UpdateProjectsList();
        }
        
        /// <summary>
        /// Заново читает список проектов и отображает
        /// его в listView.
        /// </summary>
        private void UpdateProjectsList()
        {
            listView.Items.Clear();
            foreach (var project in TaskManager.GetInstance().Projects)
            {
                listView.Items.Add(new ProjectListViewItem(project));
            }
        }

        private void usersManageButton_Click(object sender, EventArgs e)
        {
            using var form = new UsersForm(CmdExecutor);
            var result = form.ShowDialog();
        }
    }
}