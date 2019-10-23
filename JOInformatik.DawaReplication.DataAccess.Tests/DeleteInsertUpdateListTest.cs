using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace JOInformatik.DawaReplication.DataAccess.Tests
{
    [TestClass]
    public class UnitTest
    {
        public const string TxidEjerlav1d = "{ \"txid\": 1,  \"operation\": \"delete\",  \"tidspunkt\": \"2019-03-11T23:50:12.674Z\",  \"sekvensnummer\": 110006809,  \"data\": { \"kode\": 101,    \"navn\": \"Klakring By, Klakring\",    \"geo_version\": 3,    \"geo_ændret\": \"2019-03-11T23:50:12.673Z\",    \"ændret\": \"2019-03-11T23:50:12.673Z\"  }}";
        public const string TxidEjerlav2d = "{ \"txid\": 2,  \"operation\": \"delete\",  \"tidspunkt\": \"2019-03-11T23:50:12.674Z\",  \"sekvensnummer\": 110006809,  \"data\": { \"kode\": 102,    \"navn\": \"Klakring By, Klakring\",    \"geo_version\": 3,    \"geo_ændret\": \"2019-03-11T23:50:12.673Z\",    \"ændret\": \"2019-03-11T23:50:12.673Z\"  }}";
        public const string TxidEjerlav3d = "{ \"txid\": 3,  \"operation\": \"delete\",  \"tidspunkt\": \"2019-03-11T23:50:12.674Z\",  \"sekvensnummer\": 110006809,  \"data\": { \"kode\": 103,    \"navn\": \"Klakring By, Klakring\",    \"geo_version\": 3,    \"geo_ændret\": \"2019-03-11T23:50:12.673Z\",    \"ændret\": \"2019-03-11T23:50:12.673Z\"  }}";
        public const string TxidEjerlav4d = "{ \"txid\": 4,  \"operation\": \"delete\",  \"tidspunkt\": \"2019-03-11T23:50:12.674Z\",  \"sekvensnummer\": 110006809,  \"data\": { \"kode\": 104,    \"navn\": \"Klakring By, Klakring\",    \"geo_version\": 3,    \"geo_ændret\": \"2019-03-11T23:50:12.673Z\",    \"ændret\": \"2019-03-11T23:50:12.673Z\"  }}";
        public const string TxidEjerlav5d = "{ \"txid\": 5,  \"operation\": \"delete\",  \"tidspunkt\": \"2019-03-11T23:50:12.674Z\",  \"sekvensnummer\": 110006809,  \"data\": { \"kode\": 105,    \"navn\": \"Klakring By, Klakring\",    \"geo_version\": 3,    \"geo_ændret\": \"2019-03-11T23:50:12.673Z\",    \"ændret\": \"2019-03-11T23:50:12.673Z\"  }}";
        public const string TxidEjerlav1u = "{ \"txid\": 6,  \"operation\": \"update\",  \"tidspunkt\": \"2019-03-11T23:50:12.674Z\",  \"sekvensnummer\": 110006809,  \"data\": { \"kode\": 101,    \"navn\": \"Klakring By, Klakring\",    \"geo_version\": 3,    \"geo_ændret\": \"2019-03-11T23:50:12.673Z\",    \"ændret\": \"2019-03-11T23:50:12.673Z\"  }}";
        public const string TxidEjerlav2u = "{ \"txid\": 7,  \"operation\": \"update\",  \"tidspunkt\": \"2019-03-11T23:50:12.674Z\",  \"sekvensnummer\": 110006809,  \"data\": { \"kode\": 102,    \"navn\": \"Klakring By, Klakring\",    \"geo_version\": 3,    \"geo_ændret\": \"2019-03-11T23:50:12.673Z\",    \"ændret\": \"2019-03-11T23:50:12.673Z\"  }}";
        public const string TxidEjerlav3u = "{ \"txid\": 8,  \"operation\": \"update\",  \"tidspunkt\": \"2019-03-11T23:50:12.674Z\",  \"sekvensnummer\": 110006809,  \"data\": { \"kode\": 103,    \"navn\": \"Klakring By, Klakring\",    \"geo_version\": 3,    \"geo_ændret\": \"2019-03-11T23:50:12.673Z\",    \"ændret\": \"2019-03-11T23:50:12.673Z\"  }}";
        public const string TxidEjerlav4u = "{ \"txid\": 9,  \"operation\": \"update\",  \"tidspunkt\": \"2019-03-11T23:50:12.674Z\",  \"sekvensnummer\": 110006809,  \"data\": { \"kode\": 104,    \"navn\": \"Klakring By, Klakring\",    \"geo_version\": 3,    \"geo_ændret\": \"2019-03-11T23:50:12.673Z\",    \"ændret\": \"2019-03-11T23:50:12.673Z\"  }}";
        public const string TxidEjerlav5u = "{ \"txid\": 10,  \"operation\": \"update\",  \"tidspunkt\": \"2019-03-11T23:50:12.674Z\",  \"sekvensnummer\": 110006809,  \"data\": { \"kode\": 105,    \"navn\": \"Klakring By, Klakring\",    \"geo_version\": 3,    \"geo_ændret\": \"2019-03-11T23:50:12.673Z\",    \"ændret\": \"2019-03-11T23:50:12.673Z\"  }}";

        [TestMethod]
        public void FixDeleteList_FjernerDuplicates_Success()
        {
            // Arrange
            var listInsertOrUpdate = new List<Ejerlav>();
            var listDelete = new List<Ejerlav>();

            JObject update1item = JObject.Parse(TxidEjerlav1u);

            Ejerlav update1 = new Ejerlav()
            {
                Kode = 101
            };
            update1.SetEntityFields(update1item);

            JObject update2item = JObject.Parse(TxidEjerlav2u);

            Ejerlav update2 = new Ejerlav()
            {
                Kode = 101
            };
            update2.SetEntityFields(update2item);

            JObject delete1item = JObject.Parse(TxidEjerlav3d);

            Ejerlav delete1 = new Ejerlav()
            {
                Kode = 101
            };
            delete1.SetEntityFields(delete1item);

            JObject delete2item = JObject.Parse(TxidEjerlav4d);

            Ejerlav delete2 = new Ejerlav()
            {
                Kode = 101
            };
            delete2.SetEntityFields(delete2item);


            listInsertOrUpdate.Add(update1);
            listInsertOrUpdate.Add(update2);
            listDelete.Add(delete1);
            listDelete.Add(delete2);

            int expectedDelCount = 0;
            int expectedUpsertCount = 1;
            int expectedTxid = 7;

            // Act
            UpdateEntityHelper.ProcessOperationLists(listDelete, listInsertOrUpdate);

            // Assert
            int delCount = listDelete.Count();
            int upsertCount = listInsertOrUpdate.Count();
            long txid = listInsertOrUpdate.Max(f => f.EntityTxid);


            Assert.AreEqual(expectedDelCount, delCount);
            Assert.AreEqual(expectedUpsertCount, upsertCount);
            Assert.AreEqual(expectedTxid, txid);

        }
        [TestMethod]
        public void FixDeleteList_FjernerDuplicates_DeleteList_Success()
        {
            // Arrange
            var listInsertOrUpdate = new List<Ejerlav>();
            var listDelete = new List<Ejerlav>();

            JObject delete1item = JObject.Parse(TxidEjerlav1d);

            Ejerlav delete1 = new Ejerlav()
            {
                Kode = 101
            };
            delete1.SetEntityFields(delete1item);

            JObject delete2item = JObject.Parse(TxidEjerlav2d);

            Ejerlav delete2 = new Ejerlav()
            {
                Kode = 101
            };
            delete2.SetEntityFields(delete2item);

            JObject delete3item = JObject.Parse(TxidEjerlav3d);

            Ejerlav delete3 = new Ejerlav()
            {
                Kode = 101
            };
            delete3.SetEntityFields(delete3item);

            JObject delete4item = JObject.Parse(TxidEjerlav4d);

            Ejerlav delete4 = new Ejerlav()
            {
                Kode = 102
            };
            delete4.SetEntityFields(delete4item);


            listDelete.Add(delete1);
            listDelete.Add(delete2);
            listDelete.Add(delete3);
            listDelete.Add(delete4);

            int expectedDelCount = 2;
            int expectedUpsertCount = 0;
            int expectedTxid = 3;

            // Act
            UpdateEntityHelper.ProcessOperationLists(listDelete, listInsertOrUpdate);

            // Assert
            int delCount = listDelete.Count();
            int upsertCount = listInsertOrUpdate.Count();
            long txid = listDelete[0].EntityTxid;


            Assert.AreEqual(expectedDelCount, delCount);
            Assert.AreEqual(expectedUpsertCount, upsertCount);
            Assert.AreEqual(expectedTxid, txid);

        }
        [TestMethod]
        public void FixList_FjernerDuplicates_ListCount0_Success()
        {
            // Arrange
            var listInsertOrUpdate = new List<Ejerlav>();
            var listDelete = new List<Ejerlav>();


            int expectedDelCount = 0;
            int expectedUpsertCount = 0;
            //int expectedTxid = 0;

            // Act
            UpdateEntityHelper.ProcessOperationLists(listDelete, listInsertOrUpdate);

            // Assert
            int delCount = listDelete.Count();
            int upsertCount = listInsertOrUpdate.Count();
            //int txid = listInsertOrUpdate[0].EntityTxid;


            Assert.AreEqual(expectedDelCount, delCount);
            Assert.AreEqual(expectedUpsertCount, upsertCount);
            //Assert.AreEqual(expectedTxid, txid);

        }

        [TestMethod]
        public void FixUpdList_FjernerDuplicates_ListCount2_Success()
        {
            // Arrange
            var listInsertOrUpdate = new List<Ejerlav>();
            var listDelete = new List<Ejerlav>();

            JObject update1item = JObject.Parse(TxidEjerlav1u);

            Ejerlav update1 = new Ejerlav()
            {
                Kode = 101
            };
            update1.SetEntityFields(update1item);

            JObject update2item = JObject.Parse(TxidEjerlav2u);

            Ejerlav update2 = new Ejerlav()
            {
                Kode = 101
            };
            update2.SetEntityFields(update2item);

            listInsertOrUpdate.Add(update1);
            listInsertOrUpdate.Add(update2);

            int expectedDelCount = 0;
            int expectedUpsertCount = 1;
            int expectedTxid = 7;

            // Act
            UpdateEntityHelper.ProcessOperationLists(listDelete, listInsertOrUpdate);

            // Assert
            int delCount = listDelete.Count();
            int upsertCount = listInsertOrUpdate.Count();
            long txid = listInsertOrUpdate[0].EntityTxid;


            Assert.AreEqual(expectedDelCount, delCount);
            Assert.AreEqual(expectedUpsertCount, upsertCount);
            Assert.AreEqual(expectedTxid, txid);

        }
        [TestMethod]
        public void FixUpdList_FjernerDuplicates_ListCount3_Success()
        {
            // Arrange
            var listInsertOrUpdate = new List<Ejerlav>();
            var listDelete = new List<Ejerlav>();

            JObject update1item = JObject.Parse(TxidEjerlav1u);

            Ejerlav update1 = new Ejerlav()
            {
                Kode = 101
            };
            update1.SetEntityFields(update1item);

            JObject update2item = JObject.Parse(TxidEjerlav2u);

            Ejerlav update2 = new Ejerlav()
            {
                Kode = 101
            };
            update2.SetEntityFields(update2item);

            JObject update3item = JObject.Parse(TxidEjerlav3u);

            Ejerlav update3 = new Ejerlav()
            {
                Kode = 101
            };
            update3.SetEntityFields(update3item);

            listInsertOrUpdate.Add(update1);
            listInsertOrUpdate.Add(update2);
            listInsertOrUpdate.Add(update3);

            int expectedDelCount = 0;
            int expectedUpsertCount = 1;
            int expectedTxid = 8;

            // Act
            UpdateEntityHelper.ProcessOperationLists(listDelete, listInsertOrUpdate);

            // Assert
            int delCount = listDelete.Count();
            int upsertCount = listInsertOrUpdate.Count();
            long txid = listInsertOrUpdate[0].EntityTxid;


            Assert.AreEqual(expectedDelCount, delCount);
            Assert.AreEqual(expectedUpsertCount, upsertCount);
            Assert.AreEqual(expectedTxid, txid);
        }
        [TestMethod]
        public void FixList_FjernerDuplicates_3u_3d_Success()
        {
            // Arrange
            var listInsertOrUpdate = new List<Ejerlav>();
            var listDelete = new List<Ejerlav>();

            JObject update1item = JObject.Parse(TxidEjerlav1u);

            Ejerlav update1 = new Ejerlav()
            {
                Kode = 101
            };
            update1.SetEntityFields(update1item);

            JObject update2item = JObject.Parse(TxidEjerlav2u);

            Ejerlav update2 = new Ejerlav()
            {
                Kode = 101
            };
            update2.SetEntityFields(update2item);

            JObject update3item = JObject.Parse(TxidEjerlav3u);

            Ejerlav update3 = new Ejerlav()
            {
                Kode = 101
            };
            update3.SetEntityFields(update3item);

            JObject delete1item = JObject.Parse(TxidEjerlav3d);

            Ejerlav delete1 = new Ejerlav()
            {
                Kode = 101
            };
            delete1.SetEntityFields(delete1item);

            JObject delete2item = JObject.Parse(TxidEjerlav4d);

            Ejerlav delete2 = new Ejerlav()
            {
                Kode = 101
            };
            delete2.SetEntityFields(delete2item);

            JObject delete3item = JObject.Parse(TxidEjerlav5d);

            Ejerlav delete3 = new Ejerlav()
            {
                Kode = 101
            };
            delete3.SetEntityFields(delete3item);


            listInsertOrUpdate.Add(update1);
            listInsertOrUpdate.Add(update2);
            listDelete.Add(delete1);
            listDelete.Add(delete2);
            listDelete.Add(delete3);
            listInsertOrUpdate.Add(update3);
            int expectedDelCount = 0;
            int expectedUpsertCount = 1;
            int expectedTxid = 8;

            // Act
            UpdateEntityHelper.ProcessOperationLists(listDelete, listInsertOrUpdate);

            // Assert
            int delCount = listDelete.Count();
            int upsertCount = listInsertOrUpdate.Count();
            long txid = listInsertOrUpdate[0].EntityTxid;


            Assert.AreEqual(expectedDelCount, delCount);
            Assert.AreEqual(expectedUpsertCount, upsertCount);
            Assert.AreEqual(expectedTxid, txid);

        }
        [TestMethod]
        public void FixList_NoDuplicates_Success()
        {
            // Arrange
            var listInsertOrUpdate = new List<Ejerlav>();
            var listDelete = new List<Ejerlav>();

            JObject update1item = JObject.Parse(TxidEjerlav1u);

            Ejerlav update1 = new Ejerlav()
            {
                Kode = 101
            };
            update1.SetEntityFields(update1item);

            JObject update2item = JObject.Parse(TxidEjerlav2u);

            Ejerlav update2 = new Ejerlav()
            {
                Kode = 102
            };
            update2.SetEntityFields(update2item);

            JObject update3item = JObject.Parse(TxidEjerlav3u);

            Ejerlav update3 = new Ejerlav()
            {
                Kode = 103
            };
            update3.SetEntityFields(update3item);

            JObject delete1item = JObject.Parse(TxidEjerlav3d);

            Ejerlav delete1 = new Ejerlav()
            {
                Kode = 104
            };
            delete1.SetEntityFields(delete1item);

            JObject delete2item = JObject.Parse(TxidEjerlav4d);

            Ejerlav delete2 = new Ejerlav()
            {
                Kode = 105
            };
            delete2.SetEntityFields(delete2item);

            JObject delete3item = JObject.Parse(TxidEjerlav5d);

            Ejerlav delete3 = new Ejerlav()
            {
                Kode = 106
            };
            delete3.SetEntityFields(delete3item);


            listInsertOrUpdate.Add(update1);
            listInsertOrUpdate.Add(update2);
            listDelete.Add(delete1);
            listDelete.Add(delete2);
            listDelete.Add(delete3);
            listInsertOrUpdate.Add(update3);
            int expectedDelCount = 3;
            int expectedUpsertCount = 3;
            int expectedTxid = 8;

            // Act
            UpdateEntityHelper.ProcessOperationLists(listDelete, listInsertOrUpdate);

            // Assert
            int delCount = listDelete.Count();
            int upsertCount = listInsertOrUpdate.Count();
            long txid = listInsertOrUpdate.Max(f => f.EntityTxid);


            Assert.AreEqual(expectedDelCount, delCount);
            Assert.AreEqual(expectedUpsertCount, upsertCount);
            Assert.AreEqual(expectedTxid, txid);

        }
    }
}
