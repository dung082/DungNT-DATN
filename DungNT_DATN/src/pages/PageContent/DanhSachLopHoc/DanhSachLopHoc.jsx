import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import TableComponent from "../../../assets/Component/TableComponent";
import {
  chiTietLopState,
  getListHocSinhTrongLopAction,
  setAdvanceSearchCTLopAction,
} from "../../../reducers/chiTietLopReducer/chiTietLopReducer";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import { CHI_TIET_LOP_HOC_COLUMN_CONFIG } from "../../../templates/tableConfig";
export default function DanhSachLopHoc(props) {
  const dispatch = useDispatch();
  const { userInfo } = useSelector(globalState);
  const { pageNumber, pageSize, listHs } = useSelector(chiTietLopState);

  useEffect(() => {
    console.log(userInfo);
    dispatch(getListHocSinhTrongLopAction(userInfo.username));
  }, []);

  return (
    <>
      <div className="p-5">
        <div className=" bottem-border-title pb-2">
          <div className="flex justify-between">
            <div>
              <span className="font-bold text-xl">
                Danh sách học sinh trong lớp
              </span>
            </div>
          </div>
        </div>
        <div className="my-5">
          <div className="grid grid-cols-3">
            <div className="text-center">
              <span>
                Lớp :{" "}
                <span className="font-bold">
                  {listHs?.lopHocHienTai?.tenLop}
                </span>
              </span>
            </div>
            <div className="text-center">
              <span>
                Sĩ số :{" "}
                <span className="font-bold">
                  {listHs?.listHocSinh?.length}
                </span>
              </span>
            </div>
            <div className="text-center">
              <span>
                Năm học :{" "}
                <span className="font-bold">
                  {listHs?.namHocHienTai?.nameHoc}
                </span>
              </span>
            </div>
          </div>
        </div>
        <TableComponent
          className="mt-3"
          ColumnConfig={CHI_TIET_LOP_HOC_COLUMN_CONFIG}
          DataSource={listHs?.listHocSinh}
          CurrentPage={pageNumber}
          CurrentPageSize={pageSize}
          OnPageChange={(pageNumber, pageSize) => {
            dispatch(
              setAdvanceSearchCTLopAction({
                pageNumber: pageNumber,
                pageSize: pageSize,
              })
            );
          }}
        />
      </div>
    </>
  );
}
