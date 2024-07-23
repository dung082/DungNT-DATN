import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  getChiTietThoiKhoaBieuAction,
  setPageInformationTKB,
  thoiKhoaBieuState,
} from "../../../reducers/thoiKhoaBieuReducer/thoiKhoaBieuReducer";
import dayjs from "dayjs";
import TableComponent from "../../../assets/Component/TableComponent";
import { HOC_SINH_CHI_TIET_THOI_KHOA_BIEU } from "../../../templates/tableConfig";

export default function ChiTietThoiKhoaBieu(props) {
  const { chiTietTKB, pageNumber, pageSize } = useSelector(thoiKhoaBieuState);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getChiTietThoiKhoaBieuAction(props.idTietHoc));
  }, []);
  return (
    <div>
      <div className="px-3">
        <div>
          <div className="py-2 title-detail ">
            <span className="font-bold text-lg">Thông tin tiết học</span>
          </div>
          <div className="mt-2">
            <span>
              Môn học:{"   "}
              <span className="font-bold">{chiTietTKB?.cttkb?.tenMonHoc}</span>
            </span>
          </div>
          <div className="mt-2">
            <span>
              Tiết học:{"   "}
              <span className="font-bold">{chiTietTKB?.cttkb?.tenTietHoc}</span>
            </span>
          </div>
          <div className="mt-2">
            <span>
              Ngày học:{"   "}
              <span className="font-bold">
                {dayjs(chiTietTKB?.cttkb?.ngayHoc).format("DD/MM/YYYY")}
              </span>
            </span>
          </div>
          <div className="mt-2">
            <span>
              Ca học:{"   "}
              <span className="font-bold">{chiTietTKB?.cttkb?.tenCaHoc}</span>
            </span>
          </div>
          <div className="mt-2">
            <span>
              Kỳ học:{"   "}
              <span className="font-bold">{chiTietTKB?.cttkb?.tenKyHoc}</span>
            </span>
          </div>
          <div className="mt-2">
            <span>
              Năm học:{"   "}
              <span className="font-bold">{chiTietTKB?.cttkb?.namHoc}</span>
            </span>
          </div>
        </div>

        <div>
          <div className="py-2 title-detail mt-5">
            <span className="font-bold text-lg">Thông tin giáo viên</span>
          </div>
          <div className="mt-2">
            <span>
              Họ tên:{"   "}
              <span className="font-bold">
                {chiTietTKB?.cttkb?.tenGiaoVien}
              </span>
            </span>
          </div>
          <div className="mt-2">
            <span>
              Số điện thoại:{"   "}
              <span className="font-bold">
                {chiTietTKB?.cttkb?.soDienThoaiGiaoVien}
              </span>
            </span>
          </div>
          <div className="mt-2">
            <span>
              Email:{"   "}
              <span className="font-bold">
                {chiTietTKB?.cttkb?.emailGiaoVien}
              </span>
            </span>
          </div>
        </div>

        <div>
          <div className="py-2 title-detail mt-5">
            <span className="font-bold text-lg">Thông tin lớp học</span>
          </div>
          <div className="mt-2">
            <span>
              Lớp học:{"   "}
              <span className="font-bold">{chiTietTKB?.cttkb?.tenLop}</span>
            </span>
          </div>
          <div className="mt-2">
            <span>
              Sĩ số:{"   "}
              <span className="font-bold">{chiTietTKB?.lstnd?.length}</span>
            </span>
          </div>
          <div className="mt-2">
            <TableComponent
              className="mt-3"
              ColumnConfig={HOC_SINH_CHI_TIET_THOI_KHOA_BIEU}
              DataSource={chiTietTKB?.lstnd}
              CurrentPage={pageNumber}
              CurrentPageSize={pageSize}
              OnPageChange={(pageNumber, pageSize) => {
                dispatch(
                  setPageInformationTKB({
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                  })
                );
              }}
            />
          </div>
        </div>
      </div>
    </div>
  );
}
