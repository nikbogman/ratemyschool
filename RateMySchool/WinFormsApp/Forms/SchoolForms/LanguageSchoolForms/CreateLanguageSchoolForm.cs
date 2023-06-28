using Core.Entities.SchoolEntities;
using WinFormsApp.Forms.BaseForms;

namespace WinFormsApp.Forms.SchoolForms
{
    public partial class CreateLanguageSchoolForm : CreateEntityForm
    {
        protected override Type EntityType => typeof(LanguageSchoolEntity);
        public CreateLanguageSchoolForm() : base() { }
    }
}
