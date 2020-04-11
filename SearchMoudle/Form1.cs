using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchMoudle
{
    public partial class SearchForm : Form
    {
        List<TestBaseData> DataList = new List<TestBaseData>();

        public SearchForm()
        {
            InitializeComponent();
            InitTestData();
            InitComboBox();
            SearchGrid.AutoGenerateColumns = true;   

        }

        private void InitTestData()
        {
            #region 데이터 세팅 
            DataList.Add(new TestBaseData()
            {
                Category = "먹을 거",
                Name = "밥",
                Feature = "한국인의 주식이에요",
                Cmmt = "꼬돌밥이 난 좋더라"
            });

            DataList.Add(new TestBaseData()
            {
                Category = "마실 거",
                Name = "콜라",
                Feature = "탄산음료",
                Cmmt = "언제나 맛있어요"
            });

            DataList.Add(new TestBaseData()
            {
                Category = "먹을 거",
                Name = "라면",
                Feature = "끊는 물이 필요해요",
                Cmmt = "라면은 진라면"
            });
            #endregion
        }

        private void InitComboBox()
        {
            List<string> Categorys = new List<string>();
            foreach (var Data in DataList)
            {             
                Categorys.Add(Data.Category);
            }

            SearchCbo.Items.AddRange(Categorys.ToArray());
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            SearchGrid.DataSource = null;

            // 1안 : Linq 사용하기
            var GridData = DataList.Where(x => x.Category == SearchCbo.Text);

            // 2안 : Foreach 사용하기
            List<TestBaseData> GridData2 = new List<TestBaseData>();

            foreach(TestBaseData data in DataList)
            {
                if (data.Category == SearchCbo.Text) GridData2.Add(data);
            }

            BindingSource source = new BindingSource();
            source.DataSource = GridData;

            SearchGrid.DataSource = source;
            SearchGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
        }

    }
    public class TestBaseData
    {
        public string Category { get; set; }

        public string Name { get; set; }

        public string Feature { get; set; }

        public string Cmmt { get; set; }

    }

}
