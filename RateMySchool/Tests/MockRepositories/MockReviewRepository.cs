using Core.Entities;
using Core.Enums;
using Core.Interfaces.RepositoryInterfaces;
using System.Data;

namespace Tests.MockRepositories
{
    public class MockReviewRepository : MockRepository<ReviewEntity>, IReviewRepository
    {
        public bool UpdateReportedStatus(Guid id) { return true; }
        public DataTable AverageRatingForeachSchool()
        {
            DataTable dt = new();
            dt.Columns.Add("Average", typeof(float));
            dt.Columns.Add("SchoolId", typeof(Guid));
            dt.Columns.Add("SchoolType", typeof(SchoolType));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("BirthYear", typeof(int));

            DataRow row1 = dt.NewRow();
            row1["Average"] = Utilities.GenerateRandomFloat(1, 5);
            row1["SchoolId"] = Guid.NewGuid();
            row1["SchoolType"] = SchoolType.Language;
            row1["City"] = "Sofia";
            row1["BirthYear"] = 2001;
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["Average"] = Utilities.GenerateRandomFloat(1, 5);
            row2["SchoolId"] = Guid.NewGuid();
            row2["SchoolType"] = SchoolType.STEM;
            row2["City"] = "Sofia";
            row2["BirthYear"] = 2002;
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["Average"] = Utilities.GenerateRandomFloat(1, 5);
            row3["SchoolId"] = Guid.NewGuid();
            row3["SchoolType"] = SchoolType.STEM;
            row3["City"] = "Varna";
            row3["BirthYear"] = 2003;
            dt.Rows.Add(row3);

            return dt;
        }

        public IEnumerable<ReviewEntity> SelectAllBySchoolId(Guid schoolId) => _mockData.Where(r => r.SchoolId == schoolId);
    }
}
