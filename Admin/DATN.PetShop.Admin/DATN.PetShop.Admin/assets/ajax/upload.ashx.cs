using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;

namespace DATN.PetShop.Admin.assets.ajax
{
    /// <summary>
    /// Summary description for upload
    /// </summary>
    public class upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string strFlag = context.Request["flag"] ?? "0";
            string upload_type = context.Request["upload_type"] ?? "multiple";
            string result = "";
            switch (strFlag)
            {
                case "ajax.upload":
                    try
                    {
                        var strB = new StringBuilder();
                        var listFile = new List<string>();
                        var dtPhotoUpload = new DataTable(DateTime.Now.ToString());
                        dtPhotoUpload.Columns.Add("file");
                        dtPhotoUpload.Columns.Add("name");
                        dtPhotoUpload.Columns.Add("size");
                        dtPhotoUpload.Columns.Add("SizeSuffix");
                        dtPhotoUpload.Columns.Add("width");
                        dtPhotoUpload.Columns.Add("height");
                        dtPhotoUpload.Columns.Add("type");
                        dtPhotoUpload.Columns.Add("binary");
                        dtPhotoUpload.Columns.Add("url");
                        dtPhotoUpload.Columns.Add("_guid");
                        foreach (string file in context.Request.Files)
                        {
                            var hpf = context.Request.Files[file];
                            if (hpf.ContentLength == 0)
                            {
                                result = "0";
                            }
                            else
                            {
                                string fileExtension = System.IO.Path.GetExtension(hpf.FileName.ToLower());
                                if (
                                    (fileExtension != ".png")
                                    // && (fileExtension != ".ai")
                                    // && (fileExtension != ".psd")
                                    && (fileExtension != ".jpg")
                                    && (fileExtension != ".jpeg")
                                    // && (fileExtension != ".tff")
                                    && (fileExtension != ".gif")
                                    && (fileExtension != ".bmp"))
                                {
                                    result = "-1"; // Định dạng không hợp lệ
                                }
                                else if ((float.Parse(hpf.ContentLength.ToString()) / 1024f) > (50 * 1024))
                                {
                                    // file lớn hơn 5MB
                                    result = "-2";
                                }
                                else
                                {
                                    var imgStream = hpf.InputStream;
                                    var imgLen = hpf.ContentLength;
                                    byte[] imgBinaryData = new byte[imgLen];
                                    int n = imgStream.Read(imgBinaryData, 0, imgLen);

                                    var width = 0;
                                    var height = 0;
                                    using (Image img = Image.FromStream(imgStream))
                                    {
                                        width = img.Width;
                                        height = img.Height;
                                    }
                                    var filePreview = "data:image/" + fileExtension.Replace(".", "") + ";base64," +
                                                      System.Convert.ToBase64String(imgBinaryData);
                                    listFile.Add(filePreview);
                                    //strB.Append("<img src='" + filePreview + "' data-binary='" +
                                    //            System.Convert.ToBase64String(imgBinaryData) + "'/>");
                                    var dr = dtPhotoUpload.NewRow();
                                    //dr["file"] = hpf;
                                    dr["_guid"] = Guid.NewGuid().ToString("N");
                                    dr["name"] = hpf.FileName.ToLower();
                                    dr["size"] = hpf.ContentLength;
                                    dr["width"] = width;
                                    dr["height"] = height;
                                    dr["type"] = fileExtension;
                                    dr["binary"] = System.Convert.ToBase64String(imgBinaryData);
                                    dr["url"] = filePreview;
                                    dtPhotoUpload.Rows.Add(dr);
                                }
                            }

                        }
                        if (dtPhotoUpload.Rows.Count > 0)
                        {
                            result = JsonConvert.SerializeObject(dtPhotoUpload);
                        }
                    }
                    catch (Exception ex) { }
                    break;
            }
            context.Response.Write(result);
            context.Response.StatusCode = 200;
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}