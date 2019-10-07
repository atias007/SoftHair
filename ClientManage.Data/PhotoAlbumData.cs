using ClientManage.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ClientManage.Data
{
    public class PhotoAlbumData
    {
        public static DataSet GetPhotosForClient(int clientId)
        {
            var cmd = My.Database.GetStoredProcCommand("PhotoAlbum_GetPhotosForClient");
            My.Database.AddInParameter(cmd, "[?client_id]", DbType.Int32, clientId);
            return My.Database.ExecuteDataSet(cmd);
        }

        public static DataSet GetPhoto(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("PhotoAlbum_GetPhoto");
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            return My.Database.ExecuteDataSet(cmd);
        }

        public static void DeletePhoto(int id)
        {
            var cmd = My.Database.GetStoredProcCommand("PhotoAlbum_DeletePhoto");
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, id);
            My.Database.ExecuteNonQuery(cmd);
        }

        public static int AddPhoto(ClientPhoto photo)
        {
            var id = 0;
            var cmd = My.Database.GetStoredProcCommand("PhotoAlbum_AddPhoto");
            AddPhotoParameters(ref cmd, photo);
            My.Database.ExecuteNonQuery(cmd);

            cmd = My.Database.GetSqlStringCommand("SELECT MAX(id) FROM tblPhotoAlbum");

            try { id = (int)My.Database.ExecuteScalar(cmd); }
            catch { }

            return id;
        }

        public static void UpdatePhoto(ClientPhoto photo)
        {
            var cmd = My.Database.GetStoredProcCommand("PhotoAlbum_UpdatePhoto");
            AddPhotoParameters(ref cmd, photo);
            My.Database.AddInParameter(cmd, "[?id]", DbType.Int32, photo.Id);
            My.Database.ExecuteNonQuery(cmd);
        }

        private static void AddPhotoParameters(ref DbCommand cmd, ClientPhoto photo)
        {
            My.Database.AddInParameter(cmd, "[?client_id]", DbType.Int32, photo.ClientId);
            My.Database.AddInParameter(cmd, "[?picture]", DbType.String, photo.Picture);
            My.Database.AddInParameter(cmd, "[?date_created]", DbType.DateTime, Utils.GetDateTimeValueForDB(photo.DateCreated));
            My.Database.AddInParameter(cmd, "[?remark]", DbType.String, photo.Remark);
            My.Database.AddInParameter(cmd, "[?subject]", DbType.String, photo.Subject);
            My.Database.AddInParameter(cmd, "[?calendar_id]", DbType.Int32, photo.CalendarId);
        }

        public static string GetPhotoAppointmentId(int clientId)
        {
            var cmd = My.Database.GetStoredProcCommand("PhotoAlbum_GetPhotoAppointmentId");
            My.Database.AddInParameter(cmd, "[?client_id]", DbType.Int32, clientId);
            My.Database.AddInParameter(cmd, "[?duration]", DbType.Int32, Utils.CalendarTakepicDuration);
            string result = string.Empty;

            try { result = Convert.ToString(My.Database.ExecuteScalar(cmd)); }
            catch { }

            return result;
        }
    }
}