using ClientManage.Data;
using ClientManage.Interfaces;
using System;
using System.Data;

namespace ClientManage.BL
{
    public class PhotoAlbumHelper
    {
        public static ClientPhotoCollection GetPhotosForClient(int clientId)
        {
            var ds = PhotoAlbumData.GetPhotosForClient(clientId);
            var photos = new ClientPhotoCollection();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    photos.Add(GetPhotoFromRow(ds.Tables[0].Rows[i]));
                }
            }

            return photos;
        }

        public static ClientPhoto GetPhoto(int id)
        {
            ClientPhoto photo = null;
            var ds = PhotoAlbumData.GetPhoto(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                photo = GetPhotoFromRow(ds.Tables[0].Rows[0]);
            }
            return photo;
        }

        private static ClientPhoto GetPhotoFromRow(DataRow row)
        {
            var item = new ClientPhoto
                           {
                               Id = (int)row["id"],
                               ClientId = Utils.GetDBValue<int>(row["client_id"]),
                               DateCreated = Utils.GetDBValue<DateTime>(row["date_created"]),
                               Picture = Utils.GetDBValue<string>(row, "picture"),
                               Remark = Utils.GetDBValue<string>(row, "remark"),
                               Subject = Utils.GetDBValue<string>(row, "subject"),
                               CalendarId = Utils.GetDBValue<string>(row, "calendar_id")
                           };
            return item;
        }

        public static void DeletePhoto(int id)
        {
            PhotoAlbumData.DeletePhoto(id);
        }

        public static int AddPhoto(ClientPhoto photo)
        {
            return PhotoAlbumData.AddPhoto(photo);
        }

        public static void UpdatePhoto(ClientPhoto photo)
        {
            PhotoAlbumData.UpdatePhoto(photo);
        }

        public static string GetPhotoAppointmentId(int clientId)
        {
            return PhotoAlbumData.GetPhotoAppointmentId(clientId);
        }
    }
}