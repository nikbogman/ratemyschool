using WinFormsApp.Forms.SchoolForms;
using WinFormsApp;
using Core.Managers;
using DAL.Repositories;
using Core.Services;
using Core.Managers.Schools;
using Core.Enums.Schools;
using Core.Entities.Schools;
using Core.Interfaces.Repositories;
using Core.Models.Schools;

namespace WinFormsApp.TabPages
{
    public partial class SchoolsTabPage : UserControl
    {
        const string connectionString = "Server=studmysql01.fhict.local;Uid=dbi500555;Database=dbi500555;Pwd=1234";
        private readonly LanguageSchoolManager _languageSchoolManager;
        private readonly Manager<ScienceSchoolEntity, ScienceSchoolModel> _stemSchoolManager;
        private readonly Manager<VocationalSchoolEntity, VocationalSchoolSchema> _specSchoolManager;

        public SchoolsTabPage()
        {
            IRepository<LanguageSchoolEntity> languageSchoolRepositoty = new SchoolRepository<LanguageSchoolEntity>(connectionString);
            _languageSchoolManager = new(languageSchoolRepositoty);

            IRepository<ScienceSchoolEntity> stemSchoolRepositoty = new SchoolRepository<ScienceSchoolEntity>(connectionString);
            _stemSchoolManager = new(stemSchoolRepositoty);

            IRepository<VocationalSchoolEntity> specSchoolRepositoty = new SchoolRepository<VocationalSchoolEntity>(connectionString);
            _specSchoolManager = new(specSchoolRepositoty);
            InitializeComponent();
        }

        public void PreloadPage()
        {
            filterComboBox.DataSource = Enum.GetValues(typeof(SchoolCategoryType));
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
                    case SchoolCategoryType.Language:
                        LanguageSchoolForm langForm = new(_languageSchoolManager);
                        if (langForm.ShowDialog() == DialogResult.OK && langForm.Data != null)
                        {
                            var dataSource = (List<LanguageSchoolEntity>)dataGridView.DataSource;
                            dataSource.Add(langForm.Data);
                            dataGridView.Load(dataSource);
                        }
                        break;
                    case SchoolCategoryType.STEM:
                        STEMSchoolForm stemSchoolForm = new(_stemSchoolManager);
                        if (stemSchoolForm.ShowDialog() == DialogResult.OK && stemSchoolForm.Data != null)
                        {
                            var dataSource = (List<ScienceSchoolEntity>)dataGridView.DataSource;
                            dataSource.Add(stemSchoolForm.Data);
                            dataGridView.Load(dataSource);
                        }
                        break;
                    case SchoolCategoryType.Specialized:
                        SpecializedSchoolForm specSchoolForm = new(_specSchoolManager);
                        if (specSchoolForm.ShowDialog() == DialogResult.OK && specSchoolForm.Data != null)
                        {
                            var dataSource = (List<VocationalSchoolEntity>)dataGridView.DataSource;
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
                    case SchoolCategoryType.Language:
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
                    case SchoolCategoryType.STEM:
                        var stemSchool = (ScienceSchoolEntity)dataBoundItem;
                        STEMSchoolForm stemSchoolForm = new(_stemSchoolManager, stemSchool);
                        if (stemSchoolForm.ShowDialog() == DialogResult.OK && stemSchoolForm.Data != null)
                        {
                            if (stemSchool != stemSchoolForm.Data)
                            {
                                var dataSource = (List<ScienceSchoolEntity>)dataGridView.DataSource;
                                int idx = dataSource.IndexOf(stemSchool);
                                dataSource.RemoveAt(idx);
                                dataSource.Insert(idx, stemSchoolForm.Data);
                                dataGridView.Load(dataSource);
                            }
                        }
                        break;
                    case SchoolCategoryType.Specialized:
                        var specSchool = (VocationalSchoolEntity)dataBoundItem;
                        SpecializedSchoolForm specSchoolForm = new(_specSchoolManager, specSchool);
                        if (specSchoolForm.ShowDialog() == DialogResult.OK && specSchoolForm.Data != null)
                        {
                            if (specSchool != specSchoolForm.Data)
                            {
                                var dataSource = (List<VocationalSchoolEntity>)dataGridView.DataSource;
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
                    case SchoolCategoryType.Language:
                        var langSchool = (LanguageSchoolEntity)dataBoundItem;
                        _languageSchoolManager.DeleteOne(langSchool.Id);
                        var langSchoolDataSource = (List<LanguageSchoolEntity>)dataGridView.DataSource;
                        langSchoolDataSource.Remove(langSchool);
                        dataGridView.Load(langSchoolDataSource);
                        break;
                    case SchoolCategoryType.STEM:
                        var stemSchool = (ScienceSchoolEntity)dataBoundItem;
                        _languageSchoolManager.DeleteOne(stemSchool.Id);
                        var stemSchoolDataSource = (List<ScienceSchoolEntity>)dataGridView.DataSource;
                        stemSchoolDataSource.Remove(stemSchool);
                        dataGridView.Load(stemSchoolDataSource);
                        break;
                    case SchoolCategoryType.Specialized:
                        var specSchool = (VocationalSchoolEntity)dataBoundItem;
                        _languageSchoolManager.DeleteOne(specSchool.Id);
                        var specSchoolDataSource = (List<VocationalSchoolEntity>)dataGridView.DataSource;
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
                    case SchoolCategoryType.Language:
                        form = (LanguageSchoolForm)new((LanguageSchoolEntity)dataBoundItem);
                        break;
                    case SchoolCategoryType.STEM:
                        form = (STEMSchoolForm)new((ScienceSchoolEntity)dataBoundItem);
                        break;
                    case SchoolCategoryType.Specialized:
                        form = (SpecializedSchoolForm)new((VocationalSchoolEntity)dataBoundItem);
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
                    case SchoolCategoryType.Language:
                        dataGridView.Load(_languageSchoolManager.GetAll());

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
                    case SchoolCategoryType.STEM:
                        dataGridView.Load(_stemSchoolManager.GetAll());

                        var stemSchools = SearchFilterService.Filter(
                            unfiltered: (IEnumerable<ScienceSchoolEntity>)dataGridView.DataSource,
                            propertyName: filterPropertyComboBox.Text,
                            searchValue
                        );
                        if (stemSchools == Enumerable.Empty<ScienceSchoolEntity>())
                        {
                            throw new Exception("There were no specialized schools found for this search");
                        }
                        dataGridView.Load(stemSchools);
                        break;
                    case SchoolCategoryType.Specialized:
                        dataGridView.Load(_specSchoolManager.GetAll());

                        var specSchools = SearchFilterService.Filter(
                            unfiltered: (IEnumerable<VocationalSchoolEntity>)dataGridView.DataSource,
                            propertyName: filterPropertyComboBox.Text,
                            searchValue
                        );
                        if (specSchools == Enumerable.Empty<VocationalSchoolEntity>())
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
                    case SchoolCategoryType.Language:
                        filterPropertyComboBox.LoadPropsFromType(typeof(LanguageSchoolEntity), predictate);
                        dataGridView.Load(_languageSchoolManager.GetAll());
                        break;
                    case SchoolCategoryType.STEM:
                        filterPropertyComboBox.LoadPropsFromType(typeof(ScienceSchoolEntity), predictate);
                        dataGridView.Load(_stemSchoolManager.GetAll());
                        break;
                    case SchoolCategoryType.Specialized:
                        filterPropertyComboBox.LoadPropsFromType(typeof(VocationalSchoolEntity), predictate);
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
