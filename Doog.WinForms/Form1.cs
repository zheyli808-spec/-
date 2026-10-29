using Mouse.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MouseModel = Mouse.Core.Models.Mouse;
using Mouse.DataAccessLayer;
using Mouse.Interfaces;


namespace Doog.WinForms
{
    public partial class Form1 : Form
    {


        private readonly Logic logic;

        public Form1()
        {
            InitializeComponent();

            //DBContext context = new DBContext();

            //IRepository<MouseModel> repository =
            //    new EntityRepository<MouseModel>(context);

            //logic = new Logic(repository);

            IRepository<MouseModel> repository =
                 new DapperRepository<MouseModel>();

            logic = new Logic(repository);

            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor.Items.Clear();
            cmbColor.Items.AddRange(Logic.MouseColors.ToArray());

            if (cmbColor.Items.Count > 0)
                cmbColor.SelectedIndex = 0;

            dgvMice.ReadOnly = true;
            dgvMice.AllowUserToAddRows = false;
            dgvMice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMice.MultiSelect = false;
            dgvMice.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnFindId.Click += btnFindId_Click;
            btnFindColor.Click += btnFindColor_Click;
            btnVaccinated.Click += btnVaccinated_Click;
            btnShowAll.Click += btnShowAll_Click;
            btnAverageWeight.Click += btnAverageWeight_Click;

            dgvMice.SelectionChanged += dgvMice_SelectionChanged;

            RefreshMice();
        }

        /// <summary>
        /// Обновляет список мышек в таблице.
        /// </summary>
        private void RefreshMice()
        {
            dgvMice.DataSource = null;
            dgvMice.DataSource = logic.GetAllMice();
        }

        /// <summary>
        /// Проверяет введённые данные и создаёт мышку.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbColor.SelectedItem == null)
                {
                    MessageBox.Show("Выберите цвет мышки.");
                    return;
                }

                MouseModel mouse = logic.CreateMouse(
                    txtName.Text.Trim(),
                    cmbColor.SelectedItem.ToString(),
                    (int)numAge.Value,
                    (double)numWeight.Value,
                    chkVaccinated.Checked);

                RefreshMice();
                ClearFields();

                MessageBox.Show("Мышка успешно добавлена. ID: " + mouse.Id);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        /// <summary>
        /// Изменяет данные мышки с указанным ID.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Введите корректный ID мышки.");
                return;
            }

            try
            {
                if (cmbColor.SelectedItem == null)
                {
                    MessageBox.Show("Выберите цвет мышки.");
                    return;
                }

                bool updated = logic.UpdateMouse(
                    id,
                    txtName.Text.Trim(),
                    cmbColor.SelectedItem.ToString(),
                    (int)numAge.Value,
                    (double)numWeight.Value,
                    chkVaccinated.Checked);

                if (!updated)
                {
                    MessageBox.Show("Мышка не найдена.");
                    return;
                }

                RefreshMice();
                ClearFields();
                MessageBox.Show("Данные изменены.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        /// <summary>
        /// Удаляет мышку по ID.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Введите корректный ID мышки.");
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Удалить выбранную мышку?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                return;

            if (logic.DeleteMouse(id))
            {
                RefreshMice();
                ClearFields();
                MessageBox.Show("Мышка удалена.");
            }
            else
            {
                MessageBox.Show("Мышка не найдена.");
            }
        }


        /// <summary>
        /// Вычисляет и показывает средний вес мышек.
        /// </summary>
        private void btnAverageWeight_Click(object sender, EventArgs e)
        {
            if (logic.GetAllMice().Count == 0)
            {
                MessageBox.Show("Список мышек пуст.");
                return;
            }

            double averageWeight = logic.GetAverageWeight();

            MessageBox.Show(
                $"Средний вес мышек: {averageWeight:F3} кг",
                "Средний вес",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        /// <summary>
        /// Очищает поля ввода, не изменяя таблицу.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        /// <summary>
        /// Ищет мышку по ID.
        /// </summary>
        private void btnFindId_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Введите корректный ID.");
                return;
            }

            MouseModel mouse = logic.GetMouseById(id);

            if (mouse == null)
            {
                MessageBox.Show("Мышка не найдена.");
                return;
            }

            dgvMice.DataSource = null;
            dgvMice.DataSource =
                new System.Collections.Generic.List<MouseModel> { mouse };

            FillFields(mouse);
        }

        /// <summary>
        /// Показывает мышек выбранного цвета.
        /// </summary>
        private void btnFindColor_Click(object sender, EventArgs e)
        {
            if (cmbColor.SelectedItem == null)
            {
                MessageBox.Show("Выберите цвет.");
                return;
            }

            dgvMice.DataSource = null;
            dgvMice.DataSource = logic.GetMiceByColor(
                cmbColor.SelectedItem.ToString());
        }

        /// <summary>
        /// Показывает только привитых мышек.
        /// </summary>
        private void btnVaccinated_Click(object sender, EventArgs e)
        {
            dgvMice.DataSource = null;
            dgvMice.DataSource = logic.GetVaccinatedMice();
        }

        /// <summary>
        /// Показывает всех мышек.
        /// </summary>
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            RefreshMice();
        }

        /// <summary>
        /// Заполняет поля данными выбранной мышки.
        /// </summary>
        private void dgvMice_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMice.CurrentRow == null ||
                dgvMice.CurrentRow.DataBoundItem == null)
                return;

            if (dgvMice.CurrentRow.DataBoundItem is MouseModel mouse)
                FillFields(mouse);
        }

        /// <summary>
        /// Переносит данные мышки в поля формы.
        /// </summary>
        private void FillFields(MouseModel mouse)
        {
            txtId.Text = mouse.Id.ToString();
            txtName.Text = mouse.Name;
            cmbColor.SelectedItem = mouse.Color;

            numAge.Value = Math.Min(
                numAge.Maximum,
                Math.Max(numAge.Minimum, mouse.Age));

            decimal weight = (decimal)mouse.Weight;
            numWeight.Value = Math.Min(
                numWeight.Maximum,
                Math.Max(numWeight.Minimum, weight));

            chkVaccinated.Checked = mouse.IsVaccinated;
        }

        /// <summary>
        /// Очищает поля и сбрасывает выбор мышки.
        /// </summary>
        private void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();

            if (cmbColor.Items.Count > 0)
                cmbColor.SelectedIndex = 0;

            numAge.Value = numAge.Minimum;
            numWeight.Value = numWeight.Minimum;
            chkVaccinated.Checked = false;

            dgvMice.ClearSelection();
        }
















        private void lblId_Click(object sender, EventArgs e)
        {

        }

        private void lblColor_Click(object sender, EventArgs e)
        {

        }

        private void lblAge_Click(object sender, EventArgs e)
        {

        }

        private void numWeight_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnShowAll_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvMice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
