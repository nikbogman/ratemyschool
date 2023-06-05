using Core.Entities;
using Core.Entities.SchoolEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public static class Extensions
    {
        public static DataGridView Load<T>(this DataGridView dataGridView, IEnumerable<T> dataSrc)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = dataSrc;
            dataGridView.AutoGenerateColumns = true;
            if (dataSrc is IEnumerable<BaseSchoolEntity>)
            {
                dataGridView.Columns["Type"].Visible = false;
                dataGridView.Columns["TypeRank"].Visible = false;
                dataGridView.Columns["OverallRank"].Visible = false;
                dataGridView.Columns["Rating"].Visible = false;
            }
            else if (dataSrc is IEnumerable<UserEntity>)
            {
                dataGridView.Columns["Password"].Visible = false;
            }
            return dataGridView;
        }

        public static List<string> LoadPropsFromType(this ComboBox comboBox, Type type, Func<string, bool>? predictate = null)
        {
            List<string> dataSource = type
                .GetProperties()
                .Select(x => x.Name)
                .ToList();
            if (predictate != null)
            {
                dataSource = dataSource
                    .Where(predictate)
                    .ToList();
            }
            comboBox.DataSource = dataSource;
            comboBox.SelectedIndex = 0;
            return dataSource;
        }
    }
}
