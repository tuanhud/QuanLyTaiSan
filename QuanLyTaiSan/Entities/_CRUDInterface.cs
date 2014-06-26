using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSan.Entities
{
    public interface _CRUDInterface<T>
    {
        /// <summary>
        /// Lấy tất cả Object có trong bảng dữ liệu
        /// </summary>
        /// <returns></returns>
            List<T> getAll();
        /// <summary>
        /// Lấy Object theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
            T getById(int id);
        /// <summary>
        /// Thêm
        /// </summary>
        /// <returns></returns>
            int add();
        /// <summary>
        /// Sửa (cập nhật sau khi đã edit)
        /// </summary>
        /// <returns></returns>
            int update();
        /// <summary>
        /// Xóa
        /// </summary>
        /// <returns></returns>
            int delete(Boolean auto_remove_fk=false);
        /// <summary>
        /// Ngắt kết nối CSDL, sử dụng Cached
        /// </summary>
            void dispose();
        /// <summary>
        /// Trả về Object tương đương nhưng thuộc tính bị đè từ CSDL
        /// </summary>
        /// <returns></returns>
            T reload();
        /// <summary>
        /// Sử dụng để FORCE LOAD FK OBJECT khi UPDATE
        /// </summary>
            void trigger();
    }
}
