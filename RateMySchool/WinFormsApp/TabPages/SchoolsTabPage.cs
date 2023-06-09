using Core.Enums;
using WinFormsApp.Forms.SchoolForms;
using WinFormsApp;
using Core.Entities.SchoolEntities;
using Core.Managers.SchoolManagers;
using DAL.Repositories.SchoolRepositories;
using Core.FeatureManagers;
using Core.Interfaces.RepositoryInterfaces;

namespace WinFormsApp.TabPages
{
    public partial class SchoolsTabPage : UserControl
    {
        const string connectionString = "Server=localhost;Uid=root;Database=ratemyschool;Pwd=rootpass";
        private readonly LanguageSchoolManager _languageSchoolManager;
        private readonly STEMSchoolManager _stemSchoolManager;
        private readonly SpecializedSchoolManager _specSchoolManager;

        public SchoolsTabPage()
        {
            LanguageSchoolRepository languageSchoolRepositoty = new(connectionString);
            _languageSchoolManager = new(languageSchoolRepositoty);

            STEMSchoolRepository stemSchoolRepositoty = new(connectionString);
            _stemSchoolManager = new(stemSchoolRepositoty);

            SpecializedSchoolRepository specSchoolRepositoty = new(connectionString);
            _specSchoolManager = new(specSchoolRepositoty);
            InitializeComponent();
        }

        public void PreloadPage()
        {
            filterComboBox.DataSource = Enum.GetValues(typeof(SchoolType));
            filterComboBox.SelectedIndex = 0;

            filterPropertyComboBox.LoadPropsFromType(typeof(LanguageSchoolEntity), x => !x.Contains("Type") && !x.Contains("Rank") && x != "Rating");
            dataGridView.Load(_languageSchoolManager.GetAll());
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                switch (filterComboBox.SelectedItem)
                {
                    case SchoolType.Language:
                        LanguageSchoolForm langForm = new(_languageSchoolManager);
                        if (langForm.ShowDialog() == DialogResult.OK && langForm.Data != null)
                        {
                            var dataSource = (List<LanguageSchoolEntity>)dataGridView.DataSource;
                            dataSource.Add(langForm.Data);
                            dataGridView.Load(dataSource);
                        }
                        break;
                    case SchoolType.STEM:
                        STEMSchoolForm stemSchoolForm = new(_stemSchoolManager);
                        if (stemSchoolForm.ShowDialog() == DialogResult.OK && stemSchoolForm.Data != null)
                        {
                            var dataSource = (List<STEMSchoolEntity>)dataGridView.DataSource;
                            dataSource.Add(stemSchoolForm.Data);
                            dataGridView.Load(dataSource);
                        }
                        break;
                    case SchoolType.Specialized:
                        SpecializedSchoolForm specSchoolForm = new(_specSchoolManager);
                        if (specSchoolForm.ShowDialog() == DialogResult.OK && specSchoolForm.Data != null)
                        {
                            var dataSource = (List<SpecializedSchoolEntity>)dataGridView.DataSource;
                            dataSource.Add(specSchoolForm.Data);
                            dataGridView.Load(dataSource);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var dataBoundItem = dataGridView.SelectedRows.Count <= 0 ? null : dataGridView.SelectedRows[0].DataBoundItem;
                if (dataBoundItem == null)
                {
                    throw new Exception("Row with school has to be selected in order to delete it");
                }
                switch (filterComboBox.SelectedItem)
                {
                    case SchoolType.Language:
                        var langSchool = (LanguageSchoolEntity)dataBoundItem;
                        LanguageSchoolForm form = new(_languageSchoolManager, langSchool);
                        if (form.ShowDialog() == DialogResult.OK && form.Data != null)
                        {
                            if (langSchool != form.Data)
                            {
                                var dataSource = (List<LanguageSchoolEntity>)dataGridView.DataSource;
                                int idx = dataSource.IndexOf(langSchool);
                                dataSource.RemoveAt(idx);
                                dataSource.Insert(idx, form.Data);
                                dataGridView.Load(dataSource);
                            }
                        }
                        break;
                    case SchoolType.STEM:
                        var stemSchool = (STEMSchoolEntity)dataBoundItem;
                        STEMSchoolForm stemSchoolForm = new(_stemSchoolManager, stemSchool);
                        if (stemSchoolForm.ShowDialog() == DialogResult.OK && stemSchoolForm.Data != null)
                        {
                            if (stemSchool != stemSchoolForm.Data)
                            {
                                var dataSource = (List<STEMSchoolEntity>)dataGridView.DataSource;
                                int idx = dataSource.IndexOf(stemSchool);
                                dataSource.RemoveAt(idx);
                                dataSource.Insert(idx, stemSchoolForm.Data);
                                dataGridView.Load(dataSource);
                            }
                        }
                        break;
                    case SchoolType.Specialized:
                        var specSchool = (SpecializedSchoolEntity)dataBoundItem;
                        SpecializedSchoolForm specSchoolForm = new(_specSchoolManager, specSchool);
                        if (specSchoolForm.ShowDialog() == DialogResult.OK && specSchoolForm.Data != null)
                        {
                            if (specSchool != specSchoolForm.Data)
                            {
                                var dataSource = (List<SpecializedSchoolEntity>)dataGridView.DataSource;
                                int idx = dataSource.IndexOf(specSchool);
                                dataSource.RemoveAt(idx);
                                dataSource.Insert(idx, specSchoolForm.Data);
                                dataGridView.Load(dataSource);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var dataBoundItem = dataGridView.SelectedRows[0].DataBoundItem;
                if (dataGridView.SelectedRows.Count <= 0 || dataBoundItem == null)
                {
                    throw new Exception("Row with school has to be selected in order to delete it");
                }
                switch (filterComboBox.SelectedItem)
                {
                    case SchoolType.Language:
                        var langSchool = (LanguageSchoolEntity)dataBoundItem;
                        _languageSchoolManager.DeleteOne(langSchool.Id);
                        var langSchoolDataSource = (List<LanguageSchoolEntity>)dataGridView.DataSource;
                        langSchoolDataSource.Remove(langSchool);
                        dataGridView.Load(langSchoolDataSource);
                        break;
                    case SchoolType.STEM:
                        var stemSchool = (STEMSchoolEntity)dataBoundItem;
                        _languageSchoolManager.DeleteOne(stemSchool.Id);
                        var stemSchoolDataSource = (List<STEMSchoolEntity>)dataGridView.DataSource;
                        stemSchoolDataSource.Remove(stemSchool);
                        dataGridView.Load(stemSchoolDataSource);
                        break;
                    case SchoolType.Specialized:
                        var specSchool = (SpecializedSchoolEntity)dataBoundItem;
                        _languageSchoolManager.DeleteOne(specSchool.Id);
                        var specSchoolDataSource = (List<SpecializedSchoolEntity>)dataGridView.DataSource;
                        specSchoolDataSource.Remove(specSchool);
                        dataGridView.Load(specSchoolDataSource);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void detailsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var dataBoundItem = dataGridView.SelectedRows[0].DataBoundItem;
                if (dataGridView.SelectedRows.Count <= 0 || dataBoundItem == null)
                {
                    throw new Exception("Row with school has to be selected in order to view its details");
                }
                Form? form = null;
                switch (filterComboBox.SelectedItem)
                {
                    case SchoolType.Language:
                        form = (LanguageSchoolForm)new((LanguageSchoolEntity)dataBoundItem);
                        break;
                    case SchoolType.STEM:
                        form = (STEMSchoolForm)new((STEMSchoolEntity)dataBoundItem);
                        break;
                    case SchoolType.Specialized:
                        form = (SpecializedSchoolForm)new((SpecializedSchoolEntity)dataBoundItem);
                        break;
                    default:
                        break;
                }
                if (form == null)
                {
                    throw new Exception("Something went wrong. Viewing details not possible");
                }
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = filterValueTextBox.Text;
                if (searchValue == null || searchValue == string.Empty)
                {
                    throw new Exception("Value needs to be provided for search filtering");
                }
                switch (filterComboBox.SelectedItem)
                {
                    case SchoolType.Language:
                        var langSchools = SearchFilterService.Filter(
                            unfiltered: (IEnumerable<LanguageSchoolEntity>)dataGridView.DataSource,
                            propertyName: filterPropertyComboBox.Text,
                            searchValue
                        );
                        if (langSchools == Enumerable.Empty<LanguageSchoolEntity>())
                        {
                            throw new Exception("There were no language schools found for this search");
                        }
                        dataGridView.Load(langSchools);
                        break;
                    case SchoolType.STEM:
                        var stemSchools = SearchFilterService.Filter(
                            unfiltered: (IEnumerable<STEMSchoolEntity>)dataGridView.DataSource,
                            propertyName: filterPropertyComboBox.Text,
                            searchValue
                        );
                        if (stemSchools == Enumerable.Empty<STEMSchoolEntity>())
                        {
                            throw new Exception("There were no specialized schools found for this search");
                        }
                        dataGridView.Load(stemSchools);
                        break;
                    case SchoolType.Specialized:
                        var specSchools = SearchFilterService.Filter(
                            unfiltered: (IEnumerable<SpecializedSchoolEntity>)dataGridView.DataSource,
                            propertyName: filterPropertyComboBox.Text,
                            searchValue
                        );
                        if (specSchools == Enumerable.Empty<SpecializedSchoolEntity>())
                        {
                            throw new Exception("There were no stem schools found for this search");
                        }
                        dataGridView.Load(specSchools);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                filterValueTextBox.Clear();
                dataGridView.Load(_languageSchoolManager.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                static bool predictate(string x) => !x.Contains("Type") && !x.Contains("Rank") && x != "Rating";
                switch (filterComboBox.SelectedItem)
                {
                    case SchoolType.Language:
                        filterPropertyComboBox.LoadPropsFromType(typeof(LanguageSchoolEntity), predictate);
                        dataGridView.Load(_languageSchoolManager.GetAll());
                        break;
                    case SchoolType.STEM:
                        filterPropertyComboBox.LoadPropsFromType(typeof(STEMSchoolEntity), predictate);
                        dataGridView.Load(_stemSchoolManager.GetAll());
                        break;
                    case SchoolType.Specialized:
                        filterPropertyComboBox.LoadPropsFromType(typeof(SpecializedSchoolEntity), predictate);
                        dataGridView.Load(_specSchoolManager.GetAll());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
