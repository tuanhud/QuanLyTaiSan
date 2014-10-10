using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SHARED.Libraries;

namespace TSCD.Entities
{
    [Table("ATTACHMENTS")]
    public class Attachment:_EntityAbstract1<Attachment>
    {
        public Attachment()
        {

        }
        #region Dinh Nghia
        /// <summary>
        /// relativepath
        /// </summary>
        public String path { get; set; }
        /// <summary>
        /// in KB
        /// </summary>
        public long size { get; set; }
        public virtual ICollection<ChungTu> chungtus { get; set; }

        #endregion
        #region Nghiep vu
        [NotMapped]
        public String LOCAL_FILE_PATH { get; set; }
        [NotMapped]
        public long FILE_SIZE_KILOBYTE
        {
            get
            {
                if (size>0)
                {
                    return size;
                }
                else
                {
                    return FileHelper.getFileSizeKilobyte(LOCAL_FILE_PATH);
                }
            }
        }
        public event SHARED.Libraries.FTPHelper.UploadProgress onUploadProgress;

        /// <summary>
        /// set LOCAL_FILE_PATH trước: C:\folder\filename.xyz
        /// </summary>
        /// <returns></returns>
        public async Task<int> upload(CancellationToken cancel=new CancellationToken())
        {
            try
            {
                //kiem tra file co ton tai
                if (!FileHelper.isExist(LOCAL_FILE_PATH))
                {
                    return -1;
                }
                //tao filename tren ftp server
                String ftp_abs_path_tmp = "";
                ftp_abs_path_tmp += ServerTimeHelper.getNow().ToString("HHmmss_ddMMyyyy");
                ftp_abs_path_tmp += "_";
                ftp_abs_path_tmp += FileHelper.getFileName(LOCAL_FILE_PATH);
                //set lai cac thong so cho this
                this.path = ftp_abs_path_tmp;
                this.size = FileHelper.getFileSizeKilobyte(LOCAL_FILE_PATH);
                //generate abs_path
                ftp_abs_path_tmp = Global.remote_setting.ftp_host.getCombinedPath(ftp_abs_path_tmp);
                //upload len host
                var uploader = new FTPHelper();
                uploader.onUploadProgress += new FTPHelper.UploadProgress(this.onOneFileUploading);
                var re = await uploader.uploadFile(LOCAL_FILE_PATH, ftp_abs_path_tmp, Global.remote_setting.ftp_host.USER_NAME, Global.remote_setting.ftp_host.PASS_WORD,cancel);

                //finish
                return re;
            }catch(Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        private void onOneFileUploading(long current, long total)
        {
            if(onUploadProgress!=null)
            {
                onUploadProgress(current,total);
            }
        }
        #endregion

        #region override
        protected override void init()
        {
            base.init();
            size = 0;
            path = "";
        }
        #endregion
    }
}
