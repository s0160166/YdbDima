using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using Ydb.Sdk;
using Ydb.Sdk.Auth;
using Ydb.Sdk.Services.Table;
using Ydb.Sdk.Value;

namespace OnlineStore
{
    public partial class Form1 : Form
    {

        private string id = "";
        private int intRow = 0;
        private string nameTable = "Статьи расходов";
        private string connectNameTable = "Customers";
        private Driver driver;
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();
            resetMe();
            InitDB();

        }

        private async Task InitDB()
        {
            var endpoint = "grpcs://ydb.serverless.yandexcloud.net:2135";
            var database = "/ru-central1/b1gebuccfmmtc1qihoic/etnj23s4i8hm0m3lm86c";
            var token = "t1.9euelZqLl5KZmpfJk4qLm5rJmcrHle3rnpWazs7Kmc6Mns6YlIyVkZSajJzl8_doGwtQ-e88Py1Q_N3z9yhKCFD57zw_LVD8zef1656Vmseaj8mdnIuVnMqbk5KTyMiJ7_zF656Vmseaj8mdnIuVnMqbk5KTyMiJ.fmqNBet5JZ6Icjmi1fCSC7HJiQXN3Kuw-YNLutL9tAq0-A3gBlU8fk_68iN0wU871CIxuonURzXPVvKO9N36CQ";
            var config = new DriverConfig(
                endpoint: endpoint,
                database: database,
                credentials: new TokenProvider(token)
            );

            driver = new Driver(
                config: config
            );

            await driver.Initialize();
            loadData();
        }

        private void resetMe()
        {
            id = string.Empty;


        }

        private async Task loadData()
        {

            var tableClient = new TableClient(driver, new TableClientConfig());

            switch (nameTable)
            {
                case "Статьи расходов":
                    connectNameTable = "Expence_item";
                    break;
                case "Отделы":
                    connectNameTable = "Department";
                    break;
                default:
                    break;
            }

            var response = await tableClient.SessionExec(async session =>
            {
                var query = @$"SELECT * FROM {connectNameTable}";

                return await session.ExecuteDataQuery(
                query: query,
                txControl: TxControl.BeginSerializableRW().Commit()
                );
            });

            response.Status.EnsureSuccess();
            var queryResponse = (ExecuteDataQueryResponse)response;
            var resultSet = queryResponse.Result.ResultSets[0];

            dt = new DataTable();

            switch (nameTable)
            {
                case "Статьи расходов":
                    dt.Columns.Add("id", typeof(ulong));
                    dt.Columns.Add("Статья расходов", typeof(string));
                    dt.Columns.Add("Выделено", typeof(ulong));
                    foreach (var row in resultSet.Rows)
                    {
                        dt.Rows.Add((ulong?)row["id"], (string?)row["name"], (ulong?)row["summ"]);
                    }
                    break;
                case "Отделы":
                    dt.Columns.Add("id", typeof(ulong));
                    dt.Columns.Add("Отдел", typeof(string));
                    dt.Columns.Add("Зарплата", typeof(ulong));
                    dt.Columns.Add("Отпускные", typeof(ulong));
                    dt.Columns.Add("Новое оборудование", typeof(ulong));
                    dt.Columns.Add("Трансфер", typeof(ulong));
                    dt.Columns.Add("Подарки детям на новый год", typeof(ulong));
                    foreach (var row in resultSet.Rows)
                    {
                        dt.Rows.Add((ulong?)row["id"], (string?)row["name"], (ulong?)row["expence_1"], (ulong?)row["expence_2"], (ulong?)row["expence_3"], (ulong?)row["expence_4"], (ulong?)row["expence_5"]);
                    }
                    break;
                default:
                    break;
            }

            if (dt.Rows.Count > 0)
            {
                intRow = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            else
            {
                intRow = 0;
            }

            toolStripStatusLabel1.Text = "Number of row(s): " + intRow.ToString();

            DataGridView dgv1 = dataGridView1;

            dgv1.MultiSelect = false;
            dgv1.AutoGenerateColumns = true;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv1.DataSource = dt;

            dgv1.Columns[0].Width = 55;
        }

        private ulong GetLastIdFromTable()
        {
            ulong maxId = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((ulong)dt.Rows[i]["Id"] > maxId)
                    maxId = (ulong)dt.Rows[i]["Id"];
            }
            return maxId + 1;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameTable = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            loadData();
            resetMe();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridView dgv1 = dataGridView1;
                this.id = Convert.ToString(dgv1.CurrentRow.Cells[0].Value);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private async void ExpenceInsertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ExpenceNameTextBox.Text.Trim()))
            {
                MessageBox.Show("Пожалуйста введите ФИО полностью.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tableClient = new TableClient(driver, new TableClientConfig());

            var response = await tableClient.SessionExec(async session =>
            {
                var query = @"
                    DECLARE $id AS Uint64;
                    DECLARE $name AS Utf8;
                    DECLARE $summ AS Uint64;


                    UPSERT INTO Expence_item (id, name, summ) VALUES
                        ($id, $name, $summ);
                ";

                return await session.ExecuteDataQuery(
                    query: query,
                    txControl: TxControl.BeginSerializableRW().Commit(),
                    parameters: new Dictionary<string, YdbValue>
                        {
                { "$id", YdbValue.MakeUint64(GetLastIdFromTable()) },
                { "$name", YdbValue.MakeUtf8(ExpenceNameTextBox.Text.Trim()) },
                { "$summ", YdbValue.MakeUint64(Convert.ToUInt64(ExpenceSumTextBox.Text.Trim())) },
                        }
                );
            });

            response.Status.EnsureSuccess();
            if (response.Status.StatusCode == StatusCode.Success)
                MessageBox.Show("Данные сохранены.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadData();
            resetMe();
        }

        private async void ExpenceUpdateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Пожалуйста выберите элемент из списка.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(ExpenceNameTextBox.Text.Trim()))
            {
                MessageBox.Show("Пожалуйста введите ФИО полностью.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tableClient = new TableClient(driver, new TableClientConfig());

            var response = await tableClient.SessionExec(async session =>
            {
                var query = @"
                    DECLARE $id AS Uint64;
                    DECLARE $name AS Utf8;
                    DECLARE $summ AS Uint64;


                    UPSERT INTO Expence_item (id, name, summ) VALUES
                        ($id, $name, $summ);
                ";

                return await session.ExecuteDataQuery(
                    query: query,
                    txControl: TxControl.BeginSerializableRW().Commit(),
                    parameters: new Dictionary<string, YdbValue>
                        {
                { "$id", YdbValue.MakeUint64(ulong.Parse(this.id)) },
                { "$name", YdbValue.MakeUtf8(ExpenceNameTextBox.Text.Trim()) },
                { "$summ", YdbValue.MakeUint64(Convert.ToUInt64(ExpenceSumTextBox.Text.Trim())) },
                        }
                );
            });

            response.Status.EnsureSuccess();
            if (response.Status.StatusCode == StatusCode.Success)
                MessageBox.Show("Данные сохранены.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadData();
            resetMe();
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("Пожалуйста выберите элемент из списка.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Вы уверены что хотите удалить данный элемент?", "Удаление данных",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                var tableClient = new TableClient(driver, new TableClientConfig());


                var response = await tableClient.SessionExec(async session =>
                {
                    var query = @$"
                        DECLARE $id AS Uint64;        

                        DELETE FROM {connectNameTable} WHERE id == $id;
                    ";

                    return await session.ExecuteDataQuery(
                        query: query,
                        txControl: TxControl.BeginSerializableRW().Commit(),
                        parameters: new Dictionary<string, YdbValue>
                            {
                { "$id", YdbValue.MakeUint64(ulong.Parse(this.id)) }
                            }
                    );
                });
                response.Status.EnsureSuccess();
                if (response.Status.StatusCode == StatusCode.Success)
                    MessageBox.Show("Элемент был удален.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadData();
                resetMe();
            }

        }
        


        private async void ReportDapartment_Click(object sender, EventArgs e)
        {
           dt.Clear();
           dt = new DataTable();
            dt.Columns.Add("id", typeof(ulong));
            dt.Columns.Add("Отдел", typeof(string));
            dt.Columns.Add("Зарплата", typeof(ulong));
            dt.Columns.Add("Отпускные", typeof(ulong));
            dt.Columns.Add("Новое оборудование", typeof(ulong));
            dt.Columns.Add("Трансфер", typeof(ulong));
            dt.Columns.Add("Подарки детям на новый год", typeof(ulong));
            var tableClient = new TableClient(driver, new TableClientConfig());

           var response = await tableClient.SessionExec(async session =>
           {
               var query = @$"SELECT id,name,expence_1 FROM Department WHERE expence_1 > 30000000;";

               return await session.ExecuteDataQuery(
               query: query,
               txControl: TxControl.BeginSerializableRW().Commit()
               );
           });
           response.Status.EnsureSuccess();
           var queryResponse = (ExecuteDataQueryResponse)response;
           var resultSet = queryResponse.Result.ResultSets[0];

            foreach (var row in resultSet.Rows)
            {
                dt.Rows.Add((ulong?)row["id"], (string?)row["name"], (ulong?)row["expence_1"], 0, 0, 0, 0);
            }
            response = await tableClient.SessionExec(async session =>
            {
                var query = @$"SELECT id,name,expence_2 FROM Department WHERE expence_2 > 10000000;";

                return await session.ExecuteDataQuery(
                query: query,
                txControl: TxControl.BeginSerializableRW().Commit()
                );
            });
            response.Status.EnsureSuccess();
            queryResponse = (ExecuteDataQueryResponse)response;
            resultSet = queryResponse.Result.ResultSets[0];

            foreach (var row in resultSet.Rows)
            {
                dt.Rows.Add((ulong?)row["id"], (string?)row["name"], 0, (ulong?)row["expence_2"], 0, 0, 0);
            }
            response = await tableClient.SessionExec(async session =>
            {
                var query = @$"SELECT id,name,expence_3 FROM Department WHERE expence_3 > 5000000;";

                return await session.ExecuteDataQuery(
                query: query,
                txControl: TxControl.BeginSerializableRW().Commit()
                );
            });
            response.Status.EnsureSuccess();
            queryResponse = (ExecuteDataQueryResponse)response;
            resultSet = queryResponse.Result.ResultSets[0];

            foreach (var row in resultSet.Rows)
            {
                dt.Rows.Add((ulong?)row["id"], (string?)row["name"], 0, 0,(ulong?)row["expence_3"], 0, 0);
            }
            response = await tableClient.SessionExec(async session =>
            {
                var query = @$"SELECT id,name,expence_4 FROM Department WHERE expence_4 > 1000000;";

                return await session.ExecuteDataQuery(
                query: query,
                txControl: TxControl.BeginSerializableRW().Commit()
                );
            });
            response.Status.EnsureSuccess();
            queryResponse = (ExecuteDataQueryResponse)response;
            resultSet = queryResponse.Result.ResultSets[0];

            foreach (var row in resultSet.Rows)
            {
                dt.Rows.Add((ulong?)row["id"], (string?)row["name"], 0, 0, 0,(ulong?)row["expence_4"], 0);
            }
            response = await tableClient.SessionExec(async session =>
            {
                var query = @$"SELECT id,name,expence_5 FROM Department WHERE expence_5 > 500000;";

                return await session.ExecuteDataQuery(
                query: query,
                txControl: TxControl.BeginSerializableRW().Commit()
                );
            });
            response.Status.EnsureSuccess();
            queryResponse = (ExecuteDataQueryResponse)response;
            resultSet = queryResponse.Result.ResultSets[0];

            foreach (var row in resultSet.Rows)
            {
                dt.Rows.Add((ulong?)row["id"], (string?)row["name"], 0, 0, 0, 0,(ulong?)row["expence_5"]);
            }

            DataGridView dgv1 = dataGridView1;

           dgv1.MultiSelect = false;
           dgv1.AutoGenerateColumns = true;
           dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

           dgv1.DataSource = dt;

           dgv1.Columns[0].Width = 55;
        }
       /*
private async void ReportProduct_Click(object sender, EventArgs e)
{
   dt.Clear();
   dt = new DataTable();
   var tableClient = new TableClient(driver, new TableClientConfig());

   var response = await tableClient.SessionExec(async session =>
   {
       var query = @$"SELECT * FROM ProductsReport";

       return await session.ExecuteDataQuery(
       query: query,
       txControl: TxControl.BeginSerializableRW().Commit()
       );
   });
   response.Status.EnsureSuccess();
   var queryResponse = (ExecuteDataQueryResponse)response;
   var resultSet = queryResponse.Result.ResultSets[0];



   dt.Columns.Add("Id", typeof(ulong));
   dt.Columns.Add("Название товара", typeof(string));
   dt.Columns.Add("Заказано на сумму", typeof(ulong));
   dt.Columns.Add("Доставлено на сумму", typeof(ulong));
   foreach (var row in resultSet.Rows)
   {
       dt.Rows.Add((ulong?)row["Id"], (string?)row["ProductName"], (ulong?)row["OrderedPrice"], (ulong?)row["DeliveredPrice"]);
   }

   DataGridView dgv1 = dataGridView1;

   dgv1.MultiSelect = false;
   dgv1.AutoGenerateColumns = true;
   dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

   dgv1.DataSource = dt;

   dgv1.Columns[0].Width = 55;
}


*/
    }
}