using HoursTracking.Model;
using HoursTracking.View;
using System.Collections.ObjectModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;

namespace HoursTracking.ViewModel
{
    class MainPageViewModel: BaseViewModel
    {
        private HoursTrackingContext db = new HoursTrackingContext();
        private AcademicYear academicYearSelected;
        public AcademicYear AcademicYearSelected
        {
            get => academicYearSelected;
            set 
            {
                academicYearSelected = value;
                OnPropertyChanged(nameof(AcademicYearSelected));
            }
        }
        public List<CertficationRow> ListCertification { get; set; } = new();
        public ObservableCollection<AcademicYear> UchYears { get; set; } = new();
        public MainPageViewModel()
        {
            GenerateGrid();
            var yearsList = db.AcademicYears.ToList();
            UchYears = new ObservableCollection<AcademicYear>(yearsList);
        }
        public void GenerateGrid()
        {
            int columnCount = 30; 
            for (int i = 0; i < 4; i++)
            {
                CertficationRow row = new CertficationRow();
                row.Teacher = "teacher" + (i + 1);
                row.Subject = "subject" + (i + 1);
                row.dayHours = new int[columnCount];
                Array.Fill(row.dayHours, 0);
                ListCertification.Add(row);
            }
            CertificationPage.Instance!.SertificationList.AutoGenerateColumns = true;
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Предмет", typeof(string)));
            dt.Columns.Add(new DataColumn("Преподаватель", typeof(string)));
            for (var i = 0; i < columnCount; i++)
                dt.Columns.Add(new DataColumn($"{i+1}", typeof(int)));
            dt.Columns.Add(new DataColumn("Итого", typeof(string)));
            for (int i=0;i< ListCertification.Count;i++)
            {
                var r = dt.NewRow();
                r[0] = ListCertification[i].Subject;
                r[1] = ListCertification[i].Teacher;
                for(int j = 2; j < columnCount+2;j++) r[j] = 0;
                dt.Rows.Add(r);
            }
            CertificationPage.Instance!.SertificationList.ItemsSource = dt.DefaultView;
        }
    }
}
